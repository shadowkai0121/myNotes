--��sDAILY�`���B
--SELECT * FROM Daily d;
--UPDATE Daily SET ToTalAmt = OrderNum * SalePrice;

--���oMealGroup�����t
--SELECT mg.GroupID, mg.ItemID FROM MealGroup mg WHERE mg.GroupID = 'G0002';
--SELECT d.DrinkID, d.SalePrice FROM Drink d;

--SELECT mg.GroupID, mg.ItemID FROM MealGroup mg
--LEFT JOIN Drink d ON mg.ItemID = D.DrinkID
--WHERE mg.GroupID = 'G0002';

--�M�\���t�u���\33�A�W�L�ɮt��
--SELECT mg.GroupID, mg.ItemID, 
--d.DrinkName, d.DrinkSize, D.SalePrice, (d.SalePrice - 33) diffprice, 
--IIF (D.SalePrice - 33 < 0, 0, D.SalePrice) FinalPrice
--FROM MealGroup mg
--LEFT JOIN Drink d ON mg.ItemID = D.DrinkID
--WHERE mg.GroupID = 'G0002';

--�qdrink��ƪ��smealgroup���
--UPDATE MealGroup SET AddPrice = IIF(SalePrice < 33, 0, SalePrice -33)
--FROM Drink 
--WHERE MealGroup.GroupID = 'G0002'
--AND MealGroup.ItemID = DrinkID;

SELECT * FROM MealGroup mg;