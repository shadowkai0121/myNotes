## 型態

- null

	```js
	var a = null;
	console.log(a) // null
	console.log(a * 1) // 0
	console.log(null + 1) // 1
	```

- undefined

	```js
	var a;
	console.log(a) // undefined
	console.log(b) // error: b is not defined
	console.log(a * 1) // NaN
	
	function test(){
	    return;
	}
	console.log(test()); // undefined
	
	var o = {};
	console.log(o.x) // undefined
	console.log(o.x.x) // error: Cannot read property 'x' of undefined
	```

- boolean

  - Falsy Values

    ```js
    console.log(Boolean(falsyValues)) // false
    ```

    - ""
    - 0
    - null
    - undefined
    - NaN
    - false

  - Truthy Values

    ```js
    console.log(Boolean(truthyValues)) // true
    ```

    - 'some string'
    - 1
    - []
    - function(){}

- number

	> number 本身是浮點數

	```js
	console.log(0.2 + 0.1 == 0.3) // false
	console.log(0.2 + 0.1) // 0.30000000000000004
	var x = 0377; // 8bit寫法
	var y = 0xFF; // 16bit寫法
	console.log(x + "," + y) // 255,255
	```

- string

	```js
	// 字串相加
	console.log(1 + "2") // 12
	console.log(4 + 5 + "px") // 9px
	console.log("$" + 4 + 5) // $45
	// 除了 + 以外的會轉回數字計算
	console.log("" + 1 + 0) // 10
	console.log("" - 1 + 0) // -1
	console.log("2" * "3") // 6
	// 無法轉為數字會成為 Not a Number
	console.log("4px" - 2) // NaN
	// 字串中含有跳脫字元
	console.log("-9\n\t\\" + 5) // -9 \5
	// 跳脫字元被省略掉
	console.log("-9\n\t\\" - 5) // -14
	
	```

- object

	```js
	var a = {}; // 物件可指定屬性
	a.x = 10;
	console.log(a.x); // 10
	
	var a = []; // 陣列;
	```

- symbol

	> 表示獨一無二的值，確保屬性名稱不會與其他屬性產生衝突。

	```js
	var o = [];
	var idx = Symbol();
	o[idx] = "Hello";
	console.log(o[idx]); // Hello
	```

### 檢測型態

- typeof

	```js
	typeof 0 // number
	typeof true // boolean
	typeof 'hello' // string
	typeof Math // object
	typeof null // object
	typeof Symbol('hi') // symbol
	```

### by Value or by Reference

- 只有 object 是 call by reference

	``` js
	// call by value
	var a = 2;
	var b = a;
	b++;
	console.log(a + ", " + b); // 2, 3
	
	// call by reference
	var c = [1, 2, 3];
	var d = c;
	d.push(4);
	console.log(c); // [1, 2, 3, 4]
	console.log(d); // [1, 2, 3, 4]
	// c 與 d 為相同位址但與新宣告的 e 不同
	var e = [1, 2, 3, 4]
	console.log(c == d) // true
	console.log(c == e) // false
	console.log(c == c.slice()) // false
	```

	