using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Portfolio_Manager
{

    class Value : BaseUnderlying//Define the properties for basic variables, which is the base class
    {

        public Int64 step { set; get; }//steps
        public Int64 trial { set; get; }//trials
        public Value(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_)
            : base(S_S, K_K, r_r, e_e, T_T, d_d)
        {
            step = step_;
            trial = trial_;
        }//constructor
    }

    class Option : Value// class option inherit from class value 
    {
        public Option(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        { }//constructor

        protected double price(double[] matrix)//the mean of the price in time T
        {
            double result = 0;
            for (int i = 0; i < trial; i++)
                result = result + matrix[i];
            return result / trial;
        }
        protected double Phi(double x)//Simple CDF
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }
        /*protected double[] mean(double[, ,] matrix)//the mean of each row
        {
            double all=0;
            double[] result=new double[trial];
            for (int i = 0; i < trial; i++)
            {
                for (int j = 0; j < step; j++)
                    all = all + matrix[1, i, j];
                result[i] = all / step;
            }
            return result;
        }*/

        /*protected double sd(double[] matrix, double mean)//calculate the sample deviation, matrix is C(0,j), mean is C(0)
        {
            double all = 0;
            for (int i = 0; i < trial; i++)
                all = all + (matrix[i] - mean) * (matrix[i] - mean);
            return Math.Sqrt(all / (trial - 1));
        }*/

        /*protected double[,] path(double[,] matrix,Value origin)//calculate the price path, matrix is random number matrix
        {
            double dt = Convert.ToDouble(origin.T) / Convert.ToDouble(origin.step - 1);
            double[,] result = new double[origin.trial, origin.step];
            for (int i = 0; i < trial; i++)
            {
                result[i, 0] = origin.S;
                for (int j = 1; j < step; j++)
                    result[i, j] = result[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * matrix[i, j]));
            }
            return result;
        }*/
    }

    sealed class Greeks : Value
    {
        //OptionPricing f = new OptionPricing();
        public Greeks(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 sstep_, Int64 trial_)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, sstep_, trial_)
        { }
        public delegate double[] PayoffDelegate(Value temp, double[,] matrix, string s);//Use delegate to make payoff function as a parameter
        public delegate double[] PayoffDelegate2(Value temp, double[,] matrix, bool isant, string s);
        private double[] diff(Value temp, double[,] matrix, string s, PayoffDelegate payoff)//calculate the greeks, matrix is the random matrix generated before
        {
            double dt = temp.T / (temp.step - 1);
            double[] result = new double[2];
            double[,] newmatrix = new double[temp.trial, temp.step];
            /*for (int i = 0; i < temp.trial; i++)
            {
                newmatrix[i, 0] = temp.S;
                for (int j = 1; j < temp.step; j++)
                    newmatrix[i, j] = newmatrix[i, j - 1] * Math.Exp((temp.r - temp.e * temp.e * 0.5) *dt + (temp.e * Math.Sqrt(dt) * matrix[i, j]));
            }*/
            result = payoff(temp, matrix, s);
            return result;
        }
        private double[] diff(Value temp, double[,] matrix, string s, bool isant, PayoffDelegate2 payoff)//calculate the greeks, matrix is the random matrix generated before
        {
            double dt = temp.T / (temp.step - 1);
            double[] result = new double[2];
            /*for (int i = 0; i < temp.trial; i++)
            {
                newmatrix[i, 0] = temp.S;
                for (int j = 1; j < temp.step; j++)
                    newmatrix[i, j] = newmatrix[i, j - 1] * Math.Exp((temp.r - temp.e * temp.e * 0.5) *dt + (temp.e * Math.Sqrt(dt) * matrix[i, j]));
            }*/
            result = payoff(temp, matrix, isant, s);
            return result;
        }

        private double greek(double a, double b, double c, string s)//a=s+ds,b=s-ds,c=s, for calculate greeks
        {
            double temp = 0;
            double dd = 0.01;
            if (s == "delta" || s == "vega" || s == "rho" || s == "theta")
            {
                temp = (a - b) / (2 * dd * c);
            }
            else if (s == "gamma")
            {
                temp = (a - 2 * c + b) / (S * dd * dd * S);
            }
            return temp;
        }

        public double[] calculate(Value temp, double[,] matrix, string p, bool isant, PayoffDelegate2 payoff)//calculate all the greeks, temp is all values, matrix is random number matrix, payoff is Payoff function
        {
            double[] result = new double[5];
            double s = temp.S, k = temp.K, r = temp.r, e = temp.e, t = temp.T;
            double a, b, c, dd = 0.01;
            temp.S = (1 + dd) * s;
            a = diff(temp, matrix, p, isant, payoff)[0];
            temp.S = s;
            temp.S = (1 - dd) * s;
            b = diff(temp, matrix, p, isant, payoff)[0];
            result[0] = greek(a, b, s, "delta");
            temp.S = s;

            //   f.BeginInvoke(f.myDelegate);

            c = diff(temp, matrix, p, isant, payoff)[0];
            temp.K = (1 + dd) * k;
            a = diff(temp, matrix, p, isant, payoff)[0];
            temp.K = k;
            temp.K = (1 - dd) * k;
            b = diff(temp, matrix, p, isant, payoff)[0];
            result[1] = greek(a, b, c, "gamma");
            temp.K = k;

            //   f.BeginInvoke(f.myDelegate);

            temp.e = (1 + dd) * e;
            a = diff(temp, matrix, p, isant, payoff)[0];
            temp.e = e;
            temp.e = (1 - dd) * e;
            b = diff(temp, matrix, p, isant, payoff)[0];
            result[2] = greek(a, b, e, "vega");
            temp.e = e;

            //  f.BeginInvoke(f.myDelegate);

            temp.T = (1 + dd) * t;
            a = diff(temp, matrix, p, isant, payoff)[0];
            temp.T = t;
            temp.T = (1 - dd) * t;
            b = diff(temp, matrix, p, isant, payoff)[0];
            result[3] = -greek(a, b, t, "theta");
            temp.T = t;

            //  f.BeginInvoke(f.myDelegate);

            temp.r = (1 + dd) * r;
            a = diff(temp, matrix, p, isant, payoff)[0];
            temp.r = r;
            temp.r = (1 - dd) * r;
            b = diff(temp, matrix, p, isant, payoff)[0];
            result[4] = greek(a, b, r, "rho");
            temp.r = r;

            // f.BeginInvoke(f.myDelegate);

            return result;
        }
    }

    sealed class European : Option//class Eurpean inherit from class Option
    {
        //static OptionPricing f = new OptionPricing();
        public bool iscv = false;
        public European(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_, bool Iscv)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
            iscv = Iscv;
        }//constructor
        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)//payoff function for european option, origin is values, matrix is random number matrix, s is call or put
        {
            double sum_CT = 0, sum_CT2 = 0, SD = 0;
            double[] temp1 = new double[origin.trial];
            double[] temp2 = new double[origin.trial];
            double[] result = new double[2];
            double dt = Convert.ToDouble(origin.T) / Convert.ToDouble(origin.step - 1), d1 = 0, delta = 0, delta2 = 0, cv = 0, cv2 = 0;
            double[,] matrix1 = new double[origin.trial, origin.step];
            double[,] matrix2 = new double[origin.trial, origin.step];
            for (int i = 0; i < trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                cv = 0;
                cv2 = 0;
                for (int j = 1; j < step; j++)
                {
                    matrix1[i, j] = matrix1[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * randmatrix[i, j]));
                    if (iscv == true)
                    {
                        d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi(d1);
                        if (s == "call")
                            cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        else if (s == "put")
                            cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                    }
                    if (isant == true)
                    {
                        d1 = (Math.Log((matrix2[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta2 = Phi(d1);
                        matrix2[i, j] = matrix2[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * -randmatrix[i, j]));

                        if (iscv == true)
                        {
                            if (s == "call")
                            {
                             //   cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                cv2 = cv2 + delta2 * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                            else if (s == "put")
                            {
                             //   cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                cv2 = cv2 + (delta2 - 1) * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                        }
                    }
                }

                if (s == "call")
                {
                    if (iscv == false)
                    {
                        temp1[i] = Math.Max(matrix1[i, origin.step - 1] - origin.K, 0.00);

                    }
                    else if (iscv == true)
                    {
                        temp1[i] = Math.Max(0.00, matrix1[i, origin.step - 1] - origin.K) + -1 * cv;

                    }
                    if (isant == true)
                    {
                        if (iscv == false)
                        {
                            temp2[i] = Math.Max(matrix2[i, origin.step - 1] - origin.K, 0.00);
                        }
                        else if (iscv == true)
                        {
                            temp2[i] = Math.Max(matrix2[i, origin.step - 1] - origin.K, 0.00) + -1 * cv2;
                        }
                    }
                }

                else if (s == "put")
                {
                    if (iscv == false)
                    {
                        temp1[i] = Math.Max(origin.K - matrix1[i, origin.step - 1], 0.00);
                    }
                    else if (iscv == true)
                    {
                        temp1[i] = Math.Max(0, origin.K - matrix1[i, origin.step - 1]) + -1 * cv;

                    }
                    if (isant == true)
                    {
                        if (iscv == false)
                        {
                            temp2[i] = Math.Max(origin.K - matrix2[i, origin.step - 1], 0.00);
                        }
                        else if (iscv == true)
                        {
                            temp2[i] = Math.Max(origin.K - matrix2[i, origin.step - 1], 0.00) + -1 * cv2;
                        }
                    }
                }

                if (isant == true)
                {
                    temp1[i] = 0.5 * (temp1[i] + temp2[i]);
                }

                sum_CT = sum_CT + temp1[i];
                sum_CT2 = sum_CT2 + temp1[i] * temp1[i];
            }

            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);//sample standard deviation
            return result;
        }
    }

    sealed class Asian : Option//Asian arithmetic and geometric average rate or average strike option
    {
        // public string s1 { get; set; }//arithmetic or geometric
        //   public string s2 { get; set; }//average rate option or average strike option
        public bool iscv { get; set; }
        public Asian(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_, bool Iscv)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
            iscv = Iscv;
            //s2 = s_2;
        }
        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)
        {
            double dt = (double)origin.T / (origin.step - 1);
            double nudt = (origin.r - origin.d - 0.5 * origin.e * origin.e) * dt;
            double sigsdt = origin.e * Math.Sqrt(dt);
            double[,] matrix1 = new double[origin.trial, origin.step];//store regular random number
            double[,] matrix2 = new double[origin.trial, origin.step];//store antithetic random number
            double[] result = new double[2];
            double sum1 = 0;
            double sum2 = 0;
            double SD = 0, sum = 0, summ = 0, cv = 0, delta = 0, d1 = 0, cv2 = 0, delta2 = 0;
            for (int i = 0; i < origin.trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                sum = 0;//for regular
                summ = 0;//for antithemtic random number
                cv = 0;
                cv2 = 0;
                for (int j = 1; j < origin.step; j++)
                {
                    if (iscv == false)//if not using control variate
                    {
                        matrix1[i, j] = matrix1[i, j - 1] * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                        sum = sum + matrix1[i, j];
                        if (isant == true)//if using antithetic random number
                        {
                            matrix2[i, j] = (matrix2[i, j - 1] * Math.Exp(nudt + sigsdt * -randmatrix[i, j]));
                            summ = summ +  matrix2[i, j];
                        }
                    }
                    else if (iscv == true)//if using control variate
                    {
                        matrix1[i, j] = matrix1[i, j - 1] * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                        d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi(d1);
                        if (s == "call")
                            cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        else if (s == "put")
                            cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        sum = sum + matrix1[i, j];
                        if (isant == true)//if using antithetic random number
                        {
                            matrix2[i, j] = matrix2[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * -randmatrix[i, j]));
                            d1 = (Math.Log((matrix2[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                            delta2 = Phi(d1);                            
                            if (iscv == true)//if using control variate
                            {
                                if (s == "call")
                                {
                     //               cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                    cv2 = cv2 + delta2 * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                }
                                else if (s == "put")
                                {
                     //               cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                    cv2 = cv2 + (delta2 - 1) * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                                }
                            }
                            summ = summ + matrix2[i, j];
                        }
                    }
                }
                sum = sum / (origin.step - 1);
                summ = summ / (origin.step - 1);
                if (isant == false)//if not using antithemtic random number
                {
                    if (iscv == false)//if not using control variate
                    {
                        if (s == "call")
                        {
                            matrix1[i, step - 1] = Math.Max(sum - origin.K, 0);
                        }
                        else if (s == "put")
                        {
                            matrix1[i, step - 1] = Math.Max(origin.K - sum, 0);
                        }
                    }
                    else if (iscv == true)//if using control variate
                    {
                        if (s == "call")
                        {
                            matrix1[i, step - 1] = Math.Max(sum - origin.K, 0) + -1 * cv;
                        }
                        else if (s == "put")
                        {
                            matrix1[i, step - 1] = Math.Max(origin.K - sum, 0) + -1 * cv;
                        }
                    }
                }
                else if (isant == true)//if using antithetic random number
                {
                    if (iscv == false)//if not using control variate
                    {
                        if (s == "call")
                        {
                            matrix1[i, step - 1] = Math.Max(sum - origin.K, 0);
                            matrix2[i, step - 1] = Math.Max(summ - origin.K, 0);
                        }
                        else if (s == "put")
                        {
                            matrix1[i, step - 1] = Math.Max(origin.K - sum, 0);
                            matrix2[i, step - 1] = Math.Max(origin.K - summ, 0);
                        }
                    }
                    else if (iscv == true)//if using control variate
                    {
                        if (s == "call")
                        {
                            matrix1[i, step - 1] = Math.Max(sum - origin.K, 0) + -1 * cv;
                            matrix2[i, step - 1] = Math.Max(summ - origin.K, 0) + -1 * cv2;
                        }
                        else if (s == "put")
                        {
                            matrix1[i, step - 1] = Math.Max(origin.K - sum, 0) + -1 * cv;
                            matrix2[i, step - 1] = Math.Max(origin.K - summ, 0) + -1 * cv2;
                        }
                        
                    }
                    matrix1[i, step - 1] = (matrix1[i, step - 1] + matrix2[i, step - 1]) * 0.5;
                }

                sum1 = sum1 + matrix1[i, step - 1];
                sum2 = sum2 + matrix1[i, step - 1] * matrix1[i, step - 1];
            }
            SD = Math.Sqrt((sum2 - sum1 * sum1 / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[0] = Math.Exp(-origin.r * origin.T) * sum1 / trial;
            result[1] = SD / Math.Sqrt(origin.trial);
            return result;
        }
    }


    sealed class Barrier : Option//Barrier down and out call or put option
    {
        public double Sb { get; set; }//Barrier price
        public string S2 { get; set; }//Up,Down,In,Out
        public bool iscv { get; set; }//control variate
        public Barrier(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_, double S_b, string s2,bool Iscv)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
            Sb = S_b;
            S2 = s2;
            Iscv = iscv;
        }
        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)
        {
            double dt = (double)origin.T / origin.step;
            double nudt = (origin.r - origin.d - 0.5 * origin.e * origin.e) * dt;
            double sigsdt = origin.e * Math.Sqrt(dt);
            double[,] matrix1 = new double[origin.trial, origin.step];
            double[,] matrix2 = new double[origin.trial, origin.step];
            double[] result = new double[2];
            bool barrier_crossed = false;
            bool barrier_crossed2 = false;
            double sum1 = 0, sum2 = 0, SD = 0, cv = 0, cv2 = 0, delta = 0, delta2 = 0, d1 = 0;
            for (int i = 0; i < trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                cv = 0;
                cv2 = 0;
                barrier_crossed = false;//wheather the price path cross the barrier for regular random number
                barrier_crossed2 = false;//wheather the price path cross the barrier for antithemtic random number
                for (int j = 1; j < step; j++)
                {
                    matrix1[i, j] = matrix1[i, j - 1] * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                    if (iscv == true)//using control variate
                    {
                        d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi(d1);
                        if (s == "call")
                            cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        else if (s == "put")
                            cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                    }
                    if (isant == true)//using antithemtic random number
                    {
                        matrix2[i, j] = matrix2[i, j - 1] * Math.Exp(nudt + sigsdt * -randmatrix[i, j]);
                        if (iscv == true)//using control variate
                        {
                            d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                            delta2 = Phi(d1);
                            if (s == "call")
                            {
                                cv2 = cv2 + delta2 * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                            else if (s == "put")
                            {
                                cv2 = cv2 + (delta2 - 1) * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                        }
                    }
                    if (S2 == "down_out")
                    {
                        if (matrix1[i, j] <= Sb)
                        {
                            barrier_crossed = true;
                            if (isant == true)
                                if (matrix2[i, j] <= Sb)
                                    barrier_crossed2 = true;
                            break;
                        }
                    }
                    else if (S2 == "up_out")
                    {
                        if (matrix1[i, j] >= Sb)
                        {
                            barrier_crossed = true;
                            if (isant == true)
                                if (matrix2[i, j] >= Sb)
                                    barrier_crossed2 = true;
                            break;
                        }
                    }
                    else if (S2 == "up_in")
                    {
                        if (matrix1[i, j] >= Sb)
                        {
                            barrier_crossed = true;
                            if (isant == true)
                                if (matrix2[i, j] >= Sb)
                                    barrier_crossed2 = true;
                        }
                    }
                    else if (S2 == "down_in")
                    {
                        if (matrix1[i, j] <= Sb)
                        {
                            barrier_crossed = true;
                            if (isant == true)
                                if (matrix2[i, j] <= Sb)
                                    barrier_crossed2 = true;
                        } 
                    }
                }

                if (S2 == "down_out" || S2 == "up_out")//if the price crossed the barrier, set the terminal price 0
                {
                    if (barrier_crossed == true)
                        matrix1[i, step - 1] = 0;
                    if (barrier_crossed2 == true)
                        matrix2[i, step - 1] = 0;
                }
                else if (S2 == "down_in" || S2 == "up_in")//if the price doesn't crossed the barrier, set the terminal price 0
                {
                    if (barrier_crossed == false)
                        matrix1[i, step - 1] = 0;
                    if (barrier_crossed2 == false)
                        matrix2[i, step - 1] = 0;
                }

                if (s == "call")
                {
                    matrix1[i, step - 1] = Math.Max(0, matrix1[i, step - 1] - origin.K);
                    if (isant == true)
                        matrix2[i, step - 1] = Math.Max(0, matrix2[i, step - 1] - origin.K);
                    if (iscv == true)
                    {
                        matrix1[i, step - 1] = Math.Max(0, matrix1[i, step - 1] - origin.K) + -1 * cv;
                        if (isant == true)
                            matrix2[i, step - 1] = Math.Max(0, matrix2[i, step - 1] - origin.K) + -1 * cv2;
                    }
                }
                else if (s == "put")
                {
                    if (barrier_crossed == false && (S2 == "up_out" || S2 == "down_out"))//ensure that when the termial price equals to 0, don't using K-price
                        matrix1[i, step - 1] = Math.Max(0.00, origin.K - matrix1[i, step - 1]);
                    else if (barrier_crossed == true && (S2 == "up_out" || S2 == "down_out"))
                        matrix1[i, step - 1] = 0;
                    else if (barrier_crossed == false && (S2 == "up_in" || S2 == "down_in"))
                        matrix1[i, step - 1] = 0;
                    else if(barrier_crossed==true&&(S2=="up_in"||S2=="down_in"))
                        matrix1[i, step - 1] = Math.Max(0.00, origin.K - matrix1[i, step - 1]);
                    if (isant == true)
                    {
                        if (barrier_crossed == false && (S2 == "up_out" || S2 == "down_out"))
                            matrix2[i, step - 1] = Math.Max(0.00, origin.K - matrix2[i, step - 1]);
                        else if (barrier_crossed == true && (S2 == "up_out" || S2 == "down_out"))
                            matrix2[i, step - 1] = 0;
                        else if (barrier_crossed == false && (S2 == "up_in" || S2 == "down_in"))
                            matrix2[i, step - 1] = 0;
                        else if (barrier_crossed == true && (S2 == "up_in" || S2 == "down_in"))
                            matrix2[i, step - 1] = Math.Max(0.00, origin.K - matrix2[i, step - 1]);
                    }
                    if (iscv == true)
                    {
                        if (barrier_crossed == false && (S2 == "up_out" || S2 == "down_out"))
                            matrix1[i, step - 1] = Math.Max(0.00, origin.K - matrix1[i, step - 1]) - 1 * cv;
                        else if (barrier_crossed == true && (S2 == "up_out" || S2 == "down_out"))
                            matrix1[i, step - 1] = 0 - 1 * cv;
                        else if (barrier_crossed == false && (S2 == "up_in" || S2 == "down_in"))
                            matrix1[i, step - 1] = 0 - 1 * cv;
                        else if (barrier_crossed == true && (S2 == "up_in" || S2 == "down_in"))
                            matrix1[i, step - 1] = Math.Max(0.00, origin.K - matrix1[i, step - 1]) - 1 * cv;
                        if (isant == true)
                        {
                            if (barrier_crossed == false && (S2 == "up_out" || S2 == "down_out"))
                                matrix2[i, step - 1] = Math.Max(0.00, origin.K - matrix2[i, step - 1]) - 1 * cv2;
                            else if (barrier_crossed == true && (S2 == "up_out" || S2 == "down_out"))
                                matrix2[i, step - 1] = 0 - 1 * cv2;
                            else if (barrier_crossed == false && (S2 == "up_in" || S2 == "down_in"))
                                matrix2[i, step - 1] = 0 - 1 * cv2;
                            else if (barrier_crossed == true && (S2 == "up_in" || S2 == "down_in"))
                                matrix2[i, step - 1] = Math.Max(0.00, origin.K - matrix2[i, step - 1]) - 1 * cv2;
                        }
                    }
                }

                if (isant == true)
                    matrix1[i, step - 1] = (matrix1[i, step - 1] + matrix2[i, step - 1]) * 0.5;

                sum1 = sum1 + matrix1[i, step - 1];
                sum2 = sum2 + matrix1[i, step - 1] * matrix1[i, step - 1];
            }
            result[0] = Math.Exp(-origin.r * origin.T) * sum1 / origin.trial;
            SD = Math.Sqrt((sum2 - sum1 * sum1 / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (trial - 1));
            result[1] = SD / Math.Sqrt(trial);
            return result;
        }
    }

    sealed class LookBack : Option
    {
        public string S2 { get; set; }
        public bool iscv { get; set; }
        public LookBack(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_, string s2,bool Iscv)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
            S2 = s2;
            iscv = Iscv;
        }//constructor
        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)//payoff function for european option, origin is values, matrix is random number matrix, s is call or put
        {
            double sum_CT = 0, sum_CT2 = 0, SD = 0, cv = 0, cv2 = 0, delta = 0, delta2 = 0,d1=0;           
            double dt = Convert.ToDouble(origin.T) / Convert.ToDouble(origin.step - 1);
            double[] result = new double[2];
            double[,] temp1 = new double[origin.trial, 2];//for regular random number store the max and min
            double[,] temp2 = new double[origin.trial, 2];//for antithemtic random number store the max and min
            double[,] matrix1 = new double[origin.trial, origin.step];
            double[,] matrix2 = new double[origin.trial, origin.step];
            for (int i = 0; i < trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                temp1[i, 0] = origin.S; temp2[i, 0] = origin.S; temp1[i, 1] = origin.S; temp2[i, 1] = origin.S;//initial the first price in order to compare 
                cv = 0;
                cv2 = 0;
                for (int j = 1; j < step; j++)
                {
                    matrix1[i, j] = matrix1[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * randmatrix[i, j]));
                    temp1[i, 0] = Math.Max(matrix1[i, j], temp1[i, 0]);//store the max price in one path
                    temp1[i, 1] = Math.Min(matrix1[i, j], temp1[i, 1]);//store the min price in one path
                    if(iscv==true)//using control variate
                    {
                        d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi(d1);
                        if (s == "call")
                            cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        else if (s == "put")
                            cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                    }
                    if (isant == true)//using antithemtic random number
                    {
                        matrix2[i, j] = matrix2[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * -randmatrix[i, j]));
                        temp2[i, 0] = Math.Max(matrix2[i, j], temp2[i, 0]);
                        temp2[i, 1] = Math.Min(matrix2[i, j], temp2[i, 1]);
                        if(iscv==true)
                        {
                            d1 = (Math.Log((matrix2[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                            delta2 = Phi(d1);
                            if (s == "call")
                            {                             
                                cv2 = cv2 + delta2 * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                            else if (s == "put")
                            {          
                                cv2 = cv2 + (delta2 - 1) * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                        }
                    }
                }
                if (iscv == false)
                {
                    if (S2 == "fix")//fixed
                    {
                        if (s == "call")
                        {
                            temp1[i, 0] = Math.Max(temp1[i, 0] - origin.K, 0.00);
                            if (isant == true)
                                temp2[i, 0] = Math.Max(temp2[i, 0] - origin.K, 0.00);
                        }
                        else if (s == "put")
                        {
                            temp1[i, 0] = Math.Max(origin.K - temp1[i, 1], 0.00);
                            if (isant == true)
                                temp2[i, 0] = Math.Max(origin.K - temp2[i, 1], 0.00);
                        }
                        if (isant == true)
                        {
                            temp1[i, 0] = 0.5 * (temp1[i, 0] + temp2[i, 0]);
                        }
                        sum_CT = sum_CT + temp1[i, 0];
                        sum_CT2 = sum_CT2 + temp1[i, 0] * temp1[i, 0];
                    }
                    else if (S2 == "floating")//floating
                    {
                        if (s == "call")
                        {
                            temp1[i, 1] = Math.Max(matrix1[i, origin.step - 1] - temp1[i,1], 0.00);
                            if (isant == true)
                                temp2[i, 1] = Math.Max(matrix2[i, origin.step - 1] - temp2[i,1], 0.00);
                        }
                        else if (s == "put")
                        {
                            temp1[i, 1] = Math.Max(temp1[i,0] - matrix1[i, origin.step - 1], 0.00);
                            if (isant == true)
                                temp2[i, 1] = Math.Max(temp1[i,0] - matrix2[i, origin.step - 1], 0.00);
                        }
                        if (isant == true)
                        {
                            temp1[i, 1] = 0.5 * (temp1[i, 1] + temp2[i, 1]);
                        }
                        sum_CT = sum_CT + temp1[i, 1];
                        sum_CT2 = sum_CT2 + temp1[i, 1] * temp1[i, 1];
                    }
                }
                else if (iscv == true)
                {
                    if (S2 == "fix")
                    {
                        if (s == "call")
                        {
                            temp1[i, 0] = Math.Max(temp1[i, 0] - origin.K, 0.00) + -1 * cv;
                            if (isant == true)
                                temp2[i, 0] = Math.Max(temp2[i, 0] - origin.K, 0.00) + -1 * cv2;
                        }
                        else if (s == "put")
                        {
                            temp1[i, 0] = Math.Max(origin.K - temp1[i, 1], 0.00) + -1 * cv;
                            if (isant == true)
                                temp2[i, 0] = Math.Max(origin.K - temp2[i, 1], 0.00) + -1 * cv2;
                        }
                        if (isant == true)
                        {
                            temp1[i, 0] = 0.5 * (temp1[i, 0] + temp2[i, 0]);
                        }
                        sum_CT = sum_CT + temp1[i, 0];
                        sum_CT2 = sum_CT2 + temp1[i, 0] * temp1[i, 0];
                    }
                    else if (S2 == "floating")
                    {
                        if (s == "call")
                        {
                            temp1[i, 1] = Math.Max(matrix1[i, origin.step - 1] - origin.K, 0.00) + -1 * cv;
                            if (isant == true)
                                temp2[i, 1] = Math.Max(matrix2[i, origin.step - 1] - origin.K, 0.00) + -1 * cv2;
                        }
                        else if (s == "put")
                        {
                            temp1[i, 1] = Math.Max(origin.K - matrix1[i, origin.step - 1], 0.00) + -1 * cv;
                            if (isant == true)
                                temp2[i, 1] = Math.Max(origin.K - matrix2[i, origin.step - 1], 0.00) + -1 * cv2;
                        }
                        if (isant == true)
                        {
                            temp1[i, 1] = 0.5 * (temp1[i, 1] + temp2[i, 1]);
                        }
                        sum_CT = sum_CT + temp1[i, 1];
                        sum_CT2 = sum_CT2 + temp1[i, 1] * temp1[i, 1];
                    }
                }
            }

            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);//sample standard deviation
            return result;
        }

    }

    sealed class Digital : Option
    {
        public double rebate { get; set; }//rebate
        public bool iscv { get; set; }
        public Digital(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_, double R,bool Iscv)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
            rebate = R;
            iscv = Iscv;
        }
        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)
        {
            double dt = (double)origin.T / (origin.step - 1);
            double nudt = (origin.r - origin.d - 0.5 * origin.e * origin.e) * dt;
            double sigsdt = origin.e * Math.Sqrt(dt);
            double[,] matrix1 = new double[origin.trial, origin.step];
            double[,] matrix2 = new double[origin.trial, origin.step];
            double[] temp1 = new double[origin.trial];
            double[] temp2 = new double[origin.trial];
            double[] result = new double[2];
            double SD = 0, sum_CT = 0, sum_CT2 = 0, cv = 0, cv2 = 0, delta = 0, delta2 = 0, d1 = 0;
            for (int i = 0; i < origin.trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                cv=0;
                cv2=0;
                for (int j = 1; j < origin.step; j++)
                {
                    matrix1[i, j] = matrix1[i, j - 1] * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                    if (iscv == true)
                    {
                        d1 = (Math.Log((matrix1[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi(d1);
                        if (s == "call")
                            cv = cv + delta * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                        else if (s == "put")
                            cv = cv + (delta - 1) * (matrix1[i, j] - matrix1[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                    }
                    if (isant == true)
                    {
                        matrix2[i, j] = matrix2[i, j - 1] * Math.Exp(nudt + sigsdt * -randmatrix[i, j]);
                        if (iscv == true)
                        {
                            d1 = (Math.Log((matrix2[i, j - 1] / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                            delta2 = Phi(d1);                            
                            if (s == "call")
                            {
                                cv2 = cv2 + delta2 * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                            else if (s == "put")
                            {
                                cv2 = cv2 + (delta2 - 1) * (matrix2[i, j] - matrix2[i, j - 1] * Math.Exp((origin.r - origin.d) * dt));
                            }
                        }
                    }
                }
                if (iscv == false)
                {
                    if (s == "call")
                    {
                        temp1[i] = (matrix1[i, origin.step - 1] - origin.K) > 0 ? rebate : 0;
                        if (isant == true)
                            temp2[i] = (matrix2[i, origin.step - 1] - origin.K) > 0 ? rebate : 0;
                    }
                    else if (s == "put")
                    {
                        temp1[i] = (origin.K - matrix1[i, origin.step - 1]) > 0 ? rebate : 0;
                        if (isant == true)
                            temp2[i] = (origin.K - matrix1[i, origin.step - 1]) > 0 ? rebate : 0;
                    }
                    if (isant == true)
                    {
                        temp1[i] = 0.5 * (temp1[i] + temp2[i]);
                    }
                }
                else if (iscv == true)
                {
                    if (s == "call")
                    {
                        temp1[i] = (matrix1[i, origin.step - 1] - origin.K) > 0 ? rebate : 0 + -1 * cv;
                        if (isant == true)
                            temp2[i] = (matrix2[i, origin.step - 1] - origin.K) > 0 ? rebate : 0 + -1 * cv2;
                    }
                    else if (s == "put")
                    {
                        temp1[i] = (origin.K - matrix1[i, origin.step - 1]) > 0 ? rebate : 0 + -1 * cv;
                        if (isant == true)
                            temp2[i] = (origin.K - matrix1[i, origin.step - 1]) > 0 ? rebate : 0 + -1 * cv2;
                    }
                    if (isant == true)
                    {
                        temp1[i] = 0.5 * (temp1[i] + temp2[i]);
                    }
 
                }
                sum_CT = sum_CT + temp1[i];
                sum_CT2 = sum_CT2 + temp1[i] * temp1[i];
            }
            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);//sample standard deviation
            return result;
        }
    }

    sealed class Range : Option
    {
        public Range(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        {
        }

        public double[] Payoff(Value origin, double[,] randmatrix, bool isant, string s)//payoff function for european option, origin is values, matrix is random number matrix, s is call or put
        {
            double sum_CT = 0, sum_CT2 = 0, SD = 0;
            double[,] temp1 = new double[origin.trial, 2];
            double[,] temp2 = new double[origin.trial, 2];
            double[] result = new double[2];
            double dt = Convert.ToDouble(origin.T) / Convert.ToDouble(origin.step - 1);
            double[,] matrix1 = new double[origin.trial, origin.step];
            double[,] matrix2 = new double[origin.trial, origin.step];
            for (int i = 0; i < trial; i++)
            {
                matrix1[i, 0] = origin.S;
                matrix2[i, 0] = origin.S;
                temp1[i, 0] = origin.S; temp2[i, 0] = origin.S; temp1[i, 1] = origin.S; temp2[i, 1] = origin.S;
                //temp1[i, 0] = 0; temp2[i, 0] = 0; temp1[i, 1] = 0; temp2[i, 1] = 0;
                for (int j = 1; j < step; j++)
                {
                    matrix1[i, j] = matrix1[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * randmatrix[i, j]));
                    temp1[i, 0] = Math.Max(matrix1[i, j], temp1[i, 0]);//store the max price in one path
                    temp1[i, 1] = Math.Min(matrix1[i, j], temp1[i, 1]);//store the min price in one path
                    if (isant == true)
                    {
                        matrix2[i, j] = matrix2[i, j - 1] * Math.Exp((origin.r - origin.d - origin.e * origin.e * 0.5) * dt + (origin.e * Math.Sqrt(dt) * -randmatrix[i, j]));
                        temp2[i, 0] = Math.Max(matrix2[i, j], temp2[i, 0]);//store the max price in one path
                        temp2[i, 1] = Math.Min(matrix2[i, j], temp2[i, 1]);//store the min price in one path
                    }
                }
                temp1[i, 0] = temp1[i, 0] - temp1[i, 1];//max-min for regular random number
                if (isant == true)
                {
                    temp2[i, 0] = temp2[i, 0] - temp2[i, 1];//max-min for antithetic random number
                    temp1[i, 0] = 0.5 * (temp1[i, 0] + temp2[i, 0]);
                }
                sum_CT = sum_CT + temp1[i, 0];
                sum_CT2 = sum_CT2 + temp1[i, 0] * temp1[i, 0];
            }

            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);//sample standard deviation
            return result;
        }
    }

    class Control_Variate : Option
    {
        public string s3 { get; set; }//barrier option up-down-in-out, lookback option fix-floating
        public string s2 { get; set; }//option type
        public double sb { get; set; }//for barrier option
        public Control_Variate(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 sstep_, Int64 trial_, string S2)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, sstep_, trial_)
        {
            s2 = S2;
        }
        public Control_Variate(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 sstep_, Int64 trial_, string S2, string S3)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, sstep_, trial_)
        {
            s2 = S2;
            s3 = S3;
        }
        public Control_Variate(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 sstep_, Int64 trial_, string S2, string S3, double SB)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, sstep_, trial_)
        {
            s2 = S2;
            s3 = S3;
            sb = SB;
        }
        private double Phi1(double x)//Simple CDF
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }

        private double f(double x)
        {
            return (double)1 / Math.Sqrt(2 * Math.PI) * (Math.Exp(-x * x / 2));
        }

        private double[] trapezoid(double b)
        {
            double a = -5;
            double h, sum;
            double[] tn = new double[10];
            for (int k = 0; k < 10; k++)
            {
                h = (b - a) / Math.Pow(2, k);
                if (k == 0)
                    tn[k] = 0.5 * h * (f(a) + f(b));
                else
                {
                    sum = 0;
                    for (int i = 0; i < Math.Pow(2, k - 1); i++)
                        sum = f(a + (2 * i - 1) * h) + sum;
                    tn[k] = 0.5 * tn[k - 1] + h * sum;
                }
            }
            return tn;
        }
        private double normcdf(double b)//simpson integral
        {
            double[] tn = trapezoid(b);
            double[] sn = new double[10];
            for (int k = 1; k < 10; k++)
            {
                sn[k - 1] = 4.0 / 3.0 * tn[k] - 1.0 / 3.0 * tn[k - 1];
            }
            return sn[9];
        }

        public double[] delta_gamma_CV(Value origin, double[,] randmatrix, bool anti, string c)//delta-gamma-based-control-variate
        {
            double[] result = new double[2];
            double dt = origin.T / (origin.step - 1);
            double nudt = (origin.r - origin.d - 0.5 * origin.e * origin.e) * dt;
            double sigsdt = origin.e * Math.Sqrt(dt);
            double erddt = Math.Exp((origin.r - origin.d) * dt);
            double egamma = Math.Exp((2 * (origin.r - origin.d) + origin.e * origin.e) * dt) - 2 * erddt + 1;
            double d2 = 0, gamma = 0, gamma2 = 0, delta2 = 0, beta1 = -1, beta2 = -0.5, cv2 = 0, St2 = 0, sum_CT = 0;
            double sum_CT2 = 0, St = 0, Stn = 0, Stn2 = 0, cv = 0, t = 0, delta = 0, d1 = 0, CT = 0, SD = 0;
            for (int i = 0; i < origin.trial; i++)
            {
                St = origin.S;
                St2 = origin.S;
                cv = 0;
                cv2 = 0;
                for (int j = 1; j < origin.step; j++)
                {
                    t = (j - 1) * dt;
                    d1 = (Math.Log((St / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                    delta = Phi(d1);
                    gamma = f(d1) / (St * origin.e * Math.Sqrt(origin.T));
                    d2 = (Math.Log((St2 / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                    delta2 = normcdf(d1);
                    gamma2 = f(d2) / (St2 * origin.e * Math.Sqrt(origin.T));
                    Stn = St * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                    Stn2 = St2 * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                    if (c == "call")
                        cv = cv + delta * (Stn - St * erddt) + delta2 * (Stn2 - St2 * erddt);
                    else if (c == "put")
                        cv = cv + (delta - 1) * (Stn - St * erddt) + (delta2 - 1) * (Stn2 - St2 * erddt);
                    cv2 = cv2 + gamma * ((Stn - St) * (Stn - St) - St * St * egamma) + gamma2 * ((Stn2 - St2) * (Stn2 - St2) - St2 * St2 * egamma);
                    St = Stn;
                    St2 = Stn2;
                }
                if (c == "call")
                    CT = 0.5 * (Math.Max(0, St - origin.K) + Math.Max(0, St2 - origin.K) + beta1 * cv + beta2 * cv2);
                else if (c == "put")
                    CT = 0.5 * (Math.Max(0, origin.K - St) + Math.Max(0, origin.K - St2) + beta1 * cv + beta2 * cv2);
                sum_CT = sum_CT + CT;
                sum_CT2 = sum_CT2 + CT * CT;
            }
            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);
            return result;
        }

        public double[] delta_CV(Value origin, double[,] randmatrix, bool anti, string c)//delta-based-control-variate
        {
            double[] result = new double[2];
            double dt = origin.T / (origin.step - 1);// sum = 0;
            double nudt = (origin.r - origin.d - 0.5 * origin.e * origin.e) * dt;
            double sigsdt = origin.e * Math.Sqrt(dt);
            double erddt = Math.Exp((origin.r - origin.d) * dt);
            double beta1 = -1, sum_CT = 0, sum_CT2 = 0, St = 0, Stn = 0, cv = 0, t = 0, delta = 0, d1 = 0, CT = 0, SD = 0;
            if (anti == false)
            {
                for (int i = 0; i < origin.trial; i++)
                {
                    St = origin.S;
                    cv = 0;
                    for (int j = 1; j < origin.step; j++)
                    {
                        //t = (j - 1) * dt;
                        d1 = (Math.Log((St / origin.K)) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi1(d1);
                        Stn = St * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                        if (c == "call")
                            cv = cv + delta * (Stn - St * erddt);
                        else if (c == "put")
                            cv = cv + (delta - 1) * (Stn - St * erddt);
                        St = Stn;
                    }

                    if (s2 == "European")
                    {
                        if (c == "call")
                        {
                            CT = Math.Max(0, St - origin.K) + beta1 * cv;
                        }
                        else if (c == "put")
                        {
                            CT = Math.Max(0, origin.K - St) + beta1 * cv;
                        }
                    }
                    sum_CT = sum_CT + CT;
                    sum_CT2 = sum_CT2 + CT * CT;
                }
            }
            else if (anti == true)
            {
                double St2 = origin.S, cv2 = 0, delta2 = 0, Stn2 = 0;
                for (int i = 0; i < origin.trial; i++)
                {
                    St = origin.S;
                    St2 = origin.S;
                    cv = 0;
                    cv2 = 0;
                    for (int j = 1; j < origin.step; j++)
                    {
                        t = (i - 1) * dt;
                        d1 = (Math.Log(St / origin.K) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta = Phi1(d1);
                        d1 = (Math.Log(St2 / origin.K) + (origin.r + origin.e * origin.e / 2) * origin.T) / (origin.e * Math.Sqrt(origin.T));
                        delta2 = Phi1(d1);
                        Stn = St * Math.Exp(nudt + sigsdt * randmatrix[i, j]);
                        Stn2 = St2 * Math.Exp(nudt + sigsdt * -randmatrix[i, j]);
                        if (c == "call")
                        {
                            cv = cv + delta * (Stn - St * erddt);
                            cv2 = cv2 + delta2 * (Stn2 - St2 * erddt);
                        }
                        else if (c == "put")
                        {
                            cv = cv + (delta - 1) * (Stn - St * erddt);
                            cv2 = cv2 + (delta2 - 1) * (Stn2 - St2 * erddt);
                        }
                        St = Stn;
                        St2 = Stn2;
                    }
                    if (c == "call")
                    {
                        CT = 0.5 * (Math.Max(0, St - origin.K) + beta1 * cv + Math.Max(0, St2 - origin.K) + beta1 * cv2);
                    }
                    else if (c == "put")
                    {
                        CT = 0.5 * (Math.Max(0, origin.K - St) + beta1 * cv + Math.Max(0, origin.K - St2) + beta1 * cv2);
                    }
                    sum_CT = sum_CT + CT;
                    sum_CT2 = sum_CT2 + CT * CT;
                }
            }
            result[0] = sum_CT / origin.trial * Math.Exp(-origin.r * origin.T);
            SD = Math.Sqrt((sum_CT2 - sum_CT * sum_CT / origin.trial) * Math.Exp(-2 * origin.r * origin.T) / (origin.trial - 1));
            result[1] = SD / Math.Sqrt(origin.trial);
            return result;
        }

    }

    class Simulator : Value//class simulator inherit from class value, this class is to generate the random matrix
    {
        public Simulator(double S_S, double K_K, double r_r, double e_e, double T_T, double d_d, Int64 step_, Int64 trial_)
            : base(S_S, K_K, r_r, e_e, T_T, d_d, step_, trial_)
        { }//constructor

        public double[,] generateregular()//generate random numbers
        {
            int seekSeek = unchecked((int)DateTime.Now.Ticks);//seed
            Random rnd = new Random(seekSeek);
            double rand1, rand2, w, c;//temp variables, store two uniform random values,the sum of the values
            double[] randn = new double[2]; ;//temp array, store the normal random values 

            /*if (n == true)
            {
                for (int i = 0; i < trial/2; i++)
                    for (int j = 1; j < step; j = j + 2)
                    {
                        do// PR method to generate normal distribution random number
                        {
                            rand1 = rnd.NextDouble() * 2 - 1;
                            rand2 = rnd.NextDouble() * 2 - 1;
                            w = rand1 * rand1 + rand2 * rand2;
                        } while (w > 1);//w should be less than or equal 1
                        c = Math.Sqrt((-2) * Math.Log(w) / w);
                        randn[0] = c * rand1;
                        randn[1] = c * rand2;
                        if (j + 1 < step)//use two random numbers, which generated simultaneous
                        {
                            result[i, j] = randn[0];
                            result[i, j + 1] = randn[1];
                        }
                        else
                            result[i, j] = randn[0];
                    }
                for (Int64 i = trial / 2 ; i < trial; i++)
                    for (Int64 j = 0 ; j < step; j++)
                        result[i, j] = -result[i - trial / 2, j];
            }*/

            double[,] result = new double[trial, step];
            for (int i = 0; i < trial; i++)
                for (int j = 1; j < step; j = j + 2)
                {
                    do// PR method to generate normal distribution random number
                    {
                        rand1 = rnd.NextDouble() * 2 - 1;
                        rand2 = rnd.NextDouble() * 2 - 1;
                        w = rand1 * rand1 + rand2 * rand2;
                    } while (w > 1);//w should be less than or equal 1
                    c = Math.Sqrt((-2) * Math.Log(w) / w);
                    randn[0] = c * rand1;
                    randn[1] = c * rand2;
                    if (j + 1 < step)//use two random numbers, which generated simultaneous
                    {
                        result[i, j] = randn[0];
                        result[i, j + 1] = randn[1];
                    }
                    else
                        result[i, j] = randn[0];

                }
            return result;
        }
        public void multiregualr(object o)
        {
            multithreading m = (multithreading)o;
            m.rand = new double[m.underlyings.trial, m.underlyings.step];
            double[] randn = new double[2];
            double rand1, rand2, w, c;
            Random rnd = new Random();
            Monitor.Enter(m);
            for (int i = 0; i < m.underlyings.trial; i++)
                for (int j = 1; j < m.underlyings.step; j = j + 2)
                {
                    do// PR method to generate normal distribution random number
                    {
                        rand1 = rnd.NextDouble() * 2 - 1;
                        rand2 = rnd.NextDouble() * 2 - 1;
                        w = rand1 * rand1 + rand2 * rand2;
                    } while (w > 1);//w should be less than or equal 1
                    c = Math.Sqrt((-2) * Math.Log(w) / w);
                    randn[0] = c * rand1;
                    randn[1] = c * rand2;
                    if (j + 1 < m.underlyings.step)//use two random numbers, which generated simultaneous
                    {
                        m.rand[i, j] = randn[0];
                        m.rand[i, j + 1] = randn[1];
                    }
                    else
                        m.rand[i, j] = randn[0];
                }
            Monitor.Exit(m);
        }
        public double[,] generatehalton(bool n, int prime1, int prime2)
        {
            double[,] result = new double[trial, step];
            for (int i = 0; i < trial; i++)
                result[i, 0] = 0;
            if (n == false)//non-antithetic
            {
                double[] halton1 = new double[trial / 2];
                double[] halton2 = new double[trial / 2];
                halton1 = gethalton(prime1, trial / 2);
                halton2 = gethalton(prime2, trial / 2);
                for (int i = 0; i < trial / 2; i++)//Box-Muller
                {
                    double d1 = halton1[i], d2 = halton2[i];
                    halton1[i] = Math.Sqrt(-2 * Math.Log(d1)) * Math.Cos(2 * Math.PI * d2);
                    halton2[i] = Math.Sqrt(-2 * Math.Log(d1)) * Math.Sin(2 * Math.PI * d2);
                }
                for (int i = 0; i < trial / 2; i++)
                {
                    result[i, 0] = 0;
                    result[i, 1] = halton1[i];
                    result[i + trial / 2, 1] = halton2[i];
                }
            }
            /*else if (n == 1)//antithetic
            {
                double[] halton = new double[trial * (step - 1) / 2];
                halton = gethalton(prime, trial * (step - 1) / 2);
                int k=0;
                for(int i=0;i<trial/2;i++)
                    for (int j = 1; j < step; j++)
                    {
                        result[i, j] = halton[k];
                        k++;
                    }
                for(Int64 i=trial/2+1;i<trial;i++)
                    for (int j = 1; j < step; j++)
                        result[i, j] = -result[i - trial / 2, j];
            }*/
            return result;
        }

        private double[] gethalton(int prime, Int64 howmany)
        {
            double[] seq = new double[howmany];
            int numbits = 1 + ceil(Math.Log(howmany) / Math.Log(prime));
            double[] vetbase = new double[numbits];
            for (int i = 0; i < numbits; i++)
                vetbase[i] = Math.Pow(prime, -(i + 1));
            double[] workvet = new double[numbits];
            int j, k;
            for (int i = 0; i < howmany; i++)
            {
                j = 0;
                k = 0;
                while (k == 0)
                {
                    workvet[j] = workvet[j] + 1;
                    if (workvet[j] < prime)
                        k = 1;
                    else
                    {
                        workvet[j] = 0;
                        j++;
                    }
                }
                seq[i] = dot(workvet, vetbase);
            }
            return seq;
        }

        private int ceil(double temp)
        {
            int a = 0;
            if (temp > -1 && temp < 1)
            {
                if (temp <= 0)
                    a = 0;
                else if (temp > 0)
                    a = 1;
            }
            else if (temp >= 1 || temp <= -1)
            {
                if (temp / (int)temp != 1)
                {
                    if (temp < 0)
                    {
                        a = (int)temp;
                    }
                    else if (temp > 0)
                    {
                        a = (int)temp + 1;
                    }
                }
                else if (temp / (int)temp == 1)
                {
                    if (temp > 0)
                    {
                        a = (int)temp;
                    }
                    else if (temp < 0)
                    {
                        a = (int)temp;
                    }
                }

            }
            return a;
        }
        private double dot(double[] x, double[] y)
        {
            double all = 0;
            for (int i = 0; i < x.Length; i++)
                all = all + x[i] * y[i];
            return all;
        }

        private int[] decitobit(int num)
        {
            int[] temp = new int[4];
            for (int i = 3; i >= 0; i--)
            {
                temp[i] = num % 2;
                num = num / 2;
            }
            return temp;
        }

        private int[] GetDirNumber(int[] p, int[] m0, int n)//generate the direction numbers
        {
            int degree = p.Length - 1;
            int[] newp = new int[degree - 1];
            int[] m = new int[m0.Length + n - degree];
            double[] result = new double[m0.Length + n - degree];
            for (int i = 0; i < degree - 1; i++)
                newp[i] = p[i + 1];
            for (int i = 0; i < m0.Length; i++)
            {
                m[i] = m0[i];
            }
            for (int i = degree; i < n; i++)
            {
                m[i] = bittodeci(bitxor(m[i - degree], (int)Math.Pow(2, degree) * m[i - degree]));
                for (int j = 0; j < degree - 1; j++)
                    m[i] = bittodeci(bitxor(m[i], (int)Math.Pow(2, j + 1) * newp[j] * m[i - j - 1]));

            }
            for (int i = 0; i < m.Length; i++)
                result[i] = (double)m[i] / ((double)Math.Pow(2, (i + 1)));
            return m;
        }

        private int[] decitobit2(int num)//decimal to binary
        {
            int[] temp = new int[10];
            for (int i = 0; i < 10; i++)
            {
                temp[i] = num % 2;
                num = num / 2;
            }
            return temp;
        }

        private int[] bitxor(int num1, int num2)//The bitwise exclusive OR
        {
            int[] temp1 = decitobit2(num1);
            int[] temp2 = decitobit2(num2);
            int n1 = temp1.Length;
            int n2 = temp2.Length;
            while (temp1[n1 - 1] == 0 && temp2[n2 - 1] == 0)
            {
                n1--;
                n2--;
            }
            int n = Math.Max(n1, n2);
            for (int i = 0; i < n; i++)
            {
                if (temp1[i] == temp2[i])
                    temp1[i] = 0;
                else
                    temp1[i] = 1;
            }
            return temp1;
        }

        public static int bittodeci(int[] num)//binary to decimal
        {
            int temp = 0;
            int n = num.Length;
            while (num[n - 1] == 0)
                n--;
            for (int i = 0; i < n; i++)
            {
                if (num[i] != 0)
                    temp = temp + (int)Math.Pow(2, i);
            }
            return temp;
        }

    }
}


