USE [master]
GO
CREATE DATABASE [Counters] 
GO
USE [Counters]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CounterOptions](
	[CounterID] [int] NOT NULL,
	[CounterType] [varchar](15) NOT NULL,
	[CounterDescription] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CounterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CounterValue](
	[CounterValudId] [int] NOT NULL,
	[AccountID] [int] NULL,
	[CounterID] [int] NULL,
	[CounterValue] [int] NULL,
	[Unit] [varchar](15) NULL,
	[DateOfEnterValue] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CounterValudId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalAccount](
	[AccountID] [int] NOT NULL,
	[DateOfCreation] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CounterOptions]  WITH CHECK ADD CHECK  (([CounterType]='Электричество' OR [CounterType]='Вода'))
GO
INSERT INTO [dbo].[PersonalAccount] ([AccountID], [DateOfCreation]) VALUES ('15', '2016-23-12');
INSERT INTO [dbo].[PersonalAccount] ([AccountID], [DateOfCreation]) VALUES ('5', '2016-24-12');
INSERT INTO [dbo].[PersonalAccount] ([AccountID], [DateOfCreation]) VALUES ('0', '2016-25-12');

INSERT INTO [dbo].[CounterOptions] ([CounterID], [CounterType], [CounterDescription]) VALUES ('0', 'Вода', 'Счетчик воды');
INSERT INTO [dbo].[CounterOptions] ([CounterID], [CounterType], [CounterDescription]) VALUES ('4', 'Электричество', 'Счетчик электричества');
INSERT INTO [dbo].[CounterOptions] ([CounterID], [CounterType], [CounterDescription]) VALUES ('8', 'Вода', 'Счетчик воды');

INSERT INTO [dbo].[CounterValue] ([CounterValudId], [AccountID], [CounterID], [CounterValue], [Unit], [DateOfEnterValue]) VALUES ('0', '15', '0', '4', 'Кубы', '2016-10-25');
