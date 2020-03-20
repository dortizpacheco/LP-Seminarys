using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace DynamicTest
{
    public class TryMemberTest
    {
        public static void RunTest()
        {
            dynamic @dynamic = new DynamicTest();
            @dynamic.String = "string";
            Console.WriteLine(@dynamic.String);         
        }

        class DynamicTest : DynamicObject
        {
            Dictionary<string,object> dictionary = new Dictionary<string, object>();
            //del sampleObject.SampleMember
            public override bool TryDeleteMember(DeleteMemberBinder binder)
            {
                return base.TryDeleteMember(binder);
            }


            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dictionary[binder.Name] = value;
                return true;
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                return dictionary.TryGetValue(binder.Name, out result);
            }    
        }
    }
}