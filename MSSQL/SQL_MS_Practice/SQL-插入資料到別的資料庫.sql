--���McDonald�̭���zipcode

SELECT*FROM ZipCode zc;
--SELECT*FROM [McDonald].[dbo].[ZipCode];

--�٨S�����

--���J[ZipCodeDemo].[dbo].[ZipCode]
--��[McDonald].[dbo].[ZipCode]
--²���g�k ����a����

INSERT INTO ZipCode
SELECT*FROM [ZipCodeDemo].[dbo].[ZipCode];

--����g�k
INSERT INTO ZipCode (ZipCode.City,Road,Street) VALUES ('����','��','��');
SELECT*FROM ZipCode WHERE ZipCode = '����';

SELECT DISTINCT City FROM ZipCode ORDER BY City;
--�Ƨ��ܤF!!!!!
--��Ʈw�k���ݩ� �w��
--zipcodedemo �ƧǬ��t�u�v
--McDonald �ƧǬ����e