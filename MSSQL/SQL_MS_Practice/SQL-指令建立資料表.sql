--����Ʈw�W�r
--ALTER DATABASE LABTEST MODIFY NAME = ZipCodeDemo;

--�s�W��ƪ�
--CREATE table name(col datatype null)

--CREATE TABLE DataType(
--	cr CHAR(10) NULL,
--	ncr NCHAR(10) NULL,
--	vcr VARCHAR(10) NULL,
--	nvcr NVARCHAR(10) NULL,
--)

--�s�W�@����� INSERT INTO table (col1,col2,col3) values(value1,value2,value3)
--INSERT INTO DataType (cr, ncr, vcr, nvcr)
--VALUES ('appleī�G', 'appleī�G','appleī�G','appleī�G');


SELECT cr,ncr,vcr,nvcr FROM DataType dt;
--LEN�i�H���r�����
SELECT LEN(cr),LEN(ncr),LEN(vcr),LEN(nvcr) FROM DataType dt;
--datalength�e�q�j�p
SELECT DATALENGTH(cr),DATALENGTH(ncr),DATALENGTH(vcr),DATALENGTH(nvcr) 
FROM DataType dt;