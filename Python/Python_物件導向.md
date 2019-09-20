## 物件導向

- 封裝
	- 屬性
		- 屬性就是變數。
		- 屬性代表物件的特徵，特徵用來識別不同的物件。
	- 方法
		- 函式、函數、方法。
		- 操作物件的方式。
	- 存取控制
- 繼承
	- 在不修改原本的程式碼的狀況下擴充程式的功能。
- 多形

## class

> Python類別下的函數必須有 self 參數，建構子名稱必須為\__init__

- 存取控制

	| 私有: 兩個底線 | 公開: 無添加物 | 保護: 一個底線 |
	| -------------- | -------------- | -------------- |
	| \__            |                | _              |

### 封裝

> 一個時鐘具有外觀以及顯示時間的功能。

```python
class Clock:
    # 如果沒有傳入值則color預設為white
    def __init__(self, color= 'white'): 
    	self.__color = color
    def GetColor(self):
        print("這是個{}鬧鐘".format(self.__color))
    def ShowTime(self):
        import time
        print(time.localtime())

myClock= Clock()
myClock.GetColor()
myClock.ShowTime()
# output:
#	這是個white鬧鐘
#	time.struct_time(tm_year=2019, tm_mon=5, tm_mday=25, tm_hour=20, tm_min=47, tm_sec=22, tm_wday=5, tm_yday=145, tm_isdst=0)
```

### 繼承

> 有一個超級時鐘可以設定外觀以及顯示比較容易看得懂的時間。

```python
class Clock:
    # 如果沒有傳入值則color預設為white
    def __init__(self, color= 'white'): 
    	self.__color = color
    def getColor(self):
        print("這是個{}鬧鐘".format(self.__color))
    def ShowTime(self):
        import time
        print(time.localtime())

class SuperClock(Clock): # 傳入的類別代表父類別
    def setColor(self, color):
        self._Clock__color = color # 居然要指定父類別屬性!!!!!
    def ShowTime(self): # 直接覆寫同名的父類別函式
        import time
        print("現在時間：", time.strftime('%Y-%m-%d [%H:%M:%S]'))

myClock= SuperClock()
myClock.setColor('藍色')
myClock.getColor()
myClock.ShowTime()
# output:
#	這是個藍色鬧鐘
#	現在時間： 2019-05-25 [21:00:03]
```

### 多形