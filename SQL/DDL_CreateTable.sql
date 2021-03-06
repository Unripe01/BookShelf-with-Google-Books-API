USE [Bookshelf]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 2018/11/28 9:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ISBN] [nvarchar](13) NOT NULL,
	[EAN] [nvarchar](13) NULL,
	[Title] [nvarchar](500) NOT NULL,
	[PublicationDateString] [nvarchar](50) NULL,
	[ListPrice] [money] NULL,
	[Publisher] [nvarchar](200) NULL,
	[Author] [nvarchar](200) NULL,
	[DetailPageURL] [nvarchar](max) NULL,
	[MediumImageURL] [nvarchar](max) NULL,
	[TinyImageURL] [nvarchar](max) NULL,
	[InsertDatetime] [datetime] NOT NULL,
	[Disposal] [bit] NOT NULL CONSTRAINT [DF_Books_Disposal]  DEFAULT ((0)),
	[Location] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
