using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 泛型
{
    class MyTest<T>
    {
        private T[] items = new T[3];
        private int index = 0;
        //向数组中添加项
        public void Adds(T t)
        {
            if (index < 3)
            {
                items[index] = t;
                index++;
            }
            else
            {
                Console.WriteLine("数组已满！");
            }
        }

        //读取数组中的全部项
        public void Show()
        {
            foreach(T t in items)
            {
                Console.WriteLine(t);
            }
        }
    }
}
