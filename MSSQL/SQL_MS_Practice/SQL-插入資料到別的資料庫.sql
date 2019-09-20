--選取McDonald裡面的zipcode

SELECT*FROM ZipCode zc;
--SELECT*FROM [McDonald].[dbo].[ZipCode];

--還沒有資料

--插入[ZipCodeDemo].[dbo].[ZipCode]
--到[McDonald].[dbo].[ZipCode]
--簡略寫法 不能帶分號

INSERT INTO ZipCode
SELECT*FROM [ZipCodeDemo].[dbo].[ZipCode];

--完整寫法
INSERT INTO ZipCode (ZipCode.City,Road,Street) VALUES ('城市','路','街');
SELECT*FROM ZipCode WHERE ZipCode = '城市';

SELECT DISTINCT City FROM ZipCode ORDER BY City;
--排序變了!!!!!
--資料庫右鍵屬性 定序
--zipcodedemo 排序為ㄅㄆㄇ
--McDonald 排序為筆畫