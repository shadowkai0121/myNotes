## SQL 基本語法

### 查詢

- 選取

  ```MSsql
  SELECT DISTINCT 欄位 FROM 資料表 WHERE 條件; -- DISTINCT為不重複的欄位
  ORDER BY 欄位 DESC/ASC -- 依照指定欄位排序(反/順)
  
  -- 尋找空白資料
  SELECT 欄位 FROM 資料表 WHERE (欄位 = '' OR 欄位 IS NULL); 
  
  -- 取得所有資料表名稱
  SELECT * FROM  INFORMATION_SCHEMA.TABLES;
  
  -- 取得資料表所有欄位名稱
  SELECT * FROM  INFORMATION_SCHEMA.COLUMNS;
  ```

- 大小寫轉換

  ```mssql
  SELECT UPPER(欄位) FROM 資料表; -- 轉大小
  SELECT LOWER(欄位) FROM 資料表; -- 轉小寫
  ```

- 條件篩選

  > 將選取欄位以A欄位做群組然後選出符合條件(HAVING)的資料行

  ```MSsql
  SELECT 欄位A, 函數(欄位B) AS 新名稱 FROM 資料表 GROUP BY 欄位A 
  HAVING 函數(欄位B) > 條件; 
  ```

- 計算

  ```mssql
  SELECT COUNT(DISTINCT 欄位) FROM 資料表; -- 計算目標欄位有幾個
  SELECT AVG(欄位) AS 計算後的值名稱 FROM 資料表; -- 計算目標欄位值的平均值
  SELECT SUM(欄位) AS 新欄位 FROM 資料表; -- 欄位值的總和
  ```

- 最大最小值

  ```mssql
  SELECT MAX(欄位) FROM 資料表;
  SELECT MIN(欄位) FROM 資料表;
  SELECT TOP(第幾筆) 欄位 FROM 資料表 ORDER BY 欄位 DESC/ASC; -- 選取前幾筆欄位
  ```

- 雙層SELECT

  ```mssql
  SELECT 欄位A FROM 資料表A WHERE 欄位B 
  IN (SELECT 欄位C FROM 資料表B WHERE 欄位B條件
  ```

### 新增

- 資料庫

  ```mssql
  CREATE DATABASE 資料庫名稱;
  ```

- 資料表

  ```mssql
  CREATE TABLE 資料表名稱
  (
    	主鍵 INT IDENTITY(1,1) PRIMARY KEY,
      欄位A A的資料型態 可否空白,
      欄位B B的資料型態 可否空白
  )
  ```

- TRIGGER

  > 名稱前加上tr方便識別

  ```mssql
  CREATE TRIGGER tr名稱 ON 資料表名稱
  AFTER 動作 AS 
  BEGIN
      採取的程式碼
  END
  ```

- PROCEDURE

  > 名稱前加上sp方便識別

  ```mssql
  CREATE PROCEDURE sp名稱 AS 採取的程式碼
  ```

### 修改

- 資料庫

  - 修改資料庫名字

    ```mssql
    ALTER DATABASE 資料庫名稱 MODIFY NAME = 新名稱;
    ```

  - 刪除資料庫

    ```mssql
    DROP DATABASE 資料庫名稱
    ```

- 資料行
  - 插入新資料行

  	```mssql
  	INSERT INTO 目標資料表 (資料表.欄位1, 欄位2) VALUES (來源欄位1, 欄位2); //完整
  	```

  - 修改資料行

  	```mssql
  	UPDATE 資料表 SET 欄位 = 值 WHERE 條件;
  	```

  - 刪除資料行

  	```mssql
  	DELETE FROM 資料表 WHERE 條件 --刪除資料行
  	```

- 資料表

  - 修改欄位資料型態

    ```mssql
    ALTER TABLE 資料表 ALTER COLUMN 欄位名稱 資料型態 可否空白;
    ```

  - 刪除欄位

    ```mssql
    ALTER TABLE 資料表 DROP COLUMN 欄位名稱
    ```

  - 清空資料表

    ```sql
    DELETE FROM 資料表名稱 -- 流水號不會被歸零，效能較差
    TRUNCATE TABLE 資料表名稱 --流水號的PK會一同被歸零
    ```

  - 移除資料表

    ```ms
    DROP TABLE 資料表名稱
    ```

### 合併資料表

- JOIN

  > 臨時性查詢使用。

  ```mssql
  SELECT 欄位A, 欄位B FROM 資料表A 
  JOIN 資料表B ON 資料表A.欄位A = 資料表B.欄位A; -- 以雙方都有的欄位做黏合
  ```

- VIEW

  > 頻繁查詢的項目可以建立VIEW方便使用。
  >
  > 名稱前使用v方便辨識。

  ```mssql
  CREATE VIEW 命名空間.v名稱 AS SELECT 欄位A, 欄位B FROM 資料表A 
  JOIN 資料表B ON 資料表A.欄位A = 資料表B.欄位A;
  ```

  