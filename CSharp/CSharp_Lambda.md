## [Lambda](<https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions>)

> Lambda 相當於匿名函式，能夠執行未命名的程式碼區塊。

- 運算

  *~~說是匿名但是還是要命名阿...~~*

  ```csharp
  Func<int,int> square = x => x * x;
  Console.WriteLine(square(5).ToString());
  ```

- 查詢

  ```csharp
  var Query = db.Products
  	.where(w => w.ProductId == 1)
    .OrderBy(w => w.ProductName);
  // output: ProductId 為 1 的Product物件，並以 ProductName 排序。
  ```

  