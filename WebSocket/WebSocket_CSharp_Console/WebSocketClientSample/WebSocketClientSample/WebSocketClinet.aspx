<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSocketClinet.aspx.cs" Inherits="WebSocketClientSample.WebSocketClinet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>WebSocketExample</title>
    <script type="text/javascript">
        var start = function () {
            var inc = document.getElementById('incomming');
            var wsImpl = window.WebSocket || window.MozWebSocket;
            var form = document.getElementById('sendForm');
            var input = document.getElementById('sendText');

            inc.innerHTML += "connecting to server ..<br/>";

            // 建立WS物件
            window.ws = new wsImpl('ws://localhost:7181/');

            // 寫出接收數據
            ws.onmessage = function (evt) {
                inc.innerHTML += evt.data + '<br/>';
            };

            // 連線提示
            ws.onopen = function () {
                inc.innerHTML += '.. connection open<br/>';
            };

            // 關閉提示
            ws.onclose = function () {
                inc.innerHTML += '.. connection closed<br/>';
            }

            // 監聽form動作
            form.addEventListener('submit', function (e) {
                e.preventDefault();
                var val = input.value;
                ws.send(val);
                input.value = "";
            });

        }
        window.onload = start;
    </script>
</head>
<body>
    <form id="sendForm" runat="server">
        <input id="sendText" type="text" placeholder="Text to send" />
    </form>
    <pre id="incomming"></pre>
</body>
</html>
