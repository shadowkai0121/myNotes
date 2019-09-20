## Reset

> 只能使用在未發布的紀錄，避免版本衝突。

- 還原到最近一個紀錄

	```bash
	git reset HEAD^
	```

- 強制刪除所有未送交的變更

	```BASH
	git reset --hard HEAD^
	```

	

## Revert

> 使用commit來反轉前一個commit的改動，會留下紀錄。

```bash
$ git revert HEAD

$ git log --oneline
6bed114 (HEAD -> dev) Revert "d1+d2" 
f3aef6d d1+d2
69c5926 (master) m4
808545a m3
30102b8 m2
6024338 m1
7e8a5cf init
```

