USE AdventureWorks2014
GO

-- �d�߾P������m�W�B���~�I�ܥثe���~�Z�٦��t�d��P���ϰ�
SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD FROM Sales.SalesPerson sp;
SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
SELECT st.TerritoryID, st.Name,st.SalesYTD FROM Sales.SalesTerritory st;

-- �ϥ�left join �y�k�A���X���P���d�ߵ��G
SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD ,
       P.FirstName, P.LastName, st.Name
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID;

-- �Ƥ@�ӨϥΪ̥i�����ݨ쪺���ǥH�ε��G
SELECT sp.BusinessEntityID ,
       P.FirstName, P.LastName, st.Name, sp.SalesYTD
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID
--�p�G�O����A�i��|�Q�n�ξP����B�Ƨ�
ORDER BY sp.SalesYTD DESC;
--�p�G�OHR�A�i��|�Q�n�ΤH�W�Ƨ�
--ORDER BY p.FirstName;

-- view
CREATE VIEW sales.vQuerySalesYTD
AS
SELECT sp.BusinessEntityID ,
       P.FirstName, P.LastName, st.Name, sp.SalesYTD
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID

-- ����create view���\��A�d�߬ݬ�
SELECT * FROM sales.vQuerySalesYTD;