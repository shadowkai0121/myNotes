## 操作外部檔案

```python
# 必須引用 os 函式庫
import os
```

### 目錄

- 是否存在

	- os.path.exist("路徑")

- 取得資料夾下所有物件(os.listdir("路徑"))

	```python
	import os 
	
	# 判斷C槽下的檔案是否為目錄(isdir)
	path= "C:\\"
	for file in os.listdir(path):
	    # windows 上面要加入os.path.join()
	    fullName = os.path.join(path, file)
	    if os.path.isdir(fullName):
	        print("{0} is directory".format(file))
	    else:
	        print("{0} is file".format(file))
	```

- 新增 / 刪除

	```python
	import os
	# 在C槽底下新增一個Hello資料夾
	os.mkdir("C:\\Hello")
	# 刪除C槽底下的Hello資料夾
	os.remove("C:\\Hello")
	```

### 檔案

![](.\assets\2112205-861c05b2bdbc9c28.png)

- 是否存在
	- os.path.exist("路徑")
- 開啟 / 讀取 / 關閉
	- x = open("路徑", 開啟模式, 編碼方式)
	- 讀取
		- x.read() 一次全部讀成字串
		- x.readline() 逐行讀取
		- x.readlines() 依照換行符號轉換成字串陣列
	- x.close()
	- with open("路徑", 開啟模式, 編碼方式) as x:
		- 可在離開執行區段時自動清除緩衝以及關閉檔案。

