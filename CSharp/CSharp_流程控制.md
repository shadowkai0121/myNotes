## 流程控制

### 迴圈

- do...while

  > 無論如何會先執行一次do內的程式碼，之後判斷while條件是否成立。

  ```csharp
  bool flag = false;
  do
  {
  	Console.WriteLine(flag.ToString());
  } while (flag);
  
  // output: false
  ```

- while

  > while條件判斷為true時進入迴圈，當while條件不成立時離開迴圈。

  ```csharp
  int cnt = 0;
  while(cnt < 5)
  {
  	Console.Write(cnt);
  	cnt++;
  }
  // output: 01234
  ```

- for(起始值; 判斷式; 遞增)

  ```csharp
  for (int i = 0; i < 3; i++)
  {
  	Console.Write(i);
  }
  // output: 012
  ```

- foreach

  > 取出陣列元素或者實作過IEnumerable的執行個體(List、ArrayList...)

  ```csharp
  int[] num = { 1, 2, 3 };
  foreach (var item in num)
  {
  	Console.Write(item);
  }
  // output: 123
  ```

### 條件判斷

- if...else if...else

  > 當判斷式成立時執行程式碼，如果放了一堆if上去程式會每一段都進去判斷式查看，所以需要else if與else。

  ```csharp
  string text = Console.ReadLine();
  if (text == "hi")
  {
  	Console.WriteLine("hello");
  }
  else if (text == "yo")
  {
  	Console.WriteLine("yoyo");
  }
  else
  {
  	Console.WriteLine("byebye");
  }
  // input: yo
  // output: yoyo
  ```

- switch...case

  > switch的主要是針對會有特定結果的運算式做有點像列舉的判斷，所以case的條件必須是固定值或者字串，不能再做放一次條件判斷，因此有deault可以處理列舉出的case以外的狀況。
  >
  > 並且整個switch是一個程式碼區段，所以case後必須加上break。

  ```csharp
  string text = Console.ReadLine();
  switch (text.Length)
  {
  case 1:
  	Console.WriteLine("你說了一個字");
  	break;
  case 2:
  	Console.WriteLine("你說了兩個字");
  	break;
  default:
  	Console.WriteLine("你話很多");
  	break;
  }
  // input: yooo
  // output: 你話很多
  ```
### 敘述

- break

  > 中斷當前程式碼區塊並執行後續程式

  ```csharp
  for (int i = 0; i < 3; i++)
  {
  	if (i==1)
  	{
  		break;
  	}
  	Console.WriteLine(i);
  }
  
  Console.WriteLine("end");
  // output:
  // 0
  // end
  ```

- continue

  > 迴圈中，中斷當前這次迴圈內容但是繼續接下來的迴圈。

  ```csharp
  for (int i = 0; i < 3; i++)
  {
  	if (i==1)
  	{
  		continue;
  	}
  	Console.WriteLine(i);
  }
  
  Console.WriteLine("end");
  // output:
  // 0
  // 2
  // end
  ```

- return

  > 停止當前執行的函式，可以回傳資料。
  >
  > 在迴圈中的效果等同於break。

  ```csharp
  static void Main(string[] args)
  {
  	int cnt = add(1, 2);
  	Console.WriteLine(cnt);
  }
  static int add(int x, int y)
  {
  	return x + y;
  }
  // output: 3
  ```

  

- goto

  > 程式碼執行階段移動到指定的標籤處。

  ```csharp
              goto tag;
              // 迴圈無法被執行，程式直接執行到tag處
              for (int i = 0; i < 3; i++)
              {
                  Console.WriteLine(i);
              }
          tag:
              Console.WriteLine("end");
  // output: end
  ```

  

### 例外處理

- try...catch

  > 使用try包覆的程式碼當遇到錯誤時，可以透過catch捕捉錯誤訊息再透過catch的程式碼處理或者是用throw回傳錯誤訊息，讓程式繼續維持運作。

  ``` csharp
  int i = 0;
  string s = "測試";
  object obj = s;
  try
  {
  	// obj 裡面是個 string 必然會發生轉換錯誤
  	i = (int)obj;
  }
  catch (Exception e)
  {
  	// 程式依然運作中
    // 透過 catch 取得錯誤訊息 e
  	Console.WriteLine(e);
  }
  // output: System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Int32'.
  ```