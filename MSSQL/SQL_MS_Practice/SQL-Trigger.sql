--trigger �ʱ��Y�Ӹ�ƪ��Y�Ӹ�ƦC
--�����`�ɰ��X����

--CREATE TABLE LogTable (
--	DataType VARCHAR(10),
--	ItemID VARCHAR(10),
--	Price INT,
--	LogDateTime DATETIME,
--);

--SELECT * FROM LogTable lt;

--Create Trigger TriggerName ON TableName
CREATE TRIGGER trUpdateDaily ON Daily 
--�bupdate�o�ͤ��ᰵ�Ұ�
AFTER UPDATE AS --�}��
BEGIN 
	-- ��ڭ̭n���檺�{���X
	-- �ؼСG���� Daily ��ƪ��s�e�M��s�᪺��Ƽg�J��LogTable
	-- �w��ItemID & Price�@����
	-- �X�I�X���ֹ�o����찵�ƻ���

	-- �ŧi�ܼ�
	-- DECLARE @name datatype
	DECLARE @pID VARCHAR(10); -- ItemID
	DECLARE @pTot INT;     -- TotalAmt

	-- �]�ȵ�@pID
	SELECT @pID = ItemID, @pTot = TotalAmt FROM DELETED;  -- Update �e
	-- ��s�e�аODELETE ����itemID�BTotalAmt�BSYSDATETIME
	INSERT INTO LogTable (DataType, ItemID, Price, LogDateTime)
	VALUES ('DELETED', @pID, @pTot, SYSDATETIME());

	SELECT @pID = ItemID, @pTot = TotalAmt FROM INSERTED; -- Update ��
	INSERT INTO LogTable (DataType, ItemID, Price, LogDateTime)
	VALUES ('INSERTED', @pID, @pTot, SYSDATETIME());

END