USE MilkShop

--INSERT INTO DrinkMenu
--SELECT*FROM Drink;

--�M��size�O�ťժ����
--SELECT*FROM DrinkMenu dm WHERE (Size='' OR Size IS NULL);

--��s���A��ťէאּN
--UPDATE DrinkMenu SET SIZE = 'N'WHERE (Size='' OR Size IS NULL);

--NULL��ťդ��@��
--SELECT*FROM DrinkMenu dm WHERE ID IN ('GT10','TE07');
--UPDATE DrinkMenu SET SIZE = NULL WHERE ID = 'GT10';
--UPDATE DrinkMenu SET SIZE = '' WHERE ID = 'TE07';

--��s���
--UPDATE DrinkMenu SET HotPrice = HotPrice -5;
UPDATE DrinkMenu SET ColdPrice = ColdPrice -5;