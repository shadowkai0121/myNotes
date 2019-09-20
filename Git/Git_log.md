## 送交紀錄

|   log    |   show   |   diff   |
| :------: | :------: | :------: |
|  提交者  |  提交者  |          |
| 提交日期 | 提交日期 |          |
| 提交訊息 | 提交訊息 |          |
|          | 變更內容 | 變更內容 |

- log

	```bash
	# 只顯示 commit 訊息
	git log --oneline
	```

- 分支圖

	```bash
	git config --global alias.tree "log --oneline --decorate --graph --all"
	```

- 變更紀錄

	```bash
	git config --global alias.ls "log --graph --pretty=format:'%h <%an> %ar %s'"
	```