USE [RESTFull]
GO

CREATE TABLE [dbo].[Books] (
	[id] [int] IDENTITY(1, 1) NOT NULL,
	[name] [nvarchar](max),
	[author_id] [int],
	[year] [int],
	[description] [nvarchar](max),
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([id] ASC)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Books] WITH CHECK ADD CONSTRAINT [FK_Books_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[Authors] ([id])
GO

ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Author]
GO
