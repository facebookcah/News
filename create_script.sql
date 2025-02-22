create database ManageBlog
USE ManageBlog
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](225)  NULL,
	[UrlSlug] [nvarchar](225) NULL,
	[Description] [nvarchar](1024) NULL,
	[Status] [tinyint]  NULL,
	[CreatedOn] [datetime2](7)  NULL,
	[UpdatedOn] [datetime2](7)  NULL,
)
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](225)  NULL,
	[Email] [nvarchar](max)  NULL,
	[CommentHeader] [nvarchar](max) NULL,
	[CommentText] [nvarchar](225)  NULL,
	[DateTime] [datetime]  NULL,
	[PostId] [int] NULL,
	[Status] [tinyint]  NULL,
	[CreatedOn] [datetime2](7)  NULL,
	[UpdatedOn] [datetime2](7)  NULL,
	CONSTRAINT FK_POST_COMMENT FOREIGN KEY([PostId]) REFERENCES POST(ID)

)

CREATE TABLE [dbo].[Post](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[Title] [nvarchar](500)  NULL,
	[ShortDescription] [nvarchar](500)  NULL,
	[PostContent] ntext  NULL,
	[UrlSlug] [nvarchar](225) NULL,
	[Published] [bit]  NULL,
	[PostedOn] [datetime]  NULL,
	[Modifiled] [bit]  NULL,
	[ViewCount] [int]  NULL,
	[RateCount] [int]  NULL,
	[TotalRate] [int]  NULL,
	[Rate] [float]  NULL,
	[CategoryId] [int] NULL,
	[Status] [tinyint]  NULL,
	[CreatedOn] [datetime2](7)  NULL,
	[UpdatedOn] [datetime2](7)  NULL,
		CONSTRAINT FK_POST_CATEGORY FOREIGN KEY([CategoryId]) REFERENCES CATEGORY(ID)
)
CREATE TABLE [dbo].[PostTagMap](
	[TagId] [int] NOT NULL,
	[PostId] [int] NOT NULL,
	CONSTRAINT PK_POST_TAG PRIMARY KEY([TagId],[PostId]),
	CONSTRAINT FK_TAG_POST_MAP FOREIGN KEY([TagId]) REFERENCES Tag(ID),

	CONSTRAINT FK_POST_TAG_MAP FOREIGN KEY([PostId]) REFERENCES POST(ID)

 )
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY,
	[TagName] [nvarchar](225)  NULL,
	[UrlSlug] [nvarchar](225) NULL,
	[Description] [nvarchar](1024) NULL,
	[Count] [int]  NULL,
	[Status] [tinyint]  NULL,
	[CreatedOn] [datetime2](7)  NULL,
	[UpdatedOn] [datetime2](7)  NULL,
 )
