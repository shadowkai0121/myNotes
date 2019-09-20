## Controller

> Controller的存取權限必須為**public**

### 請求

- 接受GET請求

	```csharp
	public ActionResult Index(){    
	    return View();
	}
	```

- 接收POST請求

	```csharp
	[HttpPost]
	public ActionResult Index(){
		return View();
	}
	```

- 接收變數

	> 當View的請求中帶有資料時，透過相同的變數名稱可以直接接收到資料。

	```csharp
	// 網頁傳來了一段資料為
	// localhost/Home/Index?id= 1
	// 或者
	// Form Submmit內的欄位name="id", Value= 1
	public ActionResult(int id){
	    return Content(id.toString());
	    // output: 1
	}
	```

	

### 回應

> Controller 透過 Return 傳回伺服器的回應

- return View("頁面名稱", "版面頁名稱",傳遞資料);

	> 回傳對應網頁並指定版面配置頁與攜帶資料

	```csharp
	public ActionResult Index(int id){
	    return View("Index", "_Layout", id)
	}
	```

- return Content(資料)

  > 直接輸出網頁內容，通常用來驗證是否接收到前端傳來的資料。

  ```csharp
  public ActionResult Index(int id){
      return Content(id.toString());
  }
  
  public ActionResult TestXml()
  {
  	ContentResult result = new ContentResult();
  	result.Content = "<book><title>Book Name</title><Price>100</Price></book>";
  	result.ContentType = "text/xml";
  	// image/jpg, imge/gir   
  	return result;
  }
  ```

- return RedirectToAction("Action名稱")

	> 將程式重導至指定的ActionResult，限定在相同控制器。

-  return RedirectToRoute(new { controller = "", action = "" });

	> 將程式重導至另一個控制器底下的ActionResult

### 更改URL顯示名稱

> 將路徑名稱與副程式名稱脫鉤可以增加安全性，並且改版的時候不會動到之前的URL。

```csharp
[ActionName("AboutMe")]
public ActionResult About()
{
	return View("About");
}
```

### 資安相關

- 防止跨站攻擊

	```csharp
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Login(string account, string pwd){
		return View();
	}
	```

	Reference

	- [mrkt](<http://kevintsengtw.blogspot.com/2013/01/aspnet-mvc-validateantiforgerytoken.html>)

- 