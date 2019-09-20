## [亂數](<https://docs.microsoft.com/zh-tw/dotnet/api/system.random?view=netframework-4.8>)

> 必須先建立亂數物件。

```csharp
Random rnd = new Random();
// 取得隨機整數(小於int.MaxValue的整數)
rnd.Next();
// 取得小於指定數字的整數(小於9的整數)
rnd.Next(9);
// 取得指定區間的整數 (5<= num <9)
rnd.Next(5, 9)
```

### 取不重複亂數

- ***~~神~~***方法一

	[出處](<https://social.msdn.microsoft.com/Forums/zh-TW/26d0b310-74ca-4230-99a7-d3aed7bbf644/23563277142133221161-c-random-2009825976199813732535079?forum=233>)

	```csharp
	Random rnd = new Random();
	int amount = 4; // 取四個數
	List<int> data = new List<int>(Enumerable.Range(0, 9)); // 加入0 ~ 9數字
	data = data.OrderBy(o => rnd.Next()).ToList(); // 亂數排序
	for (int i = 0; i < amount; i++)
	{
	    Console.WriteLine(data[i]); // 取出亂數
	}
	// 實際上只用了 3 行(1、3、4)就造好不重複的亂數陣列了。
	```

- 方法二

	```csharp
	Random rnd = new Random();
	List<int> nums = new List<int>(Enumerable.Range(0, 9)); // 數字卡
	int amount = 4; // 取 4 個數字
	int[] data = new int[amount]; // 存放取出的數字
	int temp = 0;
	for (int i = 0; i < amount; i++)
	{
	    temp = rnd.Next(nums.Count); // 亂數取得索引，亂數範圍隨著數字卡數量變動
	    data[i] = nums[temp]; // 將取得數字存入存放區
	    nums.Remove(nums[temp]); // 移除掉這次取得的數字
	}
	```

- 方法三

	```csharp
	Random rnd = new Random(); 
	int amount = 4; // 取得 4 個數字
	int[] data = new int[amount]; 
	
	int i = 0;
	while (i < amount)  
	{
	    data[i] = rnd.Next(10); // 隨機塞一個數到存放區
	    for (int x = 0; x < i; x++) // 在目前已有值得陣列範圍做判斷
	    {
	        if (data[i] == data[x]) // 如果存放區裡面已經有這個數字
	        {
	            i--; 
	            // 迴圈次數不增加 
	            // 繼續取本次索引的值
	        }
	    }
	    i++;
	}
	```

	

