using System;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;

namespace CShap40
{
    class DynamicPerson : DynamicObject 
    {
        public Dictionary<string, object> props = new Dictionary<string, object>();
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result) 
        {
            for (int i = 0; i < args.Length; i++) {
                var key = binder.CallInfo.ArgumentNames[i];
                props.Add(key, args[i]);
            }
            result = this;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) 
        {
            var key = binder.Name;
            if (props.ContainsKey(key)) {
                result = props[key];
                return true;
            }
            result = null;
            return false;
        }
     
    
    }
}