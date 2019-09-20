USE MilkShop

--INSERT INTO DrinkMenu
--SELECT*FROM Drink;

--尋找size是空白的資料
--SELECT*FROM DrinkMenu dm WHERE (Size='' OR Size IS NULL);

--更新欄位，把空白改為N
--UPDATE DrinkMenu SET SIZE = 'N'WHERE (Size='' OR Size IS NULL);

--NULL跟空白不一樣
--SELECT*FROM DrinkMenu dm WHERE ID IN ('GT10','TE07');
--UPDATE DrinkMenu SET SIZE = NULL WHERE ID = 'GT10';
--UPDATE DrinkMenu SET SIZE = '' WHERE ID = 'TE07';

--更新欄位
--UPDATE DrinkMenu SET HotPrice = HotPrice -5;
UPDATE DrinkMenu SET ColdPrice = ColdPrice -5;