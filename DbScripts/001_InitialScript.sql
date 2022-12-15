IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Accounts] (
    [Id] int NOT NULL IDENTITY,
    [AccountNumber] varchar(26) NOT NULL,
    [IsActive] smallint NOT NULL,
    [Balance] decimal(18,0) NOT NULL,
    [HasDebit] smallint NOT NULL,
    [DebitBalance] decimal(18,0) NOT NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Addresses] (
    [Id] int NOT NULL IDENTITY,
    [ApartmentNumber] varchar(6) NOT NULL,
    [HouseNumber] varchar(6) NOT NULL,
    [Street] varchar(50) NOT NULL,
    [City] varchar(50) NOT NULL,
    [PostalCode] varchar(7) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(100) NOT NULL,
    [Pesel] varchar(12) NOT NULL,
    [PhoneNumber] varchar(15) NOT NULL,
    [Email] varchar(50) NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] int NOT NULL IDENTITY,
    [Name] varchar(50) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Login] varchar(50) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id])
);
GO

CREATE TABLE [ClientAccount] (
    [AccountId] int NOT NULL,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_ClientAccount] PRIMARY KEY ([AccountId], [ClientId]),
    CONSTRAINT [FK_ClientAccount_Accounts_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Accounts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientAccount_Clients_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ClientAddress] (
    [AddressId] int NOT NULL,
    [ClientId] int NOT NULL,
    CONSTRAINT [PK_ClientAddress] PRIMARY KEY ([AddressId], [ClientId]),
    CONSTRAINT [FK_ClientAddress_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientAddress_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ClientAccount_ClientId] ON [ClientAccount] ([ClientId]);
GO

CREATE UNIQUE INDEX [IX_ClientAddress_AddressId] ON [ClientAddress] ([AddressId]);
GO

CREATE UNIQUE INDEX [IX_ClientAddress_ClientId] ON [ClientAddress] ([ClientId]);
GO

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221215142422_InitialMigration', N'7.0.0');
GO

COMMIT;
GO

