--更改資料庫名字
--ALTER DATABASE LABTEST MODIFY NAME = ZipCodeDemo;

--新增資料表
--CREATE table name(col datatype null)

--CREATE TABLE DataType(
--	cr CHAR(10) NULL,
--	ncr NCHAR(10) NULL,
--	vcr VARCHAR(10) NULL,
--	nvcr NVARCHAR(10) NULL,
--)

--新增一筆資料 INSERT INTO table (col1,col2,col3) values(value1,value2,value3)
--INSERT INTO DataType (cr, ncr, vcr, nvcr)
--VALUES ('apple蘋果', 'apple蘋果','apple蘋果','apple蘋果');


SELECT cr,ncr,vcr,nvcr FROM DataType dt;
--LEN可以欄位字串長度
SELECT LEN(cr),LEN(ncr),LEN(vcr),LEN(nvcr) FROM DataType dt;
--datalength容量大小
SELECT DATALENGTH(cr),DATALENGTH(ncr),DATALENGTH(vcr),DATALENGTH(nvcr) 
FROM DataType dt;