--��X���u�����~�O�h��,�H�ή��~�̰����H�O��

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





--���`��� �̾� ������
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) 
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;




--�����W
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;




--�Ƨ�
SELECT p.BusinessEntityID, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName
ORDER BY maxRate DESC;




--WHY���H�S���~��?

SELECT DISTINCT p.PersonType FROM Person.Person p;





--���Jp.PersonType

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;





--���Jp.PersonType��o�{�Ӧh,�U�@�ӱ���

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p
WHERE maxRate = NULL
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;






--�y�k�L��,�� ���H[MAX(eph.Rate)] �Ө��N

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p
WHERE  MAX(eph.Rate) = NULL
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;





--�y�k�A���L��,�ϥ�having

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
HAVING  MAX(eph.Rate) = NULL
ORDER BY maxRate DESC;





--�y�k�A���L��,����max

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID

GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
HAVING  eph.Rate = NULL
ORDER BY maxRate DESC;





--�A�� WHERE eph.Rate IS NULL

SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
WHERE eph.Rate IS NULL
GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName

ORDER BY maxRate DESC;




--�Q��distinct��X�����ƪ�persontype

SELECT DISTINCT PersonType 
FROM 
(
SELECT p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName, MAX(eph.Rate) AS maxRate

FROM Person.Person p

LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID= eph.BusinessEntityID
WHERE eph.Rate IS NULL
GROUP BY p.BusinessEntityID,p.PersonType, p.FirstName, p.LastName
) AS temp
