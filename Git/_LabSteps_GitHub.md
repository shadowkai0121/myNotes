# Git 與 GitHub by 錢達智 老師

1.  GitHub 建立一個新的 repository (數據庫)
	1. 登入 http://github.com
	2. 建立一個新的 repository (數據庫)，設定如下：
		 1.  Repository name: projectD
	
		2. - [x] Initialize this repository with a README
	
			> 沒有勾選的話需要自己新增一個README.MD檔案
	
2. 複製遠端 GitHub 數據庫到本機端工作環境(近端)

	1. 回到本機端工作環境，新增一個命令提示字元

	2. 在命令提示字元輸入指令，以網址複製遠端數據庫到本機

		```
		>git clone http://github.com/你的GitHub帳號/projectD
		// Ex
		>git clone http://github.com/AppDev1226/projectD
		```

	3. 切換至projectD資料夾：

	4. 在命令提示字元輸入下列指令，觀察 origin 是否在清單之列:

		```
		>git remote -v
		```

3.  新增/修改檔案，上傳回 GitHub

	1.  滑鼠點兩下 README.md，隨意加一些新內容並且存檔。

	2.  在 projectD 資料夾新建一個檔案，檔名: cars.txt，內容如下：

	3.  將 READMD.md 與 cars.txt 加入近端的數據庫(repository)。
		    指令如下：

		```
		>git add .
		>git commit -m "update readme, add car list"
		// 重新整理 GitHub 網頁，檢視 README.md 是否出現變化。
		```

	4.  將近端的數據庫(repository)上傳到 GitHub。指令如下：

		```
		>git push
		// Username 與 Password 請輸入你 GitHub 的帳號與密碼
		// 輸入密碼時，游標不會動是正常現象
		// 重新整理 GitHub 網頁，檢視 README.md 是否出現變化。
		```

	5.  請問：GitHub 網站是在哪一個步驟之後才顯現出檔案有變化？

4.  提取 GitHub 的內容到本機端工作環境

	1.  在 GitHub 網站，針對 README.md，隨意加一些新內容並且存檔。
	2.  在 Cloud9 命令提示字元輸入 git pull
	3.  在本機端工作環境 projectD 資料夾的 README.md 檔案內容是否有變？

5.  解決遠端與近端版本衝突問題

	1.  在 GitHub 網站，針對 cars.txt 附加下列這行並且存檔：

		```
		TOYOTA TURENO GT-APEX(AE86)
		```

	2.  在本機端工作環境，針對 cars.txt 附加下列這行並且存檔：

		```
		MazdaEfiniRX-7(FD-3S)
		```

	3.  在命令提示字元輸入下列指令，將檔案存入近端數據庫：

		```
		>git add .
		>git commit -m "add FD-3S to car list"
		// 好了，現在兩地的版本有衝突了
		```

	4.  在命令提示字元輸入 git push 指令。

		>結果是錯誤訊息，指出內容發生版本衝突問題，無法上傳。

	5.  在命令提示字元輸入 git pull 指令。

		> 雖然 GitHub 遠端的內容的確下載回來了，但畫面仍然出現一堆訊息，指出內容發生版本衝突。
		>
		> **命令提示字元的提示字元變成 (master|MERGING $**

	6.  滑鼠點兩下 cars.txt，選擇「Use Both」，將兩部車的名稱都保留下來。

	7.  解決衝突之後，重新再 commit 一次，指令如下：

		```
		>git add .
		>git commit -m "keep two cars"
		```
		> **命令提示字元的提示字元變回 $**
	8.  再次輸入 git push 指令上傳數據庫。