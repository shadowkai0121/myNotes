-- ��sDAILY���`���B
SELECT * FROM Daily d ;
UPDATE Daily SET ToTalAmt = OrderNum * SalePrice;

-- ���oMealGroup�����t AddPrice
SELECT mg.GroupID, mg.ItemID FROM MealGroup mg WHERE mg.GroupID = 'G0002';
SELECT d.DrinkID, d.SalePrice FROM Drink d;

-- ��X�M�\������A���ǻݭn�W�[
SELECT mg.GroupID, mg.ItemID, d.DrinkName,d.DrinkSize, d.SalePrice,
       (d.SalePrice - 33) diffPrice,
	   -- iif ( �P�_���� , ��P�_���󬰯u , ��P�_���󬰰� )
	   IIF((d.SalePrice - 33) < 0,0,(d.SalePrice - 33)) finalPrice
FROM MealGroup mg 
LEFT JOIN Drink d ON mg.ItemID = d.DrinkID
WHERE mg.GroupID = 'G0002';

--��sMealGroup�����t���A�qDrink��ƪ��
UPDATE MealGroup SET AddPrice = IIF((d.SalePrice - 33) < 0,0,(d.SalePrice - 33)) 
FROM Drink d
WHERE MealGroup.GroupID = 'G0002' 
AND MealGroup.ItemID = D.DrinkID;

--�d�߻��t�O�_��sOK
SELECT * FROM MealGroup WHERE GroupID = 'G0002';