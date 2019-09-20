import urllib.request as urllib
import json

def FaceDetect(fileName):
    url = 'https://southeastasia.api.cognitive.microsoft.com/face/v1.0/detect'
    params= 'returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise'

    stream = None
    with open(fileName, 'rb') as f:
        stream = f.read()
    
    body = stream
    headers = {
        "Ocp-Apim-Subscription-Key": "f1f50682aed744b59461ce043b8be328",
        "Content-Type": "application/octet-stream"}
    request = urllib.Request(url+ "?"+ params, body, headers)
    response = urllib.urlopen(request)
    return response.read()

fileName = r'C:\Users\USER\Desktop\訓練圖片\test1.jpg'
text = FaceDetect(fileName)

faceIds = []
for item in json.loads(text):
    faceIds.append(item['faceId'])

url = 'https://southeastasia.api.cognitive.microsoft.com/face/v1.0/identify'
body= {
    'faceIds': faceIds,
    'personGroupId': 'kaigroup1',
    'confidenceThreshold': 0.5
}

headers = {
    "Ocp-Apim-Subscription-Key": "f1f50682aed744b59461ce043b8be328",
    "Content-Type": "application/json"
}

request = urllib.Request(url, json.dumps(body).encode('utf-8'), headers)
response = urllib.urlopen(request)

print(response.read())