using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imageColorTrun
{
    //class,interface,instance class
    class MyGenericArray<T> where T : struct//该泛型T不能用string，因为不是引用类型，是值类型
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size];
        }
        public T GetItem(int index)
        {
            return array[index];
        }
        public void SetItem(int index, T value)
        {
            array[index] = value;
        }
        public  void GenMothe<X>(X x)
        {

        }
    }

    public class setMean
    {
        void g()
        {
            MyGenericArray<int> mg = new MyGenericArray<int>(5);
            for(int i = 0; i < 5; i++)
            {
                mg.SetItem(i,i * 2);
            }
            for(int i = 0; i < 5; i++)
            {
                mg.GetItem(i);
            }
            MyGenericArray<char> mg1 = new MyGenericArray<char>(5);
            for (int i = 0; i < 5; i++)
            {
                mg1.SetItem(i, (char)(i+97));
            }
            for (int i = 0; i < 5; i++)
            {
                mg1.GetItem(i);
            }
            mg1.GenMothe<int>(100);
            mg.GenMothe<string>("nihao");
        }

    }
}
