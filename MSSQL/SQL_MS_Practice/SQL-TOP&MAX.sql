--找出員工時薪，以及時薪最高的人

--選取需要欄位
--join資料表
--max選出最高rate
--top(1)&desc選出最高
SELECT TOP 1
p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName, MAX(eph.Rate) AS maxRate
FROM Person.Person p
RIGHT JOIN HumanResources.EmployeePayHistory eph 
ON p.BusinessEntityID = eph.BusinessEntityID
GROUP BY p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName
ORDER BY maxRate DESC;



--SELECT p.BusinessEntityID, P.FirstName, P.LastName FROM Person.Person p;
--SELECT * FROM HumanResources.EmployeePayHistory eph;

--SELECT eph.BusinessEntityID, MAX(eph.Rate) 
--FROM HumanResources.EmployeePayHistory eph
--GROUP BY eph.BusinessEntityID;


--過濾NULL
--SELECT 
--p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName, MAX(eph.Rate) AS maxRate
--FROM Person.Person p
----過濾不會有薪水的TYPE
--RIGHT JOIN HumanResources.EmployeePayHistory eph 
--ON p.BusinessEntityID = eph.BusinessEntityID
----找出沒薪水的人
----WHERE eph.Rate IS NULL
--GROUP BY p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName
----LEFT JOIN過濾不會有薪水的TYPE
----HAVING MAX(eph.Rate) IS NOT NULL;

