USE AdventureWorks2014
--go 課本13-4 結束點符號
GO

--JOIN
--查詢銷售員的姓名、今年截至目前的業績還有負責行銷的區域

--SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD 
--FROM Sales.SalesPerson sp;
--SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
--SELECT st.TerritoryID, st.Name FROM Sales.SalesTerritory st;



----使用LEFT JOIN黏起來
--SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD, 
--P.FirstName, P.LastName, st.Name AS Territory
--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
----on 用BusinessEntityID作關鍵字連結。需要指定哪個資料表(sp. / p.)
--ON sp.BusinessEntityID = p.BusinessEntityID

--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID;



----優化使用體驗(刪減無用欄位、移動欄位順序)
--SELECT p.BusinessEntityID,P.FirstName, P.LastName, 
--st.Name AS Territory, sp.SalesYTD

--FROM Sales.SalesPerson sp 
--LEFT JOIN Person.Person p 
--ON sp.BusinessEntityID = p.BusinessEntityID
--LEFT JOIN Sales.SalesTerritory st 
--ON sp.TerritoryID = st.TerritoryID
----優化使用體驗(依使用者需求排序)
----(老闆可能會想用銷售金額排序)
--ORDER BY sp.SalesYTD DESC;
----(HR可能會用人名)
----↑臨時性的表格



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