## 版本衝突

> 當兩個分支上修改到同一個檔案時產生。

## 衝突模擬

- git checkout master

	- 在購物單尾端加入 - mushroom並且認可

	```
	# Shpping List
	
	- milk
	- 10 eggs
	- pork
	- barbecue grill
	- wood coal
	- mushroom
	```

- git checkout bbq

	- 在購物單尾端加入 -corn並且認可

	```
	# Shpping List
	
	- milk
	- 10 eggs
	- pork
	- barbecue grill
	- wood coal
	- corn
	```

- 切回master進行合併

	```c
	> git checkout master
	> git merge --no-ff bbq
	/* output:
	Auto-merging shoppinglist.txt
	CONFLICT (content): Merge conflict in shoppinglist.txt
	Automatic merge failed; fix conflicts and then commit the result.
	*/
	```

	- 查看shoppinglist.txt內容

		> HEAD側表示來自當前分支的異動。

		```
		# Shpping List
		
		- milk
		- 10 eggs
		- pork
		- barbecue grill
		- wood coal
		<<<<<<< HEAD
		- mushroom
		
		=======
		- corn
		>>>>>>> bbq
		
		```

- 修改後進行commit

	```CQL
	# Shpping List
	
	- milk
	- 10 eggs
	- pork
	- barbecue grill
	- wood coal
	- mushroom
	- corn
	```

	

