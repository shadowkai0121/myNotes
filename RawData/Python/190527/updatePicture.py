import urllib.request as urllib
import json

def updateFile(file):
    url ='https://southeastasia.api.cognitive.microsoft.com/face/v1.0/persongroups/kaigroup1/persons/29d89ccf-3def-4783-a1a9-dfd0052fcfac/persistedFaces'

    headers = {"Ocp-Apim-Subscription-Key": "f1f50682aed744b59461ce043b8be328","Content-Type": "application/octet-stream"}
    stream = None
    with open(file, 'rb') as f:
        stream = f.read()

    body = stream
    request = urllib.Request(url, body, headers)
    response = urllib.urlopen(request)
    print(response.read())

for i in range(2,11):
    path = r'C:\Users\USER\Desktop\myNotes\RawData\Python\\190527\a\kanna{}.jpg'.format(i)
    updateFile(path)