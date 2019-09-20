## 查詢資料庫的方式

- Pooling
  - 迴圈不停地詢問
  - 程式碼簡單
- Interupt
  - WebSocket
  - 效率好

## 通訊協定

- 七層

  1. 定義硬體

  2. 定義驅動程式

  3. IP address

  4. 封包傳遞

     1. TCP

        > 資料下載

        1. 保證對方正確收到
        2. 沒收到就重新傳
           1. 網路塞車時會不停重傳。

     2. UDP

        > 串流。EX: Youtube

        1. 對方有沒有收到不管
        2. 對Server負擔小

  5.  

  6.  

  7. 應用

     1. MQTT
        1. Machine to machine
     2. HTTP

## 安裝MQTT

_懶人裝法不包含web socket_

#### WebSocket

一種含

連接4、5層的介面

讓web與server保持連線，資料庫異動就能馬上知道。

WebSocket需要額外架Server。

主流用Google Filebase

### From Source Code

- <https://github.com/eclipse/mosquitto>

- 安裝套件

  ```
  sudo apt-get install libc-ares-dev libwebsockets-dev libssl-dev xsltproc docbook-xsl
  ```

- 解壓縮source code

- vi config.mk

  > ## 沒有改就直接make會造成websocket no support錯誤
  >
  > > make clean
  > >
  > > sudo make uninstall
  > >
  > > *修改檔案後繼續執行步驟*

  ```
  WITH_WEBSOCKETt:=no >yes
  ```

- make -j4

  > 編譯將檔案變成執行檔，結束之後可以vi Makefile查看可用指令以及執行內容

- sudo make install

  > 安裝，沒有安裝就不能執行。

  ---

  > 安裝完成

- cd /etc/mosquitto

- sudo vi mosquitto.conf
	```
	port 1883

	listener 9001
	protocol websockets
	```

- mosquitto -c /etc/mosquitto/mosquitto.conf

  > 執行以上代碼出現以下訊息之後沒有結束就完成。

  ```
  1559268552: mosquitto version 1.6.2 starting
  1559268552: Config loaded from /etc/mosquitto/mosquitto.conf.
  1559268552: Opening websockets listen socket on port 9001.
  1559268552: Opening ipv4 listen socket on port 1883.
  1559268552: Opening ipv6 listen socket on port 1883.
  ```

## 建立系統服務

- sudo adduser --no-create-home mosquitto

  > 建立使用者，執行後需要輸入密碼，然後依照標籤填資料。

- mosquitto -d -c /etc/mosquitto/mosquitto.conf

  > daemon
  >
  > 背景執行

- 開啟第二個連線

  - mosquitto_sub -h localhost -t hello

	  > -h = sucribe
	  >
	  > -h localhost
	  >
	  > localhost = 執行時的機器名
	  >
	  > -t 訂閱的主題
	  - ### 錯誤處理

	    > mosquitto_sub: error while loading shared libraries: 		libmosquitto.so.1: cannot open shared object file: No such file or directory

	    - 找不到libery
	      ```
	      cd /usr/lib/arm-linux-gnueabihf 
	      sudo ln -fs /usr/local/lib/libmosquitto.so.1 lismosquitto.so.1
	      ```
- 切回第一個連線
- mosquitto_pub -h localhost -t hello -m "aaaaple"

  > sub端看到aaaaple代表成功

## Apache

- cd / var/www/html

- sudo vi test.html

  > 建立測試用網頁

  ```html
  <html>
    <head>    
    </head>
    <body>
      <div>
        Hello
      </div>
    </body>
  </html>
  ```

- 開啟瀏覽器，網址列執行

  ```
  http://hostname/test.html
  或者
  樹梅派IP/test.html
  ```

- 看到網頁內容完成



## 背景執行mqtt

- wget raw的網址

  ```
  https://raw.githubusercontent.com/eclipse/mosquitto/master/service/systemd/mosquitto.service.simple
  ```

- mv mosquitto.service.simple mosquitto.service

- whereis mosquitto

  > 確認mosquitto所在路徑

- vi mosquitto.service

  ```
  ExecStart= 路徑
  ```

- sudo mv mosquitto.service /etc/systemd/system

- sudo systemctl enable mosquitto.service

  > 允許背景執行

- sudo reboot

- ps -elf | grep mos

  > 找出ps -elf裡面有mos字串的資料行

  ```
  4 S mosquit+   458     1  0  80   0 -  1599 -      15:52 ?        00:00:00 /usr/local/sbin/mosquitto -c /etc/mosquitto/mosquitto.conf
  0 S pi        4358  4288  0  80   0 -  1092 pipe_w 16:01 pts/1    00:00:00 grep --color=auto mos
  ```

##  cloudMQTT

- sudo vi /var/www/html/test.html

  > 編輯測試網頁

  ```html
  <html>
  
  <head>
    <meta charset="utf-8">
  </head>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/paho-mqtt/1.0.1/mqttws31.min.js" type="text/javascript"></script>
  
  <script type="text/javascript">
  
    // Create a client instance
    //client = new Paho.MQTT.Client("host", port,"client_id");
    client = new Paho.MQTT.Client("IpAddress", 9001, "web_" + parseInt(Math.random() * 100, 10));
  
    // set callback handlers
    client.onConnectionLost = onConnectionLost;
    client.onMessageArrived = onMessageArrived;
    var options = {
      // useSSL: true,
      // userName: "username",
      // password: "password",
      onSuccess: onConnect,
      onFailure: doFail
    }
  
    client.connect(options);
  
    // called when the client connects
    function onConnect() {
      // Once a connection has been made, make a subscription and send a message.
      console.log("onConnect");
      // 發布者使用的名稱
      client.subscribe("cloudmqtt");
      // 訂閱訊息
      message = new Paho.MQTT.Message("Hello CloudMQTT");
      // 訂閱者使用的名稱
      message.destinationName = "send_cloudmqtt";
      client.send(message);
    }
  
    function doFail(e) {
      console.log(e);
    }
  
    // called when the client loses its connection
    function onConnectionLost(responseObject) {
      if (responseObject.errorCode !== 0) {
        console.log("onConnectionLost:" + responseObject.errorMessage);
      }
    }
  
    // called when a message arrives
    function onMessageArrived(message) {
      console.log("onMessageArrived:" + message.payloadString);
      // 修改網頁div內容
      document.getElementById("msg").innerHTML = message.payloadString;
    }
  </script>
  
  
  
  <body>
    <div id="msg">
      HellO!! Python!!
    </div>
  </body>
  
  </html>
  ```

- 瀏覽器開啟網頁

- mosquitto_sub -t send_cloudmqtt

  ```
  Hello CloudMQTT
  ```

- mosquitto_pub -t cloudmqtt -m "aaaaple"

  > 網頁看到 aaaple 完成

  