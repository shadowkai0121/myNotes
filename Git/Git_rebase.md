## Rebase

> 大幅修改紀錄，重新定位分支的起始位置。

- 移動分支基礎

	```bash
	git rebase 來源分支
	```

- 處理多個併行衝突

	```bash
	git rebase --continue
	```

- 合併送交紀錄

	```bash
	git log --oneline
	cbc1964 (HEAD -> dev) d2
	931632f d1
	69c5926 (master) m4
	808545a m3
	30102b8 m2
	6024338 m1
	7e8a5cf init
	
	# 可以改成使用
	# git rebase 931632f
	git rebase HEAD~2
	# 留下需要的 commit 開頭為pick， 剩下的改成squash
	# 修改commit message
	
	git log --oneline
	f3aef6d (HEAD -> dev) d1+d2
	69c5926 (master) m4
	808545a m3
	30102b8 m2
	6024338 m1
	7e8a5cf init
	```

	

