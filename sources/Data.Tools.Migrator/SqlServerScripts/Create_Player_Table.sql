CREATE TABLE [dbo].[Players] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [PlayerGUID] NVARCHAR (50) NULL,
    [Name]       NVARCHAR (50) NULL,
    [Level]      INT           NULL,
    [Race]       NVARCHAR (50) NULL,
    [Class]      NVARCHAR (50) NULL,
	[WowheadTalentUrl] NVARCHAR(MAX) NULL,
    [CreatedAt]  DATETIME      NULL,
    [UpdatedAt]  DATETIME      NULL,
    [UpdatedBy]  INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo_Players_dbo_Users_UserId] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[Users] ([Id])
);
GO
CREATE PROCEDURE [dbo].[PlayerInsert]

	@PlayerGUID nvarchar(50),
	@Name nvarchar(50)

AS
BEGIN

	-- USER
	INSERT INTO [Players]
	(
		[PlayerGUID],
		[Name]
	)
	VALUES
	(
		@PlayerGUID,
		@Name
	)

	SELECT SCOPE_IDENTITY() AS Id

END
GO
