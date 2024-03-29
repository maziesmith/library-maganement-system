USE [master]
GO
/****** Object:  Database [AustLibraryBD]    Script Date: 5/5/2015 10:03:40 PM ******/
CREATE DATABASE [AustLibraryBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AustLibraryBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AustLibraryBD.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AustLibraryBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\AustLibraryBD_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AustLibraryBD] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AustLibraryBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AustLibraryBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AustLibraryBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AustLibraryBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AustLibraryBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AustLibraryBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [AustLibraryBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AustLibraryBD] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AustLibraryBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AustLibraryBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AustLibraryBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AustLibraryBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AustLibraryBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AustLibraryBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AustLibraryBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AustLibraryBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AustLibraryBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AustLibraryBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AustLibraryBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AustLibraryBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AustLibraryBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AustLibraryBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AustLibraryBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AustLibraryBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AustLibraryBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AustLibraryBD] SET  MULTI_USER 
GO
ALTER DATABASE [AustLibraryBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AustLibraryBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AustLibraryBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AustLibraryBD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [AustLibraryBD]
GO
/****** Object:  StoredProcedure [dbo].[_sp_DeleteAccountByID]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_DeleteAccountByID]
(
     @AccountId varchar(50)
 )
AS
BEGIN
     SET NOCOUNT ON;
     DELETE FROM Account
	        WHERE AccountId=@AccountId
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_DeleteAllAccount]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_DeleteAllAccount]

AS
BEGIN
     SET NOCOUNT ON;
     DELETE FROM Account
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_DeleteExperiedAccountWhomHaveNoBorrowedBook]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[_sp_DeleteExperiedAccountWhomHaveNoBorrowedBook]
(
@ToDay as datetime,
@ErrorMsg  as VARCHAR(100) OUT
 )
AS
    
BEGIN
     delete  from account where  ExpDate<@ToDay AND AccountId NOT IN (select AccountId from Borrower)
        SET @ErrorMsg= +' Experied Account Whom Have No Borrowed Book Deleted Successfully'    
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_DeleteRowAccountByID]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_DeleteRowAccountByID]
(
     @AccountId varchar(50)
 )
AS
BEGIN
     SET NOCOUNT ON;
     DELETE FROM Account
	        WHERE AccountId=@AccountId
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_GetAccountDetail]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_GetAccountDetail]
AS
BEGIN
     SET NOCOUNT ON;
     SELECT * FROM Account
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_GetAllBorrower]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_GetAllBorrower]
AS
BEGIN
     SET NOCOUNT ON;
     SELECT * FROM Borrower
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_GetAllExpiredAccount]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_GetAllExpiredAccount]
(
@ToDay as datetime
 )
AS
    
BEGIN
     
	  SELECT * FROM Account WHERE ExpDate<@ToDay
      
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_GetAnAccountById]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_GetAnAccountById]
(
     @AccountId varchar(50)
    
)
AS
BEGIN
     SET NOCOUNT ON;
     SELECT * FROM Account
	 WHERE AccountId=@AccountId
	      
		         
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_InsertIntoAccount]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_InsertIntoAccount]
(
     @AccountId varchar(50),
     @FirstName nvarchar(50),
     @LastName varchar(50),
	 @AccountType varchar(50),
     @Email nvarchar(50), 
     @CellNo int,
	 @Address varchar(50),
	 @ExpDate datetime
)
AS
BEGIN
     INSERT INTO Account(AccountId,FirstName,LastName,AccountType,Email,CellNo,Address,ExpDate)
                 VALUES(@AccountId,@FirstName,@LastName,@AccountType,@Email,@CellNo,@Address,@ExpDate)
	
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_InsertIntoBorrower]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[_sp_InsertIntoBorrower]
     
(
     @BookId as int,
     @AccountId as varchar(50),   
   	 @IssueDate as datetime,
	 @ReturnDate as datetime,
	 @ErrorMsg  as VARCHAR(100) OUT
)
AS
    
BEGIN   

SET NOCOUNT ON;
 
IF EXISTS( SELECT BookId FROM Book WHERE BookId=@BookId and Quantity>0)
   
   BEGIN
        IF EXISTS( SELECT AccountId FROM Account WHERE AccountId=@AccountId AND ExpDate>@ReturnDate)
     
	    BEGIN
             IF NOT EXISTS( SELECT AccountId FROM Borrower WHERE AccountId=@AccountId)
			    
                BEGIN
                     INSERT INTO Borrower(BookId,AccountId,IssueDate,ReturnDate)
                     VALUES(@BookId,@AccountId,@IssueDate,@ReturnDate)
				    
					 Update Book set Quantity=Quantity-1 where BookId=@BookId
					
				     SET @ErrorMsg= +'Book Borrwed Successfully'
	              
	             END
			  ELSE
			     BEGIN
                 SET @ErrorMsg= @AccountId + ' Has Alreay taken a book you a Id cannot Borrow more than ONE Book '
				 END
	     END
		 ELSE
		    BEGIN
              SET @ErrorMsg= + 'This Id is Expaired or This Id will be experied before retun date'
		    END
 END

      
ELSE
    BEGIN
    SET @ErrorMsg= + 'The Book has no copy '
	END   
END


GO
/****** Object:  StoredProcedure [dbo].[_sp_ReturnFromBorrower]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[_sp_ReturnFromBorrower]
     
(
     @BookId as int,
     @AccountId as varchar(50),   
   	
	 @ErrorMsg  as VARCHAR(100) OUT
)
AS
    
BEGIN   

SET NOCOUNT ON;
 
    IF EXISTS( SELECT AccountId FROM Borrower WHERE AccountId=@AccountId and BookId=@BookId)
	   BEGIN
            DELETE FROM Borrower WHERE AccountId=@AccountId and BookId=@BookId 
                    				    
			Update Book set Quantity=Quantity+1 where BookId=@BookId
					
			SET @ErrorMsg= +'Book Returned Successfully'
	              
	    END
	ELSE
		BEGIN
             SET @ErrorMsg= @AccountId + ' Has has not borrowed This Book '
	    END
 END
		


GO
/****** Object:  StoredProcedure [dbo].[_sp_SearchAccountDetail]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_SearchAccountDetail]
(
     @AccountId varchar(50),
     @FirstName nvarchar(50),
     @LastName varchar(50),
	 @Address varchar(50),
	 @ExpDate datetime 

)
AS
BEGIN
     SET NOCOUNT ON;
     SELECT * FROM Account
	 WHERE AccountId=@AccountId OR
	       FirstName= @FirstName OR
		   LastName=@LastName OR
		   Address=@Address or 
		   ExpDate<@ExpDate
		         
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_UpdateAccountById]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_UpdateAccountById]
(
     @AccountId varchar(50),
     @FirstName nvarchar(50),
     @LastName varchar(50),
	 @AccountType varchar(50),
     @Email nvarchar(50), 
     @CellNo int,
	 @Address varchar(50),
	 @ExpDate datetime
	
)
AS
BEGIN
     SET NOCOUNT ON;
     UPDATE Account
	 SET FirstName= @FirstName,
		 LastName=@LastName,
		 AccountType=@AccountType,
		 Email=@Email,
		 CellNo=@CellNo,
		 Address=@Address,
		 ExpDate=@ExpDate
	 WHERE AccountId=@AccountId 
	  
		         
END

GO
/****** Object:  StoredProcedure [dbo].[_sp_UpdateRowAccountById]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[_sp_UpdateRowAccountById]
(
     @AccountId varchar(50),
     @FirstName nvarchar(50),
     @LastName varchar(50),
	 @AccountType varchar(50),
     @Email nvarchar(50), 
     @CellNo int,
	 @Address varchar(50)
	
)
AS
BEGIN
     SET NOCOUNT ON;
     UPDATE Account
	 SET FirstName= @FirstName,
		 LastName=@LastName,
		 AccountType=@AccountType,
		 Email=@Email,
		 CellNo=@CellNo,
		 Address=@Address
	 WHERE AccountId=@AccountId 
	  
		         
END

GO
/****** Object:  StoredProcedure [dbo].[spuserdetail]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spuserdetail]
@UserName varchar(50),
@Password varchar(50),
@Email varchar(50),
@Country varchar(50),
@ERROR VARCHAR(100) OUT
AS
BEGIN   
         
SET NOCOUNT ON;
 
IF NOT EXISTS(SELECT * FROM UserDetail WHERE UserName=@UserName) 
   BEGIN
        INSERT INTO UserDetail(UserName,[Password],Email,Country)
               VALUES(@UserName,@Password,@Email,@Country)
               SET @ERROR=@UserName+' Registered Successfully'
   END
ELSE
   BEGIN
    SET @ERROR=@UserName + ' Already Exists'
   END
END


GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[AccountType] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[CellNo] [int] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[ExpDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Author] [varchar](50) NOT NULL,
	[BookType] [varchar](50) NOT NULL,
	[Version] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[PublisherName] [varchar](50) NOT NULL,
	[PublisherAddress] [varchar](50) NULL,
	[PublisherContactNo] [int] NOT NULL,
	[PublishYear] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Book_1] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Borrower]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Borrower](
	[BookId] [int] NOT NULL,
	[AccountId] [varchar](50) NOT NULL,
	[IssueDate] [date] NOT NULL,
	[ReturnDate] [date] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 5/5/2015 10:03:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetail](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Borrower]  WITH CHECK ADD  CONSTRAINT [FK_Borrower_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Borrower] CHECK CONSTRAINT [FK_Borrower_Account]
GO
ALTER TABLE [dbo].[Borrower]  WITH CHECK ADD  CONSTRAINT [FK_Borrower_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Book] ([BookId])
GO
ALTER TABLE [dbo].[Borrower] CHECK CONSTRAINT [FK_Borrower_Book]
GO
USE [master]
GO
ALTER DATABASE [AustLibraryBD] SET  READ_WRITE 
GO
