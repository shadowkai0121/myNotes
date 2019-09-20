## BaseController

> Controller本身也是一個類別，基於物件導向的概念可以新增一個Controller作為基底類別給其他Controller繼承，方便擴充、整理程式碼。

- 存取限制

	> 基底內的屬性、方法需要使用 Protected 權限才能提供給其他Controller使用。

### Example

- 繼承屬性

	- BaseController

		```csharp
		public class BaseController : Controller
		{
		    protected string Title
		    {
		        get { return Title; }
		        set { ViewBag.Title = value; }
		    }
		}
		```

	- HomeController

		```csharp
		public class HomeController : BaseController
		{
		    // GET: Home
		    public ActionResult Index()
		    {
		        Title = "Index";
		        return View();
		    }
		}
		```

	- View

		![Image201906161514](D:\Respository\myNotes\CSharp\ASP.NET\assets\Image201906161514-1560669322093.png)

	- 結果

		![Image201906161515](D:\Respository\myNotes\CSharp\ASP.NET\assets\Image201906161515.png)

- 繼承方法

	- BaseController

		```csharp
		public class BaseController : Controller
		{
		    protected void setTitle(string str)
		    {
		        ViewBag.Title = str;
		    }
		}
		```

	- HomeController

		```csharp
		public ActionResult Index()
		{
		    setTitle("Index");
		    return View();
		}
		```

	- 結果等同於直接在屬性Title內設定ViewBag.Title



### Reference

- [OOP繼承技巧：BaseController與BaseApiController](https://blog.kkbruce.net/2014/05/oop-Inherit-basecontroller-baseapicontroller.html)
- [BaseController的重要性](https://ithelp.ithome.com.tw/articles/10158057)