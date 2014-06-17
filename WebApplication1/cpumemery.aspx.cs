using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Runtime.InteropServices;
using System.Management;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Timers;

namespace WebApplication1
{
    public partial class cpumemery : System.Web.UI.Page
    {
        public string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            NetworkInterface[] nics1 = NetworkInterface.GetAllNetworkInterfaces();
            //IDictionary list = System.Environment.GetEnvironmentVariables();

            if (false)
            {
                //Process[] p = Process.GetProcessesByName("devenv");//获取指定进程信息
                Process[] p = Process.GetProcesses();//获取所有进程信息
                Int64 tm = 0;
                if (p.Length > 0)
                {
                    foreach (Process pr in p)
                    {
                        tm += pr.WorkingSet64;
                    }
                    tm /= 1024 * 1024;
                }
            }

            if (false)
            {
                PerformanceCounter pfc = new PerformanceCounter("Processor", "% Processor Time", "_Total");//性能计数器
                //pc.CategoryName = "Process";//指定获取计算机进程信息 如果传Processor参数代表查询计算机CPU
                //pc.CounterName = "% Processor Time";//占有率
                //如果pp.CategoryName="Processor",那么你这里赋值这个参数 pp.InstanceName = "_Total"代表查询本计算机的总CPU。
                //pc.InstanceName = "_Total";//指定进程
                //pc.MachineName = ".";
                int i = 0;
                List<float> lf = new List<float>();
                while (i < 100)
                {
                    lf.Add(pfc.NextValue());
                    i++;
                    Thread.Sleep(1000);
                }
                Chart1.Series["Default"].Points.Clear();
                foreach (float f in lf)
                {
                    DataPoint dp = new DataPoint();
                    dp.SetValueY(f);
                    Chart1.Series["Default"].Points.Add(dp);
                }
            }

            if (false)
            {
                PerformanceCounter[] counters = new PerformanceCounter[System.Environment.ProcessorCount];
                for (int i = 0; i < counters.Length; i++)
                {
                    counters[i] = new PerformanceCounter("Processor", "% Processor Time", i.ToString());
                }

                while (true)
                {
                    for (int i = 0; i < counters.Length; i++)
                    {
                        float f = counters[i].NextValue();
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

            if (false)
            {
                PerformanceCounterCategory[] pcc = PerformanceCounterCategory.GetCategories();
                foreach (PerformanceCounterCategory pp in pcc)
                {
                    if (pp.CategoryName == "IPv4")
                    {
                        string[] instanceName = pp.GetInstanceNames();
                    }
                    //s += pp.CategoryName + "<br />" + pp.CategoryType + "<br />" + pp.CategoryHelp + "<br /><br />";
                    //string[] instanceNames = pp.GetInstanceNames();
                    //if (instanceNames.Length > 0)
                    //{
                    //    foreach (string iui in instanceNames)
                    //    {
                    //        s += iui + "<br />";
                    //    }
                    //    s += "<br /><br />";
                    //}
                    //s += "<br />";
                }
                PerformanceCounter pfcc = new PerformanceCounter("Memory", "Available KBytes", "");//性能计数器
                float ff = pfcc.NextValue() / 1024;
            }

            if (true)
            {
                Info.MemoryInfo mi = new Info.MemoryInfo();
                double total = mi.TotalPhys;
                double av = mi.AvailPhys;
                double used = mi.UsedPhys;
            }
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instancename = category.GetInstanceNames();
            long old=0;
            Info.NetInfo iiii = new Info.NetInfo();
            List<Info.NetInfo.NetInfoBaseStruct> ll = iiii.GetNetInfoBase();

            PerformanceCounter ulCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", instancename[6]);
            while (true)
            {
                Info.NetInfo.NetPerformanceStruct sssssssss = iiii.GetNetPerformance(instancename[6]);
                float sdsd = ulCounter.NextValue() / 1024;
                Thread.Sleep(1000);
            }

        }
    }
}


namespace Info
{
    /// <summary>
    /// 内存信息类
    /// </summary>
    public class MemoryInfo
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYINFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORYINFO meminfo);

        private MEMORYINFO MemInfo;
        public MemoryInfo()
        {
            MemInfo = new MEMORYINFO();
            GlobalMemoryStatus(ref MemInfo);
        }

        /// <summary>
        /// 内存使用率
        /// </summary>
        public double MemoryLoad
        {
            get
            {
                return MemInfo.dwMemoryLoad;
            }
        }
        /// <summary>
        /// 总物理内存
        /// </summary>     
        public double TotalPhys
        {
            get { return Utility.Bytes2MB(MemInfo.dwTotalPhys, 3); }

        }


        /// <summary>
        /// 可用物理内存
        /// </summary>
        public double AvailPhys
        {
            get
            {
                return Utility.Bytes2MB(MemInfo.dwAvailPhys, 3);
            }
        }

        /// <summary>
        /// 已用物理内存
        /// </summary>
        public double UsedPhys
        {
            get
            {
                return Utility.Bytes2MB(MemInfo.dwTotalPhys - MemInfo.dwAvailPhys, 3);
            }
        }

        /// <summary>
        /// 总交换文件大小
        /// </summary>        
        public double TotalPageFile
        {
            get { return Utility.Bytes2MB(MemInfo.dwTotalPageFile, 3); }
        }

        /// <summary>
        /// 可交换文件大小
        /// </summary> 
        public double AvailPageFile
        {
            get { return Utility.Bytes2MB(MemInfo.dwAvailPageFile, 3); }
        }


        /// <summary>
        /// 总虚拟内存大小
        /// </summary>
        public double TotalVirtual
        {
            get { return Utility.Bytes2MB(MemInfo.dwTotalVirtual, 3); }
        }


        /// <summary>
        /// 未用虚拟内存
        /// </summary>
        public double AvailVirtual
        {
            get { return Utility.Bytes2MB(MemInfo.dwAvailVirtual, 3); }
        }


    }

    /// <summary>
    /// 格式化数据
    /// </summary>
    public class Utility
    {
        public static double Bytes2MB(uint input, int lenght)
        {
            return Math.Round((Convert.ToDouble(input) / 1024 / 1024), lenght);
        }
    }



    public class NetInfo
    {
        public NetPerformanceStruct netPerformanceStruct;
        //定义PerformanceCounter
        #region 定义PerformanceCounter
        PerformanceCounter pcBytesTotal = new PerformanceCounter();
        PerformanceCounter pcBytesSent = new PerformanceCounter();
        PerformanceCounter pcBytesReceived = new PerformanceCounter();
        PerformanceCounter pcPacketsTotal = new PerformanceCounter();
        PerformanceCounter pcPacketsSent = new PerformanceCounter();
        PerformanceCounter pcPacketsSentUnicast = new PerformanceCounter();
        PerformanceCounter pcPacketsSentNonUnicast = new PerformanceCounter();
        PerformanceCounter pcPacketsSentDiscarded = new PerformanceCounter();
        PerformanceCounter pcPacketsSentErrors = new PerformanceCounter();
        PerformanceCounter pcPacketsReceived = new PerformanceCounter();
        PerformanceCounter pcPacketsReceivedUnicast = new PerformanceCounter();
        PerformanceCounter pcPacketsReceivedNonUnicast = new PerformanceCounter();
        PerformanceCounter pcPacketsReceivedDiscarded = new PerformanceCounter();
        PerformanceCounter pcPacketsReceivedErrors = new PerformanceCounter();
        #endregion
        //构造函数
        #region 构造函数
        public NetInfo()
        {
        }
        #endregion
        //网络基础信息结构体
        #region 网络基础信息结构体
        public struct NetInfoBaseStruct
        {
            public string NetName;  //网络名称
            public string[] IPAddress;  //IP地址，包括IPv4和IPv6
            public string MACAddress;  //MAC地址
            public string IPSubnet;  //子网掩码
            public string DefaultIPGateway;  //默认网关
        }
        #endregion
        //网络性能结构体
        #region 网络性能结构体
        public struct NetPerformanceStruct
        {
            //字节
            #region 字节
            public float BytesTotal;  //每秒总字节数
            public float BytesSent;  //每秒发送字节数
            public float BytesReceived;  //每秒发送字节数
            #endregion
            //包
            #region 包
            public float PacketsTotal;  //每秒总包数
            //包发送
            #region 包发送
            public float PacketsSent;  //每秒发送包数
            public float PacketsSentUnicast;  //每秒发送单播包数
            public float PacketsSentNonUnicast;  //每秒发送非单播包数
            public float PacketsSentDiscarded;  //被丢弃的发送包数
            public float PacketsSentErrors;  //错误的发送包数
            #endregion
            //包接收
            #region 包接收
            public float PacketsReceived;  //每秒接收包数
            public float PacketsReceivedUnicast;  //每秒接收单播包数
            public float PacketsReceivedNonUnicast;  //每秒接收非单播包数
            public float PacketsReceivedDiscarded;  //被丢弃的接收包数
            public float PacketsReceivedErrors;  //错误的接收包数
            #endregion
            #endregion
        }
        #endregion
        //获取网络基本信息
        #region 获取网络基本信息
        /**/
        /// <summary>
        /// 获取网络基本信息
        /// </summary>
        /// <returns>包含网络基本信息结构体的列表</returns>
        public List<NetInfoBaseStruct> GetNetInfoBase()
        {
            List<NetInfoBaseStruct> lNetInfo = new List<NetInfoBaseStruct>();
            NetInfoBaseStruct netInfoBaseStruct;

            ManagementObjectSearcher query =
                            new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = TRUE");
            ManagementObjectCollection moCollection = query.Get();
            //遍历
            foreach (ManagementObject mObject in moCollection)
            {
                try
                {
                    netInfoBaseStruct = new NetInfoBaseStruct();
                    netInfoBaseStruct.NetName = mObject["Description"].ToString();
                    netInfoBaseStruct.IPAddress = (string[])mObject["IPAddress"];
                    netInfoBaseStruct.MACAddress = mObject["MACAddress"].ToString();
                    //DefaultIPGateway
                    #region DefaultIPGateway
                    if (mObject["DefaultIPGateway"] == null)  //如果默认网关只有一个则返回
                    {
                        netInfoBaseStruct.DefaultIPGateway = mObject["DefaultIPGateway"].ToString();
                    }
                    else   //否则返回默认网关的数组(注：这里为了简单起见，只返回第一个网关)
                    {
                        netInfoBaseStruct.DefaultIPGateway = ((string[])mObject["DefaultIPGateway"])[0];
                    }
                    #endregion
                    //IPSubnet
                    #region IPSubnet
                    if (mObject["IPSubnet"] == null)
                    {
                        netInfoBaseStruct.IPSubnet = mObject["IPSubnet"].ToString();
                    }
                    else
                    {
                        netInfoBaseStruct.IPSubnet = ((string[])mObject["IPSubnet"])[0];
                    }
                    #endregion
                    lNetInfo.Add(netInfoBaseStruct);
                }
                catch
                {
                    continue;
                }
            }
            return lNetInfo;
        }
        #endregion
        //GetNetPerformance
        #region GetNetPerformance
        public NetPerformanceStruct GetNetPerformance(string NetName)
        {
            netPerformanceStruct = new NetPerformanceStruct();
            //定义CategoryName
            #region 定义CategoryName
            pcBytesTotal.CategoryName = "Network Interface";
            pcBytesSent.CategoryName = "Network Interface";
            pcBytesReceived.CategoryName = "Network Interface";
            pcPacketsTotal.CategoryName = "Network Interface";
            pcPacketsSent.CategoryName = "Network Interface";
            pcPacketsSentUnicast.CategoryName = "Network Interface";
            pcPacketsSentNonUnicast.CategoryName = "Network Interface";
            pcPacketsSentDiscarded.CategoryName = "Network Interface";
            pcPacketsSentErrors.CategoryName = "Network Interface";
            pcPacketsReceived.CategoryName = "Network Interface";
            pcPacketsReceivedUnicast.CategoryName = "Network Interface";
            pcPacketsReceivedNonUnicast.CategoryName = "Network Interface";
            pcPacketsReceivedDiscarded.CategoryName = "Network Interface";
            pcPacketsReceivedErrors.CategoryName = "Network Interface";
            #endregion
            //定义InstanceName
            #region 定义InstanceName
            pcBytesTotal.InstanceName = NetName;
            pcBytesSent.InstanceName = NetName;
            pcBytesReceived.InstanceName = NetName;
            pcPacketsTotal.InstanceName = NetName;
            pcPacketsSent.InstanceName = NetName;
            pcPacketsSentUnicast.InstanceName = NetName;
            pcPacketsSentNonUnicast.InstanceName = NetName;
            pcPacketsSentDiscarded.InstanceName = NetName;
            pcPacketsSentErrors.InstanceName = NetName;
            pcPacketsReceived.InstanceName = NetName;
            pcPacketsReceivedUnicast.InstanceName = NetName;
            pcPacketsReceivedNonUnicast.InstanceName = NetName;
            pcPacketsReceivedDiscarded.InstanceName = NetName;
            pcPacketsReceivedErrors.InstanceName = NetName;
            #endregion
            //定义CounterName
            #region 定义CounterName
            pcBytesTotal.CounterName = "Bytes Total/sec";
            pcBytesSent.CounterName = "Bytes Sent/sec";
            pcBytesReceived.CounterName = "Bytes Received/sec";
            pcPacketsTotal.CounterName = "Packets/sec";
            pcPacketsSent.CounterName = "Packets Sent/sec";
            pcPacketsSentUnicast.CounterName = "Packets Sent Unicast/sec";
            pcPacketsSentNonUnicast.CounterName = "Packets Sent Non-Unicast/sec";
            pcPacketsSentDiscarded.CounterName = "Packets Outbound Discarded";
            pcPacketsSentErrors.CounterName = "Packets Outbound Errors";
            pcPacketsReceived.CounterName = "Packets Received/sec";
            pcPacketsReceivedUnicast.CounterName = "Packets Received Unicast/sec";
            pcPacketsReceivedNonUnicast.CounterName = "Packets Received Non-Unicast/sec";
            pcPacketsReceivedDiscarded.CounterName = "Packets Received Discarded";
            pcPacketsReceivedErrors.CounterName = "Packets Received Errors";
            #endregion
            //为结构体赋值
            #region 为结构体赋值
            netPerformanceStruct.BytesTotal = pcBytesTotal.NextValue();
            netPerformanceStruct.BytesSent = pcBytesSent.NextValue();
            netPerformanceStruct.BytesReceived = pcBytesReceived.NextValue();
            netPerformanceStruct.PacketsTotal = pcPacketsTotal.NextValue();
            netPerformanceStruct.PacketsSent = pcPacketsSent.NextValue();
            netPerformanceStruct.PacketsSentUnicast = pcPacketsSentUnicast.NextValue();
            netPerformanceStruct.PacketsSentNonUnicast = pcPacketsSentNonUnicast.NextValue();
            netPerformanceStruct.PacketsSentDiscarded = pcPacketsSentDiscarded.NextValue();
            netPerformanceStruct.PacketsSentErrors = pcPacketsSentErrors.NextValue();
            netPerformanceStruct.PacketsReceived = pcPacketsReceived.NextValue();
            netPerformanceStruct.PacketsReceivedUnicast = pcPacketsReceivedUnicast.NextValue();
            netPerformanceStruct.PacketsReceivedNonUnicast = pcPacketsReceivedNonUnicast.NextValue();
            netPerformanceStruct.PacketsReceivedDiscarded = pcPacketsReceivedDiscarded.NextValue();
            netPerformanceStruct.PacketsReceivedErrors = pcPacketsReceivedErrors.NextValue();
            #endregion
            return netPerformanceStruct;
        }
        #endregion
    }


}