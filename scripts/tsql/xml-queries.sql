SELECT * FROM [dbo].[Company] WHERE companyName = 'Test Company';

SELECT * FROM [dbo].[Company] WHERE companyName = 'Test Company' FOR XML AUTO;

-- by id
SELECT helperTable.Employee.query('.')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./EmployeeID').value('.', 'int') = 1;

-- all
SELECT helperTable.Employee.query('.')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company';

-- by first name
SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = 'Test Company' AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = 'Bob';

-- by last name
SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = 'Test Company' AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = 'Frank';

-- by full name
SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
                  CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
                  WHERE companyName = 'Test Company' 
				  AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = 'Bob'
				  AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = 'Frank';

-- insert new employee
