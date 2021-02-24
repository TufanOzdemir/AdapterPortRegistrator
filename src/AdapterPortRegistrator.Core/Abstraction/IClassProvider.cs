using System;
using System.Collections.Generic;

namespace AdapterPortRegistrator.Core.Abstraction
{
    public interface IClassProvider
    {
        Dictionary<Type, Type> RegisteredClassDictionary { get; }
        void Register(Type portAssembly, Type adapterAssembly, Type targetInterface);
    }
}