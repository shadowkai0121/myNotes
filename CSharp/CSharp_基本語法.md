## Hello, World.

- console

	```csharp
	Console.WriteLine("Hello, World.");
	```

## 變數宣告

> C# 是靜態語言，變數宣告的值必須對應型態的關鍵字。

- 字串

	- string

- 數值

	- int
	- float
	- double
	- decimal
	- byte

- 陣列

	> 陣列宣告在資料型別後加上[]做宣告

	```csharp
	// 一維陣列
	int[] num = {1, 2, 3};
	// 2*10的二維陣列
	int[,] num = new int[2,10]
	```

## 計算

> 必須是相同型別或者能夠隱含轉換的型別才能做計算。

- 相同型別

	```csharp
	string str1 = "1";
	string str2 = "2";
	Console.WriteLine(str1 + str2);
	// output: 12
	```

- 隱含型別轉換

	```csharp
	int iNum = 1;
	float fNum = 1.1f;
	Console.WriteLine(iNum + fNum);
	// output: 2.1
	// int 能夠隱含轉換成為 float
	```

- [運算子](<https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/>)
	- 有趣的寫法

		- ??

			```csharp
			// int? = 可為 null 的數值 = Nullable<int>
			int? x = null;
			// 當 x 為 null 時回傳-1
			int y = x ?? -1;
			Console.WriteLine(y);
			// output: -1
			```

		- condition ? x : y

			```csharp
			string question = "你好";
			string answer = question == "你好嗎" ? "我很好" : "再說一次";
			Console.WriteLine(answer);
			// output: 再說一次
			// 等同於以下的 if
			if (question == "你好嗎")
			{
			    answer = "我很好";
			}
			else
			{
			    answer = "再說一次"
			}
			Console.WriteLine(answer);
			    
			// 可以不停地向右延長
			string question = "你好";
			string answer = question == "你好嗎" ? "我很好" : question == "你好" ? "顆顆" : "再說一次";
			Console.WriteLine(answer);
			// output: 顆顆
			```

			