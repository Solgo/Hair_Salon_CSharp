USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 12/8/2016 8:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_name] [varchar](50) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 12/8/2016 8:46:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stylist_name] [varchar](50) NULL,
	[work_hours] [varchar](50) NULL,
	[days_of_week] [varchar](100) NULL
) ON [PRIMARY]

GO
