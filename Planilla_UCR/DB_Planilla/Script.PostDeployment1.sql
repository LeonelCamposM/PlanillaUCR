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
VALUES('jeremy@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Person
VALUES('jeremy2@ucr.ac.cr',
'Jeremy',
'Vargas',
'Artavia',
'117810140',
'40234020012',
'San José, Costa Rica',
'62571204'
)

INSERT INTO Employer
VALUES('jeremy2@ucr.ac.cr')

INSERT INTO Employee
VALUES('jeremy@ucr.ac.cr')

INSERT INTO Project
VALUES('jeremy2@ucr.ac.cr', 'ProjectNameExample', 'ProjectDescription:D',10,2,'NormalInterval')

INSERT INTO AgreementType
Values('TypeOfAgreement1', 100)

DELETE FROM Agreement