USE ZipCodeDemo
GO

--����S���j���J�W�� �k��S���d�q������
----LEFT JOIN �H����TABLE��쬰�D �k���������|��NULL
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--LEFT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----RIGHT JOIN �H�k����쬰�D ������������ܦ�NULL
----ItemName��lt.�|��NULL
--SELECT lt.SEQ, rt.ItemName, rt.Price FROM lefttable lt 
--RIGHT JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----INNER JOIN ��ӳ������~�|�X�{
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--INNER JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----FULL JOIN ������i�h �S�����Ȫ�����ܦ�NULL
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--FULL JOIN RightTable rt ON lt.ItemName = rt.ItemName;

----JOIN�OINNER JOIN
--SELECT lt.SEQ, lt.ItemName, rt.Price FROM lefttable lt 
--JOIN RightTable rt ON lt.ItemName = rt.ItemName;


--�R��table
--DROP TABLE LeftTable;
--DROP TABLE RightTable;

--�إߴ���table
--CREATE TABLE LeftTable(
--	SEQ CHAR(1),
--	ItemName nVARCHAR(10),
--)

--CREATE TABLE RightTable(
--	ItemName nVARCHAR(10),
--	Price INT
--)

--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('1','��������');
--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('2','�w�洵�¤���');
--INSERT INTO LeftTable (SEQ, ItemName) VALUES ('3','�d�q��������');

--INSERT INTO RightTable (ItemName, Price) VALUES ('��������', 5);
--INSERT INTO RightTable (ItemName, Price) VALUES ('�w�洵�¤���', 55);
--INSERT INTO RightTable (ItemName, Price) VALUES ('�j���J', 555);