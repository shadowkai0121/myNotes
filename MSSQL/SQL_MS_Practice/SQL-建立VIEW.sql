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