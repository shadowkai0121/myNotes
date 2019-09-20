import urllib.request as urllib
import json
# here is your endpoint url
url ='https://southeastasia.api.cognitive.microsoft.com/face/v1.0/persongroups/kaigroup1/persons'
body = {"name": "kanna"}
headers = {"Ocp-Apim-Subscription-Key": "f1f50682aed744b59461ce043b8be328","Content-Type": "application/json"}

request = urllib.Request(url,json.dumps(body).encode('utf-8'), headers)
request.get_method = lambda: 'PUT'
response = urllib.urlopen(request)

print(response.read()) # return empty body
print("create person groups done" )