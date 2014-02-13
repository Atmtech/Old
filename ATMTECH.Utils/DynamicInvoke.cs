using System;
using System.Collections;
using System.Reflection;

namespace ATMTECH.Utils
{
    //    // Create an object array consisting of the parameters to the method.
    //// Make sure you get the types right or the underlying
    //// InvokeMember will not find the right method
    //Object [] args = {1, "2", 3.0};
    //Object Result = DynaInvoke("c:\FullPathToDll.DLL", 
    //                "ClassName", "MethodName", args);
    //// cast the result to the type that the method actually returned.

    public class DynamicInvoke
    {
        // this way of invoking a function
        // is slower when making multiple calls
        // because the assembly is being instantiated each time.
        // But this code is clearer as to what is going on
        public static Object InvokeMethodSlow(string assemblyName,
               string className, string methodName, Object[] args)
        {
            // load the assemly
            Assembly assembly = Assembly.LoadFrom(assemblyName);

            // Walk through each type in the assembly looking for our class
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsClass)
                {
                    if (type.FullName.EndsWith("." + className))
                    {
                        // create an instance of the object
                        object classObj = Activator.CreateInstance(type);

                        // Dynamically Invoke the method
                        object result = type.InvokeMember(methodName,
                          BindingFlags.Default | BindingFlags.InvokeMethod,
                               null,
                               classObj,
                               args);
                        return (result);
                    }
                }
            }
            throw (new Exception("could not invoke method"));
        }

        // ---------------------------------------------
        // now do it the efficient way
        // by holding references to the assembly
        // and class

        // this is an inner class which holds the class instance info
        public class DynaClassInfo
        {
            public Type _type;
            public Object _classObject;

            public DynaClassInfo()
            {
            }

            public DynaClassInfo(Type t, Object c)
            {
                _type = t;
                _classObject = c;
            }
        }


        public static Hashtable _assemblyReferences = new Hashtable();
        public static Hashtable _classReferences = new Hashtable();

        public static DynaClassInfo
               GetClassReference(string assemblyName, string className)
        {
            if (_classReferences.ContainsKey(assemblyName) == false)
            {
                Assembly assembly;
                if (_assemblyReferences.ContainsKey(assemblyName) == false)
                {
                    _assemblyReferences.Add(assemblyName,
                          assembly = Assembly.LoadFrom(assemblyName));
                }
                else
                    assembly = (Assembly)_assemblyReferences[assemblyName];

                // Walk through each type in the assembly
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass)
                    {
                        // doing it this way means that you don't have
                        // to specify the full namespace and class (just the class)
                        if (type.FullName.EndsWith("." + className))
                        {
                            DynaClassInfo ci = new DynaClassInfo(type,
                                               Activator.CreateInstance(type));
                            _classReferences.Add(assemblyName, ci);
                            return (ci);
                        }
                    }
                }
                throw (new Exception("could not instantiate class"));
            }
            return ((DynaClassInfo)_classReferences[assemblyName]);
        }

        public static Object InvokeMethod(DynaClassInfo ci,
                             string methodName, Object[] args)
        {
            // Dynamically Invoke the method
            Object result = ci._type.InvokeMember(methodName,
              BindingFlags.Default | BindingFlags.InvokeMethod,
                   null,
                   ci._classObject,
                   args);
            return (result);
        }

        // --- this is the method that you invoke ------------
        public static Object InvokeMethod(string assemblyName,
               string className, string methodName, Object[] args)
        {
            DynaClassInfo ci = GetClassReference(assemblyName, className);
            return (InvokeMethod(ci, methodName, args));
        }
    }
}
