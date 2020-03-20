using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;

namespace DynamicTest
{
    public class TryIndexTest
    {
        public static void RunTest()
        {
            dynamic @dynamic = new DynamicTest();
            @dynamic[1,3,4,5,6,7] = 3;

            foreach (object item in @dynamic[1,2,3,4,5,6,7,8,9,0])
            {
                if(item == null) Console.Write("null, ");
                else Console.Write(item + ", ");
            }
            Console.WriteLine();
            //@dynamic[1:2];
        }

        class DynamicTest : DynamicObject
        {
            object[] a = new object[100];

            //@dynamic[1:2];
            //Nunca entra aqui pues la sintaxi de c# no lo permite
            public override bool TryDeleteIndex(DeleteIndexBinder binder, object[] indexes)
            {
                Console.WriteLine("Aqui toy");   
                return true;
            }
            public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
            {
                foreach (var item in indexes)
                {
                    if(item is int && (int)item < 100 && (int)item > -1)
                        a[(int)item] = value;
                    else return false;
                }

                return true;   
            }
            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
            {
                result = new List<object>();
                foreach (var item in indexes)
                {
                    if(item is int && (int)item < 100 && (int)item > -1)
                        ((List<object>)result).Add(a[(int)item]);
                    else return false;
                }

                return true;
            }
        
        }
    }
}