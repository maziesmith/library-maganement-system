USE [AustLibraryBD]
GO
/****** Object:  StoredProcedure [dbo].[_sp_InsertIntoBorrower]    Script Date: 4/3/2015 12:36:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[_sp_InsertIntoBorrower]
     
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

