## 爬蟲


```python
	import re
	# 網頁互動函式庫
	import urllib.request as url
	
	response = url.urlopen('https://www.etax.nat.gov.tw/etw-main/web/ETW183W2_10801/')
	text = response.read().decode('utf-8')
	pattern = '<th id="specialPrize" rowspan="2">(.+?)</th>(.*|\s*)<td headers="specialPrize" class="number">(.+?)</td>'
	match = re.search(pattern, text)
	
	print("{}: {}".format(match.group(1), match.group(3).strip()))
	# output: 特別獎: 00106725
```