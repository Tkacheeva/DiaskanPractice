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

        private List<Task> tasksList;
        private List<Msg> msgL;    

        public Launcher()
        {
            msgL = new List<Msg>();
            tasksList = new List<Task>();
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
            Assembly asm;
            Type typeOfClass;
            object obj;
            MethodInfo mInfo;

            if (msgL.Count != 0)
            {
                Msg tmp = msgL[0];
                Task ts = tasksList[tmp.type];
                

                msgL.RemoveAt(0);
                asm = Assembly.LoadFrom(ts.path);
                string t = asm.GetType().GetTypeInfo().FullName;
                // = typeof().GetTypeInfo();
                string s1 = asm.ToString();
                string s = Assembly.GetExecutingAssembly().GetName().Name;
                typeOfClass = asm.GetType(ts.type, true, true);
                obj = System.Activator.CreateInstance(typeOfClass);
                mInfo = typeOfClass.GetMethod(ts.method);
                mInfo.Invoke(obj, new object[] { tmp.message });                      
            }
            else
                return false;
            return true;
        }

    }
}
