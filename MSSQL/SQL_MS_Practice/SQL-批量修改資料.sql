--穝DAILY羆肂
--SELECT * FROM Daily d;
--UPDATE Daily SET ToTalAmt = OrderNum * SalePrice;

--眔MealGroup基畉
--SELECT mg.GroupID, mg.ItemID FROM MealGroup mg WHERE mg.GroupID = 'G0002';
--SELECT d.DrinkID, d.SalePrice FROM Drink d;

--SELECT mg.GroupID, mg.ItemID FROM MealGroup mg
--LEFT JOIN Drink d ON mg.ItemID = D.DrinkID
--WHERE mg.GroupID = 'G0002';

--甅繺基畉す砛33禬筁干畉基
--SELECT mg.GroupID, mg.ItemID, 
--d.DrinkName, d.DrinkSize, D.SalePrice, (d.SalePrice - 33) diffprice, 
--IIF (D.SalePrice - 33 < 0, 0, D.SalePrice) FinalPrice
--FROM MealGroup mg
--LEFT JOIN Drink d ON mg.ItemID = D.DrinkID
--WHERE mg.GroupID = 'G0002';

--眖drink戈穝mealgroup逆
--UPDATE MealGroup SET AddPrice = IIF(SalePrice < 33, 0, SalePrice -33)
--FROM Drink 
--WHERE MealGroup.GroupID = 'G0002'
--AND MealGroup.ItemID = DrinkID;

SELECT * FROM MealGroup mg;