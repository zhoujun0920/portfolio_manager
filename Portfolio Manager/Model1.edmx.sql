
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/11/2014 06:51:08
-- Generated from EDMX file: C:\Users\JUNZHOU\documents\visual studio 2013\Projects\Portfolio Manager\Portfolio Manager\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Portfolio Manager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InstTypeBarrierOption]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BarrierOptions] DROP CONSTRAINT [FK_InstTypeBarrierOption];
GO
IF OBJECT_ID(N'[dbo].[FK_InstTypeDigitalOption]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DigitalOptions] DROP CONSTRAINT [FK_InstTypeDigitalOption];
GO
IF OBJECT_ID(N'[dbo].[FK_InstrumentPrice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prices] DROP CONSTRAINT [FK_InstrumentPrice];
GO
IF OBJECT_ID(N'[dbo].[FK_InstrumentTrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trades] DROP CONSTRAINT [FK_InstrumentTrade];
GO
IF OBJECT_ID(N'[dbo].[FK_InstTypeInstrument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Instruments] DROP CONSTRAINT [FK_InstTypeInstrument];
GO
IF OBJECT_ID(N'[dbo].[FK_InstTypeLookBackOption]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LookBackOptions] DROP CONSTRAINT [FK_InstTypeLookBackOption];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BarrierOptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BarrierOptions];
GO
IF OBJECT_ID(N'[dbo].[DigitalOptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DigitalOptions];
GO
IF OBJECT_ID(N'[dbo].[Instruments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Instruments];
GO
IF OBJECT_ID(N'[dbo].[InstTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InstTypes];
GO
IF OBJECT_ID(N'[dbo].[InterestRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InterestRates];
GO
IF OBJECT_ID(N'[dbo].[LookBackOptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LookBackOptions];
GO
IF OBJECT_ID(N'[dbo].[Prices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prices];
GO
IF OBJECT_ID(N'[dbo].[Trades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trades];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BarrierOptions'
CREATE TABLE [dbo].[BarrierOptions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsUp] bit  NULL,
    [IsIn] bit  NULL,
    [barrier] float  NULL,
    [InstTypeId] int  NOT NULL
);
GO

-- Creating table 'DigitalOptions'
CREATE TABLE [dbo].[DigitalOptions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [rebate] float  NULL,
    [InstTypeId] int  NOT NULL
);
GO

-- Creating table 'Instruments'
CREATE TABLE [dbo].[Instruments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NULL,
    [Ticker] nvarchar(max)  NULL,
    [Exchange] nvarchar(max)  NULL,
    [Underlying] nvarchar(max)  NULL,
    [Strike] float  NULL,
    [Tenor] float  NULL,
    [IsCall] smallint  NULL,
    [InstTypeId] int  NOT NULL
);
GO

-- Creating table 'InstTypes'
CREATE TABLE [dbo].[InstTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NULL,
    [Underlying] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InterestRates'
CREATE TABLE [dbo].[InterestRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tenor] float  NULL,
    [Rate] float  NULL
);
GO

-- Creating table 'LookBackOptions'
CREATE TABLE [dbo].[LookBackOptions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsFixed] bit  NULL,
    [InstTypeId] int  NOT NULL
);
GO

-- Creating table 'Prices'
CREATE TABLE [dbo].[Prices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Timestamp] nvarchar(max)  NULL,
    [ClosingPrice] float  NULL,
    [InstrumentId] int  NOT NULL
);
GO

-- Creating table 'Trades'
CREATE TABLE [dbo].[Trades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsBuy] bit  NULL,
    [Quantity] float  NOT NULL,
    [UnderlyingP] float  NULL,
    [MarketPrice] float  NULL,
    [Price] float  NOT NULL,
    [Timestamp] nvarchar(max)  NOT NULL,
    [PL] float  NOT NULL,
    [Delta] float  NULL,
    [Gamma] float  NULL,
    [Vega] float  NULL,
    [Theta] float  NULL,
    [Rho] float  NULL,
    [InstrumentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BarrierOptions'
ALTER TABLE [dbo].[BarrierOptions]
ADD CONSTRAINT [PK_BarrierOptions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DigitalOptions'
ALTER TABLE [dbo].[DigitalOptions]
ADD CONSTRAINT [PK_DigitalOptions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [PK_Instruments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InstTypes'
ALTER TABLE [dbo].[InstTypes]
ADD CONSTRAINT [PK_InstTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InterestRates'
ALTER TABLE [dbo].[InterestRates]
ADD CONSTRAINT [PK_InterestRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LookBackOptions'
ALTER TABLE [dbo].[LookBackOptions]
ADD CONSTRAINT [PK_LookBackOptions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [PK_Prices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [PK_Trades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [InstTypeId] in table 'BarrierOptions'
ALTER TABLE [dbo].[BarrierOptions]
ADD CONSTRAINT [FK_InstTypeBarrierOption]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstTypeBarrierOption'
CREATE INDEX [IX_FK_InstTypeBarrierOption]
ON [dbo].[BarrierOptions]
    ([InstTypeId]);
GO

-- Creating foreign key on [InstTypeId] in table 'DigitalOptions'
ALTER TABLE [dbo].[DigitalOptions]
ADD CONSTRAINT [FK_InstTypeDigitalOption]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstTypeDigitalOption'
CREATE INDEX [IX_FK_InstTypeDigitalOption]
ON [dbo].[DigitalOptions]
    ([InstTypeId]);
GO

-- Creating foreign key on [InstrumentId] in table 'Prices'
ALTER TABLE [dbo].[Prices]
ADD CONSTRAINT [FK_InstrumentPrice]
    FOREIGN KEY ([InstrumentId])
    REFERENCES [dbo].[Instruments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentPrice'
CREATE INDEX [IX_FK_InstrumentPrice]
ON [dbo].[Prices]
    ([InstrumentId]);
GO

-- Creating foreign key on [InstrumentId] in table 'Trades'
ALTER TABLE [dbo].[Trades]
ADD CONSTRAINT [FK_InstrumentTrade]
    FOREIGN KEY ([InstrumentId])
    REFERENCES [dbo].[Instruments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstrumentTrade'
CREATE INDEX [IX_FK_InstrumentTrade]
ON [dbo].[Trades]
    ([InstrumentId]);
GO

-- Creating foreign key on [InstTypeId] in table 'Instruments'
ALTER TABLE [dbo].[Instruments]
ADD CONSTRAINT [FK_InstTypeInstrument]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstTypeInstrument'
CREATE INDEX [IX_FK_InstTypeInstrument]
ON [dbo].[Instruments]
    ([InstTypeId]);
GO

-- Creating foreign key on [InstTypeId] in table 'LookBackOptions'
ALTER TABLE [dbo].[LookBackOptions]
ADD CONSTRAINT [FK_InstTypeLookBackOption]
    FOREIGN KEY ([InstTypeId])
    REFERENCES [dbo].[InstTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstTypeLookBackOption'
CREATE INDEX [IX_FK_InstTypeLookBackOption]
ON [dbo].[LookBackOptions]
    ([InstTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------