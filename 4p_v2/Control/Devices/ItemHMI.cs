using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Giamsat.Control.Devices.RFMaster;

namespace SabanWi.Control.Devices
{
    internal class ItemHMI
    {
        public enum sendToHmicmd
        {
            NON,
            GET_STATE,
            SET_STATUS_LOGIN,
            SET_STATUS_REQUEST,
        }
        public enum hmiResponseCmd
        { 
            NON,
            LOGIN,
            REQUEST,
            UPDATE_STATUS,
        } 
        
        public enum hmiState
        { 
            START,
            LOGOUT, 
            LOGED,  
            CHECKSTATUS, 
        }
        public uint addrHMI;
        public hmiState state;
        public hmiResponseCmd cmd;
        public string dataRev;

        /* get user password form dataRev*/
        public string user;
        public string password;

        /* get data call material*/

        public UInt64 callID;
        public string machineCode;
        public string line;
        public string lane;
        public string partNumber;
        public string slot;
        public string number;
        public string level;
        public string status;
        public DateTime time;

        /* response Status*/

        public string statusRes;

    }
}
