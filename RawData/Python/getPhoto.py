import cv2

esc = 27
cam = cv2.VideoCapture(0)
cv2.namedWindow('frame', cv2.WINDOW_AUTOSIZE)
ratio = cam.get(cv2.CAP_PROP_FRAME_WIDTH)/ cam.get(cv2.CAP_PROP_FRAME_HEIGHT)

WIDTH = 400
HEIGHT = int(WIDTH/ratio)

while True:
    ret, frame = cam.read()
    frame = cv2.resize(frame, (WIDTH, HEIGHT))
    frame = cv2.flip(frame, 1)

    cv2.imshow('frame', frame)

    if cv2.waitKey(1)== esc:
        cv2.destroyAllWindows()
        break