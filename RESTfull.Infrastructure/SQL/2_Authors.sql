USE [RESTFull]
GO

CREATE TABLE [dbo].[Authors](
	[id] [int] IDENTITY(1, 1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([id] ASC)
) ON [PRIMARY]
GO


