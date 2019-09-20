USE AdventureWorks2014

-- 產品大分類在哪個資料表
--SELECT*FROM Production.ProductCategory pc;

-- 加拿大(Canada)本年度銷售金額是多少
--SELECT*FROM Sales.SalesTerritory st WHERE Name = 'canada';

-- 產品單位清單(儲存資料比較小)在哪個資料表
--SELECT*FROM Production.UnitMeasure um ORDER BY Name;

-- 採購明細是哪一個資料表
--SELECT*FROM Purchasing.PurchaseOrderDetail pod;

-- 產品報廢原因在哪一個資料表
--SELECT*FROM Production.ScrapReason sr;

-- 產品供應商在哪個資料表
--SELECT*FROM Purchasing.Vendor v;

-- 銷售明細是哪一個資料表
--SELECT*FROM Sales.SalesOrderDetail sod;

-- Person資料表內，PersonType欄位紀錄SP，那是什麼意思? (這裡需要找一下資料)
--SELECT*FROM Person.Person p;
--SC = Store Contact, IN = Individual (retail) customer, SP =Sales person, 
--EM = Employee (non-sales), VC = Vendocr contat, GC = General contact
--最好開一張代碼表

-- 這一份BusinessEntity資料表裡面存放的是什麼資料? (這個和下一題有關係)
--SELECT * FROM Person.BusinessEntity be;
--SELECT * FROM Sales.Customer c WHERE customerID = 1;

-- Person資料表，和Employee還有其他哪些資料表有關係，差異在哪邊?(陷阱?)
