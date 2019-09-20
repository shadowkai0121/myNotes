-- 找出員工的時薪是多少，以及時薪最高的人是誰
SELECT DISTINCT p.PersonType FROM Person.Person p;

SELECT * FROM HumanResources.EmployeePayHistory;
SELECT eph.BusinessEntityID, max(eph.Rate) 
FROM HumanResources.EmployeePayHistory eph
GROUP BY eph.BusinessEntityID;

-- 彙總函式前面的欄位都必須是GROUP BY的條件
SELECT p.BusinessEntityID, p.FirstName, p.LastName , max(eph.Rate) as maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID = eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;

-- 挑選第一名
SELECT TOP 1 p.BusinessEntityID, P.PersonType,p.FirstName, 
       p.LastName, max(eph.Rate) as maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID = eph.BusinessEntityID
WHERE eph.Rate IS NOT NULL
GROUP BY p.BusinessEntityID, P.PersonType,p.FirstName, p.LastName
ORDER BY maxRate desc;

-- 從結果集裡面找出不重複(DISTINCT)的PersonType，而且要有薪水是NULL的
SELECT DISTINCT PersonType 
FROM 
(
SELECT p.BusinessEntityID, P.PersonType,p.FirstName, 
       p.LastName, max(eph.Rate) as maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID = eph.BusinessEntityID
WHERE eph.Rate IS NULL
GROUP BY p.BusinessEntityID, P.PersonType,p.FirstName, p.LastName
) AS temp
