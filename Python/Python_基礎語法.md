[TOC]

## 編碼

> Python2預設編碼為ASCII；Python3預設為UTF-8，而Windows預設的中文為Big5，因此Python容易出現編碼問題。

- 在檔案開頭使用編碼記號
	```python
	#coding=utf-8
	```

---

## Hello, Python

```python
print('Hello, Python')
# output: Hello, Python
```

---

## Format

```python
text= "Python"
print("Hello, {}".format(text))
# output: Hello, Python
```
---

## 變數

> Python中的變數不需要宣告資料型態，**變數=值**依照等號右邊資料判定。
>
> Python的特色之一是變數宣告可以一次放兩個變數

- 純量型別

	| 整數 | 小數  | 字串 | 布林 |
	| :--: | :---: | :--: | :--: |
	| int  | float | str  | bool |

- 使用

     ```python
     x, y = 1, 2
     print(x+ y)
     # output: 3
     
     # 交換數值
     x, y= y, x
     print("x= {}, y= {}".format(x, y))
     # output: x= 2, y= 1
     ```

- 接收輸入資料

     > _**input預設輸入為string**_
     >
     > python2為raw_input()
     
     ```python
     x= input('請輸入第一個數字：')
     y= input('請輸入第二個數字：')
     print(x+ y)
     
     # input: 1 2
     # output: 12
     ```
     
- 使用命令列參數輸入資料

     ```python
     >>> python test.py 1 2
     import sys
     print(sys.argv[1]+ sys.argv[2])
     # output: 3
     print(sys.argv[0])
     # output: test.py
     ```

- 轉換型別

     ```python
     x= int(input('請輸入第一個數字：'))
     y= int(input('請輸入第二個數字：'))
     print(x+ y)
     
     # input: 1 2
     # output: 3
     ```

---

## 數學運算子

- 運算子的種類

	|  加  |  減  |  乘  |  除  | 餘數 | 取整商數 | 次方 |
	| :--: | :--: | :--: | :--: | :--: | :------: | :--: |
	|  +   |  -   |  *   |  /   |  %   |    //    |  **  |

- 整數相除

	> int / int = int

	```python
	print(17/ 3)
	# output: 5
	```

- 整數除浮點數

     > int / float = float

     ```python
     print(17/ 3.0)
     # output: 5.666666666666667
     ```
- 絕對值 abs(數值)
---

## 字串處理

- 多行字串

	> 使用"""..."""或是'''...'''

	```python
	print("""
	Hello,
	World
	""")
	# output:
	# Hello,
	# World
	```

- 字串相加

	```python
	print("a"+ "b")
	print("a" "b")
	# output: ab
	```

- 字串長度

	```python
	print(len("hello"))
	# output: 5
	```

- 字元陣列

  > 每一個字串都是一個字元陣列。
  >
  > 可以直接透過[:]方式達成substring效果。
  >
  > Python的特色之一是陣列具有「負索引」。

  |  P   |  y   |  t   |  h   |  o   |  n   |
  | :--: | :--: | :--: | :--: | :--: | :--: |
  |  0   |  1   |  2   |  3   |  4   |  5   |
  |  -6  |  -5  |  -4  |  -3  |  -2  |  -1  |

  ```python
  text= "Python"
  print(text[3])
  # output: h
  print(text[-2])
  # output: o
  print(text[2:4])
  # output: th
  print(text[-4:])
  # output: thon
  print(text[2:])
  # output: thon
  print(text[2:-2])
  # output: th
  ```

- 查詢字元索引

  - index('查詢字串', 起始位置: int, 結束位置: int)

    > index在沒有回傳值的狀況下會丟回錯誤訊息

    ```python
    text= "Python is a widely used literal translation, advanced programming, general-purpose programming language."
    print(text.index('y'))
    # 回傳第一個找到的y的索引
    # output: 1
    ```

  - find('查詢字串', 起始位置: int, 結束位置: int)

  	```python
  	text= "Python is a widely used literal translation, advanced programming, general-purpose programming language."
  	
  	# 起始索引值為 1
  	# 當變成 -1 時停止迴圈
  	index= 0
  	while index != -1:
  		index= text.find('n', index+ 1)
  		print(index)
  	# output: 
  	#	 5
  	#	35
  	#	42
  	#	49
  	#	63
  	# 	69
  	#	92
  	#	97
  	#	-1 <-- 無字串則回傳-1
  	```

- Trim

	> 去除頭尾或者其中一邊的指定字元

	- strip

		```python
		str= ", abc,"
		print(str.strip(','))
		# output:    abc
		```

	- lstrip

		```python
		str= ", abc,"
		print(str.lstrip(','))
		# output:    abc ,
		```

	- rstrip

		```python
		str= ", abc,"
		print(str.rstrip(','))
		# output: ,   abc
		```

- replace("目標字串", "取代字串")

	```python
	str= "abcdefg"
	print(str.replace("fg", "hhh"))
	# output: abcdehhh
	```

- spilt("指定字元", "取代數量")

	> 通常用來處理CSV檔案，處理完之後會變成陣列型態。

	```python
	str= "ab,cd,ef"
	print(str.spilt(","))
	# output: ['ab', 'cd', 'ef']
	print(str.spilt(',', 1))
	# output: ['ab', 'cd,ef']
	```
	
- 轉換大小寫

	- lower()
	- upper()
---

## 引用函式庫

- import 函式庫名稱 as 使用名稱

	```python
	import sys as s
	x= s.argv[0]
	
	import myLib.modul
	# 引用myLib資料夾下的modul.py檔案
	# myLib資料夾底下必須有__init__.py檔案
	```

- from 函式庫名稱 import 函式名稱

	> 只引用函式庫內特定的函式

	```python
	from modul import add, minus
	# 引用modul.py檔案裡面的add與minus函式
	from modul import *
	# 引用modul.py裡面的所有函式
	```

- 常用函式庫

	| 名稱           | 功能                               |
	| -------------- | ---------------------------------- |
	| math           | 數學相關。math.pi 圓周率           |
	| random         | 產生亂數。random.randomrange(a, b) |
	| re             | 正則運算式。                       |
	| urllib.request | 呼叫網頁相關函式。                 |
	| time           | 時間相關函式。time.sleep()         |
	| json           | 處理JSON資料。                     |
	| os             | I/O相關函式。                      |
| threading      | 多執行緒。                         |
	
	