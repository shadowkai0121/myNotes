USE AdventureWorks2014
--go �ҥ�13-4 �����I�Ÿ�
GO

--JOIN
--�d�߾P������m�W�B���~�I�ܥثe���~�Z�٦��t�d��P���ϰ�

--SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD 
--FROM Sales.SalesPerson sp;
--SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
--SELECT st.TerritoryID, st.Name FROM Sales.SalesTerritory st;



----�ϥ�LEFT JOIN�H�_��
--SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD, 
--P.FirstName, P.LastName, st.Name AS Territory
--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
----on ��BusinessEntityID�@����r�s���C�ݭn���w���Ӹ�ƪ�(sp. / p.)
--ON sp.BusinessEntityID = p.BusinessEntityID

--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID;



----�u�ƨϥ�����(�R��L�����B������춶��)
--SELECT p.BusinessEntityID,P.FirstName, P.LastName, 
--st.Name AS Territory, sp.SalesYTD

--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
--ON sp.BusinessEntityID = p.BusinessEntityID
--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID
----�u�ƨϥ�����(�̨ϥΪ̻ݨD�Ƨ�)
----(����i��|�Q�ξP����B�Ƨ�)
--ORDER BY sp.SalesYTD DESC;
----(HR�i��|�ΤH�W)
----���{�ɩʪ����



--���ܱ`�Ϊ��{�ɪ��|��VIEW�ʸ�
--view �R�W�Ŷ�.�W��
--CREATE VIEW sales.vQuerySalesYTD
--AS
--SELECT p.BusinessEntityID,P.FirstName, P.LastName, 
--st.Name AS Territory, sp.SalesYTD
--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
--ON sp.BusinessEntityID = p.BusinessEntityID
--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID;



--����creat view���S�����\
--�|�s�b�˵��̭�
SELECT * FROM Sales.vQuerySalesYTD;