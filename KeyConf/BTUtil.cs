using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using InTheHand.Net.Sockets;
namespace KeyConf
{
    class BTUtil
    {
        private static List<BluetoothDeviceInfo> btinfos = new List<BluetoothDeviceInfo>();

        private static Task task = null;
        private static CancellationTokenSource cancelToken = null;

        public static void StartCheckBTDevice()
        {
            if (task != null)
            {
                return;
            }
            cancelToken = new CancellationTokenSource();
            task = Task.Factory.StartNew((Action)(() =>
            {
                Console.WriteLine("BlueThoothの監視を始めます");
                while (true)
                {
                    if (cancelToken.Token.IsCancellationRequested)
                    {
                        Console.WriteLine("BlueThoothの監視がキャンセルされた");
                        return;
                    }

                    UpdateBTInfo();

                    Thread.Sleep(1000);
                }

            }), cancelToken.Token);
            task.ContinueWith((obj) =>
            {
                try
                {
                    task.Dispose();
                    cancelToken.Dispose();
                }
                finally
                {
                    task = null;
                    cancelToken = null;
                }
            });

        }

        public static void StopCheckBTDevice()
        {
            if (task == null)
            {
                return;
            }
            cancelToken.Cancel();
        }

        public static void UpdateBTInfo()
        {
            var client = new BluetoothClient();
            var devices = client.DiscoverDevices(100,true,false,false);
            btinfos = new List<BluetoothDeviceInfo>();
            if (devices.Length == 0)
            {
                return;
            }
            foreach (var dev in devices)
            {
                btinfos.Add(dev);
            }
        }


        public static bool IsConnected(String name)
        {
            
            if (btinfos.Count == 0)
            {
                return false;
            }
            foreach (var dev in btinfos)
            {
                //Console.WriteLine(dev.DeviceName);
                
                if (dev.Connected == false) 
                {
                    continue;
                }
                if (dev.DeviceName == name)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
