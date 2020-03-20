using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace DynamicTest
{
    public class TryConvertTest
    {
        public static void RunTest()
        {
            dynamic @dynamic = new DynamicTest(){Value = 4, Text = "Four"};

            //Note que basta con que uno este marcado con dynamic para que se realice un enlaca tardio 
            Console.WriteLine("------------------Trasformacion Implicita con Reflection-----------------");
            int testImplicit = @dynamic;
            Console.WriteLine($"dynamic == {testImplicit}");
            Console.WriteLine("------------------Trasformacion Explicita sin Reflection-----------------");
            string testExplicit = (string)@dynamic;
            Console.WriteLine($"dynamic == {testExplicit}");
        }

        class DynamicTest : DynamicObject
        {
            public  int Value {get;set;}
            public string Text {get;set;}
            public override bool TryConvert(ConvertBinder binder, out object result)
            {
                if(binder.Type == typeof(string))
                {
                    result = this.Text;
                    return true;
                } 
                else
                {
                    foreach (PropertyInfo item in this.GetType().GetProperties())
                    {
                        Console.WriteLine($"{binder.Type } : {item.PropertyType}"); 
                        if(binder.Type == item.PropertyType)
                        {
                            result = item.GetValue(this);
                            return true;
                        }
                    }
                }
                result = null;
                return false;
                
            }

        }
    }
}