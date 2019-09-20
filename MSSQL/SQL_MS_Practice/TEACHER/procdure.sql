-- 目的：輸入員工姓名，就可以取得，員工的相關資料：姓名、地址、電話、Email

-- 找到相對應的資料表
SELECT * FROM Person.Person p;
SELECT * FROM Person.Address a;
SELECT * FROM Person.BusinessEntityAddress bea;
SELECT * FROM Person.PersonPhone pp;
SELECT * FROM Person.EmailAddress ea;

-- 取得需要的欄位
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

-- 測試查詢條件
SELECT p.BusinessEntityID, p.LastName, p.FirstName, A.AddressLine1, pp.PhoneNumber, EA.EmailAddress
FROM Person.Person p
LEFT JOIN Person.BusinessEntityAddress bea ON p.BusinessEntityID = bea.BusinessEntityID
LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
LEFT JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
LEFT JOIN Person.EmailAddress ea ON p.BusinessEntityID = ea.BusinessEntityID
WHERE p.LastName + p.FirstName = 'AbercrombieKim'
;

--寫入成為procdure
--DROP PROCEDURE HumanResources.sp_QueryPerson;

CREATE PROCEDURE HumanResources.sp_QueryPerson
	@inputName VARCHAR(10)
AS

	-- 查看用，確認之後就可以移除
	--PRINT @inputName;

SELECT p.BusinessEntityID, p.LastName, p.FirstName, A.AddressLine1, pp.PhoneNumber, EA.EmailAddress
FROM Person.Person p
LEFT JOIN Person.BusinessEntityAddress bea ON p.BusinessEntityID = bea.BusinessEntityID
LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
LEFT JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
LEFT JOIN Person.EmailAddress ea ON p.BusinessEntityID = ea.BusinessEntityID
WHERE p.LastName + p.FirstName LIKE '%' + @inputName + '%'

EXEC HumanResources.sp_queryPerson 'A';
