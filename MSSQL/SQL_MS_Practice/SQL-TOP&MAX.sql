--��X���u���~�A�H�ή��~�̰����H

--����ݭn���
--join��ƪ�
--max��X�̰�rate
--top(1)&desc��X�̰�
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


--�L�oNULL
--SELECT 
--p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName, MAX(eph.Rate) AS maxRate
--FROM Person.Person p
----�L�o���|���~����TYPE
--RIGHT JOIN HumanResources.EmployeePayHistory eph 
--ON p.BusinessEntityID = eph.BusinessEntityID
----��X�S�~�����H
----WHERE eph.Rate IS NULL
--GROUP BY p.BusinessEntityID, P.PersonType, P.FirstName, P.LastName
----LEFT JOIN�L�o���|���~����TYPE
----HAVING MAX(eph.Rate) IS NOT NULL;

