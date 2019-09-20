[TOC]

## 程式碼區段

> Python使用:作為程式碼區段的開始，區塊內的程式碼必須縮排一致才能執行程式碼區段

- - [x] 正確

	```python
	i= 0
	while i< 3:
	    print(i)
	    i+= 1
	# output:
	#	0
	#	1
	#	2
	```

- 錯誤

	```python
	i= 0
	while i< 3
	print(i)
	i+= 1
	# output: syntax error
	# 沒有+:
	# 沒有縮排對齊
	```

---

## if...elif...else

> Python中沒有switch...case的寫法

```python
text = input("請輸入指令：");

if "關" in text:
    print("關燈了");
elif "開" in text:
    print("打開了");
else:
    print("聽不懂");
    
# input: 幫我開燈
# output: 打開了
```

### 邏輯運算子

| 大於 | 小於 | 等於 | 不等於 | 以上 | 以下 | 而且 | 或者 | 相反 |
| :--: | :--: | :--: | :----: | :--: | :--: | :--: | :--: | :--: |
|  >   |  <   |  ==  |   !=   |  >=  |  <=  | and  |  or  | not  |

---

## For

- 類似Foreach的用法

	> 讀取字串陣列到最後一個為止，可以搭配substring使用。
	> 在結尾加上else會在迴圈結束後執行else內的指令，如果使用break脫離迴圈則不會執行else內的指令。

	```python
	zoo = ['長頸鹿', '獅子', '老虎', '企鵝']
	for animal in zoo[:2]:
		print("動物園有 {}".format(animal))
	else
		print("動物園沒有動物了")
	# output:
	#	動物園有 長頸鹿
	#	動物園有 獅子
	#	動物園沒有動物了
	```

- 指定次數 for i in range(起始數值, 結束數值, 遞增數值)

	```python
	# i= 2, i< 6, i+=2
	for i in range(2, 6, 2):
		print(i, end=",") #使用end做同行輸出
	print() # 必須要加入print()斷行
	# output:2, 4,
	```

---

## While

- 費式數列

	```python
	a, b = 1, 1;
	n = 0;
	while n < 10:
	    print(a, end = ", ")
	    a, b = b, a + b;
	    n += 1;    
	print()
	# output: 1, 1, 2, 3, 5, 8, 13, 21, 34, 55,
	```

## 跳過執行

- continue

	```python
	for i in range(3):
	    if i == 1:
	        continue
	    print (i, end = '')
	print()
	# output: 02
	```

- break

	```python
	for i in range(3):
		if i == 1:
	        break
		print(i, end = '')
	print()
	# output: 0
	```