using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LazyCLI
{
    public class CLI
    {
        public static void HandleArgs(string[] args)
        {
            Assembly a = Assembly.GetCallingAssembly();
            Type[] types = a.GetTypes();
            List<string> arguments = new List<string>(args);

            foreach (Type t in types)
            {
                MethodInfo[] methods = t.GetMethods();
                foreach (MethodInfo m in methods)
                {
                    MethodAttributes ma = m.Attributes;
                    var customAttr = m.GetCustomAttributes(typeof(LazyCLIAttribute), true);

                    if (customAttr.Length > 0)
                    {
                        int argsIndex = 0;
                        while (argsIndex < arguments.Count)
                        {
                            var alias = (customAttr[0] as LazyCLIAttribute).Alias;
                            List<string> newArgs = new List<string>();

                            if (alias != null &&
                                alias.Equals(arguments[argsIndex++]))
                            {
                                while (argsIndex < arguments.Count &&
                                    !arguments[argsIndex].Contains("-"))
                                {
                                    newArgs.Add(arguments[argsIndex]);
                                    argsIndex++;
                                    if (argsIndex >= arguments.Count)
                                    {
                                        break;
                                    }
                                }
                                newArgs.ForEach(s => Console.WriteLine(s));

                                m.Invoke(null, newArgs.ToArray());
                            }
                        }
                    }
                }
            }
        }
    }
}
