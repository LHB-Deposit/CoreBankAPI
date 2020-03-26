IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200318131834_InitailDBCreation')
BEGIN
    CREATE TABLE [UserLevels] (
        [Id] bigint NOT NULL IDENTITY,
        [UserLevelCode] varchar(2) NULL,
        [UserLevelName] varchar(50) NULL,
        CONSTRAINT [PK_UserLevels] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200318131834_InitailDBCreation')
BEGIN
    CREATE TABLE [UserMatrices] (
        [Id] bigint NOT NULL IDENTITY,
        [UserLevel] varchar(10) NULL,
        [FunctionCode] varchar(6) NULL,
        CONSTRAINT [PK_UserMatrices] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200318131834_InitailDBCreation')
BEGIN
    CREATE TABLE [UserProfiles] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] varchar(10) NOT NULL,
        [UserLevel] varchar(2) NULL,
        [NameTH] nvarchar(300) NULL,
        [NameEN] varchar(300) NULL,
        [Email] varchar(200) NULL,
        [Department] varchar(200) NULL,
        [Hash] text NULL,
        [Salt] text NULL,
        [ActiveStatus] bit NOT NULL,
        [IPAddress] varchar(50) NOT NULL,
        [LastUsage] datetime2 NULL,
        [LastLogin] datetime2 NULL,
        [LastLogout] datetime2 NULL,
        [CreateBy] varchar(50) NOT NULL,
        [CreateDate] datetime2 NOT NULL,
        [UpdateBy] nvarchar(max) NULL,
        [UpdateDate] datetime2 NULL,
        CONSTRAINT [PK_UserProfiles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200318131834_InitailDBCreation')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200318131834_InitailDBCreation', N'3.1.2');
END;

GO

