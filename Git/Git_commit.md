## Commit

> 送交變更之前必須要將新增的檔案加入追蹤
>
> ```bash
> # 當前目錄
> git add .
> # 當前專案
> git add --all
> ```

- 基本款

	```bash
	git commit -m "message"
	```

- 與add合併

	```bash
	git commit -a -m "message"
	```

- 修改message

	```bash
	git commit --amend -m "new message"
	```

- 補送 commit

	> 不會額外增加 log

	```bash
	git commit --amend --no-edit
	```