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
        public string message;

        public Msg(int t, string m) => (type, message) = (t, m);
    }

    public struct Task
    {
        public string name;
        public string path;
        public string type;
        public string method;

        public Task(string n, string p, string t, string m) => (name, path, type, method) = (n, p, t, m);
    }
    
    public class Launcher
    {
        private Assembly asm;
        private Type typeOfClass;
        private object obj;
        private MethodInfo mInfo;
        private List<Task> tasksList;
        private List<Msg> msgL;    

        public Launcher()
        {
            msgL = new List<Msg>();
            tasksList = new List<Task>();
        }
        public bool LoadLib(string DllName)
        {
            asm = Assembly.LoadFrom(DllName);
            if (asm == null)
                return false;

            return true;
        }

        public bool CreateInstance(Type typeOfClass)
        {
            obj = System.Activator.CreateInstance(typeOfClass);

            if (obj == null)
                return false;
            return true;
        }

        public bool GetType(string type)
        {
            typeOfClass = asm.GetType(type, true, true);

            if (typeOfClass != null)
                return true;
            return false;
        }

        public bool GetMethod(string method)
        {
            mInfo = typeOfClass.GetMethod(method);
            if (mInfo != null)
                return true;

            return false;
        }

        public object Invoke(object arg)
        {
            object res = mInfo.Invoke(obj, new object[] { arg });

            return res;
        }

        public void RemoveTask(int index)
        {
            msgL.RemoveAt(index);
        }
        public void AddTask(int type, string message)
        {
            msgL.Add(new Msg(type, message));
        }

        public void AddNewTask(string name, string path, string type, string method)
        {
            tasksList.Add(new Task(name, path, type, method));
        }

        public bool Launch()
        {          
            if (msgL.Count != 0)
            {
                Msg tmp = msgL[0];
                Task ts = tasksList[tmp.type];

                msgL.RemoveAt(0);

                LoadLib(ts.path);
                GetType(ts.type);
                CreateInstance(typeOfClass);
                GetMethod(ts.method);
                object res = Invoke(tmp.message);
                string[] arr = ((IEnumerable)res).Cast<object>().Select(x => x.ToString()).ToArray();
                       
                foreach (string o in arr)
                    Console.WriteLine(o);
            }
            else
                return false;
            return true;
        }

    }
}
