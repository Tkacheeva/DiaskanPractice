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
    public struct TaskList
    {
        public string TaskName;
        public string DllPath;
        public string type;
        public string method;
        public string PathToRun;
        public string startTime;
        public string endTime;
        public enum Status
        {
            Expectation = 0,
            Executing = 1,
            Success = 2,
            Failure = 3
        }

        public Status status;

        public TaskList(string tn, string d, string t, string m, string p, string st, string et, Status s) => (TaskName, DllPath, type, method, PathToRun, startTime, endTime, status) = (tn, d, t, m, p, st, et, s);
    }
    
    public class Launcher
    {
        private List<TaskList> taskL;

        public Launcher()
        {
            taskL = new List<TaskList>();
            System.Timers.Timer goal = new System.Timers.Timer(500);
            goal.Elapsed += TimerCallback;
            goal.AutoReset = true;
            goal.Enabled = true;
        }

        private void TimerCallback(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < taskL.Count; i++)
            {
                if (taskL[i].status == 0)
                {
                    Task myTask = new Task(() => Launch(taskL[i]));
                    myTask.Start();
                    return;
                }
            }
        }

        public void RemoveTask(int index)
        {
            taskL.RemoveAt(index);
        }
        public void AddTask(TaskList goal, string path)
        {
            taskL.Add(new TaskList(goal.TaskName, goal.DllPath, goal.type, goal.method, path, null, null, 0));
        }

        public TaskList[] CheckList()
        {
            if (taskL.Count != 0)
                return taskL.ToArray();
            return null;
        }

        public void Launch(object input)
        {
            Assembly asm;
            Type typeOfClass;
            object obj;
            MethodInfo mInfo;

            TaskList goal = (TaskList)input;
            int index = taskL.IndexOf(goal);
            goal.status = TaskList.Status.Executing;
            taskL[index] = goal;
            try
            {
                asm = Assembly.LoadFrom(goal.DllPath);
                typeOfClass = asm.GetType(goal.type, true, true);
                obj = System.Activator.CreateInstance(typeOfClass);
                mInfo = typeOfClass.GetMethod(goal.method);
                goal.startTime = DateTime.Now.ToString();
                mInfo.Invoke(obj, new object[] { goal.PathToRun });
                goal.endTime = DateTime.Now.ToString();
                goal.status = TaskList.Status.Success;
                taskL[index] = goal;
            }
            catch 
            {
                goal.startTime = DateTime.Now.ToString();
                goal.status = TaskList.Status.Failure;
                taskL[index] = goal;
            }
        }

    }
}
