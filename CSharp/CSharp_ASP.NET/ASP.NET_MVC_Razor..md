## [Razor語法](https://docs.microsoft.com/en-us/aspnet/web-pages/overview/getting-started/introducing-razor-syntax-c)

> Razor語法是基於C#語言的語法。
>
> 可以在前端頁面執行C#。

- 在網頁中使用@來寫CODE

- 可以使用@{...}作為程式碼區塊：
	- @function
	- @if
	- @for
	- @foreach
	- @while
	- @try
	
- 程式碼區塊中可以插入HTML標籤

- 接收資料
	- @model (資料型態)
		- @Model.欄位名稱
	- @ViewBag.名稱
	- @ViewData["名稱"]
	- @TempData["名稱"]
	
- 建立函式

	> 前端中引用 Razor 函式需要在函式名稱前面加上@

	- @helper 名稱{ ... }

		> helper函式無法回傳值

	- @functions{ ... }

		> functions內可以建立多個 function 並且帶有回傳值

- 傳遞JSON

	> 會被瀏覽器加上quot;
	
	```html
	@Html.Raw(JSON字串)
	```
	
- 取得伺服器路徑

	> 只有主目錄是真的。

	```csharp
	@Request.MapPath("/")
	```

	

### Exampler

- 流程控制

	```csharp
	@if (ViewBag.Number != null){
	    for (int = 0; i < ViewBag.Number; i++){
	        <h1>@i</h1>
	    }
	}
	```

- 建立函式

	```csharp
	@helper printTable(int amt){
	    <table>
	        @for (int i = 0; i < amt; i++){
	        	<tr>
	        		<td>@add(i, i + 1)</td>
	        		<td></td>
	        		<td></td>
	        	</tr>
	    	}
		</table>
	}
	@functions{
	    int add(int x, int y){
	        return x + y;
	    }
	}
	```

