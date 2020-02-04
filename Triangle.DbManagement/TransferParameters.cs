using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle.DbManagement
{
    public class TransferParameters
    {

        private Dictionary<string, object> parameters;


        public TransferParameters()
        {
            this.parameters = new Dictionary<string, object>();
        }


        public void Add(string parameterName, object value)
        {
            if (!this.parameters.ContainsKey(parameterName))
            {
                this.parameters.Add(parameterName, value);
            }
            else
            {
                this.parameters[parameterName] = value;
            }
        }


        public void Remove(string parameterName)
        {
            if (this.parameters.ContainsKey(parameterName))
            {
                this.parameters.Remove(parameterName);
            }
        }


        public object ReadValue(string parameterName)
        {
            if (this.parameters.ContainsKey(parameterName))
            {
                return this.parameters[parameterName];
            }

            return new object();
        }
    }
}
