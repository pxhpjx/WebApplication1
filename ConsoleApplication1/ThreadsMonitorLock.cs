using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApplication1
{
    class ThreadsMonitorLock
    {
        //public static void Main(string[] args)
        //{
        //    LockObj obj = new LockObj();

        //    //注意，这里使用的是同一个资源对象obj
        //    th1 th1 = new th1(obj);
        //    th2 th2 = new th2(obj);

        //    Thread t1 = new Thread(new ThreadStart(th1.Run));
        //    Thread t2 = new Thread(new ThreadStart(th2.Run));
        //    t1.Name = "t1";
        //    t1.Start();
        //    t2.Name = "t2";
        //    t2.Start();

        //    Console.ReadLine();
        //}
    }

    //锁定对象
    public class LockObj { }

    public class th1
    {
        private LockObj obj;

        public th1(LockObj obj)
        {
            this.obj = obj;
        }

        public void Run()
        {
            Monitor.Enter(this.obj);
            Console.WriteLine("{0}: [1]entered", Thread.CurrentThread.Name);
            Console.WriteLine("{0}：[2]calling wait", Thread.CurrentThread.Name);
            //暂时的释放锁资源
            Monitor.Wait(this.obj);
            Console.WriteLine("{0}：[3]wait end,calling pulse", Thread.CurrentThread.Name);
            //唤醒等待队列中的线程
            //Monitor.Pulse(this.obj);
            //Console.WriteLine("{0}：[4]pulse end,calling exit", Thread.CurrentThread.Name);
            Monitor.Exit(this.obj);
        }
    }

    public class th2
    {
        private LockObj obj;
        public th2(LockObj obj)
        {
            this.obj = obj;
        }

        public void Run()
        {
            Monitor.Enter(this.obj);
            Console.WriteLine("{0}: [a]entered,calling pulse",Thread.CurrentThread.Name);
            //唤醒等待队列中的线程
            Monitor.Pulse(this.obj);
            //Console.WriteLine("{0}: [b]pulse end,calling wait", Thread.CurrentThread.Name);
            ////暂时的释放锁资源
            //Monitor.Wait(this.obj);
            //Console.WriteLine("{0}: [c]wait end,calling exit", Thread.CurrentThread.Name);
            Monitor.Exit(this.obj);
        }
    }
}
