using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Threading;
using System.Timers;

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
            System.Timers.Timer t = new System.Timers.Timer(500);
            t.Elapsed += TimerCallback;
            t.AutoReset = true;
            t.Enabled = true;
        }

        private void TimerCallback(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < msgL.Count; i++)
            {
                if (msgL[i].status == 0)
                {
                    Thread myThread = new Thread(new ParameterizedThreadStart(Launch));
                    myThread.Start(msgL[i]);
                    return;
                }
            }
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
            try
            {
                asm = Assembly.LoadFrom(ts.path);
                typeOfClass = asm.GetType(ts.type, true, true);
                obj = System.Activator.CreateInstance(typeOfClass);
                mInfo = typeOfClass.GetMethod(ts.method);

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
