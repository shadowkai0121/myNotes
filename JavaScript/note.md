- Syntax Parsers

	> 語法解析器 (編譯器、直譯器)
	>
	> 一個能夠讀取程式語言並轉譯成機器碼的程式

- Execution contexts

	> 執行環境
	>
	> 代碼執行的地方，包含所有在寫下代碼之外的東西。

	- Basef Execution Context (Global)

		> 可以在任何地方取用，由JS引擎宣告

		- Global (in JavaScript)

			> 不在函式內的變數與函數都會成為 Global Object

		- Global Object

			> JavaScript 永遠會有一個 Global Object
			>
			> 在瀏覽器是 window

		- this

			> 在瀏覽器層級下，this = window

		- Outer Enviroment

			> 每個執行環境都有一個它參照的外部環境。
			>
			> 由 Lexical Enviroment 定義它的外部是誰。
			>
			> 如果你需要的執行環境內找不到變數，會向外尋找符合的變數。

		- arguments

			> 包含所有傳入到呼叫函數的值，動作和陣列相似但是並不是陣列，他只有一部份的陣列功能。

		- spread

	- Execution

		- 逐行執行程式碼

- Lexical Evironments

	> 詞彙環境 (作用域?)
	>
	> 代表程式碼在程式中(電腦記憶體)實際的位置，如何與其他變數、函數互動。
	>
	> "程式碼被寫在哪裡？它的周圍有甚麼？"

- Name / Value Pairs

	> 一個名稱對應到唯一的值，名稱可以被重複定義但是在一個正在執行的程式碼，同一個名稱只會有一個值。
	>
	> 值可以是另一個鍵值對 (成為物件)

	```js
	// Name/Value Pair
	Address = "100 Main St."
	```

- Objects

	> 鍵值對的組合

	```js
	// A collection of Name/Value Pairs
	Address = {
	    Street: "Main",
	    Number: 100,
	    Apartment: {
	        Floor:3,
	        Number:301
	    }
	}
	```

- Creation

	> 建構執行環境，執行時產生全域物件、this、Outer Environment

- Hoisting

	> 為變數與函數設定記憶體位置，在逐行執行之前，JS程式已經存在記憶體中了。
	>
	> 所有的變數在此時都會先被設置為「undefined」

- Undefined

	> 是一個特殊值，會占用記憶體空間。
	>
	> 如˙果主動設置值為 undefined 的話會造成無法分辨是自己設定還是JS設定的混亂。

- invocation

	> 執行函式
	>
	> JavaScript 在單字後面加上()代表呼叫函式
	>
	> 所有函式都會創造一個執行環境

- Variable Environment

	> 創造變數的位置，還有他與其他變數在記憶體中的關係。
	>
	> 每個執行環境都有自己的變數環境。

- Scope Chain

	> 變數能夠被取用的地方。
	>
	> 是外部參照的連結。

- Operator

	> 是一種特殊函數

- Coercion

	> 將一個數值從一個型別轉換至另一個

- 預設值

	> 利用型別轉換的特性設定空字串或undefined時的預設值。

	```js
	function greet(name){
	    name = name || "<Your Name>"
	    console.log("Hello, " + name)
	}
	```

- NameSpace

	> 變數與函數的容器，JS本身並沒有這個功能。
	>
	> 使用 { } 達成命名空間的效果。

- First class function

	> 所有針對資料型態做的事情都可以作用在函式上，同時可以具有屬性與方法。

	- Primitive

	- Object

	- Function

	- Name

	- Code

		> Code 在 JS Function 中是一種屬性

- mutate

	> 改變某些東西

- Array

	> 任何東西的集合

- 分號

	```js
	// return 會受到自動插入分號導致 firname未定義
	function getPerson(){
	    return // ;
	    {
	        firstname: "kai"
	    }
	}
	
	// 避免自動插入分號的問題，大括號應該盡量不要換行
	function getPerson(){
	    return {
	        firstname: "kai"
	    }
	}
	```

- IIFE (Immediately Invoked Function Expressions)

	> 在函數表達式之後加上() 使函式在創造之後立即執行。

	```js
	var greeting = function(name){
	    console.log("Hello " + name);
	}();
	// 傳入參數
	var greeting = function(name){
	    console.log("Hello " + name);
	}("Kai");
	// 匿名函式IIFE
	// function 匿名時不能在開頭，使用()群組讓JS引擎知道這是個引擎，然後在最後使用()執行IIFE
	var firstname = "kai";
	(function(name) {
	    console.log("Hello " + name);
	}(firstname));
	// output: Hello kai
	```

	

- Closures (閉包)

	> 一般情況下，執行環境結束之後記憶體的空間會進行GC。
	>
	> JS引擎會自動將所有需要參照的變數留下，成為閉包。

	```js
	function greet(whattosay){
	    return function(name){
	        console.log(whattosay + " " + name);
	    }
	}
	
	greet("hi")("Kai");
	```

	```js
	function buildFunction(){
	    var arr = [];
	    for (var i = 0; i < 3; i++){
	        arr.push(
	        	function(){
	                console.log(i);
	            }
	        );
	    }
	}
	
	var fs = buildFunctions();
	fs[0]();
	fs[1]();
	fs[2]();
	// output: 3 3 3
	```

	

- Callback

	> 執行 A 結束之後在執行另一個你給的函式B

	```js
	// function() 在 setTimeout結束之後才執行
	setTimeout(function() {
	    
	}, 3000);
	```



- function

	> 所有 function 都有以下三種方法，可以控制 this 指向的物件。

	- call()

		> 執行程式並且控制 this 的指向

		```js
		var person = {
		    firstname: "Kai",
		    lastname: "Hsieh",
		    getFullName: function() {
		        var fullname = this.firstname + " " + this.lastname;
		        return fullname;
		    }
		}
		
		var who = function() {
		    console.log(this.getFullName());
		}
		
		// logName();
		// Error: this 指向 window
		
		// 使用 call 將 this 指向 person 並且執行 logName
		who.call(person, 'en', 'es');
		```

	- apply()

		> 與 call 相同，差別在只接受陣列作為參數。

		```js
		logName.apply(person, ['en', 'es']);
		```

		

	- bind()

		> 產生指定物件的複製

		```js
		var person = {
		    firstname: "Kai",
		    lastname: "Hsieh",
		    getFullName: function() {
		        var fullname = this.firstname + " " + this.lastname;
		        return fullname;
		    }
		}
		
		var logName = function() {
		    console.log("Logged: " + this.getFullName());
		}
		
		// logName();
		// Error: this 指向 window
		
		// 使用 bind 將 this 指向 person
		var logPersonName = logName.bind(person);
		logPersonName();
		
		// 簡化版
		var logName = function() {
		    console.log("Logged: " + this.getFullName());
		}.bind(person);
		```

- Function currying

	> 建立一個函數的拷貝並且設定預設參數

- Functional Programming

- Inheritance

	> 一個物件取用另一個物件的屬性或方法

	- Classical Inheritance

		> 不停擴展程式最終可能出現非常大又錯綜複雜的東西，造成的問題像是蓋了間錯綜複雜的房子結果要換個燈泡造成馬桶開始沖水。

	- Prototype Inheritance

		> 專精於分享屬性或方法。

		- Prototype

			> 所有物件都具有 \__proto__ 物件，在物件本身不具有屬性或方法時，JS引擎會往 proto 物件裡面找。
			>
			> Proto 物件可以再具有 proto 物件。(Prototype chain)
			>
			> 物件可以分享同一個 proto

- reflection

	> 物件可以看到自己的成員並且改變他。藉此達成 Extend

- function constructors

	> JS 使用 new 與函式作為物件的建構子，新瀏覽器使用 object.create() 替代

	- Object.create()

		```js
		// polyfill
		// 確認瀏覽器是否有 Object.create 功能
		if (!Object.create){
		    Object.create = function(o) {
		        if (arguments.length > 1){
		            throw new Error("Object.create implementation only accepts the first parameter.")
		        }
		        function F(){};
		        F.prototype = o;
		        return new F();
		    };
		}
		
		var person = {
		    firstname: "Default",
		    lastname: "Default",
		    greet: function(){
		        return "Hi " + this.firstname;
		    }
		}
		
		var john = Object.create(person);
		john.firstname = "John";
		john.lastname = "Doe";
		console.log(john.greet());
		```

		

- polyfill

	> 將JS引擎缺少的功能增加到程式中。

- method chaining

	> obj.method1().method2();
	>
	> 在方法的最後 return this 達成效果。
	>
	> 需要所有的東西都在同一個原型鍊上

- 

## Libery

- 命名
- 需求
- 重複利用
- 簡單使用
- 支援其他函式庫

### Do

- 建立環境

	> 主要在Greetr.js 裡面工作，建立一個新的執行環境(IIFE)確保所有變數都是安全的。
	>
	> 需要全域使用的物件就交到window底下

	```html
	<!DOCTYPE html>
	<html lang="en">
	<head>
	    <meta charset="UTF-8">
	    <meta name="viewport" content="width=device-width, initial-scale=1.0">
	    <meta http-equiv="X-UA-Compatible" content="ie=edge">
	    <title>Document</title>
	</head>
	<body>
	   
	    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js'></script>
	    <script src="Greetr.js"></script>
	    <script src="app.js"></script>
	</body>
	</html>
	```

- 撰寫程式

	- 建立執行環境

		> 需要與全域與jQuery物件互動所以需要傳入這兩項物件

		```js
		(function(global, $){
		    
		}(window, jQuery))
		```

	- 