--DROP TABLE LogTable;
--CREATE TABLE LogTable(
--	DataType VARCHAR(10),
--	seq VARCHAR(1),
--	ItemID VARCHAR(10),
--	Price INT,
--	UPDATEID VARCHAR(10),
--	LogDateTime DATETIME
--);
--SELECT * FROM LogTable lt;

DROP TRIGGER trUpdateDaily;
CREATE TRIGGER trUpdateDaily ON Daily AFTER UPDATE AS
BEGIN
	-- ��ڭ̭n���檺�{���X �ؼСG�N Daily ��ƪ� ��s�e �M ��s�� ����Ƽg�J�� LogTable
	DECLARE @pSEQ VARCHAR(10); 
	DECLARE @pID VARCHAR(10); -- ItemID
	DECLARE @pTot INT;        -- TotalAmt

	SELECT @pSEQ=Seq,  @pID = ItemID, @pTot = ToTalAmt FROM DELETED; -- update�e
	INSERT INTO LogTable (DataType, SEQ,ItemID, Price,UPDATEID, LogDateTime)
	VALUES ('DELETED', @pSEQ , @pID, @pTot, 'Eric', SYSDATETIME());

	SELECT @pSEQ=Seq,  @pID = ItemID, @pTot= ToTalAmt FROM INSERTED;-- update��
	INSERT INTO LogTable(DataType, SEQ,ItemID, Price,UPDATEID, LogDateTime)
	VALUES ('INSERTED', @pSEQ , @pID, @pTot, 'Eric', SYSDATETIME());
END;
-- ����trigger�O�_���\
UPDATE Daily SET ToTalAmt = 10000 WHERE Seq = 1;
SELECT * FROM Daily d WHERE d.Seq = 1;
SELECT * FROM LogTable lt WHERE Seq = 1;