## 台灣地圖製作

~~*困難點在轉換檔案格式*~~

- 取得台灣地圖資料

	- [縣市](<https://data.gov.tw/dataset/7442>)
	- [鄉鎮市區](<https://data.gov.tw/dataset/7441>)
	- [村里](<https://data.gov.tw/dataset/7440>)

- 將shp檔案轉成為topojson

	> D3.js不支援shp格式

	- [mapshaper](<https://mapshaper.org/>)

- 使用D3.js讀取地圖資料並產生投影

- 從後端取得資料庫數據傳送給D3.js

- 將數據轉化成對應色階繪製顏色

- 加入圖例與Tooltip

## Reference

- [shp to topojson](<https://mapshaper.org/?fbclid=IwAR0_sLNUJLqpi7gsAoa-1AyNWlZGZYpsxFvRstQBGTi4TGV8NWl3RQyfeOQ>)
- [如何用 D3.js 繪製地圖](<http://blog.maxkit.com.tw/2016/06/d3js.html>)
- [視覺化實戰 － D3.js 地理區塊視覺化](<http://blog.infographics.tw/2015/04/visualize-geographics-with-d3js/>)
- [TaiwanMap](<https://github.com/aobichen/taiwanmap>)

