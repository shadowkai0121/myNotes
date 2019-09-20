## AJAX

> 能夠透過多執行緒傳送使用者請求，改善使用者體驗。

- JQuery

  > 以JSON格式傳遞資料，只要格式的 key 與 Controller 的變數名稱一樣就能接收到 Value。

  ```js
  $.ajax({
    method: "POST", // GET一樣直接透過query string攜帶資料
    url: "server位址或控制器路徑",
    // 送出請求
    contentType: "application/json",
    data: JSON.stringify({name:"Kai",age:"27"}),
    // 接收回應, 透過 sucess 的 callback 做出後續動作
  dataType: "json",
    sucess: function(response){ ... }
  })
  
  $("selector").load(來源, JSON資料, 回呼函式);
  // 當資料攜帶在來源後方時為 GET 請求
  $("selector").load("url/Home/Index?var=value");
  // 當資料透過 JSON 物件傳送時送出 POST 請求
  $("selector").load(url, {var: value});
  // 回呼函式中可以抓取回應狀態做例外處理或使用回應做後續動作
  $("selector").load(url, function(response, status, error){
     if(status == "sucess") { ... }
  });
  ```
  
  - load()
  
  	> load 與 AJAX 類似，差別在於 load 可以直接將讀取到的頁面寫入透過CSS selector指定的位置，例如與 MVC 架構中的 PartialVIew 合作達成異步更新範圍頁面的功能。

### 在 MVC 上實作polling

> 透過 nameID 的值取得後端對應的名稱資料。

- 前端程式碼

  > - 將 client 資料透過 contentType 與 data 的設置送出
  > - 透過 sucess 屬性取得 server 回傳資料
  > - 設置下一次請求的 timeout 

  ```html
  @{
      ViewBag.Title = "Index";
  }
  
  <h2 id="response">Index</h2>
  <input type="number" id="nameID" value="0" min="0" max="3"/>
  <script src="~/Scripts/jquery-3.3.1.min.js"></script>
  <script>
      (function polling() {
          $.ajax({
            	// 指定發送地點與類型
              url: "@Url.Action("takeName")",
              type: "POST",
            	// 設置Request內的資料
              contentType: "application/json",
              data: "{'num':" + $("#nameID").val() + "}",
            	// 成功發送時取得回傳資料
              success: (data) => {
                  $("#response").text(data.name);
              },
              dataType: "json",
              // 設置下一次請求時間
              complete: setTimeout(() => { polling() }, 500),
          })
      })();
  </script>
  ```

- 後端程式碼

  ```csharp
      public class HomeController : Controller
      {
          // GET: Home
          public ActionResult Index()
          {
              return View();
          }
  
          [HttpPost]
          public ActionResult takeName(int num)
          {
              string[] userName = { "Kai", "Yoga", "Won", "Moo" };
              return Json(new { name = userName[num] });
          }
      }
  ```

  