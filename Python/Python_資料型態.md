[TOC]

## 資料結構

### string

> Python中的字串本身是一種陣列，而這個陣列是無法更動的。

### list

> list使用[]宣告，可以建立彈性修改的陣列來儲存資料。

- append(物件)

	> 在尾端增加新元素

	```python
	myList = ['Egg', 'Milk']
	myList.append('Sugar')
	print(myList)
	# output: ['Egg', 'Milk', 'Sugar']
	```

- insert(索引值, 物件)

	> 插入物件至指定索引位置

	```python
	myList = ['Egg', 'Milk']
	myList.insert(1, 'Sugar')
	print(myList)
	# output: ['Egg', 'Sugar', 'Milk']
	```

- remove

	> 刪除第一個匹配的物件，如果沒有找到會出現錯誤訊息。

	```python
	myList = ['Egg', 'Milk']
	myList.remove('Egg')
	print(myList)
	# output: ['Milk']
	```

- extend

	> 將第二個列表附加到第一個列表的尾端

	```python
	# 使用extend方法
	aList = [1, 2, 3]
	bList = [4, 5, 6]
	aList.extend(bList)
	print(aList)
	# output: [1, 2, 3, 4, 5, 6]
	
	# 使用運算子
	# 運算子不改變原陣列
	aList = [1, 2, 3]
	bList = [4, 5, 6]
	print(aList + bList)
	# output: [1, 2, 3, 4, 5, 6]
	print(aList)
	# output: [1, 2, 3]
	print(bList)
	# output: [4, 5, 6]
	```

- max/ min

	> 回傳列表中的最大/ 最小值

	```python
	myList = [5, 10, 37, 33, 25]
	print(max(myList))
	# output: 37
	print(min(myList))
	# output: 5
	```

- sort / sorted

	> sort 對陣列進行排序，會改變陣列的元素位置
	>
	> sorted不改變原陣列位置

	```python
	myList = [5, 10, 37, 33, 25]
	mySortedList = sorted(myList)
	print(myList)
	# output: [5, 10, 37, 33, 25]
	print(mySortedList)
	# output: [5, 10, 25, 33, 37]
	myList.sort()
	print(myList)
	# output: [5, 10, 25, 33, 37]
	```

- reverse

	> 將陣列反轉

	```python
	myList = [5, 10, 37, 33, 25]
	myList.reverse()
	print(myList)
	# output: [25, 33, 37, 10, 5]
	```

- count

	> 計算物件在列表中出現的次數

	```python
	myList = [5, 10, 37, 33, 25, 5]
	print(myList.count(5))
	# output: 2
	```

- pop

	> 回傳列表中指定索引位置的物件並移除他

	```python
	myList = ['Egg', 'Milk', 'Sugar']
	print(myList.pop(0))
	# output: Egg
	print(myList)
	# output: ['Milk', 'Sugar']
	```

### tuple

> tuple是個常數陣列不可改變內容，使用()宣告。

```python
tp = ("我", "安",2 ,3);
print(tp[1]);
# output: 安
```

### set

> set使用{}宣告，判斷兩個集合之間的關係。

- 是否為子集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print(s1.issubset(s2))
	# output: False
	```

- 是否為超集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print("s1 issuperset s2:", s1.issuperset(s2))
	# output: True
	```

- 是否為空集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print("s1 isdisjoint s2 :", s1.isdisjoint(s2))
	# output: False
	```

- 聯集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print(s1.union(s2))
	# output: {1, 2, 3, 4}
	```

- 交集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print(s1.intersection(s2))
	# output: {2, 3}
	```

- 差集

	```python
	s1 = {1, 2, 3, 4}
	s2 = {2, 3}
	print(s1.difference(s2))
	# output: {1, 4}
	```

### dict

> 使用{"key": "value"}宣告，直接對應到JSON格式。可以動態新增修改刪除。

- 查詢

	```python
	myDict = {"Name": "Kai", "Age": "27", "Gender": "Male"}
	print(myDict["Name"])
	# output: Kai
	
	for key in myDict.keys():
	    print("{}: {}".format(key, myDict[key]))
	# output:
	#	Name: Kai
	#	Age: 27
	#	Gender: Male
	
	for value in myDict.values():
	    print(value)
	# output:
	#	Kai
	#	27
	#	Male
	
	for item in myDict.items():
	    print(item)
	# output:
	#	('Name', 'Kai')
	#	('Age', '27')
	#	('Gender', 'Male')
	```

- dict.fromkey(keyList, valList)

	> 由list產生字典

	```python
	aList= [1, 2, 3]
	bList= ["Egg", "Milk", "Sugar"]
	
	myDict= dict.fromkeys(aList)
	print(myDict)
	# output: {1: None, 2: None, 3: None}
	
	myDict=""
	for item in bList:
	    myDict= dict.fromkeys(aList, item)
	print(myDict)
	# output: {1: 'Sugar', 2: 'Sugar', 3: 'Sugar'}
	```

- update(字典)

	> 將第二個字典合併到第一個字典內。

	```python
	aDict = {"Name": "Kai", "Age": "27", "Gender": "Male"}
	bDict = {"Job": "Programmer"}
	aDict.update(bDict)
	print(aDict)
	# output: {'Name': 'Kai', 'Age': '27', 'Gender': 'Male', 'Job': 'Programmer'}
	```

