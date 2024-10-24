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


        /* get data call material*/

        public UInt64 callID;
        public string machineCode;
        public string line;
        public string lane;
        public string position;
        public string slot;
        public string urgent;
        public string status;
        public DateTime time;

        /* get user password form dataRev*/
        public string userID;
        public string username;
        public string password;
        /* response Status*/

        public string statusRes;

    }
}
