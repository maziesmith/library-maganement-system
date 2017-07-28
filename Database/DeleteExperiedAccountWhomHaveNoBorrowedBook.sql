USE [AustLibraryBD]
GO
/****** Object:  StoredProcedure [dbo].[_sp_DeleteExperiedAccountWhomHaveNoBorrowedBook]    Script Date: 4/3/2015 12:37:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[_sp_DeleteExperiedAccountWhomHaveNoBorrowedBook]
(
@ToDay as datetime
 )
AS
    
BEGIN
     delete  from account where  ExpDate<@ToDay AND AccountId NOT IN (select AccountId from Borrower)
          
END
