USE AdventureWorks2014
GO

--�N���~��ƪ��A�Ҧ����~�W�٫��r�������j�g�^��r�� (UPPER)
--SELECT UPPER(NAME) FROM Production.Product;	
--�@��Ƥ��ΡA��Ʈw���i��Ϥ��j�p�g

--�N���~��ƪ��A�Ҧ����~�W�٫��r�������p�g�^��r�� (LOWER)
--SELECT LOWER(NAME) FROM Production.Product;	

--���~���v��ƪ��̫K�y�����~������ (MIN) 2.29
--SELECT MIN(ListPrice) FROM Production.ProductListPriceHistory plph;

--�k���~��ƪ��̶Q�����~������ (MAX) 3578.27
--SELECT MAX(ListPrice) FROM Production.Product p;

-- ���~��ƪ��A�@���X�����~? (COUNT) 504
--SELECT COUNT(DISTINCT Name) FROM Production.Product p;

-- 4�����u���������~�O�h�� (AVG) 20.7287
--SELECT AVG(rate) AS avgrate FROM HumanResources.EmployeePayHistory eph 
--WHERE eph.BusinessEntityID = 4;

-- ���~�w�s��ƪ��A4�����~�w�s�q�`�M�O�h�� (SUM) 1322
--SELECT SUM(pi.Quantity) AS totalQuantity FROM Production.ProductInventory pi
--WHERE pi.ProductID = 4;

-- ���ʭq���`���B�b15000��20000������ (BETWEEN) nothing
--SELECT * FROM Purchasing.PurchaseOrderHeader poh
--WHERE poh.TotalDue BETWEEN 15000 AND 20000;

-- �ϥ� TOP ��k��X ���ʭq���`���B�� �̶Q ������ 
--SELECT TOP(1) poh.TotalDue FROM Purchasing.PurchaseOrderHeader poh
--ORDER BY poh.TotalDue DESC;
 
-- �ϥ� TOP ��k��X ���ʭq���`���B �̫K�y ������ 
--SELECT TOP(1) poh.TotalDue FROM Purchasing.PurchaseOrderHeader poh
--ORDER BY poh.TotalDue asc;

-- ���~�w�s��ƪ��A�̷� ProductID �έp�`�M (group by)
--SELECT ProductID,SUM(quantity) FROM Production.ProductInventory
--GROUP BY ProductID;



--���hselect
--SELECT * FROM Production.Product p 
--WHERE p.ProductID IN (
--SELECT pi.Quantity FROM Production.ProductInventory pi
--WHERE p.ProductID = 710);



-- ���~�w�s��ƪ��A�̷� ProductID �έp�`�M��A��X�w�s�`�M�j�� 1800 �����~
--(having)
--SELECT ProductID,SUM(quantity) FROM Production.ProductInventory
--GROUP BY ProductID HAVING SUM(Quantity) > 1800;

-- ���@�ӫȤ�(CustomerID)�U�L�̦h�q��? �̦h�q�檺�Ȥ�Ƴ̫e��

--SELECT CustomerID, COUNT(*) AS OrderCNT 
--FROM Sales.SalesOrderHeader soh
--GROUP BY soh.CustomerID ORDER BY COUNT(*) desc;

--���customerID��q��ƶq count(SalesOrderID)
--�HCustomerID�@�s�� �έq��ƶq����Ƨ�


-- 43659 �q��q�ʪ����~�W�٬O����?
--��X�ݭn�����
--SELECT sod.SalesOrderID,sod.SalesOrderDetailID,sod.ProductID 
--FROM Sales.SalesOrderDetail sod 
--WHERE sod.SalesOrderID = 43659;

--SELECT p.ProductID,Name FROM Production.Product p;

--�H�b�@�_
--SELECT p.Name, sod.SalesOrderID, sod.SalesOrderDetailID, sod.ProductID 
--FROM Sales.SalesOrderDetail sod
----inner left right full cross
--JOIN Production.Product p ON sod.ProductID = p.ProductID
--WHERE sod.SalesOrderID = 43659 ORDER BY Name;