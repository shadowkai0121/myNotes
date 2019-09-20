import numpy as np
import cv2

# 建立512 * 512畫布, 有三色
gc = np.zeros((512,512,3), np.uint8)

# GBR色彩 255,255,255 = white
gc.fill(255)

# 從10, 50到400, 300畫一條5px的藍色直線
cv2.line(gc, (30, 50), (400, 300), (250, 0, 0), 5)

# 畫矩形，指定對角線起始點
cv2.rectangle(gc, (30, 50), (400, 300), (0, 255, 0), 3)

# 顯示文字
# 中文必須裝pillow
font = cv2.FONT_HERSHEY_COMPLEX
cv2.putText(gc, 'OpenCV', (0,400), font, 4, (0,0,0), 2, cv2.LINE_AA)

cv2.imshow("draw", gc)
cv2.waitKey(0)
cv2.destroyAllwindows()