CREATE Procedure EmailCheck(@UserEmail varchar(255))
AS
BEGIN
    Select * from Employer where Employer.Email = @UserEmail
END