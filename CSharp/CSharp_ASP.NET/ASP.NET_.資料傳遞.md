## 資料傳遞

### Server To Client

|          | ViewBag | ViewData | TempData |  Model  |   Session    | Application |      Cookie       |
| :------: | :-----: | :------: | :------: | :-----: | :----------: | :---------: | :---------------: |
| 生命週期 | Action  |  Action  | Request  | Request | 20min/可調整 | 瀏覽器關閉  | 瀏覽器關閉/可調整 |
|  儲存端  | Server  |  Server  |  Server  | Server  |    Server    |   Server    |      Client       |

- ViewBag
	- 動態型別
	- 速度略比ViewData慢
- ViewData
	- 大致上與ViewBag相同
	- 使用時需要轉換型別
- TempData
	- 可以透過 Redirect 傳遞資料到別的Action
	- 主要儲存在 Session 內，使用後就會刪除
- Model
	- return 時攜帶的資料，通常用來傳送實體資料模型的內容

### 傳遞多個 Model

- Tuple

	> 使用 Tuple 資料型態

	- Controller

		```csharp
		var TupleModel = new Tuple<firstData, secondData>(firstDataResource, secondDataResource)
		```

	- View

		> Model 層級會出現智慧選字

		```html
		@using projectName.Models
		@model Tuple<firstData, secondData>
		@foreach (item1 items in Model.Item1){}
		```

- ExpandoObject

	> 透過屬性合併

	- Controller

		> 屬性名稱 (firstDataName) 為 View 叫用時的名稱

		```csharp
		using System.Dynamic;
		
		dynamic data = new ExpandoObject();
		data.firstDataName = dataResource;
		data.secondDataName = dataResource;
		```

	- View

		> Model 層級不會出現智慧選字

		```csharp
		@using projectName.Models
		@model dynamic
		@foreach (firstData items in Model.firstDataName){}
		```

- View Model

	> 在 Model 中新增類別用來合併資料，安全性較佳。

	- Model

		```csharp
		public class ViewModelName
		{
		    public IEnumerable<firstDataType> FirstDataName;
		    public IEnumerable<secondDataType> SecondDataName;
		}
		```

	- Controller

		```csharp
		ViewModelName data = new ViewModelName();
		data.FirstDataName = dataResource;
		data.SecondDataName = dataResource;
		```

	- View

		```csharp
		@using projectName.Models
		@model ViewModelName
		@foreach (firstDataType items in Model.FirstDataName){}
		```

		

## Reference

- [[ASP.NET][MVC]Multiple Models(一)ViewBag、ViewData、TempData](<https://dotblogs.com.tw/stanley14/2016/11/19/mvc-multiplemodels>)
- [[ASP.NET][MVC]Multiple Models(二)ExpandoObject、Tuple、View Model](<https://dotblogs.com.tw/stanley14/2016/11/19/mvc-multiplemodels2>)
- [[Asp.net MVC] TempData、ViewData、ViewBag](<https://dotblogs.com.tw/inblackbox/2013/06/03/105240>)
- [[ASP.NET MVC] ASP.NET MVC 傳遞資料容器(三) - 總結](<https://dotblogs.com.tw/jasonyah/2013/05/06/102831>)