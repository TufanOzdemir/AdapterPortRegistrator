using AdapterPortRegistrator.Core.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdapterPortRegistrator.Core
{
    public class ClassProvider : IClassProvider
    {
        private Lazy<Dictionary<Type, Type>> MainDictionary = new Lazy<Dictionary<Type, Type>>(() =>
        {
            var classDictionary = new Dictionary<Type, Type>();
            return classDictionary;
        });

        public Dictionary<Type, Type> RegisteredClassDictionary => MainDictionary.Value;

        public void Register(Type portType, Type adapterType, Type targetInterface)
        {
            var portTypes = portType.Assembly.GetTypes();
            var adapterTypes = adapterType.Assembly.GetTypes();
            var targetTypeName = targetInterface.Name;
            foreach (var port in portTypes)
            {
                var myInterface = port.GetInterfaces().FirstOrDefault(c => c.Name == targetTypeName);
                if (myInterface != null)
                {
                    foreach (var adapter in adapterTypes)
                    {
                        var adapterInterfaces = adapter.GetInterfaces();
                        var targetAdapterInterface = adapterInterfaces.FirstOrDefault(c => c.Name == port.Name);
                        if (targetAdapterInterface != null)
                        {
                            RegisteredClassDictionary.Add(port, adapter);
                        }
                    }
                }
            }
        }
    }
}