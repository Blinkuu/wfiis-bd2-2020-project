CREATE DATABASE [HierarchyDB];
GO

USE [HierarchyDB];
GO

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
</xsd:schema>';
GO

CREATE TABLE [dbo].[Company] (
	id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	companyName varchar(255) NOT NULL,
	companyData XML (CompanyDataSchemaCollection) NOT NULL
);
GO

ALTER TABLE [dbo].[Company] WITH CHECK ADD CONSTRAINT CompanyNameUniqueContraint UNIQUE (companyName);
GO

INSERT INTO [dbo].[Company]
           ([companyName]
           ,[companyData])
     VALUES
           ('Test Company',
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
				<EmployeeID>3</EmployeeID>
				<ManagerID>1</ManagerID>
				<FirstName>Ricky</FirstName>
				<LastName>Boss</LastName>
				<ContactNo>+48123456789</ContactNo>
				<Email>ricky@boss.com</Email>
				<Address>
				  <City>RickyCity</City>
				  <State>RickyState</State>
				  <Zip>14578</Zip>
				</Address>
			  </Employee>
			</Company>');
GO

INSERT INTO [dbo].[Company]
           ([companyName]
           ,[companyData])
     VALUES
           ('Other Co.',
		   '<Company xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
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
				<EmployeeID>fd6b7c83-d699-4a5b-9284-00c783a9162c</EmployeeID>
				<ManagerID>1</ManagerID>
				<FirstName>TestFirstName</FirstName>
				<LastName>TestLastName</LastName>
				<ContactNo>+48987654321</ContactNo>
				<Email>test@test.com</Email>
				<Address>
				  <City>TestCity</City>
				  <State>TestState</State>
				  <Zip>54321</Zip>
				</Address>
			  </Employee>
			  </Company>');
  GO