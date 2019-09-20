## 函式 (Function)

> 將常常重複使用的程式碼打包成函式可以更方便的維護程式。

- function

  > 需要建立物件後才能呼叫 function，並且必須指定資料型態並回傳數值。

  ```csharp
  class Program{
    // 函式為 int 型態，需要傳入兩個 int 變數 x 與 y
    int add (int x, int y){
      // 函式回傳 x+ y的值
      return x+y;
    }
    
    static void Main(string[] args){
      // 建立物件
      Program p = new Program();
      // 呼叫函式
      int cnt = p.add(1, 2);
      Console.WriteLine(cnt);
      // output: 3
    }
  }
  ```

- static

  > 靜態可以讓函式在程式執行時就分配記憶體存在，不需要先建立物件再呼叫他。

  ```csharp
  class Program{
    static int add(int x, int y){
      return x + y;
    }
    static void Main(string[] args){
      Console.WriteLine(add(1,2));
      // output: 3
    }
  }
  ```

- void

  > void 函式可以不帶有回傳值。

  ```csharp
  class Program{
    void add(int x, int y){
      Console.WriteLine(x + y);
    }
    static void Main(string[] args){
      Program p = new Program();
      p.add(1, 2);
      // output: 3
    }
}
  ```
  

### 多載

> 同名函式有不同的引入參數執行不同的動作。
>
> 以相同功能處理不同參數時為主要使用情境。
>
> *~~幫助命名困難症~~*

```csharp
static void Main(string[] args)
{
    castMagic(5);

    castMagic(5, "暴風雪");
}

static void castMagic(int lv)
{
    Console.WriteLine($"玩家施放了 {lv} 級火球術，效果十分顯著。");
}

static void castMagic(int lv, string kind)
{
    Console.WriteLine($"玩家施放了 {lv} 級{kind}，效果十分顯著");
}
```

![Image201906161958](D:\Respository\myNotes\CSharp\assets\Image201906161958.png)



