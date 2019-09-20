## 多執行緒

> 讓電腦能夠一次執行多行程式，如果主執行緒執行函式太大會造成電腦卡住，影響使用者。
>
> 理論上電腦有幾核心就能跑幾條執行緒，如果超過核心數需要做分配的動作。

```python
import threading
```

- 建立執行緒

  ```python
  import threading, random, time
  
  def t1():
      for i in range(5):
          print("A")
          time.sleep(random.random())
          
  def t2():
      for i in range(5):
          print("B")
          time.sleep(random.random())
  
  # 註冊執行緒
  threading.Thread(target=t1).start()
  threading.Thread(target=t2).start() 
  ```

- 單一函式多執行緒

  ```python
  import threading, random, time
  
  # 單一函式使用不同的執行緒
  def t1(s):
      for i in range(5):
          print(s)
          time.sleep(random.random())
  
  # args參數一律為陣列
  threading.Thread(target=t1, args=['A']).start()
  threading.Thread(target=t1, args=['B']).start()
  ```

- 多執行緒使用物件

  ```python
  import threading, random, time
  # 固定宣告方式
  class MyClass(threading.Thread):
      def __init__(self, str):
          threading.Thread.__init__(self)
          self.str = str
      
      def run(self):
          print(self.name+"\n")
          for i in range(5):
              print(self.str)
              time.sleep(random.random())
  # 以上為多執行緒固定宣告模式
      
          
  MyClass('A').start()
  MyClass('B').start()
  
  print(threading.currentThread().name)
  ```