using System;

using System.Collections.Generic;



namespace TestClass

{

    public class PersonReflectionIndex

    {

        public string FirstName {get;set;}

        public string LastName {get;set;}
 
        public string this[string index]
        {
            get
            {
                foreach (var item in this.GetType().GetProperties())
                    if(item.Name == index)
                        return (string)item.GetValue(this);
                
                throw new KeyNotFoundException();
            }
            set
            {
                foreach (var item in this.GetType().GetProperties())
                    if(item.Name == index)
                    {
                        item.SetValue(this,value);
                        return ;
                    }
                
                throw new KeyNotFoundException();

            }

        }

    }
}