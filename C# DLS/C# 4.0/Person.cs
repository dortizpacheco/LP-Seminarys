using System;
using System.Dynamic;
using System.Reflection;
using System.Collections.Generic;

namespace CShap40
{
    class Person : DynamicObject 
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
        public override bool TrySetMember(SetMemberBinder binder, object value) 
        {
            var key = binder.Name;
            if (props.ContainsKey(key))
                props[key] = value;
            else
                props.Add(key, value);
            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result) 
        {
            if (indexes.Length != 1)
                throw new IndexOutOfRangeException();
            var key = indexes[0].ToString();
            if (props.ContainsKey(key)) {
                result = props[key];
                return true;
            }
            result = null;
            return false;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value) 
        {
            if (indexes.Length != 1)
                throw new IndexOutOfRangeException();
            var key = indexes[0].ToString();
            if (props.ContainsKey(key))
                props[key] = value;
            else
                props.Add(key, value);
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) 
        {
            var key = binder.Name;
            if (props.ContainsKey(key)) {
                if (args.Length > 1)
                    props[key] = args;
                else
                    props[key] = args[0];
            }
            else {
                if (args.Length > 1)
                    props.Add(key, args);
                else
                    props.Add(key, args[0]);
            }
            result = this;
            return true;
        }
    }
}