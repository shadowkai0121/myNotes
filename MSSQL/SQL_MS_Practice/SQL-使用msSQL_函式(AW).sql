USE AdventureWorks2014
GO

--將產品資料表中，所有產品名稱拼字都換成大寫英文字母 (UPPER)
--SELECT UPPER(NAME) FROM Production.Product;	
--作資料比對用，資料庫有可能區分大小寫

--將產品資料表中，所有產品名稱拼字都換成小寫英文字母 (LOWER)
--SELECT LOWER(NAME) FROM Production.Product;	

--產品歷史資料表中最便宜的產品的價格 (MIN) 2.29
--SELECT MIN(ListPrice) FROM Production.ProductListPriceHistory plph;

--法產品資料表中最貴的產品的價格 (MAX) 3578.27
--SELECT MAX(ListPrice) FROM Production.Product p;

-- 產品資料表中，共有幾項產品? (COUNT) 504
--SELECT COUNT(DISTINCT Name) FROM Production.Product p;

-- 4號員工的平均調薪是多少 (AVG) 20.7287
--SELECT AVG(rate) AS avgrate FROM HumanResources.EmployeePayHistory eph 
--WHERE eph.BusinessEntityID = 4;

-- 產品庫存資料表中，4號產品庫存量總和是多少 (SUM) 1322
--SELECT SUM(pi.Quantity) AS totalQuantity FROM Production.ProductInventory pi
--WHERE pi.ProductID = 4;

-- 採購訂單總金額在15000到20000之間的 (BETWEEN) nothing
--SELECT * FROM Purchasing.PurchaseOrderHeader poh
--WHERE poh.TotalDue BETWEEN 15000 AND 20000;

-- 使用 TOP 方法找出 採購訂單總金額中 最貴 的價格 
--SELECT TOP(1) poh.TotalDue FROM Purchasing.PurchaseOrderHeader poh
--ORDER BY poh.TotalDue DESC;
 
-- 使用 TOP 方法找出 採購訂單總金額 最便宜 的價格 
--SELECT TOP(1) poh.TotalDue FROM Purchasing.PurchaseOrderHeader poh
--ORDER BY poh.TotalDue asc;

-- 產品庫存資料表中，依照 ProductID 統計總和 (group by)
--SELECT ProductID,SUM(quantity) FROM Production.ProductInventory
--GROUP BY ProductID;



--雙層select
--SELECT * FROM Production.Product p 
--WHERE p.ProductID IN (
--SELECT pi.Quantity FROM Production.ProductInventory pi
--WHERE p.ProductID = 710);



-- 產品庫存資料表中，依照 ProductID 統計總和後，找出庫存總和大於 1800 的產品
--(having)
--SELECT ProductID,SUM(quantity) FROM Production.ProductInventory
--GROUP BY ProductID HAVING SUM(Quantity) > 1800;

-- 哪一個客戶(CustomerID)下過最多訂單? 最多訂單的客戶排最前面

--SELECT CustomerID, COUNT(*) AS OrderCNT 
--FROM Sales.SalesOrderHeader soh
--GROUP BY soh.CustomerID ORDER BY COUNT(*) desc;

--選取customerID跟訂單數量 count(SalesOrderID)
--以CustomerID作群組 用訂單數量遞減排序


-- 43659 訂單訂購的產品名稱是什麼?
--選出需要的欄位
--SELECT sod.SalesOrderID,sod.SalesOrderDetailID,sod.ProductID 
--FROM Sales.SalesOrderDetail sod 
--WHERE sod.SalesOrderID = 43659;

--SELECT p.ProductID,Name FROM Production.Product p;

--黏在一起
--SELECT p.Name, sod.SalesOrderID, sod.SalesOrderDetailID, sod.ProductID 
--FROM Sales.SalesOrderDetail sod
----inner left right full cross
--JOIN Production.Product p ON sod.ProductID = p.ProductID
--WHERE sod.SalesOrderID = 43659 ORDER BY Name;