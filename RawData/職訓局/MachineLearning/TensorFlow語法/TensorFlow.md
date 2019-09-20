### TensorFlow語法

```javascript
import tensorflow as tf;
```
- 宣告

  - 指定資料型態
  	
    - 使用shape轉換一維陣列

      ```javascript
              // 2x3 的張量
              const shape = [2, 3]; // 2 行 3 列
              const a = tf.tensor([1.0, 2.0, 3.0, 10.0, 20.0, 30.0], shape);
              // 輸出： [[1 , 2 , 3 ],
              //        [10, 20, 30]]
      ```
      
    - 預先處理好陣列
      
      ```javascript
              const b = tf.tensor([[1.0, 2.0, 3.0], [10.0, 20.0, 30.0]]);
              // 輸出： [[1 , 2 , 3 ],
              //        [10, 20, 30]]
      ```
      
    - 直接使用陣列
      
      ```javascript
              var arr = new Array([1.0, 2.0, 3.0], [10.0, 20.0, 30.0]);
              const c = tf.tensor(arr);
              // 輸出： [[1 , 2 , 3 ],
              //        [10, 20, 30]]
      ```
  	
  - 指定tensor型態
  	- scalar
		  ```js
      				 const x = tf.scalar(3.14);
	          	  // 輸出: 3.14
      ```
    - tensor2d
      
      ```javascript
        	      const c = tf.tensor2d([[1.0, 2.0, 3.0], [10.0, 20.0, 30.0]]);
	  	 	        // 輸出： [[1 , 2 , 3 ],
      	        //        [10, 20, 30]]
  		```
  	
	  - zeros
    
      ```javascript
              // 2x3 張量，值都為 0
              const zeros = tf.zeros([2, 3]);
              // 輸出： [[0, 0, 0],
              //        [0, 0, 0]]
      ```
  
  	- ones
  	
  	  ```javascript
  	  				tf.ones([2, 3], tf.int32)  
		  				//輸出: [[1, 1, 1], 
  	          //			 [1, 1, 1]]
  		```
  - 變量
  
    - variable
    
      ```javascript
              const initialValues = tf.zeros([5]);
              // 初始化偏差
              const biases = tf.variable(initialValues);
              // 輸出： [0, 0, 0, 0, 0]
      ```
  
    - assign
    
      ```javascript
              const updatedValues = tf.tensor1d([0, 1, 0, 1, 0]);
              // 更改偏差的值
              biases.assign(updatedValues); 
              // 輸出： [0, 1, 0, 1, 0]
  		```
  
  - operator
  
    - square
    
      ```javascript
              const d = tf.tensor2d([[1.0, 2.0], [3.0, 4.0]]);
              const d_squared = d.square();
              // 輸出： [[1, 4 ],
              //        [9, 16]]
      ```
    
    - add
    
      ```javascript
              const e = tf.tensor2d([[1.0, 2.0], [3.0, 4.0]]);
              const f = tf.tensor2d([[5.0, 6.0], [7.0, 8.0]]);
              const e_plus_f = e.add(f);
              // 輸出： [[6 , 8 ],
              //        [10, 12]]
      ```
    
    - sub
    
      ```javascript
              const g = tf.tensor2d([[1.0, 2.0], [3.0, 4.0]]);
              const h = tf.tensor2d([[5.0, 6.0], [7.0, 8.0]]);
              const g_sub_h = g.sub(h);
              // 輸出： [[-4, -4],
              //        [-4, -4]]
      ```
    
    - mul
    
      ```javascript
              const i = tf.tensor2d([[1.0, 2.0], [3.0, 4.0]]);
              const j = tf.tensor2d([[5.0, 6.0], [7.0, 8.0]]);
              const i_mul_j = i.mul(j);
              // 輸出： [[5, 12],
              //        [21, 32]]
      ```
      
    - matMul
    
      ```javascript
              const x = tf.tensor2d([1, 2], [1, 2]);
              const y = tf.tensor2d([1, 2, 3, 4], [2, 2]);
              const ans = x.matMul(y);  // or tf.matMul(x, y)
              // 輸出: [[7, 10],]
      ```
    
    - 多重運算
    
      ```javascript
              const e = tf.tensor2d([[1.0, 2.0], [3.0, 4.0]]);
              const f = tf.tensor2d([[5.0, 6.0], [7.0, 8.0]]);
              const sq_sum = e.add(f).square();
              // 輸出： [[36 , 64 ],
              //        [100, 144]]
      ```
  
  - model
  
    - 預測函數
    
      ```javascript
              // 定義函數
              function predict(input) {
                  // y = a * x ^ 2 + b * x + c
                  // 下個部分會再詳細講 tf.tify
                  return tf.tidy(() => {
                      const x = tf.scalar(input);
      
                      const ax2 = a.mul(x.square());
                      const bx = b.mul(x);
                      const y = ax2.add(bx).add(c);
      
                      return y;
                  });
              }
      
              // 定義係數： y = 2x^2 + 4x + 8
              const a = tf.scalar(2);
              const b = tf.scalar(4);
              const c = tf.scalar(8);
      
              // 輸入 2 ，預測輸出
              const result = predict(2);
              // 輸出：24
      ```
    
    - layer
    
      ```javascript
              // sequential是一種一層接一層的神經網路
              const model = tf.sequential();
              // 設置隱藏層
              const config_hidden = {
                  inputShape: [3],
                  activation: 'sigmoid',
                  units: 4
              }
              // 設置輸出層
              const config_output = {
                  units: 2,
                  activation: 'sigmoid'
              }
              // 定義隱藏層及輸出層
              // tf.layers.dense(設定);
              const hidden = tf.layers.dense(config_hidden);
              const output = tf.layers.dense(config_output);
              // 將 layer 輸入至 model
              model.add(hidden);
              model.add(output);
      ```
    
    - optimizer與梯度下降
    
      ```javascript
              // 定義最佳化引擎
              // tf.train.sgd 為梯度下降計算
              const optimize = tf.train.sgd(0.1);
              // 模型設定
              const config = {
                  optimizer: optimize,
                  loss: 'meanSquaredError'
              }
              // 編譯模型
              model.compile(config);
              console.log('Model Successfully Compiled');
      ```
    
    - 資料處理
    
      ```javascript
          	  //Dummy training data
              const x_train = tf.tensor([
                  [0.1, 0.5, 0.1],
                  [0.9, 0.3, 0.4],
                  [0.4, 0.5, 0.5],
                  [0.7, 0.1, 0.9]
              ])
              //Dummy training labels
              const y_train = tf.tensor([
                  [0.2, 0.8],
                  [0.9, 0.10],
                  [0.4, 0.6],
                  [0.5, 0.5]
              ])
              //Dummy testing data
              const x_test = tf.tensor([
                  [0.9, 0.1, 0.5]
              ])
      ```
    
    - 評估
    
      ```javascript
              train_data().then(function () {
                  console.log('Training is Complete');
                  console.log('Predictions :');
                  model.predict(x_test).print();
              })
              async function train_data() {
                  for (let i = 0; i < 10; i++) {
                      const res = await model.fit(x_train, y_train, epoch = 1000, batch_size = 10);
                      console.log(res.history.loss[0]);
                  }
              }
      ```
  
  - 資源管理
  
    - tidy()
    
      ```javascript
              // tf.tidy() 執行一個方法，並在最後清理它。
              const average = tf.tidy(() => {
            // tf.tidy 會清理這方法內所有被張量用掉的記憶體，除了需要的張量以外。
              // 即使是像下面的簡單操作，一些中間產物張量也會產生。所以保持簡潔的數學運算是很重要的。
                const y = tf.tensor1d([1.0, 2.0, 3.0, 4.0]);
                  const z = tf.ones([4]);
      
                  return y.sub(z).square().mean();
              });
      
              // 輸出： 3.5
      ```
    
    - dispose()
    
      ```javascript
              const x = tf.tensor2d([[0.0, 2.0], [4.0, 6.0]]);
              const x_squared = x.square();
      
              debug.innerText = x;
      
              x.dispose();
              x_squared.dispose();
              
              // Uncaught Error: Tensor is disposed.
              debug2.innerText = x;
      ```