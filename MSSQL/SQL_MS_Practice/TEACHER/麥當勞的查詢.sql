-- �M�\�N�������F�A�й��է�sMeal
SELECT * FROM Meal M;
SELECT M.MealID, SUBSTRING(M.MealID,1,1), SUBSTRING(M.MealID,2,3) FROM Meal M;
SELECT M.MealID, SUBSTRING(M.MealID,1,1) + '0' + SUBSTRING(M.MealID,2,3) FROM Meal M;
UPDATE Meal SET MealID = SUBSTRING(MealID,1,1) + '0' + SUBSTRING(MealID,2,3);

-- �M�\�N�������F�A�й��է�sDaily
SELECT * FROM Daily d WHERE d.ItemID LIKE 'M%' 
UPDATE Daily SET ItemID = SUBSTRING(ItemID,1,1) + '0' + SUBSTRING(ItemID,2,3) WHERE ItemID LIKE 'M%' 

-- ���@�ؤf���� �~�� ��o�̦n (����) ���I�����p�U �O �� �٬O �� �٬O ��?
SELECT e.EntreeID, e.EntreeFlavor FROM Entree e WHERE e.EntreeClass = 'Burgers';
SELECT d.ItemID, d.ItemName, d.ToTalAmt FROM Daily d;

SELECT e.EntreeFlavor, SUM(d.ToTalAmt)
FROM Daily d LEFT JOIN Entree e ON D.ItemID = e.EntreeID
WHERE D.ItemID LIKE 'E%' AND e.EntreeClass = 'Burgers'
GROUP BY e.EntreeFlavor;

-- ��ܨt�η�몺������
SELECT * FROM Daily d WHERE d.OrderDate BETWEEN '20180301' AND '20180331';
SELECT * FROM Daily d WHERE SUBSTRING(d.OrderDate,5,2) = '03';
SELECT *, DATEPART(MONTH, d.OrderDate), DATEPART(MONTH, GETDATE()) FROM Daily d WHERE DATEPART(MONTH, d.OrderDate) = DATEPART(MONTH, GETDATE());

-- �έp�X1/1-3/31�B4/1-6/30�B7/1-9/30�B10/1-12/31 �o�ǰ϶�������`���B�O�h��
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

-- ���� �O �դ� (10:30 - 18:00) ��o�n�A�٬O�ߤW (18:00 - 24:00)��o�n  (����)
SELECT * FROM Daily d;
SELECT * FROM Entree e WHERE e.EntreeClass = 'FrenchFries';

-- join��D����
SELECT d.OrderTime, d.ToTalAmt, REPLACE(d.OrderTime,':',''), SUBSTRING(REPLACE(d.OrderTime,':',''),1,4)
FROM Daily d 
LEFT JOIN Entree e ON D.ItemID = E.EntreeID
WHERE e.EntreeClass = 'FrenchFries';

-- ��case���s�աA�p�G�u������Ӯɬq�A�|���@�q�ɶ��S���a�� ==> �[�J else 
SELECT 
	CASE
		--WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1030' AND '1800' THEN '�դ�'
		WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1800' AND '2400' THEN '�ߤW'
		ELSE '�դ�'
	END
	,SUM(d.ToTalAmt)
FROM Daily d 
LEFT JOIN Entree e ON D.ItemID = E.EntreeID
WHERE e.EntreeClass = 'FrenchFries'
GROUP BY 	CASE
		--WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1030' AND '1800' THEN '�դ�'
		WHEN SUBSTRING(REPLACE(d.OrderTime,':',''),1,4) BETWEEN '1800' AND '2400' THEN '�ߤW'
		ELSE '�դ�'
	END
