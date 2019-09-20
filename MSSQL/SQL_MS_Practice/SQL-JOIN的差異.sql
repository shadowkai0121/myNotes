USE ZipCodeDemo
GO

--左邊沒有大麥克名稱 右邊沒有千島蝦價錢
----LEFT JOIN 以左邊TABLE欄位為主 右邊對應不到會變NULL
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--LEFT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----RIGHT JOIN 以右邊欄位為主 左邊對應不到變成NULL
----ItemName用lt.會變NULL
--SELECT lt.SEQ, rt.ItemName, rt.Price FROM lefttable lt 
--RIGHT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----INNER JOIN 兩個都有的才會出現
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--INNER JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----FULL JOIN 全部放進去 沒對應值的欄位變成NULL
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--FULL JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----JOIN是INNER JOIN
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--JOIN RightTable rt ON lt.ItemName = rt.ItemName;


--刪除table
--DROP TABLE LeftTable;
--DROP TABLE RightTable;

--建立測試table
--CREATE TABLE LeftTable(
--	SEQ CHAR(1),
--	ItemName nVARCHAR(10),
--)

--CREATE TABLE RightTable(
--	ItemName nVARCHAR(10),
--	Price INT
--)

--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('1','麥香魚堡');
--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('2','安格斯黑牛堡');
--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('3','千島黃金蝦堡');

--INSERT INTO RightTable (ItemName, Price) VALUES ('麥香魚堡', 5);
--INSERT INTO RightTable (ItemName, Price) VALUES ('安格斯黑牛堡', 55);
--INSERT INTO RightTable (ItemName, Price) VALUES ('大麥克', 555);