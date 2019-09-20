## try...except

> 例外處理的目的在於將有可能出現錯誤的程式碼包起來，如果有出問題的時候可以在執行階段透過exception採取動作，避免讓程式直接當掉。

```python
text= "Python is a widely used literal translation, advanced programming, general-purpose programming language."

try:
    idx = -1
    while True:
        idx = text.index('p', idx + 1)
        print(idx)
except:
    print('not found')
# output:
#	54
#	75
#	78
#	83
#	not found
```

