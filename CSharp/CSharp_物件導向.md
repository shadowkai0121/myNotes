## 類別

> 物件的藍圖，內容分為屬性及方法。

- [存取權限](<https://docs.microsoft.com/zh-tw/dotnet/csharp/language-reference/keywords/accessibility-levels>)

	> 將資料或方法隱蔽起來，只讓外部存取必要的方法與屬性。

	- public

		> 所有程式都能存取。

	- private

		> 限定所屬類別成員存取。

	- protected

		> 限定所屬類別與繼承類別存取。

- 類別的基本結構

	```csharp
	class Wizzard
	{
	    // 類別的屬性，可以分開設定讀取以及寫入的權限。
	    public int Lv { get; private set; }
	    public string Name { get; private set; }
	    public string Race { get; private set; }
	    // 可直接指定屬性初始值。
	    protected List<string> SkillList = new List<string>() { "火箭術", "冰箭術", "雷電術" };
	
	    // 與類別同名的public函式為建構子。
	    // 在 C# 中如果沒有寫，編譯時會產生預設建構子。
	    public Wizzard(string inputName)
	    {
	        Name = inputName;
	        Race = "人類";
	        Lv = 1;
	
	        Console.WriteLine($"歡迎， {Race} 的巫師－－{inputName}");
	        Console.WriteLine($"目前等級：{Lv}");
	    }
	
	    // 建構子也能多載
	    public Wizzard(string inputName, string inputRace)
	    {
	        Name = inputName;
	        Race = inputRace;
	        Lv = 1;
	
	        Console.WriteLine($"歡迎， {Race} 的巫師－－{inputName}");
	        Console.WriteLine($"目前等級：{Lv}");
	    }
	
	    // 類別方法
	    public void ShowSkillList()
	    {
	        Console.WriteLine("開啟技能列...");
	        Console.WriteLine("目前已習得以下技能：");
	        foreach (var item in SkillList)
	        {
	            Console.WriteLine(item);
	        }
	    }
	    
	    // virtual關鍵字可讓此函式被繼承類別改寫
	    virtual public void CastSkill(string skillName)
		{
	    	Random rnd = new Random();
	    	Console.WriteLine($"{Name} 施放了 {SkillList[rnd.Next(SkillList.Count)]}");
		}
	
	}
	```

- 類別的使用

	```csharp
	static void Main(string[] args)
	{
	    // 建立新物件
	    Wizzard w = new Wizzard("Kai", "不死族");
	    w.ShowSkillList();
	    w.CastSkill("雷電術");
	}
	```

	![Image201906162055](assets\Image201906162055.png)

## 繼承、多型

> 繼承與多形可以安全地擴充程式碼功能，並且重複利用舊的程式碼。

- 類別的繼承與多形

	```csharp
	// 透過: 表達繼承自Wizzard
	class FireWizzard : Wizzard
	{
	    // 建構子後方 base 代表父類別的建構子
	    // 編譯時，優先執行父類別建構子才執行子類別建構子。
	    public FireWizzard(string name, string race) : base(name, race)
	    {
	        // 子類別可以繼承父類別屬性以及方法。
	        SkillList = new List<string>() { "火箭術", "火球術", "隕石術" };
	        Console.WriteLine("目前身分為火焰巫師");
	    }
	
	    // 使用 override 關鍵字可複寫父類別有 virtual 關鍵字的同名方法
	    public override void CastSkill(string skillName)
	    {
	        if (SkillList.Contains(skillName)) 
	        {
	            Console.WriteLine($"{Name} 施放了 {skillName}");
	        }
	    }
	}
	
	```

- 使用

	```csharp
	static void Main(string[] args)
	{
	    // 建立新物件
	    FireWizzard w = new FireWizzard("Kai", "不死族");
	    w.ShowSkillList();
	    w.CastSkill("隕石術");
	}
	```

	![](assets\Image201906162131.png)

### 抽象類別

> 不實作的類別，主要提供繼承類別使用。

```csharp
// 透過 abstract 關鍵字宣告為抽象類別
public abstract class Player{
    
}
```

### 介面

> 與抽象類別相似，但一個類別可以繼承多個介面。

``` csharp
// 使用 interface 宣告介面，命名習慣以大寫I做為識別。
public interface ICastSkill{
    
}
```

### 抽象與介面

|      |                抽象                |                介面                |
| :--: | :--------------------------------: | :--------------------------------: |
| 目的 | 定義相同種類物件所具有的共通特性。 | 定義不同種類的物件具有的相同功能。 |
| 對象 |           針對類別的抽象           |           針對行為的抽象           |
| 存取 |      可以有private和protected      |        所有成員必須為public        |
| 使用 |    可以不用實作抽象類別內的成員    |       必須實作介面所有的成員       |



## Reference

- [抽象類別與介面](<https://dotblogs.com.tw/atowngit/archive/2009/08/26/10253.aspx>)

- [抽象類別與介面](https://jeffprogrammer.wordpress.com/2015/07/27/%E6%B7%BA%E8%AB%87-c-%E6%8A%BD%E8%B1%A1%E9%A1%9E%E5%88%A5%E8%88%87%E4%BB%8B%E9%9D%A2/)

- [MSDN: 介面](<https://docs.microsoft.com/zh-tw/dotnet/csharp/programming-guide/interfaces/>)

