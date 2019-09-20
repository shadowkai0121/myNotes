--找出員工的時薪是多少,以及時薪最高的人是誰

SELECT * FROM Person.Person p;
SELECT * FROM HumanResources.EmployeePayHistory eph;




SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
SELECT eph.BusinessEntityID FROM HumanResources.EmployeePayHistory eph;





SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
SELECT eph.BusinessEntityID FROM HumanResources.EmployeePayHistory eph;

SELECT p.BusinessEntityID, p.FirstName, p.LastName, eph.Rate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID;





SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
SELECT eph.BusinessEntityID,MAX(eph.Rate)  
FROM HumanResources.EmployeePayHistory eph
GROUP BY eph.BusinessEntityID;




SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate)
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID;





--匯總欄位 依據 選取欄位
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) 
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;




--欄位取名
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;




--排序
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName
ORDER BY maxRate DESC;




--WHY有人沒有薪水?

SELECT DISTINCT p.PersonType FROM Person.Person p;





--插入p.PersonType

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;





--插入p.PersonType後發現太多,下一個條件

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p
WHERE maxRate = NULL
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;






--語法無效,拿 本人[MAX(eph.Rate)] 來取代

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p
WHERE  MAX(eph.Rate) = NULL
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;





--語法再次無效,使用having

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
HAVING  MAX(eph.Rate) = NULL
ORDER BY maxRate DESC;





--語法再次無效,拿掉max

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
HAVING  eph.Rate = NULL
ORDER BY maxRate DESC;





--再試 WHERE eph.Rate IS NULL

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
WHERE eph.Rate IS NULL
GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;




--利用distinct找出不重複的persontype

SELECT DISTINCT PersonType 
FROM 
(
SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
WHERE eph.Rate IS NULL
GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
) AS temp
