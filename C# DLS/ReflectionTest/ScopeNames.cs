using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ReflectionTest
{
    public class ScopeNames
    {
        public static void RunTest()
        {
            int i = 6;
            int[] e = new int[12];
            for (int j = 0; j< 1; j++)
            {
                bool @break = true;
                while(@break)
                {
                    @break = false;
                    int y  = 3;
                    Action t = () => e[3] = @break? i + j + y : 0;  
                    foreach (FieldInfo type in CollectFields(t))
                    {
                        Console.WriteLine($"{type.Name} : {type.FieldType}");


                    }
                }
              
            }
        }

    public static IReadOnlyList<FieldInfo> CollectFields(Delegate instance)
    {
        // Local, recursive function to explore the closure type
        IEnumerable<FieldInfo> CollectFields(Type type)
        {
            foreach (FieldInfo field in type.GetFields())
            {
                if (field.Name.StartsWith("CS$<>")) // Nested closure type
                {
                    yield return field;
                    foreach (FieldInfo nested in CollectFields(field.FieldType))
                    {
                        yield return nested;
                    }
                }
                else yield return field;
            }
        }

        return CollectFields(instance.Target.GetType()).ToArray();
    }
    }
}