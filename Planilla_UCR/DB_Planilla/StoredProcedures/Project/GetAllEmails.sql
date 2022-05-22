CREATE Procedure EmailCheck(@EmployerEmail varchar(255))
AS
BEGIN
    Select * from Employer where Employer.Email = @EmployerEmail
END