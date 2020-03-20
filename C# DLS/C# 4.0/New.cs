using System.Reflection;
using System;
using System.Dynamic;

namespace CShap40
{
    public class New: DynamicObject 
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        public override bool TryGetMember(GetMemberBinder binder, out object result) 
        {
            Type[] classes = assembly.GetTypes();
            foreach (var type in classes) {
                if (type.Name == binder.Name) {
                    result = Activator.CreateInstance(type);
                    return true;
                }
            }
            result = null;
            return false;
        }
    }
}