## Web API

> Web API 主要目的為**建立 HTTP 服務提供給用戶端使用**，相較於 Web Services ，Web API的傳輸資料較小，而且可以直接通過 HTTP 的 GET、POST、PUT、DELETE來操作服務。
>
> 在 .NET 中同樣屬於 Controller 但是繼承自 ApiController，並且可以提供其他網站呼叫。

- Web API 語法架構

	> 接收資料的來源限制：
	>
	> - [FromUrl]
	>
	> 	預設為此，但只能接受簡單型別的資料，表示可以接受來自 URL 的資料
	>
	> - [FromBody]
	>
	> 	限定必須是來自文件主體內的資料，例如 Form。
	>
	> 	如果接收的是複雜型別的資料逾社會改變為此。

	- class

		> 名稱為 Default 繼承自 ApiController

		```csharp
		public class DefaultController : ApiController
		{
			
		}
		```

	- GET

		> 接收GET請求，透過網址後方附加參數。

		```csharp
		// GET: api/Default/{id}
		public string Get(int id)
		{
		    return "value";
		}
		```

	- POST

		```csharp
		// POST: api/Default/
		public void Post([FromBody]string value)
		{
		}
		```

	- PUT

		```csharp
		// PUT: api/Default/{id}
		public void Put(int id, [FromBody]string value)
		{
		}
		```

	- DELETE

		```csharp
		//DELETE: api/Default/{id}
		public void Delete(int id)
		{
		}
		```



## Reference

- [[ASP.NET] WebAPI Get 使用複雜型別](https://dotblogs.com.tw/ian/2013/06/02/105171)