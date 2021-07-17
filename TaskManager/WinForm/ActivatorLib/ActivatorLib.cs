using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Threading;

namespace ActivatorLib
{

    public struct Msg
    {
        public int type;
        public string message;
        public enum Status
        {
            Expectation = 0,
            Executing = 1,
            Success = 2,
            Failure = 3
        }

        public Status status;

        public Msg(int t, string m, Status s) => (type, message, status) = (t, m, s);
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
            Timer t = new Timer(TimerCallback, null, 0, 500);
        }

        private void TimerCallback(Object o)
        {
            msgL.ForEach(delegate (Msg task) {
                if (task.status == 0)
                {
                    Thread myThread = new Thread(new ParameterizedThreadStart(Launch));
                    myThread.Start(task);
                }
            });
        }

        public void RemoveTask(int index)
        {
            msgL.RemoveAt(index);
        }
        public void AddTask(int type, string message)
        {
            msgL.Add(new Msg(type, message, 0));
        }

        public void AddNewTask(string name, string path, string type, string method)
        {
            tasksList.Add(new Task(name, path, type, method));
        }

        public Msg[] CheckList()
        {
            if (msgL.Count != 0)
                return msgL.ToArray();
            return null;
        }

        public void Launch(object tmp)
        {
            Assembly asm;
            Type typeOfClass;
            object obj;
            MethodInfo mInfo;

            Msg t = (Msg)tmp;
            Task ts = tasksList[t.type];
            int index = msgL.IndexOf(t);
            t.status = Msg.Status.Executing;
            msgL[index] = t;

            asm = Assembly.LoadFrom(ts.path);
            typeOfClass = asm.GetType(ts.type, true, true);
            obj = System.Activator.CreateInstance(typeOfClass);
            mInfo = typeOfClass.GetMethod(ts.method);
            try
            {
                mInfo.Invoke(obj, new object[] { t.message });
                t.status = Msg.Status.Success;
                msgL[index] = t;

            }
            catch 
            {
                t.status = Msg.Status.Failure;
                msgL[index] = t;
            }
        }

    }
}
