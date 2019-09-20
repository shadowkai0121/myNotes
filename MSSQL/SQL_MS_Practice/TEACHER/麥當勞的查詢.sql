-- 套餐代號給錯了，請嘗試更新Meal
SELECT * FROM Meal M;
SELECT M.MealID, SUBSTRING(M.MealID,1,1), SUBSTRING(M.MealID,2,3) FROM Meal M;
SELECT M.MealID, SUBSTRING(M.MealID,1,1) + '0' + SUBSTRING(M.MealID,2,3) FROM Meal M;
UPDATE Meal SET MealID = SUBSTRING(MealID,1,1) + '0' + SUBSTRING(MealID,2,3);

-- 套餐代號給錯了，請嘗試更新Daily
SELECT * FROM Daily d WHERE d.ItemID LIKE 'M%' 
UPDATE Daily SET ItemID = SUBSTRING(ItemID,1,1) + '0' + SUBSTRING(ItemID,2,3) WHERE ItemID LIKE 'M%' 

-- 哪一種口味的 漢堡 賣得最好 (價錢) 單點的情況下 是 牛 還是 雞 還是 魚?
SELECT e.EntreeID, e.EntreeFlavor FROM Entree e WHERE e.EntreeClass = 'Burgers';
SELECT d.ItemID, d.ItemName, d.ToTalAmt FROM Daily d;

SELECT e.EntreeFlavor, SUM(d.ToTalAmt)
FROM Daily d LEFT JOIN Entree e ON D.ItemID = e.EntreeID
WHERE D.ItemID LIKE 'E%' AND e.EntreeClass = 'Burgers'
GROUP BY e.EntreeFlavor;

-- 顯示系統當月的交易資料
SELECT * FROM Daily d WHERE d.OrderDate BETWEEN '20180301' AND '20180331';
SELECT * FROM Daily d WHERE SUBSTRING(d.OrderDate,5,2) = '03';
SELECT *, DATEPART(MONTH, d.OrderDate), DATEPART(MONTH, GETDATE()) FROM Daily d WHERE DATEPART(MONTH, d.OrderDate) = DATEPART(MONTH, GETDATE());

-- 統計出1/1-3/31、4/1-6/30、7/1-9/30、10/1-12/31 這些區間的交易總金額是多少
SELECT 
    CASE 
		WHEN d.OrderDate BETWEEN '20180101' AND '20180331' THEN 'Q1'
		WHEN d.OrderDate BETWEEN '20180401' AND '20180630' THEN 'Q2'
		WHEN d.OrderDate BETWEEN '20180701' AND '20180930' THEN 'Q3'
		WHEN d.OrderDate BETWEEN '20181001' AND '20181231' THEN 'Q4'
	END,
	SUM(d.ToTalAmt)
FROM Daily d
GROUP BY CASE 
		WHEN d.OrderDate BETWEEN '20180101' AND '20180331' THEN 'Q1'
		WHEN d.OrderDate BETWEEN '20180401' AND '20180630' THEN 'Q2'
		WHEN d.OrderDate BETWEEN '20180701' AND '20180930' THEN 'Q3'
		WHEN d.OrderDate BETWEEN '20181001' AND '20181231' THEN 'Q4'
	END

-- 薯條 是 白天 (10:30 - 18:00) 賣得好，還是晚上 (18:00 - 24:00)賣得好  (價錢)
SELECT * FROM Daily d;
SELECT * FROM Entree e WHERE e.EntreeClass = 'FrenchFries';

-- join後挑選資料
SELECT d.OrderTime, d.ToTalAmt, REPLACE(d.OrderTime,':',''), SUBSTRING(REPLACE(d.OrderTime,':',''),1,4)
FROM Daily d 
LEFT JOIN Entree e ON D.ItemID = E.EntreeID
WHERE e.EntreeClass = 'FrenchFries';

-- 用case分群組，如果只有分兩個時段，會有一段時間沒有帶到 ==> 加入 else 
SELECT 
	CASE
		--WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1030' AND '1800' THEN '白天'
		WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1800' AND '2400' THEN '晚上'
		ELSE '白天'
	END
	,SUM(d.ToTalAmt)
FROM Daily d 
LEFT JOIN Entree e ON D.ItemID = E.EntreeID
WHERE e.EntreeClass = 'FrenchFries'
GROUP BY 	CASE
		--WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1030' AND '1800' THEN '白天'
		WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1800' AND '2400' THEN '晚上'
		ELSE '白天'
	END
