USE LabTest
GO

--DROP TABLE LeftTable;
--DROP TABLE RightTable;

--CREATE TABLE LeftTable(
--	SEQ CHAR(1),
--	ItemName NVARCHAR(10)
--);

--CREATE TABLE RightTable
--(
--	ItemName VARCHAR(10),
--	Price TINYINT
--);

SELECT * FROM LeftTable lt;
SELECT * FROM RightTable rt;

--INSERT INTO LeftTable (SEQ , ItemName) VALUES ('1' , 'Fish');
--INSERT INTO LeftTable (SEQ , ItemName) VALUES ('2' , 'Beef');
--INSERT INTO LeftTable (SEQ , ItemName) VALUES ('3' , 'Shrimp');

--INSERT INTO RightTable (ItemName, Price) VALUES ('Fish',99);
--INSERT INTO RightTable (ItemName, Price) VALUES ('Beef',109);
--INSERT INTO RightTable (ItemName, Price) VALUES ('BigMac',129);

SELECT lt.SEQ, lt.ItemName FROM LeftTable lt;
SELECT rt.ItemName, rt.Price FROM RightTable rt;

-- 以左邊的table所選取的欄位為主，如果右邊的table對應不到，就會是NULL
SELECT lt.SEQ, lt.ItemName, rt.Price
FROM LeftTable lt LEFT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

-- 以右邊的table所選取的欄位為主，如果左邊的table對應不到，就會是NULL
-- (注意這邊的ItemName，要改選用 righttable.ItemName 才會顯示
SELECT lt.SEQ, rt.ItemName, rt.Price
FROM LeftTable lt RIGHT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

-- inner就是有交集的部份才會顯示
SELECT lt.SEQ, rt.ItemName, rt.Price
FROM LeftTable lt INNER JOIN RightTable rt ON lt.ItemName = rt.ItemName