using System.Collections.Generic;
using System.Linq;

namespace BinksDisassembler.Tools
{
    public class StringFormatter
    {
        public string Value {get;set;}

        public Dictionary<string, object> Parameters {get;set;}

        public StringFormatter(string value){
            Value = value;
            Parameters = new Dictionary<string, object>();
        }

        public void Add(string key, object val){
            Parameters[key] = val;
        }

        public override string ToString(){
            return Parameters.Aggregate(Value, (current, parameter)=> current.Replace(parameter.Key, parameter.Value.ToString()));
        }
    }
}