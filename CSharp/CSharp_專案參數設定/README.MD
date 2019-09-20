## 專案屬性設定

> 將設定資料寫入config檔案中由外部變更值。

- 開啟專案屬性視窗

	![Image001](D:\Respository\myNotes\CSharp\專案參數設定\assets\Image001.png)

- 設定變數名稱、型別、值

	![Image002](D:\Respository\myNotes\CSharp\專案參數設定\assets\Image002.png)

- 設定檔預設在執行檔的工作目錄下

	![Image003](D:\Respository\myNotes\CSharp\專案參數設定\assets\Image003.png)

- Properties.Settings.Default.變數名稱

	> 取得設定參數。

- 在config檔案中可修改參數

	``` xml
	專案名稱.Properties.Settings
	<text0411_Lottery.Properties.Settings>
	    name = 變數名稱 serializeAs = 資料型別
		<setting name="MyDataFileName" serializeAs="String">
	        變數值在這行變更
			<value>C:\Users\admin\Desktop\ADOdotNET\data\</value>
		</setting>
	</text0411_Lottery.Properties.Settings>
	```

	

