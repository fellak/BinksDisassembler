using System;
using System.Collections.Generic;
using System.Linq;

namespace BinksDisassembler.Tools
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetImplementingTypes(this Type itype) 
            => AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(itype));
    }
}