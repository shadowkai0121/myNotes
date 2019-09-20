## 定義

> Python的資料傳遞大多屬於call-by-values，只有陣列或物件會在函式中被修改。

```python
def add(x, y):
    return x+ y
print(add(3, 5))
# output: 8

def sum(*values):
	"""傳入不特定數量的參數"""
    s= 0
    for n in values:
        s+= n
    return s
print(sum(1, 2, 3))
# output: 6
print(sum.__doc__)
# output: 傳入不特定數量的參數
# 必須要在函式宣告之後的第一行使用多行註解，主要用來配合套件產生說明文件使用。
```

## 變數的生命週期

- 區域？全域？

	```python
	n= 0 # 這個n是全域變數
	def f1(n):
	    n= 10 # 這裡的n是區域變數，離開了函式就消失了
	f1(n)
	print(n)
	# output: 0
	# 最終印出全域變數
	
	arr= [0]
	def f2(arr):
	    arr[0]= 20
	f2(arr)
	print(arr[0])
	# output: 20
	# 陣列傳入函式中會被修改指定索引的值
	```

- 函式中使用全域變數

	```python
	n= 0
	def f1():
	    global n # f1(n)-> 如果函式接收傳入的變數也叫n會產生重複命名的錯誤
	    n= 10
	f1()
	print(n)
	# output: 10
	# 呼叫函式之後直接修改了全域變數 n 的值
	# 沒有任何的數值傳遞，因此不算是call-by-address
	```

- 函式中使用父函式的區域變數

	> nonlocal會拉上一層的變數，如果沒有就再往上一層找。

	```python
	def f1():
	    n = 1
	    def f2():
	        # f2 並沒有宣告 n
	        print("n before f3= ", n)
	        def f3():
	            nonlocal n
	            n = 3
	        f3()
	        print("n after f3= ", n)   
	    f2()
	    # f1 的 n 被 f3 修改了
	    print("n final= ", n)
	f1()
	# output: 
	#   n before f3= 1
	#   n after f3= 3
	#   n final= 3
	```