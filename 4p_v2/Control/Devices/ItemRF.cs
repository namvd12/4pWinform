using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.ItemInfor;

namespace Giamsat.Control.Devices
{
    public class ItemRF
    {

        public string OK = "OK";
        public string NG = "NG";
        public string Dis = "DIS";

        public int machineid;
        public string machineCode;
        public string machineName;
        public uint addr;
        public uint port;
        public string status;
        public string timeNG;
        public int location_x;
        public int location_y;
        public int line;
        public int lane;
        public string region;
        public ButtonX ButtonItem;

        public bool blinkLed;

        public float xRatio;
        public float yRatio;
        public float RatioWidth;
        public float RatioHeight;
        public float RatioImageWidth;
        public float RatioImageHeight;

        public uint cntNG;
        public uint cntOK;
        public uint cntDIS;
    }
}
