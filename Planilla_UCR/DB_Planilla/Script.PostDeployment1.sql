/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
use [DB_Planilla]

INSERT INTO Person
VALUES('jeremyEmployee@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Person
VALUES('jeremyEmployer@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Person
VALUES('Mauricioemployee@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Employer
VALUES('jeremyEmployer@ucr.ac.cr')

INSERT INTO Employee
VALUES('jeremyEmployee@ucr.ac.cr')

INSERT INTO Employee
VALUES('Mauricioemployee@ucr.ac.cr')

INSERT INTO Project
VALUES('jeremyEmployer@ucr.ac.cr', 'ProjectNameExample', 'ProjectDescription:D',10,2,'NormalInterval')

INSERT INTO Project
VALUES('jeremyEmployer@ucr.ac.cr', 'ProjectNameExample2', 'ProjectDescription:D',10,2,'NormalInterval')

INSERT INTO AgreementType
Values('TypeOfAgreement1', 100)

INSERT INTO AgreementType
Values('TypeOfAgreement1', 100)

DELETE FROM Agreement

INSERT INTO Agreement
VALUES ('Mauricioemployee@ucr.ac.cr',
'jeremy2@ucr.ac.cr', 
'ProjectNameExample', 
'2022-01-01', 
'TypeOfAgreement1', 
100, 
'2023-01-01')

-- Agreement agreement = new Agreement("jeremy@ucr.ac.cr", "jeremy2@ucr.ac.cr", "ProjectNameExample", "2022-01-01", "TypeOfAgreement1", 100, "2023-01-01");

    --protected override async Task OnInitializedAsync()
    --{
       -- //Agreement agreement = new Agreement("Mauricioemployee@ucr.ac.cr", "jeremy2@ucr.ac.cr", "ProjectNameExample", "2022-01-01", "TypeOfAgreement1", 100, "2023-01-01");
       -- Agreement agreement = new Agreement("jeremy@ucr.ac.cr", "jeremy2@ucr.ac.cr", "ProjectNameExample", "2022-01-01", "TypeOfAgreement1", 100, "2023-01-01");
       -- await AgreementService.CreateAgreementAsync(agreement);
        --_loading = false;
   -- }
