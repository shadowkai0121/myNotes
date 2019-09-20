import urllib.request as urllib
import json

url ='https://eastasia.api.cognitive.microsoft.com/face/v1.0/persongroups/group11/persons'
      # group11
body = {"name": "kanna"}

headers = {"Ocp-Apim-Subscription-Key": "0d2fb9aa9f9f4f548fdd2969c355c4e2","Content-Type": "application/json"}

request = urllib.Request(url,json.dumps(body).encode('utf-8'), headers)
request.get_method = lambda: 'PUT'
response = urllib.urlopen(request)
print(response.read())