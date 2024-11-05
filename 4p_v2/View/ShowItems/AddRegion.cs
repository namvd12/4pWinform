using GiamSat;
using GiamSat.model;
using GiamSat.View;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.ClientRF;
using static GiamSat.model.Machine;
using Machine = GiamSat.model.Machine;

namespace Giamsat.View.ShowItems
{
    public partial class AddRegion : Form
    {

        List<ClientData> lsClient = new List<ClientData>();

        List<machineData> lsMachineData = new List<machineData>();

        ClientRF clientRF = new ClientRF();

        Machine machineDb = new Machine();

        private Main mAppInstance;

        public Main CalledApplication
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                clientRF.database = mAppInstance.db;
                machineDb.database = mAppInstance.db;
                lsClient = clientRF.getAll();
                lsMachineData = machineDb.getAll();

            }
        }

        public AddRegion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EditPosition_Click(object sender, EventArgs e)
        {
            bool regionExit = false;
            AddItems addItems = new AddItems();
            addItems.CalledApplication = mAppInstance;

            /* check region exit*/
            string regionName = string.Format("{0}_{1}", cb_region.Text, cb_line.Text);

            foreach (var client in lsClient)
            {
                if (client.machineName == regionName)
                {
                    regionExit = true;
                }

            }

            int machineID = 1;
            /* search first machineID on line*/
            foreach (var item in lsMachineData)
            {
                if (item.linePosition == cb_line.Text)
                {
                    machineID = item.machineID;
                }                
            }
            if (!regionExit)
            {
               // mAppInstance.machineDb
                addItems.LoadItem(machineID, "", regionName, 0, 0, "DIS", "",10, 10, Convert.ToUInt16(cb_line.Text), 0,"", true);
            }
        }
    }
}
