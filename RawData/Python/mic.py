#coding=utf-8
import speech_recognition as sr
bgsound = 3
r = sr.Recognizer()
# 從麥克風取得聲音訊號
with sr.Microphone() as source:
    print("環境聲音偵測中，請等{0}秒。".format(bgsound))
    r.adjust_for_ambient_noise(source, duration=bgsound)
    print("現在開始說些什麼...")    
    audio = r.listen(source)
try:
    text = r.recognize_google(audio, language="zh-TW")
    print("Google的辨識結果為：")
    print(text)
except sr.UnknownValueError:
    print("Google聽不懂你說什麼。")
except sr.RequestError as e:
    print("Google辨識引擎無回應，錯誤訊息為： {0}".format(e))