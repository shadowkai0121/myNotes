-- 輸入員工姓名取得相關資料：姓名、地址、電話、E-MAIL

--對應的資料表
SELECT * FROM Person.Person p;
SELECT * FROM Person.Address a;
SELECT * FROM Person.BusinessEntityAddress bea;

SELECT * FROM Person.PersonPhone pp;
SELECT * FROM Person.EmailAddress ea;

--連結需要的欄位
SELECT BusinessEntityID, LastName, FirstName FROM Person.Person p;
SELECT a.AddressID, a.AddressLine1 FROM Person.Address a;
SELECT bea.BusinessEntityID, bea.AddressID FROM Person.BusinessEntityAddress bea;

SELECT pp.BusinessEntityID,pp.PhoneNumber FROM Person.PersonPhone pp;
SELECT ea.BusinessEntityID,ea.EmailAddressID FROM Person.EmailAddress ea;

--join
SELECT p.BusinessEntityID, LastName, FirstName FROM Person.Person p
	LEFT JOIN Person.BusinessEntityAddress bea ON P.BusinessEntityID = bea.BusinessEntityID
	LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
	LEFT JOIN Person.PersonPhone pp ON P.BusinessEntityID = pp.BusinessEntityID
	LEFT JOIN  Person.EmailAddress ea ON P.BusinessEntityID = ea.BusinessEntityID
WHERE P.LastName + P.FirstName = 'AbbasSyed';

--寫入成為procdure
--procdure可以沒有回傳值
DROP PROCEDURE HumanResources.sp_QueryPerson;

CREATE PROCEDURE HumanResources.sp_QueryPerson
	@inputName VARCHAR(20) 
	AS
		SELECT p.BusinessEntityID, LastName, FirstName FROM Person.Person p
			LEFT JOIN Person.BusinessEntityAddress bea ON P.BusinessEntityID = bea.BusinessEntityID
			LEFT JOIN Person.Address a ON bea.AddressID = a.AddressID
			LEFT JOIN Person.PersonPhone pp ON P.BusinessEntityID = pp.BusinessEntityID
			LEFT JOIN Person.EmailAddress ea ON P.BusinessEntityID = ea.BusinessEntityID
		WHERE P.LastName + P.FirstName = @inputName

--測試
EXEC HumanResources.sp_QueryPerson 'AbbasSyed';
--OK