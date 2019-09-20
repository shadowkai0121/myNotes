## Tag

> 將分支加上註記，通常用來標示穩定的版本

### 命名習慣

- [主版本號].[次版本號].[修訂版本號]

	> v0.0.1

### 使用

```bash
# 新增
$ git tag v0.01

# 查詢
$ git tag
v0.01

# 刪除
$ git tag -d v0.01
Deleted tag 'v0.01' (was 32f10b0)

# 增加註解
$ git tag v0.0.1 -m "增加很厲害的東西"

# 查看版本資訊
$ git show v0.0.1
tag v0.0.1
Tagger: Kai <shadowkai0121@gmail.com>
Date:   Mon Jul 15 15:14:10 2019 +0800

增加很厲害的東西
```

