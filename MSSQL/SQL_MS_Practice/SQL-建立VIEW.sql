--↓很常用的臨時表格會用VIEW封裝
--view 命名空間.名稱
--CREATE VIEW sales.vQuerySalesYTD
--AS
--SELECT p.BusinessEntityID,P.FirstName, P.LastName, 
--st.Name AS Territory, sp.SalesYTD
--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
--ON sp.BusinessEntityID = p.BusinessEntityID
--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID;



--測試creat view有沒有成功
--會存在檢視裡面
SELECT * FROM Sales.vQuerySalesYTD;