using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace ActivatorLib
{
    public struct Msg
    {
        public int type;
        public string[] message;

        public Msg(int t, string[] m) => (type, message) = (t, m);
    }
    
    public class Launcher
    {
        private Assembly asm;
        private Type t;
        private object obj;
        private MethodInfo m;
        public List<Msg> msgQ;

        public Launcher()
        {
            msgQ = new List<Msg>();
        }
        public bool LoadLib(string DllName)
        {
            asm = Assembly.LoadFrom(DllName);
            if (asm == null)
                return false;

            return true;
        }

        public bool CreateInstance(Type t)
        {
            obj = System.Activator.CreateInstance(t);

            if (obj == null)
                return false;
            return true;
        }

        public bool GetType(string type)
        {
            t = asm.GetType(type, true, true);

            if (t != null)
                return true;
            return false;
        }

        public bool GetMethod(string method)
        {
            m = t.GetMethod(method);
            if (m != null)
                return true;

            return false;
        }

        public object Invoke(string[] arg)
        {
            object res = m.Invoke(obj, new object[] { arg });

            return res;
        }

        public bool Launch()
        {
            if (msgQ.Count != 0)
            {
                Msg tmp = msgQ[0];
                msgQ.RemoveAt(0);

                switch (tmp.type)
                {
                    case 0:
                        LoadLib("D:\\csprojects\\Hash\\Hash\\bin\\Debug\\Hash.dll");
                        GetType("Hash.Hash");
                        CreateInstance(t);
                        GetMethod("Hashing");
                        object res = Invoke(tmp.message);
                        string[] arr = ((IEnumerable)res).Cast<object>().Select(x => x.ToString()).ToArray();
                        //string[] s = ;
                        foreach (string o in arr)
                            Console.WriteLine(o);
                        break;
                    case 1:
                        Console.WriteLine(tmp.message);
                        break;
                    default:
                        break;
                }
            }
            else 
                return false;
            return true;
        }

    }
}
