--�M�\�N�������F�A�й��է�sMeal
--�Τ@�����X

--SELECT M.MealID FROM Meal M;
--���Φr�� substring(���,�_�l��m,����)
--SELECT SUBSTRING(M.MealID,1,1),SUBSTRING(M.MealID,2,3) FROM Meal M;
--�W�[�@�ӹs
--SELECT MealID, SUBSTRING(M.MealID,1,1)+ '0'+SUBSTRING(M.MealID,2,3) FROM Meal M;
--Update
--UPDATE Meal SET MealID = SUBSTRING(MealID,1,1)+ '0'+SUBSTRING(MealID,2,3);
--SELECT MealID FROM Meal M;


--�M�\�N�������F�A�й��է�sDaily
--M�}�Y���~�O�M�\
--LIKE 'M%' �ҽk�d�� �u�n�}�Y�OM�N�i�H
--SELECT * FROM Daily d WHERE d.ItemID LIKE 'M%';

--UPDATE Daily
--SET ItemID = SUBSTRING(itemID,1,1)+ '0'+SUBSTRING(itemID,2,3)
--WHERE ItemID LIKE 'M%';

--SELECT ItemID FROM Daily d;


--���@�ؤf�����~�����I�ɽ�o�̦n ��? ��? ��?
--SELECT e.EntreeID, e.EntreeFlavor FROM Entree e 
--WHERE e.EntreeClass = 'burgers';
--SELECT d.ItemID, d.ItemName, d.ToTalAmt FROM Daily d 

--SELECT e.EntreeFlavor, SUM(d.ToTalAmt)
--FROM Daily d LEFT JOIN Entree e ON D.ItemID = e.EntreeID
--WHERE D.ItemID LIKE 'E%' AND e.EntreeClass = 'Burgers'
--GROUP BY e.EntreeFlavor;

--��ܨt�η�몺������
--�����
--SELECT * FROM Daily d WHERE d.OrderDate BETWEEN '20180301' AND '20180331';
--SELECT * FROM Daily d WHERE SUBSTRING(D.OrderDate,5,2) = '03' ;
--SELECT * FROM Daily d 
--WHERE DATEPART(MONTH,d.OrderDate) = DATEPART(MONTH, GETDATE());


--�έp1/1~3/31�B4/1~6/30�B7/1~9/31�B10/1~12/31 �϶�����`�B
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


--�����O�դѽ�o�n�٬O�ߤW��o�n?
--SELECT * FROM Daily d;
--SELECT * FROM Entree e 
--WHERE e.EntreeClass = 'FrenchFries';

--��replace�B�z:�BSUBSRING�B�z����
--SELECT SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4), D.ToTalAmt 
--FROM Daily d 
--LEFT JOIN Entree e ON d.ItemID = e.EntreeID
--WHERE e.EntreeClass = 'FrenchFries';

SELECT 
	CASE
		--WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
		--		BETWEEN '1030' AND '1800' THEN '�դ�'
		WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
				BETWEEN '1800' AND '2400' THEN '�ߤW'
		--1800~2400�H�~���ɬq���s�դ�
		ELSE '�դ�'
	END,
	SUM(d.ToTalAmt)
FROM Daily d
LEFT JOIN Entree e ON d.ItemID = e.EntreeID
WHERE e.EntreeClass = 'FrenchFries'
GROUP BY 
	CASE
		WHEN  SUBSTRING(REPLACE(d.OrderTime,':',''), 1, 4) 
				BETWEEN '1800' AND '2400' THEN '�ߤW'
		ELSE '�դ�'
	END;