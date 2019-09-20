-- ��X���u�����~�O�h�֡A�H�ή��~�̰����H�O��
SELECT DISTINCT p.PersonType FROM Person.Person p;

SELECT * FROM HumanResources.EmployeePayHistory;
SELECT eph.BusinessEntityID, max(eph.Rate) 
FROM HumanResources.EmployeePayHistory eph
GROUP BY eph.BusinessEntityID;

-- �J�`�禡�e������쳣�����OGROUP BY������
SELECT p.BusinessEntityID, p.FirstName, p.LastName , max(eph.Rate) as maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID = eph.BusinessEntityID
GROUP BY p.BusinessEntityID, p.FirstName, p.LastName;

-- �D��Ĥ@�W
SELECT TOP 1 p.BusinessEntityID, P.PersonType,p.FirstName, 
       p.LastName, max(eph.Rate) as maxRate
FROM Person.Person p
LEFT JOIN HumanResources.EmployeePayHistory eph ON p.BusinessEntityID = eph.BusinessEntityID
WHERE eph.Rate IS NOT NULL
GROUP BY p.BusinessEntityID, P.PersonType,p.FirstName, p.LastName
ORDER BY maxRate desc;

-- �q���G���̭���X������(DISTINCT)��PersonType�A�ӥB�n���~���ONULL��
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
