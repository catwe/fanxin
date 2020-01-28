using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、分别创建一个 int 的可空类型变量和 double 的可空类型变量，
            //并使用 HasValue 属性判断其值是否为空。
            int? i = null;
            double? d = 3.14;
            if (i.HasValue)
            {
                Console.WriteLine("i的值为：{0}", i);
            }
            else
            {
                Console.WriteLine("i的值为空！");
            }

            if (d.HasValue)
            {
                Console.WriteLine("d的值为：{0}",d);
            }
            else
            {
                Console.WriteLine("d的值为空！");
            }


            /*
             * 2、
             创建泛型方法，实现对两个数的求和运算。
             */
            Add<double>(3.2,5);//调用方法
            Add<int>(9, 6);

            //创建实例
            MyTest<int> myTest = new MyTest<int>();
            myTest.Adds(5);
            myTest.Adds(6);
            myTest.Adds(7);
            myTest.Show();



            /*
             
            3、 使用泛型集合 List<T> 实现对学生信息的添加和遍历。
            将学生信息定义为一个类，并在该类中定义学号、姓名、年龄属性。
            在泛型集合 List<T> 中添加学生信息类的对象，并遍历该集合。
             */
            //定义泛型集合
            List<Student> list = new List<Student>();
            //向集合中存入3名学员
            list.Add(new Student(1, "小张", 18));
            list.Add(new Student(1, "小王", 19));
            list.Add(new Student(1, "小李", 26));
            list.Sort();//按照从大到小排列
            //遍历集合中的元素
            foreach(Student Stu in list)
            {
                Console.WriteLine(Stu);
            }



            /*
             使用泛型集合 Dictionary<K,V> 实现学生信息的添加，并能够按照学号查询学生信息。
             */
            Dictionary<int, Student> dictionary = new Dictionary<int, Student>();
            Student stu1 = new Student(1, "小明", 20);
            Student stu2 = new Student(2, "小李", 21);
            Student stu3 = new Student(3, "小赵", 22);
            dictionary.Add(stu1.id,stu1);
            dictionary.Add(stu2.id, stu2);
            dictionary.Add(stu3.id, stu3);
            Console.WriteLine("请输入学号：");
            int id = int.Parse(Console.ReadLine());
            if (dictionary.ContainsKey(id))
            {
                Console.WriteLine("学生信息为：{0}", dictionary[id]);
            }
            else
            {
                Console.WriteLine("您查找的学号不存在。");
            }


            /*
             将学生信息按照年龄从大到小输出。
             */




            Console.ReadLine();
        }

        private static void Add<T>(T a,T b)
        {
            double sum = double.Parse(a.ToString()) + double.Parse(b.ToString());
            Console.WriteLine(a + "+" + b + "=" + sum);
        }
    }

    //学生类
    class Student : IComparable<Student>
    {
        //id
        public int id{get;set;}
        //姓名
        public string name { get; set; }
        //年龄
        private int age { get; set; }
        //提供有参构造方法，为属性赋值
        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return id + ":" + name + ":" + age;
        }

        //定义比较方法，按照学生的年龄比较
        public int CompareTo(Student other)
        {
            if (this.age > other.age)
            {
                return -1;
            }
            return 1;
        }

    }
}
