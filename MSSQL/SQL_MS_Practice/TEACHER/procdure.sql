-- �ت��G��J���u�m�W�A�N�i�H���o�A���u��������ơG�m�W�B�a�}�B�q�ܡBEmail

-- ���۹�������ƪ�
SELECT * FROM Person.Person p;
SELECT * FROM Person.Address a;
SELECT * FROM Person.BusinessEntityAddress bea;
SELECT * FROM Person.PersonPhone pp;
SELECT * FROM Person.EmailAddress ea;

-- ���o�ݭn�����
SELECT p.BusinessEntityID, p.LastName, p.FirstName FROM Person.Person p;
SELECT a.AddressID, a.AddressLine1 FROM Person.Address a;
SELECT bea.BusinessEntityID, bea.AddressID FROM Person.BusinessEntityAddress bea;
SELECT pp.BusinessEntityID, pp.PhoneNumber FROM Person.PersonPhone pp;
SELECT ea.BusinessEntityID, ea.EmailAddressID FROM Person.EmailAddress ea;

-- JOIN
SELECT p.BusinessEntityID, p.LastName, p.FirstName, A.AddressLine1, pp.PhoneNumber, EA.EmailAddress
FROM Person.Person p
LEFT JOIN Person.BusinessEntityAddress bea ON p.BusinessEntityID = bea.BusinessEntityID
LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
LEFT JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
LEFT JOIN Person.EmailAddress ea ON p.BusinessEntityID = ea.BusinessEntityID;

-- ���լd�߱���
SELECT p.BusinessEntityID, p.LastName, p.FirstName, A.AddressLine1, pp.PhoneNumber, EA.EmailAddress
FROM Person.Person p
LEFT JOIN Person.BusinessEntityAddress bea ON p.BusinessEntityID = bea.BusinessEntityID
LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
LEFT JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
LEFT JOIN Person.EmailAddress ea ON p.BusinessEntityID = ea.BusinessEntityID
WHERE p.LastName + p.FirstName = 'AbercrombieKim'
;

--�g�J����procdure
--DROP PROCEDURE HumanResources.sp_QueryPerson;

CREATE PROCEDURE HumanResources.sp_QueryPerson
	@inputName VARCHAR(10)
AS

	-- �d�ݥΡA�T�{����N�i�H����
	--PRINT @inputName;

SELECT p.BusinessEntityID, p.LastName, p.FirstName, A.AddressLine1, pp.PhoneNumber, EA.EmailAddress
FROM Person.Person p
LEFT JOIN Person.BusinessEntityAddress bea ON p.BusinessEntityID = bea.BusinessEntityID
LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
LEFT JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
LEFT JOIN Person.EmailAddress ea ON p.BusinessEntityID = ea.BusinessEntityID
WHERE p.LastName + p.FirstName LIKE '%' + @inputName + '%'

EXEC HumanResources.sp_queryPerson 'A';
