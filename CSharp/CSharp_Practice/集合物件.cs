using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//===集合===
using System.Collections;

namespace _20190408
{
    class Program
    {
        //enum 列舉名稱{}
        enum month
        { Jan = 1, Feb, Mar, Apr }; //指定首項、後續會自動順延。

        static void printList(List<int> inputList)
        {
            Console.WriteLine("===============================");
            foreach (int item in inputList)
            {
                Console.WriteLine($"List => {item}");
            }
        }

        static void Main(string[] args)
        {
            //集合：如果是相同資料型態，但長度不固定的情況下可以採用List<>。
            //List<資料型態> 名稱 = new List<資料型態>();
            List<int> lis = new List<int>();
            lis.Add(1);// 0
            lis.Add(2);// 1
            lis.Add(3);// 2
            //lis[3] = 4; //List透過Add設值才有記憶體位址
            foreach (int item in lis)
            {
                Console.WriteLine($"List => {item}");
            }

            lis[0] = 99; //已有lis[0]的空間，所以能直接修改。
            lis.Add(4);
            lis.Add(5);
            //foreach (int item in lis)
            //{
            //    Console.WriteLine($"List => {item}");
            //}

            printList(lis);

            //尋找 & 刪除 & 插入 
            int pos = lis.IndexOf(2);
            Console.WriteLine($" lis.IndexOf(2) =>{pos}");

            lis.RemoveAt(pos); //index的概念
            lis.Remove(3);
            //去除掉2、3
            printList(lis);

            lis.Insert(lis.IndexOf(5), 88); // 5前面插入88
            printList(lis);

            //集合：如果是*不同*資料型態，但長度*不固定*的情況下可以採用ArrayList。
            //ArrayList 集合名稱 = new ArrayList();
            ArrayList arL = new ArrayList();
            arL.Add(1);
            arL.Add("apple");
            foreach (var item in arL) //var包括所有類型資料
            {
                Console.WriteLine($"ArrayList => {item}");
            }

            //Dictionary<key的資料型態, value的資料型態> 名稱 = new Dictonary<key的資料型態, value的資料型態>();
            Dictionary<string, string> dc = new Dictionary<string, string>();
            dc.Add("L", "Large"); //如果KEY是L的話希望被翻譯成Large
            dc.Add("M", "Medium");
            dc.Add("S", "Small");
            //Dictionary巡覽必須使用KeyValuePair<key資料型態, value資料型態>
            foreach (KeyValuePair<string, string> item in dc)
            {
                Console.WriteLine($"item.key, item.value => { item.Key}, { item.Value}");
            }
            //只想知道dc裡面的KEY有哪些
            foreach (var item in dc.Keys)
            {
                Console.WriteLine($"key => { item}");
            }
            foreach (var item in dc.Values)
            {
                Console.WriteLine($"value => { item}");
            }
            Console.WriteLine("==================================");

            //數量
            Console.WriteLine($"dc.Count => {dc.Count}");
            //尋找
            Console.WriteLine($"dc.ContainsKey('Z') =>{dc.ContainsKey("Z")}");
            Console.WriteLine($"dc.ContainsValue('small') =>{dc.ContainsValue("small")}");
            //大小寫有影響
            Console.WriteLine($"dc.ContainsValue('Small') =>{dc.ContainsValue("Small")}");

            //判斷是否存在
            string result = "";
            bool flag = dc.TryGetValue("L", out result);
            Console.WriteLine($"dc.TryGetValue('L', out result) => {flag}, {result}");

            //Hashtable：不確定字典的資料型態時使用。
            Hashtable ht = new Hashtable();
            ht.Add(1, "Hello-1");
            ht.Add("Hello-2", 2);
            //ht.Add(1, "Hello-3"); //key不能重複
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine($"item.key, item.value => {item.Key}, {item.Value}");
            }
            Console.WriteLine("==========================");

            //enum 列舉：依照變數名稱給予常數，每一個項目在列舉中的基礎類型都是int。
            DateTime d = new DateTime();
            d = DateTime.Today;
            Console.WriteLine(d);
            Console.WriteLine($"{month.Apr}");
            Console.WriteLine($"{(int)month.Apr}");


            Console.ReadKey();
        }
    }
}
