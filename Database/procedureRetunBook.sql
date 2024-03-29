USE [AustLibraryBD]
GO
/****** Object:  StoredProcedure [dbo].[_sp_ReturnFromBorrower]    Script Date: 4/3/2015 12:36:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[_sp_ReturnFromBorrower]
     
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
		

