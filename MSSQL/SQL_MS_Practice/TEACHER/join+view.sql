USE AdventureWorks2014
GO

-- 查詢銷售員的姓名、今年截至目前的業績還有負責行銷的區域
SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD FROM Sales.SalesPerson sp;
SELECT p.BusinessEntityID, p.FirstName, p.LastName FROM Person.Person p;
SELECT st.TerritoryID, st.Name,st.SalesYTD FROM Sales.SalesTerritory st;

-- 使用left join 語法，結合不同的查詢結果
SELECT sp.BusinessEntityID, sp.TerritoryID, sp.SalesYTD ,
       P.FirstName, P.LastName, st.Name
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID;

-- 排一個使用者可能期望看到的順序以及結果
SELECT sp.BusinessEntityID ,
       P.FirstName, P.LastName, st.Name, sp.SalesYTD
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID
--如果是老闆，可能會想要用銷售金額排序
ORDER BY sp.SalesYTD DESC;
--如果是HR，可能會想要用人名排序
--ORDER BY p.FirstName;

-- view
CREATE VIEW sales.vQuerySalesYTD
AS
SELECT sp.BusinessEntityID ,
       P.FirstName, P.LastName, st.Name, sp.SalesYTD
FROM Sales.SalesPerson sp
LEFT JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
LEFT JOIN Sales.SalesTerritory st ON sp.TerritoryID = st.TerritoryID

-- 執行create view成功後，查詢看看
SELECT * FROM sales.vQuerySalesYTD;