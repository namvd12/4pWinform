using _4P_PROJECT.Control;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using static _4P_PROJECT.Control.Https;
namespace Giamsat.Control.Websocket
{
    internal class StatusToWebSocket
    {

        List<DeviceSocketStatus> listDevices = new List<DeviceSocketStatus>();

        Https httpRequest = new Https();

        private string jsonRequestOld = "";
        public class DeviceSocketStatus
        {
            public string tula_key;
            public string tula1;
            public string tula2;
            public string tula3;
            public string tula4;
            public string tula5;
            public string tula6;
        }
        class StatusResponse
        {
            public string data;
        }

        private  void ws_receive(object sender, MessageEventArgs e)
        {
            string receive = e.Data;
        }
        public void set(int tula_key, string tula1, string tula2, string tula3, string tula4, string tula5, string tula6)
        {
            DeviceSocketStatus statusDevice = new DeviceSocketStatus();
            statusDevice.tula_key = tula_key.ToString();
            statusDevice.tula1 = tula1;
            statusDevice.tula2 = tula2;
            statusDevice.tula3 = tula3;
            statusDevice.tula4 = tula4;
            statusDevice.tula5 = tula5 == null ? "" : tula5;
            statusDevice.tula6 = tula6 == null ? "" : tula6;
            listDevices.Add(statusDevice);
        }
        public void update()
        {
            if (listDevices != null)
            { 
                var jsonString = JsonConvert.SerializeObject(listDevices);
                StatusResponse status = new StatusResponse();
                status.data = jsonString;
                var jsonStringStatus = JsonConvert.SerializeObject(status);

                if (jsonRequestOld != jsonStringStatus)
                {
                    jsonRequestOld = jsonStringStatus;
                    httpRequest.SetData(TypeInfor.MACHINE_LIST_NG, jsonStringStatus);
                }
            }
            listDevices.Clear();
        }

        public List<DeviceSocketStatus> getListDevice()
        { 
            return listDevices;
        }
    }
}
