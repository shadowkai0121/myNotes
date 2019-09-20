-- 更新DAILY的總金額
SELECT * FROM Daily d ;
UPDATE Daily SET ToTalAmt = OrderNum * SalePrice;

-- 取得MealGroup的價差 AddPrice
SELECT mg.GroupID, mg.ItemID FROM MealGroup mg WHERE mg.GroupID = 'G0002';
SELECT d.DrinkID, d.SalePrice FROM Drink d;

-- 找出套餐的售價，那些需要增加
SELECT mg.GroupID, mg.ItemID, d.DrinkName,d.DrinkSize, d.SalePrice,
       (d.SalePrice - 33) diffPrice,
	   -- iif ( 判斷條件 , 當判斷條件為真 , 當判斷條件為假 )
	   IIF((d.SalePrice - 33) < 0,0,(d.SalePrice - 33)) finalPrice
FROM MealGroup mg 
LEFT JOIN Drink d ON mg.ItemID = d.DrinkID
WHERE mg.GroupID = 'G0002';

--更新MealGroup的價差欄位，從Drink資料表來
UPDATE MealGroup SET AddPrice = IIF((d.SalePrice - 33) < 0,0,(d.SalePrice - 33)) 
FROM Drink d
WHERE MealGroup.GroupID = 'G0002' 
AND MealGroup.ItemID = D.DrinkID;

--查詢價差是否更新OK
SELECT * FROM MealGroup WHERE GroupID = 'G0002';