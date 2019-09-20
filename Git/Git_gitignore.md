## .gitignore

- 檔案內註記的檔名不會被送入數據庫

- [常用設定](https://github.com/github/gitignore)

### Example

```bash
# log 為不打算送進數據庫檔案
touch system.log
git add .
git cm "add log"
```

- 刪除錯誤檔案

	```bash
	# 刪除檔案
	rm system.log
	git st
	On branch master
	Changes not staged for commit:
	  (use "git add/rm <file>..." to update what will be committed)
	  (use "git checkout -- <file>..." to discard changes in working directory)
	
	        deleted:    system.log
	
	no changes added to commit (use "git add" and/or "git commit -a")
	
	# 更新數據庫
	git add .
	git commit -m "remove log"
	git st
	On branch master
	nothing to commit, working tree clean
	```

- 建立 .gitignore

	```bash
	$ touch .gitignore
	$ vi .gitignore
	# .gitignore 內容
	# 所有 .log 結尾的檔案都忽略
	"""
	*.log
	"""
	git add .
	git commit -m "ignore file"
	```

- 測試

	```bash
	touch system.log
	
	# 無視了 system.log 檔案!
	git st
	On branch master
	nothing to commit, working tree clean
	```

	

