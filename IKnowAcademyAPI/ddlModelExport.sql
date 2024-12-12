-- IKADB.dbo.CourseCard definition

-- Drop table

-- DROP TABLE IKADB.dbo.CourseCard;

CREATE TABLE IKADB.dbo.CourseCard (
	Id int IDENTITY(1,1) NOT NULL,
	[Order] int NOT NULL,
	CardName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CardShortDescription nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CardShortImageUrl nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_CourseCard PRIMARY KEY (Id)
);


-- IKADB.dbo.CourseContent definition

-- Drop table

-- DROP TABLE IKADB.dbo.CourseContent;

CREATE TABLE IKADB.dbo.CourseContent (
	Id int IDENTITY(1,1) NOT NULL,
	Header nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	subHeaders nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	shortDescription nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	content nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_CourseContent PRIMARY KEY (Id)
);


-- IKADB.dbo.Users definition

-- Drop table

-- DROP TABLE IKADB.dbo.Users;

CREATE TABLE IKADB.dbo.Users (
	Id int IDENTITY(1,1) NOT NULL,
	FullName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Email nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Phone nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (Id)
);


-- IKADB.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE IKADB.dbo.[__EFMigrationsHistory];

CREATE TABLE IKADB.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- IKADB.dbo.CourseDetails definition

-- Drop table

-- DROP TABLE IKADB.dbo.CourseDetails;

CREATE TABLE IKADB.dbo.CourseDetails (
	Id int IDENTITY(1,1) NOT NULL,
	DetailName nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	DetailDescription nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	EducationProcessDescription nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CarrierOpportunies nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CourseContentId int NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_CourseDetails PRIMARY KEY (Id),
	CONSTRAINT FK_CourseDetails_CourseContent_CourseContentId FOREIGN KEY (CourseContentId) REFERENCES IKADB.dbo.CourseContent(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_CourseDetails_CourseContentId ON dbo.CourseDetails (  CourseContentId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- IKADB.dbo.Courses definition

-- Drop table

-- DROP TABLE IKADB.dbo.Courses;

CREATE TABLE IKADB.dbo.Courses (
	Id int IDENTITY(1,1) NOT NULL,
	Price int NOT NULL,
	StartDate datetime2 NOT NULL,
	Duration nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CourseCardId int NOT NULL,
	CourseDetailsId int NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_Courses PRIMARY KEY (Id),
	CONSTRAINT FK_Courses_CourseCard_CourseCardId FOREIGN KEY (CourseCardId) REFERENCES IKADB.dbo.CourseCard(Id) ON DELETE CASCADE,
	CONSTRAINT FK_Courses_CourseDetails_CourseDetailsId FOREIGN KEY (CourseDetailsId) REFERENCES IKADB.dbo.CourseDetails(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_Courses_CourseCardId ON dbo.Courses (  CourseCardId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE NONCLUSTERED INDEX IX_Courses_CourseDetailsId ON dbo.Courses (  CourseDetailsId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- IKADB.dbo.RatingData definition

-- Drop table

-- DROP TABLE IKADB.dbo.RatingData;

CREATE TABLE IKADB.dbo.RatingData (
	Id int IDENTITY(1,1) NOT NULL,
	CourseId int NOT NULL,
	GeneralRating real NOT NULL,
	ReviewCount int NOT NULL,
	CreatedAt datetime2 NOT NULL,
	UpdatedAt datetime2 NOT NULL,
	IsDeleted bit NOT NULL,
	CONSTRAINT PK_RatingData PRIMARY KEY (Id),
	CONSTRAINT FK_RatingData_Courses_CourseId FOREIGN KEY (CourseId) REFERENCES IKADB.dbo.Courses(Id) ON DELETE CASCADE
);
 CREATE  UNIQUE NONCLUSTERED INDEX IX_RatingData_CourseId ON dbo.RatingData (  CourseId ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;