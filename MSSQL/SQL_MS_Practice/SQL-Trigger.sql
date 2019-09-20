--trigger 監控某個資料表的某個資料列
--有異常時做出反應

--CREATE TABLE LogTable (
--	DataType VARCHAR(10),
--	ItemID VARCHAR(10),
--	Price INT,
--	LogDateTime DATETIME,
--);

--SELECT * FROM LogTable lt;

--Create Trigger TriggerName ON TableName
CREATE TRIGGER trUpdateDaily ON Daily 
--在update發生之後做啟動
AFTER UPDATE AS --開關
BEGIN 
	-- 放我們要執行的程式碼
	-- 目標：紀錄 Daily 資料表更新前和更新後的資料寫入到LogTable
	-- 針對ItemID & Price作紀錄
	-- 幾點幾分誰對這個欄位做甚麼更動

	-- 宣告變數
	-- DECLARE @name datatype
	DECLARE @pID VARCHAR(10); -- ItemID
	DECLARE @pTot INT;     -- TotalAmt

	-- 設值給@pID
	SELECT @pID = ItemID, @pTot = TotalAmt FROM DELETED;  -- Update 前
	-- 更新前標記DELETE 紀錄itemID、TotalAmt、SYSDATETIME
	INSERT INTO LogTable (DataType, ItemID, Price, LogDateTime)
	VALUES ('DELETED', @pID, @pTot, SYSDATETIME());

	SELECT @pID = ItemID, @pTot = TotalAmt FROM INSERTED; -- Update 後
	INSERT INTO LogTable (DataType, ItemID, Price, LogDateTime)
	VALUES ('INSERTED', @pID, @pTot, SYSDATETIME());

END