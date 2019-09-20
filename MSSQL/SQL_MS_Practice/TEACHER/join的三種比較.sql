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

-- �H���䪺table�ҿ������쬰�D�A�p�G�k�䪺table��������A�N�|�ONULL
SELECT lt.SEQ, lt.ItemName, rt.Price
FROM LeftTable lt LEFT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

-- �H�k�䪺table�ҿ������쬰�D�A�p�G���䪺table��������A�N�|�ONULL
-- (�`�N�o�䪺ItemName�A�n���� righttable.ItemName �~�|���
SELECT lt.SEQ, rt.ItemName, rt.Price
FROM LeftTable lt RIGHT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

-- inner�N�O���涰�������~�|���
SELECT lt.SEQ, rt.ItemName, rt.Price
FROM LeftTable lt INNER JOIN RightTable rt ON lt.ItemName = rt.ItemName