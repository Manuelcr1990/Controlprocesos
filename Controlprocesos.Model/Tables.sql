USE [CP]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 18/4/2018 23:11:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Notes] [varchar](max) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ODP]    Script Date: 18/4/2018 23:11:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ODP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NODP] [varchar](15) NOT NULL,
	[ClientId] [int] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Notes] [varchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[FinishedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ODP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ODPProcess]    Script Date: 18/4/2018 23:11:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ODPProcess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ODPId] [int] NOT NULL,
	[ProcessId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Notes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ODPProcess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Process]    Script Date: 18/4/2018 23:11:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Process](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[Notes] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ODP]  WITH CHECK ADD  CONSTRAINT [FK_ODP_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
GO
ALTER TABLE [dbo].[ODP] CHECK CONSTRAINT [FK_ODP_Client]
GO
ALTER TABLE [dbo].[ODPProcess]  WITH CHECK ADD  CONSTRAINT [FK_ODPProcess_ODP] FOREIGN KEY([ODPId])
REFERENCES [dbo].[ODP] ([Id])
GO
ALTER TABLE [dbo].[ODPProcess] CHECK CONSTRAINT [FK_ODPProcess_ODP]
GO
ALTER TABLE [dbo].[ODPProcess]  WITH CHECK ADD  CONSTRAINT [FK_ODPProcess_Process] FOREIGN KEY([ProcessId])
REFERENCES [dbo].[Process] ([Id])
GO
ALTER TABLE [dbo].[ODPProcess] CHECK CONSTRAINT [FK_ODPProcess_Process]
GO
