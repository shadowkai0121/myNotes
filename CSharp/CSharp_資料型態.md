## 數值型態

> C#的數值有各自的極限值，需要注意數值溢位的狀況。

### 整數

- [整數型別表](<https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/integral-types-table>)

### 浮點數

- [浮點數型別表](<https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/floating-point-types-table>)
- 數字後需要加上對應字母
  - float = f
  - double = d
  - decimal = m

### 隱含數值轉換

> 數值型態可以隱含轉換成包含自己的型態。
>
> Ex：浮點數可以包含整數，所以int可以隱含轉換為float、decimal等型態。

- [隱含數值轉換表](<https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/implicit-numeric-conversions-table>)

## 資料結構

- Array

  > 陣列能夠將多個變數儲存在一段連續的記憶體當中隨時讀取，因為連續的關係，必須在一開始就宣告陣列的長度。
  >
  > 優點：面對頻繁讀取時，因為索引值直接對應資料所以效能較好。
  >
  > 缺點：無法彈性改變陣列大小

  ```csharp
  int[] nums = new int[10];
  int[] nums = { 1, 2, 3};
  ```

  

- List

	> 透過節點的概念讓資料能被連結起來，必須宣告型別
	>
	> 優點：空間彈性、增刪快速。
	>
	> 缺點：需要額外的記憶體紀錄索引值，記憶體占用較大。

	```csharp
	list<int> nums = new list<int>;
	nums.add(1);
	nums.add(2);
	```

- Dictionary

	> 使用自訂的索引建綁定資料

	```csharp
	string[] strs = { "雞蛋", "牛奶", "麵包" };
	int[] nums = { 10, 20, 30 };
	Dictionary<string, int> dc = new Dictionary<string, int>();
	for (int i = 0; i < strs.Length; i++)
	{
	    dc.Add(strs[i], nums[i]);
	}
	for (int i = 0; i < strs.Length; i++)
	{
	    Console.WriteLine($"key={strs[i]}, value={dc[strs[i]]}");
	}
	// output
	// key=雞蛋, value=10
	// key=牛奶, value=20
	// key=麵包, value=30
	```

- ArrayList

	> 大部分的時候都不如List，唯一的優點大概是每個元素都視為物件，所以可以將不同型別的物件放入ArrayList內

- LinkedList

	> 功能與List一樣，但是LinkedList在處理頻繁插入的效能上比List好

- Queue、Stack

	> 實作先進先出或後進先出的物件

	```csharp
	Queue<int> nums = new Queue<int>();
	nums.Enqueue(1);
	nums.Enqueue(2);
	nums.Enqueue(3);
	for (int i = 0; i < nums.Count; i++)
	{
		Console.WriteLine($"item = {nums.Dequeue()} | count = {nums.Count}");
	}
	// output: 
	// item = 1 | count = 2
	// item = 2 | count = 1
	```

	