## 套件



- pip install numpy
- pip install opencv-python
- pip install opencv-contrib-python



## Code Example

```Python
import cv2, time

# 離開視窗用
ESC = 27 
# 儲存按鈕
save = 115
# 讀取圖片
load = 108



# 開啟第一個攝影機，需要確認攝影機是否已經開啟。
cap = cv2.VideoCapture(0) 
# 設置攝影機畫面的比例。
cv2.namedWindow('video', cv2.WINDOW_AUTOSIZE) 
# 設置長寬比
ratio = cap.get(cv2.CAP_PROP_FRAME_WIDTH) / cap.get(cv2.CAP_PROP_FRAME_HEIGHT) 
# 用來動態設置畫面大小並且維持視窗比例
WIDTH = 400 
HEIGHT = int(WIDTH / ratio)
while True: 
    # 開啟攝影機，傳回兩個值，第一個是bool，第二個攝影機內容。
    ret, frame = cap.read() 
    # 設置畫面大小。
    frame = cv2.resize(frame, (WIDTH, HEIGHT))
    # 水平方向左右對調，預設畫面會左右相反
    frame = cv2.flip(frame, 1)
    # 視窗名字, 視窗內容
    cv2.imshow('video', frame) 
    # 離開視窗
    if cv2.waitKey(1) == ESC:
        cv2.destroyAllWindows()
        break

    # 拍照
    elif cv2.waitKey(1) == save:
        cv2.imwrite("my.jpg", frame)
        
        
    # 開啟照片
    elif cv2.waitKey(1) == load:
        frame2 = cv2.imread('my.jpg', 1)
        cv2.namedWindow('image', cv2.WINDOW_NORMAL)
        cv2.imshow('image', frame2)
```



## 計算FPS

- [Epoch Timer]





cd /var/log

ls -l

sudo rm name

sudo touch name

