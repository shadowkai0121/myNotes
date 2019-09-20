## 自訂指令

```bash
git config --global alias.簡寫 "指令"
```



### 建議設置

- 分支圖
	```bash
	git config --global alias.tree "log --oneline --decorate --graph --all"
	```
	
- 切換分支
	```bash
	git config --global alias.co "checkout"
	```
	
- 查詢狀態

	```bash
	git config --global alias.st "status"
	```

- commit

	```bash
	git config --global alias.cm "commit -m"
	```

- 查詢/建立分支

	```bash
	git config --global alias.br "branch"
	```

- 修改紀錄

	```bash
	git config --global alias.ls "log --graph --pretty=format:'%h <%an> %ar %s'"
	```
