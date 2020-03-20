using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace DynamicTest
{
    public class TryInvokeTest
    {
        public static void RunTest()
        {
            dynamic @dynamic = new DynamicTest();
            @dynamic(
                Name : "aaaa",
                Count : 3

            );         
        }

        class DynamicTest : DynamicObject
        {
            public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
            {
                for (int i = 0; i < binder.CallInfo.ArgumentCount; i++)
                {
                    Console.WriteLine($"{binder.CallInfo.ArgumentNames[i]} : {args[i]} : {args[i].GetType()}");
                }

                result = null;
                return true;
            }
        }
    }
}