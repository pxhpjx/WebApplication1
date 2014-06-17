using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class readwritelock
    {
        static List<int> list = new List<int>();

        static ReaderWriterLock rw = new System.Threading.ReaderWriterLock();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(AutoAddFunc);

            Thread t2 = new Thread(AutoReadFunc);

            t1.Start();

            t2.Start();

            Console.Read();
        }

        /// <summary>
        /// 模拟3s插入一次
        /// </summary>
        /// <param name="num"></param>
        public static void AutoAddFunc()
        {
            //3000ms插入一次
            Timer timer1 = new Timer(new TimerCallback(Add), null, 0, 3000);
        }

        public static void AutoReadFunc()
        {
            //1000ms自动读取一次
            Timer timer1 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer2 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer3 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer4 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer5 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer6 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer7 = new Timer(new TimerCallback(Read), null, 0, 3000);
            Timer timer8 = new Timer(new TimerCallback(Read), null, 0, 3000);
        }

        public static void Add(object obj)
        {
            var num = new Random().Next(0, 1000);

            //写锁
            rw.AcquireWriterLock(TimeSpan.FromSeconds(30));

            list.Add(num);

            Console.WriteLine("\tThread:{0}，Insert:{1}", Thread.CurrentThread.ManagedThreadId, num);

            //释放锁
            rw.ReleaseWriterLock();
        }

        public static void Read(object obj)
        {
            //读锁
            rw.AcquireReaderLock(TimeSpan.FromSeconds(30));

            Console.WriteLine("Thread:{0},Read:{1}",Thread.CurrentThread.ManagedThreadId, string.Join(",", list));
            //释放锁
            rw.ReleaseReaderLock();
        }
    }
}