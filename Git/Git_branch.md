## 分支操作

> 做一個功能開一個分支

- 查詢

	```bash
	# 只有本地端
	git branch
	# 包含遠端
	git branch --all
	```

- 新增

	```bash
	# 以master為基礎新增名稱為 dev 的分支
	git branch dev
	# 指定dev2分支的基礎來源為dev
	git branch dev2 dev
	```

- 刪除

	```bash
	# 一般刪除，未合併的無法刪掉
	git branch -d dev
	# 強制刪除
	git branch -D dev
	```

- 切換

	```bash
	# 切換至 dev 分支
	git checkout dev
	```

	