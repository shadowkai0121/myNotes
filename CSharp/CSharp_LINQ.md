## [LINQ](<https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries>)

> 提供程式語言內部查詢資料功能的語法。

### 基本操作

> LINQ 使用var作為儲存的變數型別較為方便。

- 查詢

  ```csharp
  var Query = from 變數 in 資料來源
  	select 變數;
  ```

- 條件查詢

  ```csharp
  var Query = from 變數 in 資料來源
  	where 條件式
  	select 變數;
  
  // Example
  var Query = from product in db.Products
  	where product.Id == 1
    select product;
  // output: ID 為 1 的 Product物件
  ```

- 排序

  ```csharp
  var Query = from 變數 in 資料來源
  	orderby 變數.欄位名稱 ascending/descending
    select 變數;
  ```

- 連結

  ```csharp
  var Query = from 變數一 in 資料來源;
  	// 兩個資料表必須有相同的欄位
  	join 變數二 in 資料來源 on 變數一.欄位 equals 變數二.欄位
  	select new [可以指定新表單型別]{新欄位 = 來源變數.欄位}
  
  // Example
  var Query = from product in db.Products
  	join vendor in db.Vendors on product.VendorName eaquals vendor.VendorName
  	select new {ProductName = product.ProductName, VendorName = vendor.VendorName};
  ```

