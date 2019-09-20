using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class和Stucture
{
    //一個命名空間底下可以有很多不同Class
    //class 類別名稱{}
    class DemoClass
    {
        //存取修飾詞 資料型態 欄位名稱
        public string name;

        //存取修飾詞 [static] 回傳資料型態 方法名稱() {}
        private void print()
        {

        }

        //建構函式
        //存取修飾詞 和類別同名() {}
        public DemoClass()
        {

        }
    }


    struct DemoStruct
    {
        //結構內不能初始化欄位。
        //public string name = "";
        public string name;

        public DemoStruct(string inputName) //建構子內必須初始化欄位
        {
            this.name = inputName;
        }

        private void print() { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //類別和結構
            DemoClass c1 = new DemoClass();
            c1.name = "C1 Name";
            DemoClass c2 = c1;
            c2.name = "C2 Name";

            Console.WriteLine($"c1.name =>{c1.name}");
            Console.WriteLine($"c2.name =>{c2.name}");
            // class型態是以ref存在。

            Console.WriteLine("===============================");
            DemoStruct s1;
            s1.name = "S1 Name";
            DemoStruct s2 = s1;
            s2.name = "S2 Name";
            Console.WriteLine($"S1.name =>{s1.name}");
            Console.WriteLine($"S1.name =>{s2.name}");
            //struct型態是傳值

            int a = 5;
            int b = a;
            b = 10;
            Console.WriteLine($"{a}, {b}");

            //reference type：class interface object delgate
            //value type:struct

            // CLR => Common Language Runtime
            //傳值只在Stack運作，運作也會比傳址快。
            //┌──────────┬──────────┐
            //│     Stack            Heap    │
            // DemoClass c1     ↘ 
            // DemoClass c2 = c1=> DemoClass
            //
            //   struct S1
            //   struct S2
            Console.ReadKey();
        }
    }
}
