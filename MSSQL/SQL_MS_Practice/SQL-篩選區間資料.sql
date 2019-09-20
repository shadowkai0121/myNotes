--套餐代號給錯了，請嘗試更新Meal
--統一給五碼

--SELECT M.MealID FROM Meal M;
--分割字串 substring(欄位,起始位置,長度)
--SELECT SUBSTRING(M.MealID,1,1),SUBSTRING(M.MealID,2,3) FROM Meal M;
--增加一個零
--SELECT MealID, SUBSTRING(M.MealID,1,1)+ '0'+SUBSTRING(M.MealID,2,3) FROM Meal M;
--Update
--UPDATE Meal SET MealID = SUBSTRING(MealID,1,1)+ '0'+SUBSTRING(MealID,2,3);
--SELECT MealID FROM Meal M;


--套餐代號給錯了，請嘗試更新Daily
--M開頭的才是套餐
--LIKE 'M%' 模糊查詢 只要開頭是M就可以
--SELECT * FROM Daily d WHERE d.ItemID LIKE 'M%';

--UPDATE Daily
--SET ItemID = SUBSTRING(itemID,1,1)+ '0'+SUBSTRING(itemID,2,3)
--WHERE ItemID LIKE 'M%';

--SELECT ItemID FROM Daily d;


--哪一種口味的漢堡單點時賣得最好 牛? 豬? 魚?
--SELECT e.EntreeID, e.EntreeFlavor FROM Entree e 
--WHERE e.EntreeClass = 'burgers';
--SELECT d.ItemID, d.ItemName, d.ToTalAmt FROM Daily d 

--SELECT e.EntreeFlavor, SUM(d.ToTalAmt)
--FROM Daily d LEFT JOIN Entree e ON D.ItemID = e.EntreeID
--WHERE D.ItemID LIKE 'E%' AND e.EntreeClass = 'Burgers'
--GROUP BY e.EntreeFlavor;

--顯示系統當月的交易資料
--當月資料
--SELECT * FROM Daily d WHERE d.OrderDate BETWEEN '20180301' AND '20180331';
--SELECT * FROM Daily d WHERE SUBSTRING(D.OrderDate,5,2) = '03' ;
--SELECT * FROM Daily d 
--WHERE DATEPART(MONTH,d.OrderDate) = DATEPART(MONTH, GETDATE());


--統計1/1~3/31、4/1~6/30、7/1~9/31、10/1~12/31 區間交易總額
--SELECT
--	CASE
--		WHEN d.OrderDate BETWEEN '20180101' AND '20180331' THEN 'Q1' 
--		WHEN d.OrderDate BETWEEN '20180401' AND '20180630' THEN 'Q2' 
--		WHEN d.OrderDate BETWEEN '20180701' AND '20180930' THEN 'Q3' 
--		WHEN d.OrderDate BETWEEN '20181001' AND '20181231' THEN 'Q4' 
--	END,
--	SUM(d.ToTalAmt)
--FROM Daily d
--GROUP BY 
--	CASE
--		WHEN d.OrderDate BETWEEN '20180101' AND '20180331' THEN 'Q1' 
--		WHEN d.OrderDate BETWEEN '20180401' AND '20180630' THEN 'Q2' 
--		WHEN d.OrderDate BETWEEN '20180701' AND '20180930' THEN 'Q3' 
--		WHEN d.OrderDate BETWEEN '20181001' AND '20181231' THEN 'Q4' 
--	END


--薯條是白天賣得好還是晚上賣得好?
--SELECT * FROM Daily d;
--SELECT * FROM Entree e 
--WHERE e.EntreeClass = 'FrenchFries';

--用replace處理:、SUBSRING處理長度
--SELECT SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4), D.ToTalAmt 
--FROM Daily d 
--LEFT JOIN Entree e ON d.ItemID = e.EntreeID
--WHERE e.EntreeClass = 'FrenchFries';

SELECT 
	CASE
		--WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
		--		BETWEEN '1030' AND '1800' THEN '白天'
		WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
				BETWEEN '1800' AND '2400' THEN '晚上'
		--1800~2400以外的時段都叫白天
		ELSE '白天'
	END,
	SUM(d.ToTalAmt)
FROM Daily d
LEFT JOIN Entree e ON d.ItemID = e.EntreeID
WHERE e.EntreeClass = 'FrenchFries'
GROUP BY 
	CASE
		WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
				BETWEEN '1800' AND '2400' THEN '晚上'
		ELSE '白天'
	END;