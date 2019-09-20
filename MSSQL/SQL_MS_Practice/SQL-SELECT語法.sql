USE Northwind
GO
--選取ZipCode所有欄位 * = all
SELECT*FROM ZipCode;

--選取縣市欄位 city
SELECT City FROM ZipCode zc;

--重複資料只出現一次
SELECT DISTINCT City FROM ZipCode zc;

--依據縣市欄位排序 order by
SELECT DISTINCT * FROM Products ORDER BY UnitPrice;

--把zipcodedemo專案複製到McDonald

Select 欄位
From 伺服器.資料庫.結構.表格名稱
Where 條件
group by 欄位
Order By 欄位