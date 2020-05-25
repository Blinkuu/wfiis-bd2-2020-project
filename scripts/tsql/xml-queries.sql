-- select all
SELECT * FROM [dbo].[Company];

-- select from a company
SELECT * FROM [dbo].[Company] WHERE companyName = 'Test Company';

-- by id
SELECT helperTable.Employee.query('.')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar') = '1';

-- all
SELECT helperTable.Employee.query('.')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company';

-- by first name
SELECT helperTable.Employee.query('.') FROM [dbo].[Company]
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = 'Bob';

-- by last name
SELECT helperTable.Employee.query('.') FROM [dbo].[Company]
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = 'Frank';

-- by full name
SELECT helperTable.Employee.query('.') FROM [dbo].[Company]
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' 
AND helperTable.Employee.query('./FirstName').value('.', 'varchar(max)') = 'Bob'
AND helperTable.Employee.query('./LastName').value('.', 'varchar(max)') = 'Frank';

-- get manager by employee id
DECLARE @managerID int;
SELECT @managerID = helperTable.Employee.value('./ManagerID', 'integer')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar') = '2'

SELECT helperTable.Employee.query('.')  
FROM [dbo].[Company]  
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.query('./EmployeeID').value('.', 'varchar') = CAST(@managerID AS varchar(max));

-- get staff by manager id
SELECT helperTable.Employee.query('.') FROM[dbo].[Company]
CROSS APPLY companyData.nodes('/Company/Employee') as helperTable(Employee)
WHERE companyName = 'Test Company' AND helperTable.Employee.value('ManagerID', 'varchar(max)') = 1;

-- insert new employee
DECLARE @currData xml

DECLARE @currentData xml
SELECT @currentData = companyData FROM [dbo].[Company] WHERE companyName = 'Test Company';
SELECT @currentData;

SET @currData = 
'<Company xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Employee>
    <EmployeeID>1</EmployeeID>
    <ManagerID xsi:nil="true" />
    <FirstName>Bob</FirstName>
    <LastName>Frank</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>bob@frank.com</Email>
    <Address>
      <City>BobCity</City>
      <State>BobState</State>
      <Zip>12345</Zip>
    </Address>
  </Employee>
  <Employee>
    <EmployeeID>2</EmployeeID>
    <ManagerID>1</ManagerID>
    <FirstName>Michael</FirstName>
    <LastName>Ross</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>michale@ross.com</Email>
    <Address>
      <City>MichaelCity</City>
      <State>MichaelState</State>
      <Zip>12345</Zip>
    </Address>
  </Employee>
</Company>'

DECLARE @newData xml;

SET @newData =
'<Employee>
    <EmployeeID>1</EmployeeID>
    <ManagerID>1</ManagerID>
    <FirstName>TestFirstName</FirstName>
    <LastName>TestLastName</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>test@test.com</Email>
    <Address>
      <City>TestCity</City>
      <State>TestState</State>
      <Zip>54321</Zip>
    </Address>
  </Employee>';

DECLARE @final XML

SET @final = CAST('<tmp>' + CAST(@newData AS VARCHAR(MAX)) + '</tmp>' + CAST(@currData AS VARCHAR(MAX)) AS XML)

SET @final.modify('insert /tmp/* into (/Company)[1]')
SET @final.modify('delete /tmp')

SELECT @final

-- remove employee by id
DECLARE @currentDataForRemoval xml

SET @currentDataForRemoval = 
'<Company xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Employee>
    <EmployeeID>1</EmployeeID>
    <ManagerID xsi:nil="true" />
    <FirstName>Bob</FirstName>
    <LastName>Frank</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>bob@frank.com</Email>
    <Address>
      <City>BobCity</City>
      <State>BobState</State>
      <Zip>12345</Zip>
    </Address>
  </Employee>
  <Employee>
    <EmployeeID>2</EmployeeID>
    <ManagerID>1</ManagerID>
    <FirstName>Michael</FirstName>
    <LastName>Ross</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>michale@ross.com</Email>
    <Address>
      <City>MichaelCity</City>
      <State>MichaelState</State>
      <Zip>12345</Zip>
    </Address>
  </Employee>
  <Employee>
    <EmployeeID>123456789</EmployeeID>
    <ManagerID>1</ManagerID>
    <FirstName>Michael</FirstName>
    <LastName>Ross</LastName>
    <ContactNo>+48123456789</ContactNo>
    <Email>michale@ross.com</Email>
    <Address>
      <City>MichaelCity</City>
      <State>MichaelState</State>
      <Zip>12345</Zip>
    </Address>
  </Employee>
</Company>'

SET @currentDataForRemoval.modify('delete /Company/Employee[EmployeeID = 123456789]')
SELECT @currentDataForRemoval

-- drop xml schema colletion
DROP XML SCHEMA COLLECTION CompanyDataSchemaCollection;

-- create xml schema collection
CREATE XML SCHEMA COLLECTION CompanyDataSchemaCollection
    AS'<xsd:schema xmlns:xsd="http://www.w3.org/2001/XMLSchema" elementFormDefault="qualified">
  <xsd:element name="Company">
    <xsd:complexType>
      <xsd:complexContent>
        <xsd:restriction base="xsd:anyType">
          <xsd:sequence>
            <xsd:element name="Employee" minOccurs="0" maxOccurs="unbounded">
              <xsd:complexType>
                <xsd:complexContent>
                  <xsd:restriction base="xsd:anyType">
                    <xsd:sequence>
                      <xsd:element name="EmployeeID" type="xsd:string" />
                      <xsd:element name="ManagerID" type="xsd:string" nillable="true" />
                      <xsd:element name="FirstName" type="xsd:string" />
                      <xsd:element name="LastName" type="xsd:string" />
                      <xsd:element name="ContactNo" type="xsd:string" />
                      <xsd:element name="Email" type="xsd:string" />
                      <xsd:element name="Address">
                        <xsd:complexType>
                          <xsd:complexContent>
                            <xsd:restriction base="xsd:anyType">
                              <xsd:sequence>
                                <xsd:element name="City" type="xsd:string" />
                                <xsd:element name="State" type="xsd:string" />
                                <xsd:element name="Zip" type="xsd:string" />
                              </xsd:sequence>
                            </xsd:restriction>
                          </xsd:complexContent>
                        </xsd:complexType>
                      </xsd:element>
                    </xsd:sequence>
                  </xsd:restriction>
                </xsd:complexContent>
              </xsd:complexType>
            </xsd:element>
          </xsd:sequence>
        </xsd:restriction>
      </xsd:complexContent>
    </xsd:complexType>
  </xsd:element>
</xsd:schema>'

-- see xsd schema
SELECT xml_schema_namespace(N'dbo', N'CompanyDataSchemaCollection');