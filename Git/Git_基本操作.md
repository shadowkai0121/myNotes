[TOC]



## Git操作

### 設定Git Config

> Git的操作指令原則上在命令列中進行。

- git config --list

	> 設置使用者名稱，在傳送認可時作為識別使用。

	```c
	> git config --list
	// output: 本機上的git資料
	```


- git config --global user.name "你的名稱"

	```c
	> git config --global user.name "Kai"
	>
	> git config --global user.name
	// output: Kai
	```


- git config --global user.email "信箱"

	```c
	>git config --global user.email "shadowkai0121@gmail.com"
	>
	>git config --global user.email
	// output: shadowkai0121@gmail.com
	```

---

### 建立Repository (數據庫)

> Respository中存放著程式的版本資料，建立後會出現隱藏的.git資料夾。

- 切換到目標資料夾下

	```C
	> cd c:\temp
	c:\temp>
	```

	- 目標下有shopping.txt作為練習範本

		```C
		# ShoppingList
		- milk
		- eggs
		```

- git status

	> 查詢資料夾狀態，目前資料夾還沒有設置為數據庫。

	```c
	> git status
	// output: fatal: not a git repository (or any of the parent directories): .git
	```

- git init

	> 建立 git 數據庫，指令輸入完成後可以查看資料夾是否多了.git 的隱藏資料夾。

	```c
	> git init
	// output: Initialized empty Git repository in C:/Users/admin/Desktop/gitLab/.git/
	```

- 再次使用 git status查詢資料夾狀態

	> - 正在mater分支上
	>
	> - 還沒有認可
	>
	> - 未被追蹤的檔案:
	>
	> 	​	shoppinglist.txt
	>
	> - 建立我們使用git add指令將檔按加入追蹤

	```c
	> git status
	/* output: 
	On branch master
	
	No commits yet
	
	Untracked files:
	  (use "git add <file>..." to include in what will be committed)
	
	        shoppinglist.txt
	
	nothing added to commit but untracked files present (use "git add" to track)
	*/
	```

- git add

	> 將檔案加入git的版本控管中，並且再次使用git status查看。
	>
	> - 正在mater分支上
	> - 還沒有認可
	> - 有改變需要被認可
	> 	- 新檔案: shoppinglist.txt

	```c
	>git add shoppinglist.txt
	>git status
	/* output: 
	On branch master
	
	No commits yet
	
	Changes to be committed:
	  (use "git rm --cached <file>..." to unstage)
	
	        new file:   shoppinglist.txt
	*/
	```

- git commit -m "改動說明" 

	> git 完成一個階段變動之後，需要使用commit來讓系統知道改動已經完成了。

	```c
	> git commit -m "建立新的購物清單"
	/* output:
	[master (root-commit) b84b9f3] 建立購物清單
	 1 file changed, 3 insertions(+)
	 create mode 100644 shoppinglist.txt
	*/
	> git status
	/* output:
	On branch master
	nothing to commit, working tree clean
	*/
	```

### 分支操作

> 為了避免並行衝突或者意外毀損的狀況，修改一般在master以外的分支上執行，等到功能完成並測試穩定後再合併回mater上。

- git branch

	> 查看當前分支狀態

	```c
	> git branch
	// output: * master
	```

- git branch "bbq"

	> 建立名為bbq的新分支，並使用git branch查看。
	>
	> *代表當前所在分支。

	```c
	> git branch "bbq"
	> git branch
	/*output: 
	  bbq
	* master
	*/
	```

- git checkout bbq

	> 切換至bbq分支上

	```CQL
	> git checkout bbq
	// output: Switched to branch 'bbq'
	> git branch
	/* output:
	* bbq
	  master
	*/
	```
	- 將資料夾內容加入bbq分支
	
		```c
		> git add shoppinglist.txt
		```
	
- 修改檔案內容

	```
	# Shpping List
	
	- milk
	- 10 eggs
	- pork
	- barbecue grill
	- wood coal
	```

	- 發送認可

		```c
		> git commit -m "增加烤肉用具"
		/* output:
		On branch bbq
		Changes not staged for commit:
		        modified:   shoppinglist.txt
		
		no changes added to commit
		*/
		```

- 切換回master分支

	- 開啟檔案

		```
		# ShoppingList
		- milk
		- egg
		```

	> 改動在bbq分支上進行，因此並沒有影響到master分支的檔案。

- git diff bbq

	```c
	> git diff bbq
	/* output:
	diff --git a/shoppinglist.txt b/shoppinglist.txt
	index 5f6497d..502c4af 100644
	--- a/shoppinglist.txt
	+++ b/shoppinglist.txt
	@@ -1,7 +1,3 @@
	-# Shpping List
	-
	+# ShoppingList
	 - milk
	-- 10 eggs
	-- pork
	-- barbecue grill
	-- wood coal
	+- egg
	\ No newline at end of file
	*/
	```

- git merge --no-ff bbq

	```c
	> git merge --no-ff bbq
	/* output:
	Merge made by the 'recursive' strategy.
	 shoppinglist.txt | 8 ++++++--
	 1 file changed, 6 insertions(+), 2 deletions(-)
	*/
	```

- 