USE [Student]
GO
/****** Object:  Table [dbo].[StudentInformation]    Script Date: 20-02-2020 13:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInformation](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [nvarchar](50) NULL,
	[StudentRollNumber] [nvarchar](50) NULL,
	[StudentFatherName] [nvarchar](50) NULL,
	[StudentMotherName] [nvarchar](50) NULL,
 CONSTRAINT [PK_StudentInformation] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[StudentInformation] ON 

INSERT [dbo].[StudentInformation] ([StudentId], [StudentName], [StudentRollNumber], [StudentFatherName], [StudentMotherName]) VALUES (1, N'Devloper Universal', N'23', N'ML', N'Su')
INSERT [dbo].[StudentInformation] ([StudentId], [StudentName], [StudentRollNumber], [StudentFatherName], [StudentMotherName]) VALUES (2, N'Devloper Universal', N'23', N'ML', N'Su')
INSERT [dbo].[StudentInformation] ([StudentId], [StudentName], [StudentRollNumber], [StudentFatherName], [StudentMotherName]) VALUES (3, N'Alok Saxena', N'23', N'ML', N'Su')
INSERT [dbo].[StudentInformation] ([StudentId], [StudentName], [StudentRollNumber], [StudentFatherName], [StudentMotherName]) VALUES (4, N'Sarika Pathare', N'23', N'ML', N'Su')
SET IDENTITY_INSERT [dbo].[StudentInformation] OFF
/****** Object:  StoredProcedure [dbo].[Student__FetchAll]    Script Date: 20-02-2020 13:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Author: <Author,,Name>

-- Create date: <Create Date,,>

-- Description: <Description,,>

-- =============================================

CREATE PROCEDURE [dbo].[Student__FetchAll]
--EXEC [Student__FetchAll]
--@StudentId int


AS

BEGIN

-- SET NOCOUNT ON added to prevent extra result sets from

-- interfering with SELECT statements.

SET NOCOUNT ON;

SELECT si.[StudentId],si.[StudentName],si.[StudentRollNumber],si.[StudentFatherName],si.[StudentMotherName]
     FROM [StudentInformation] si 
	 --WHERE  si.StudentId = @StudentId


END

GO
/****** Object:  StoredProcedure [dbo].[Student_InsertUpdate]    Script Date: 20-02-2020 13:27:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================

-- Author: <Author,,Name>

-- Create date: <Create Date,,>

-- Description: <Description,,>

-- =============================================

CREATE PROCEDURE [dbo].[Student_InsertUpdate]

@StudentId int

,@StudentName [nvarchar](50)

,@StudentRollNumber [nvarchar](50)

,@StudentFatherName [nvarchar](50)

,@StudentMotherName [nvarchar](50)

AS

BEGIN

-- SET NOCOUNT ON added to prevent extra result sets from

-- interfering with SELECT statements.

SET NOCOUNT ON;

INSERT INTO [dbo].[StudentInformation]

           ([StudentName]

           ,[StudentRollNumber]

           ,[StudentFatherName]

           ,[StudentMotherName])

     VALUES

           (@StudentName

           ,@StudentRollNumber

           ,@StudentFatherName

           ,@StudentMotherName)



END


GO
