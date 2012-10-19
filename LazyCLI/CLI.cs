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

            foreach (Type t in types) {
                MethodInfo[] methods = t.GetMethods();
                foreach (MethodInfo m in methods) {
                    MethodAttributes ma = m.Attributes;
                    var customAttr = m.GetCustomAttributes(typeof(LazyCLIAttribute), true);

                    if (customAttr.Length > 0) {
                        var alias = (customAttr[0] as LazyCLIAttribute).Alias;
                        if (alias != null) {
                            List<string> tmp = new List<string>(args);
                            var trgt = string.Join(".", tmp.ToArray());
                            if (trgt.Contains(alias)) {
                                trgt = trgt.Replace(alias, "");
                                string[] newArgs = trgt.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                                m.Invoke(null, newArgs.ToArray());
                            }
                        } else {
                            string decl = args[0] + "." + args[1];
                            if (decl.Equals(m.DeclaringType.ToString())
                                && m.Name.ToString().Equals(args[2])) {
                                List<string> newArgs = new List<string>();
                                for (int i = 3; i < args.Length; i++) {
                                    newArgs.Add(args[i]);
                                }

                                m.Invoke(null, newArgs.ToArray());
                            }
                        }
                    }
                }
            }
        }
    }
}
