## 基礎操作

### Hello

```javascript
console.log("Hello, Node!");
// > node hello.js
// output: Hello, Node!
```

### 建立server

> NodeJS不只是實作應用程式，同時也實作了http server。

1. 引用http

   ```javascript
   var http = require('http')
   ```

   

2. 建立伺服器

   ```javascript
   // 引用http
   var http = require("http");
   
   http
     .createServer(function(request, response) {
       // 發送http header
       // http status = 200
       // 網頁內容: text/plain
       response.writeHead(200, { "Content-Type": "text/plain" });
   
       // 發送回應
       response.end("Hello, Node!");
     })
     .listen(8888);
   
     // Terminal顯示以下訊息
     console.log('Server running at http://127.0.0.1:8888/');
   	// 完成網站架設
   ```

   

3. Request & Response

   - 開啟瀏覽器執行

     ```
     http://127.0.0.1:8888
     ```

   - 看到Hello, Node!完成

### 使用npm

- 安裝模組
   - 本地安裝
   		
   	> *路徑*> ./node_modules
   	
   	```
   	> npm install [module name] //安裝至目前目錄
   	```
   	
   - 全域安裝
   
      > 路徑> node安裝目錄
   
      ```
      > npm install -g [module name] //全域安裝 
      ```
   
   - package.json
   
      > 紀錄模組資訊。
      >
      > 路徑>./node_modules/[module name]/
   
   - 解除安裝
   
      ```
      > npm uninstall [module name]
      ```
   
   - 更新
   
      ```
      > npm update [modul name]
      ```
   
- 查看模組列表

   ```
   > node list -g
   > node list 
   ```

- 錯誤處理

  - npm err! Error: connect ECONNREFUSED 127.0.0.1:8087 

    ```
    npm config set proxy null
    ```

### 讀取檔案

```javascript
var fs = require('fs')
```

> 建立測試用檔案 test.txt
>
> 內容：YAAAAAAAAAAAAAAAAAA

- 單執行緒

  > 程式碼依序執行。

  ```javascript
  var fs = require('fs')
  
  var data = fs.readFileSync('test.txt')
  
  console.log(data.toString());
  console.log('Program done');
  // output:
  //	YAAAAAAAAAAAAAAAAAA
  // 	Program done
  ```

- 多執行緒

  > 使用call back : function(value, call back 1, call back 2){ ... }

  ```javascript
  var fs = require("fs");
  
  fs.readFile("test.txt", (err, data) => {
    if (err) {
      return console.error(err);
    }
    console.log(data.toString());
  });
  console.log("Program done");
  // output:
  // 	Program done
  // 	YAAAAAAAAAAAAAAAAAA
  ```


## Reference

- [安裝教學](<https://blog.gtwang.org/web-development/install-node-js-in-windows-mac-os-x-linux/>)
- [菜鳥教程](<http://www.runoob.com/nodejs/nodejs-tutorial.html>)
- [Node.js 新手入門1：Node Module System 模組化系統](<https://medium.com/@brianwu291/learn-basic-node-part1-module-system-e9ee1724656b>)