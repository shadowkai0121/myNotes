import urllib.request as urllib
import json, time
url = 'https://southeastasia.api.cognitive.microsoft.com/face/v1.0/persongroups/kaigroup1/train'
body = ''
headers = {
"Ocp-Apim-Subscription-Key": "f1f50682aed744b59461ce043b8be328",
"Content-Type": "application/json"
}
request = urllib.Request(url, json.dumps(body).encode('utf-8'), headers)
response = urllib.urlopen(request)
print(response.read()) # return empty body
# Get training status

while True:
    request = urllib.Request(url + "ing", json.dumps(body).encode('utf-8'), headers)
    request.get_method = lambda: 'GET'
    response = urllib.urlopen(request)
    text = response.read()
    print(text)
    if "succeeded" or "failed" in text:
        print('training is done.')
        break
    time.sleep(1)