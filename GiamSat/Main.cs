using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Resources;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

//using LibUsbDotNet;
//using LibUsbDotNet.LibUsb;
//using LibUsbDotNet.Main;
//using LibUsbDotNet.LudnMonoLibUsb;

using OfficeOpenXml;
using OfficeOpenXml.Drawing;

//using EC = LibUsbDotNet.Main.ErrorCode;
using UsbHid;
using UsbHid.USB.Classes;
using DevComponents.DotNetBar;
using _4P_PROJECT.DataBase;
using UsbHid.USB.Classes;

namespace GiamSat
{
    public partial class Main : Form
    {

        #region SET YOUR USB Vendor and Product ID!

        // //RF Mobile
        //public static UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x400, 0x580A);

        //RF Master

        UsbHidDevice device;

        /* Define the vendor id and product id */
        #endregion

        #region Member variables

        private string fileName = "";
        private int mItemIndex = 0;
        private ushort mDeviceID;
        private string mDeviceTen;
        private string mDeviceVitriTinhieu;
        private byte mDevieTinhieuIndex;
        private string mDeviceNote;

        private string imagePath;

        private ResourceManager mMainResourceManager;
        private CultureInfo mEnglishCultureInfo;
        private CultureInfo mVietnameseCultureInfo;

        private List<ItemInfor> mlstItemInfor = new List<ItemInfor>();

        /// how many list will save
        /// </summary>
        const int mRecentFileNumber = 5;

        DataBase db = new DataBase();
        System.Collections.Generic.List<string> mRecentFileList = new List<string>();
 
        //System.Collections.Generic.Queue<string> mRecentFileList = new Queue<string>();


        //public enum ItemStatus { NONE, NORMAL, ERROR, BUSY, DISCONNECT }

        public enum DeviceInformation { OK, SAME_ID, SAME_LOCATION, SAME_ID_LOCATION };

        public enum LedColour { NONE, GREEN, RED, YELLOW, BLACK};
      
        public enum SendCommand { NONE, READ_ADD, WRITE_ADD, READ_SABAN, WRITE_SABAN, READ_TIME, WRITE_TIME,
                                  READ_RUNNING_INFO, DELETE_RUNNING_INFO, READ_SYS_STATUS, SCAN_SYS_STATUS };
       
        public SendCommand sendCommand { get; set; }

        public string Password { get; set; }

        public bool EditEnable;
        public bool ShowName;

        public enum LoginResult
        {
            LoginOK = 0,
            LoginWrongUsername = 1,
            LoginWrongPassword = 2
        }

        #endregion

        #region delegate

        #endregion

        #region Properties

        public ushort DeviceID { get { return mDeviceID; } set { mDeviceID = value; } }

        public string DeviceTen { get { return mDeviceTen; } set { mDeviceTen = value; } }

        public string DeviceVitriTinhieu { get { return mDeviceVitriTinhieu; } set { mDeviceVitriTinhieu = value; } }

        public byte DeviceTinhieuIndex { get { return mDevieTinhieuIndex; } set { mDevieTinhieuIndex = value; } }

        public string DeviceNote { get { return mDeviceNote; } set { mDeviceNote = value; } }

        public int ItemIndex { get { return mItemIndex; } set { mItemIndex = value; } }

        public List<ItemInfor> ListItemInfor { get { return mlstItemInfor; } set { mlstItemInfor = value; } }

        public ResourceManager MainResourceManager { get { return mMainResourceManager; } }

        public LedColour Ledcolour { get; set; }

        #endregion

        #region contructor

        public Main()
        {
            InitializeComponent();

            mMainResourceManager = new ResourceManager("GiamSat.Localization", System.Reflection.Assembly.GetExecutingAssembly());
            mEnglishCultureInfo = new CultureInfo("en-US");
            mVietnameseCultureInfo = new CultureInfo("vi-VN");
            vietnameseToolStripMenuItem.Checked = false;
            englishToolStripMenuItem.Checked = true;
            Thread.CurrentThread.CurrentUICulture = mEnglishCultureInfo;

            LoadDisplayList();
            //this.WindowState = FormWindowState.Minimized;

            //Helper.ControlMover.Init(this.button1);
            //Helper.ControlMover.Init(this.button2);
            //Helper.ControlMover.Init(this.button3);
            //Helper.ControlMover.Init(this.button4);
            //Helper.ControlMover.Init(this.button5);


            //Helper.ControlMover.Init(this.checkBox1);
            //Helper.ControlMover.Init(this.groupBox1);
        }

        #endregion

        #region Item method

        public void AddNewItem()
        {
            
            ItemInfor item = new ItemInfor();

            item.ID = mDeviceID;
            item.Ten = mDeviceTen;
            item.VitriTinhieu = mDeviceVitriTinhieu;
            item.TinhieuIndex = mDevieTinhieuIndex;
            item.Note = mDeviceNote;

            if (ShowName)
                item.ButtonItem.Text = item.Ten;
            else
                item.ButtonItem.Text = "  ";

            //item.ButtonItem.Image = Properties.Resources.ledgreen24px;

            item.ButtonItem.Image = LedDisplay(LedColour.BLACK, item.ID);
            item.ButtonItem.Location = new System.Drawing.Point(0, 0);

            item.ButtonItem.Name = "ButtonItem" + mlstItemInfor.Count; // ;

            item.ButtonItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            item.ButtonItem.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            item.ButtonItem.BackColor = Color.Transparent;
            item.ButtonItem.FocusCuesEnabled = false;
            item.ButtonItem.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            item.ButtonItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;

            int nLength;

            nLength = mDeviceTen.Length;
            if (nLength < 3) nLength = 3;

            if (mDevieTinhieuIndex==0)
            {
                item.ButtonItem.Size = new System.Drawing.Size(110*nLength, 200);  // namvd
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 1)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength, 60);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 2)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 36, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            }
            else if (mDevieTinhieuIndex == 3)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 36, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            }

            mlstItemInfor.Add(item);
            this.pictureBox1.Controls.Add(item.ButtonItem);

            item.ButtonItem.Parent = pictureBox1;
            item.ButtonItem.BackColor = Color.Transparent;

            if (EditEnable)
            {
                Helper.ControlMover.Init(item.ButtonItem);
            }
                
            ItemIndex++;
        }

        public void AddNewItem(int x, int y, ushort id, string ten, string vitriTH, byte index, string note)
        {
            ItemInfor item = new ItemInfor();

            item.ID = id;
            item.Ten = ten;
            item.VitriTinhieu = vitriTH;
            item.TinhieuIndex = index;
            item.Note = note;

            if (ShowName)
                item.ButtonItem.Text = item.Ten;
            else
                item.ButtonItem.Text = "  ";

            //item.ButtonItem.Image = Properties.Resources.ledgreen24px;
            item.ButtonItem.Image = LedDisplay(LedColour.BLACK, item.ID);
            item.ButtonItem.Location = new System.Drawing.Point(x, y);

            item.ButtonItem.Name = "ButtonItem" + mlstItemInfor.Count; // 

            item.ButtonItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            item.ButtonItem.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
 
            //item.ButtonItem.BackColor = DevCom;
            item.ButtonItem.FocusCuesEnabled = false;
            //item.ButtonItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            item.ButtonItem.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
 
            item.ButtonItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;

            int nLength;

            nLength = item.Ten.Length;
            if (nLength < 3) nLength = 3;

            if (mDevieTinhieuIndex == 0)
            {
                item.ButtonItem.Size = new System.Drawing.Size(110 * nLength, 200);   // namvd
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 1)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength, 60);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 2)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 36, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            }
            else if (mDevieTinhieuIndex == 3)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 38, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            }


            mlstItemInfor.Add(item);
            this.pictureBox1.Controls.Add(item.ButtonItem);

            item.ButtonItem.Parent = pictureBox1;
            item.ButtonItem.BackColor = Color.Transparent;

            if (EditEnable)
            {
                Helper.ControlMover.Init(item.ButtonItem);
            }
            
            ItemIndex++;
        }

        public void UpdateItem(ItemInfor item)
        {
            item.ID = mDeviceID;
            item.Ten = mDeviceTen;
            item.VitriTinhieu = mDeviceVitriTinhieu;
            item.TinhieuIndex = mDevieTinhieuIndex;
            item.Note = mDeviceNote;

            item.ButtonItem.Text = mDeviceTen;
            item.Note = mDeviceNote;

            if (ShowName)
                item.ButtonItem.Text = mDeviceTen;
            else
                item.ButtonItem.Text = "  ";

            //item.ButtonItem.Name = "ButtonItem" + mlstItemInfor.Count; // 
            item.ButtonItem.Image = LedDisplay(LedColour.BLACK, item.ID);

            item.ButtonItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            item.ButtonItem.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
        
            item.ButtonItem.FocusCuesEnabled = false;
            //item.ButtonItem.BackColor = DevCom;
            item.ButtonItem.FocusCuesEnabled = false;
            item.ButtonItem.Font = new System.Drawing.Font("Arial", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            item.ButtonItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;

            int nLength;

            nLength = item.Ten.Length;
            if (nLength < 3) nLength = 3;

            if (mDevieTinhieuIndex == 0)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength, 60);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 1)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength, 60);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            }
            else if (mDevieTinhieuIndex == 2)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 36, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            }
            else if (mDevieTinhieuIndex == 3)
            {
                item.ButtonItem.Size = new System.Drawing.Size(11 * nLength + 38, 35);
                item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Left;
                item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Right;
            }

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Image LedDisplay(LedColour colour, ushort number)
        {
            Image image;
            //image = Properties.Resources.LedGreen32px;
            image = Properties.Resources.Ledblack32px;

            if (colour == LedColour.BLACK)
            {
                switch (number)
                {
                    case 1: image = Properties.Resources.ledblack32px1; break;
                    case 2: image = Properties.Resources.ledblack32px2; break;
                    case 3: image = Properties.Resources.ledblack32px3; break;
                    case 4: image = Properties.Resources.ledblack32px4; break;
                    case 5: image = Properties.Resources.ledblack32px5; break;
                    case 6: image = Properties.Resources.ledblack32px6; break;
                    case 7: image = Properties.Resources.ledblack32px7; break;
                    case 8: image = Properties.Resources.ledblack32px8; break;
                    case 9: image = Properties.Resources.ledblack32px9; break;
                    case 10: image = Properties.Resources.ledblack32px10; break;
                    case 11: image = Properties.Resources.ledblack32px11; break;
                    case 12: image = Properties.Resources.ledblack32px12; break;
                    case 13: image = Properties.Resources.ledblack32px13; break;
                    case 14: image = Properties.Resources.ledblack32px14; break;
                    case 15: image = Properties.Resources.ledblack32px15; break;
                    case 16: image = Properties.Resources.ledblack32px16; break;
                    case 17: image = Properties.Resources.ledblack32px17; break;
                    case 18: image = Properties.Resources.ledblack32px18; break;
                    case 19: image = Properties.Resources.ledblack32px19; break;
                    case 20: image = Properties.Resources.ledblack32px20; break;
                    case 21: image = Properties.Resources.ledblack32px21; break;
                    case 22: image = Properties.Resources.ledblack32px22; break;
                    case 23: image = Properties.Resources.ledblack32px23; break;
                    case 24: image = Properties.Resources.ledblack32px24; break;
                    case 25: image = Properties.Resources.ledblack32px25; break;
                    case 26: image = Properties.Resources.ledblack32px26; break;
                    case 27: image = Properties.Resources.ledblack32px27; break;
                    case 28: image = Properties.Resources.ledblack32px28; break;
                    case 29: image = Properties.Resources.ledblack32px29; break;
                    case 30: image = Properties.Resources.ledblack32px30; break;
                    case 31: image = Properties.Resources.ledblack32px31; break;
                    case 32: image = Properties.Resources.ledblack32px32; break;
                    case 33: image = Properties.Resources.ledblack32px33; break;
                    case 34: image = Properties.Resources.ledblack32px34; break;
                    case 35: image = Properties.Resources.ledblack32px35; break;
                    case 36: image = Properties.Resources.ledblack32px36; break;
                    case 37: image = Properties.Resources.ledblack32px37; break;
                    case 38: image = Properties.Resources.ledblack32px38; break;
                    case 39: image = Properties.Resources.ledblack32px39; break;
                    case 40: image = Properties.Resources.ledblack32px40; break;
                    case 41: image = Properties.Resources.ledblack32px41; break;
                    case 42: image = Properties.Resources.ledblack32px42; break;
                    case 43: image = Properties.Resources.ledblack32px43; break;
                    case 44: image = Properties.Resources.ledblack32px44; break;
                    case 45: image = Properties.Resources.ledblack32px45; break;
                    case 46: image = Properties.Resources.ledblack32px46; break;
                    case 47: image = Properties.Resources.ledblack32px47; break;
                    case 48: image = Properties.Resources.ledblack32px48; break;
                    case 49: image = Properties.Resources.ledblack32px49; break;
                    case 50: image = Properties.Resources.ledblack32px50; break;
                    case 51: image = Properties.Resources.ledblack32px51; break;
                    case 52: image = Properties.Resources.ledblack32px52; break;
                    case 53: image = Properties.Resources.ledblack32px53; break;
                    case 54: image = Properties.Resources.ledblack32px54; break;
                    case 55: image = Properties.Resources.ledblack32px55; break;
                    case 56: image = Properties.Resources.ledblack32px56; break;
                    case 57: image = Properties.Resources.ledblack32px57; break;
                    case 58: image = Properties.Resources.ledblack32px58; break;
                    case 59: image = Properties.Resources.ledblack32px59; break;
                    case 60: image = Properties.Resources.ledblack32px60; break;
                    case 61: image = Properties.Resources.ledblack32px61; break;
                    case 62: image = Properties.Resources.ledblack32px62; break;
                    case 63: image = Properties.Resources.ledblack32px63; break;
                    case 64: image = Properties.Resources.ledblack32px64; break;
                    case 65: image = Properties.Resources.ledblack32px65; break;
                    case 66: image = Properties.Resources.ledblack32px66; break;
                    case 67: image = Properties.Resources.ledblack32px67; break;
                    case 68: image = Properties.Resources.ledblack32px68; break;
                    case 69: image = Properties.Resources.ledblack32px69; break;
                    case 70: image = Properties.Resources.ledblack32px70; break;
                    case 71: image = Properties.Resources.ledblack32px71; break;
                    case 72: image = Properties.Resources.ledblack32px72; break;
                    case 73: image = Properties.Resources.ledblack32px73; break;
                    case 74: image = Properties.Resources.ledblack32px74; break;
                    case 75: image = Properties.Resources.ledblack32px75; break;
                    case 76: image = Properties.Resources.ledblack32px76; break;
                    case 77: image = Properties.Resources.ledblack32px77; break;
                    case 78: image = Properties.Resources.ledblack32px78; break;
                    case 79: image = Properties.Resources.ledblack32px79; break;
                    case 80: image = Properties.Resources.ledblack32px80; break;
                    case 81: image = Properties.Resources.ledblack32px81; break;
                    case 82: image = Properties.Resources.ledblack32px82; break;
                    case 83: image = Properties.Resources.ledblack32px83; break;
                    case 84: image = Properties.Resources.ledblack32px84; break;
                    case 85: image = Properties.Resources.ledblack32px85; break;
                    case 86: image = Properties.Resources.ledblack32px86; break;
                    case 87: image = Properties.Resources.ledblack32px87; break;
                    case 88: image = Properties.Resources.ledblack32px88; break;
                    case 89: image = Properties.Resources.ledblack32px89; break;
                    case 90: image = Properties.Resources.ledblack32px90; break;
                    case 91: image = Properties.Resources.ledblack32px91; break;
                    case 92: image = Properties.Resources.ledblack32px92; break;
                    case 93: image = Properties.Resources.ledblack32px93; break;
                    case 94: image = Properties.Resources.ledblack32px94; break;
                    case 95: image = Properties.Resources.ledblack32px95; break;
                    case 96: image = Properties.Resources.ledblack32px96; break;
                    case 97: image = Properties.Resources.ledblack32px97; break;
                    case 98: image = Properties.Resources.ledblack32px98; break;
                    case 99: image = Properties.Resources.ledblack32px99; break;
                    case 100: image = Properties.Resources.ledblack32px100; break;
                    case 101: image = Properties.Resources.ledblack32px101; break;
                    case 102: image = Properties.Resources.ledblack32px102; break;
                    case 103: image = Properties.Resources.ledblack32px103; break;
                    case 104: image = Properties.Resources.ledblack32px104; break;
                    case 105: image = Properties.Resources.ledblack32px105; break;
                    case 106: image = Properties.Resources.ledblack32px106; break;
                    case 107: image = Properties.Resources.ledblack32px107; break;
                    case 108: image = Properties.Resources.ledblack32px108; break;
                    case 109: image = Properties.Resources.ledblack32px109; break;
                    case 110: image = Properties.Resources.ledblack32px110; break;
                    case 111: image = Properties.Resources.ledblack32px111; break;
                    case 112: image = Properties.Resources.ledblack32px112; break;
                    case 113: image = Properties.Resources.ledblack32px113; break;
                    case 114: image = Properties.Resources.ledblack32px114; break;
                    case 115: image = Properties.Resources.ledblack32px115; break;
                    case 116: image = Properties.Resources.ledblack32px116; break;
                    case 117: image = Properties.Resources.ledblack32px117; break;
                    case 118: image = Properties.Resources.ledblack32px118; break;
                    case 119: image = Properties.Resources.ledblack32px119; break;
                    case 120: image = Properties.Resources.ledblack32px120; break;
                    case 121: image = Properties.Resources.ledblack32px121; break;
                    case 122: image = Properties.Resources.ledblack32px122; break;
                    case 123: image = Properties.Resources.ledblack32px123; break;
                    case 124: image = Properties.Resources.ledblack32px124; break;
                    case 125: image = Properties.Resources.ledblack32px125; break;
                    case 126: image = Properties.Resources.ledblack32px126; break;
                    case 127: image = Properties.Resources.ledblack32px127; break;
                    case 128: image = Properties.Resources.ledblack32px128; break;
                    case 129: image = Properties.Resources.ledblack32px129; break;
                    case 130: image = Properties.Resources.ledblack32px130; break;
                    case 131: image = Properties.Resources.ledblack32px131; break;
                    case 132: image = Properties.Resources.ledblack32px132; break;
                    case 133: image = Properties.Resources.ledblack32px133; break;
                    case 134: image = Properties.Resources.ledblack32px134; break;
                    case 135: image = Properties.Resources.ledblack32px135; break;
                    case 136: image = Properties.Resources.ledblack32px136; break;
                    case 137: image = Properties.Resources.ledblack32px137; break;
                    case 138: image = Properties.Resources.ledblack32px138; break;
                    case 139: image = Properties.Resources.ledblack32px139; break;
                    case 140: image = Properties.Resources.ledblack32px140; break;
                    case 141: image = Properties.Resources.ledblack32px141; break;
                    case 142: image = Properties.Resources.ledblack32px142; break;
                    case 143: image = Properties.Resources.ledblack32px143; break;
                    case 144: image = Properties.Resources.ledblack32px144; break;
                    case 145: image = Properties.Resources.ledblack32px145; break;
                    case 146: image = Properties.Resources.ledblack32px146; break;
                    case 147: image = Properties.Resources.ledblack32px147; break;
                    case 148: image = Properties.Resources.ledblack32px148; break;
                    case 149: image = Properties.Resources.ledblack32px149; break;
                    case 150: image = Properties.Resources.ledblack32px150; break;
                    case 151: image = Properties.Resources.ledblack32px151; break;
                    case 152: image = Properties.Resources.ledblack32px152; break;
                    case 153: image = Properties.Resources.ledblack32px153; break;
                    case 154: image = Properties.Resources.ledblack32px154; break;
                    case 155: image = Properties.Resources.ledblack32px155; break;
                    case 156: image = Properties.Resources.ledblack32px156; break;
                    case 157: image = Properties.Resources.ledblack32px157; break;
                    case 158: image = Properties.Resources.ledblack32px158; break;
                    case 159: image = Properties.Resources.ledblack32px159; break;
                    case 160: image = Properties.Resources.ledblack32px160; break;
                    case 161: image = Properties.Resources.ledblack32px161; break;
                    case 162: image = Properties.Resources.ledblack32px162; break;
                    case 163: image = Properties.Resources.ledblack32px163; break;
                    case 164: image = Properties.Resources.ledblack32px164; break;
                    case 165: image = Properties.Resources.ledblack32px165; break;
                    case 166: image = Properties.Resources.ledblack32px166; break;
                    case 167: image = Properties.Resources.ledblack32px167; break;
                    case 168: image = Properties.Resources.ledblack32px168; break;
                    case 169: image = Properties.Resources.ledblack32px169; break;
                    case 170: image = Properties.Resources.ledblack32px170; break;
                    case 171: image = Properties.Resources.ledblack32px171; break;
                    case 172: image = Properties.Resources.ledblack32px172; break;
                    case 173: image = Properties.Resources.ledblack32px173; break;
                    case 174: image = Properties.Resources.ledblack32px174; break;
                    case 175: image = Properties.Resources.ledblack32px175; break;
                    case 176: image = Properties.Resources.ledblack32px176; break;
                    case 177: image = Properties.Resources.ledblack32px177; break;
                    case 178: image = Properties.Resources.ledblack32px178; break;
                    case 179: image = Properties.Resources.ledblack32px179; break;
                    case 180: image = Properties.Resources.ledblack32px180; break;
                    case 181: image = Properties.Resources.ledblack32px181; break;
                    case 182: image = Properties.Resources.ledblack32px182; break;
                    case 183: image = Properties.Resources.ledblack32px183; break;
                    case 184: image = Properties.Resources.ledblack32px184; break;
                    case 185: image = Properties.Resources.ledblack32px185; break;
                    case 186: image = Properties.Resources.ledblack32px186; break;
                    case 187: image = Properties.Resources.ledblack32px187; break;
                    case 188: image = Properties.Resources.ledblack32px188; break;
                    case 189: image = Properties.Resources.ledblack32px189; break;
                    case 190: image = Properties.Resources.ledblack32px190; break;
                    case 191: image = Properties.Resources.ledblack32px191; break;
                    case 192: image = Properties.Resources.ledblack32px192; break;
                    case 193: image = Properties.Resources.ledblack32px193; break;
                    case 194: image = Properties.Resources.ledblack32px194; break;
                    case 195: image = Properties.Resources.ledblack32px195; break;
                    case 196: image = Properties.Resources.ledblack32px196; break;
                    case 197: image = Properties.Resources.ledblack32px197; break;
                    case 198: image = Properties.Resources.ledblack32px198; break;
                    case 199: image = Properties.Resources.ledblack32px199; break;
                    case 200: image = Properties.Resources.ledblack32px200; break;
                    case 201: image = Properties.Resources.ledblack32px201; break;
                    case 202: image = Properties.Resources.ledblack32px202; break;
                    case 203: image = Properties.Resources.ledblack32px203; break;
                    case 204: image = Properties.Resources.ledblack32px204; break;
                    case 205: image = Properties.Resources.ledblack32px205; break;
                    case 206: image = Properties.Resources.ledblack32px206; break;
                    case 207: image = Properties.Resources.ledblack32px207; break;
                    case 208: image = Properties.Resources.ledblack32px208; break;
                    case 209: image = Properties.Resources.ledblack32px209; break;
                    case 210: image = Properties.Resources.ledblack32px210; break;
                    case 211: image = Properties.Resources.ledblack32px211; break;
                    case 212: image = Properties.Resources.ledblack32px212; break;
                    case 213: image = Properties.Resources.ledblack32px213; break;
                    case 214: image = Properties.Resources.ledblack32px214; break;
                    case 215: image = Properties.Resources.ledblack32px215; break;
                    case 216: image = Properties.Resources.ledblack32px216; break;
                    case 217: image = Properties.Resources.ledblack32px217; break;
                    case 218: image = Properties.Resources.ledblack32px218; break;
                    case 219: image = Properties.Resources.ledblack32px219; break;
                    case 220: image = Properties.Resources.ledblack32px220; break;
                    case 221: image = Properties.Resources.ledblack32px221; break;
                    case 222: image = Properties.Resources.ledblack32px222; break;
                    case 223: image = Properties.Resources.ledblack32px223; break;
                    case 224: image = Properties.Resources.ledblack32px224; break;
                    case 225: image = Properties.Resources.ledblack32px225; break;
                    case 226: image = Properties.Resources.ledblack32px226; break;
                    case 227: image = Properties.Resources.ledblack32px227; break;
                    case 228: image = Properties.Resources.ledblack32px228; break;
                    case 229: image = Properties.Resources.ledblack32px229; break;
                    case 230: image = Properties.Resources.ledblack32px230; break;
                    case 231: image = Properties.Resources.ledblack32px231; break;
                    case 232: image = Properties.Resources.ledblack32px232; break;
                    case 233: image = Properties.Resources.ledblack32px233; break;
                    case 234: image = Properties.Resources.ledblack32px234; break;
                    case 235: image = Properties.Resources.ledblack32px235; break;
                    case 236: image = Properties.Resources.ledblack32px236; break;
                    case 237: image = Properties.Resources.ledblack32px237; break;
                    case 238: image = Properties.Resources.ledblack32px238; break;
                    case 239: image = Properties.Resources.ledblack32px239; break;
                    case 240: image = Properties.Resources.ledblack32px240; break;
                    case 241: image = Properties.Resources.ledblack32px241; break;
                    case 242: image = Properties.Resources.ledblack32px242; break;
                    case 243: image = Properties.Resources.ledblack32px243; break;
                    case 244: image = Properties.Resources.ledblack32px244; break;
                    case 245: image = Properties.Resources.ledblack32px245; break;
                    case 246: image = Properties.Resources.ledblack32px246; break;
                    case 247: image = Properties.Resources.ledblack32px247; break;
                    case 248: image = Properties.Resources.ledblack32px248; break;
                    case 249: image = Properties.Resources.ledblack32px249; break;
                    case 250: image = Properties.Resources.ledblack32px250; break;
                    case 251: image = Properties.Resources.ledblack32px251; break;
                    case 252: image = Properties.Resources.ledblack32px252; break;
                    case 253: image = Properties.Resources.ledblack32px253; break;
                    case 254: image = Properties.Resources.ledblack32px254; break;
                    case 255: image = Properties.Resources.ledblack32px255; break;
                    default: image = Properties.Resources.Ledblack32px; break;
                }
            }

            else if (colour == LedColour.GREEN)
            {
                switch (number)
                {
                    case 1: image = Properties.Resources.LedGreen32px1; break;
                    case 2: image = Properties.Resources.LedGreen32px2; break;
                    case 3: image = Properties.Resources.LedGreen32px3; break;
                    case 4: image = Properties.Resources.LedGreen32px4; break;
                    case 5: image = Properties.Resources.LedGreen32px5; break;
                    case 6: image = Properties.Resources.LedGreen32px6; break;
                    case 7: image = Properties.Resources.LedGreen32px7; break;
                    case 8: image = Properties.Resources.LedGreen32px8; break;
                    case 9: image = Properties.Resources.LedGreen32px9; break;
                    case 10: image = Properties.Resources.LedGreen32px10; break;
                    case 11: image = Properties.Resources.LedGreen32px11; break;
                    case 12: image = Properties.Resources.LedGreen32px12; break;
                    case 13: image = Properties.Resources.LedGreen32px13; break;
                    case 14: image = Properties.Resources.LedGreen32px14; break;
                    case 15: image = Properties.Resources.LedGreen32px15; break;
                    case 16: image = Properties.Resources.LedGreen32px16; break;
                    case 17: image = Properties.Resources.LedGreen32px17; break;
                    case 18: image = Properties.Resources.LedGreen32px18; break;
                    case 19: image = Properties.Resources.LedGreen32px19; break;
                    case 20: image = Properties.Resources.LedGreen32px20; break;
                    case 21: image = Properties.Resources.LedGreen32px21; break;
                    case 22: image = Properties.Resources.LedGreen32px22; break;
                    case 23: image = Properties.Resources.LedGreen32px23; break;
                    case 24: image = Properties.Resources.LedGreen32px24; break;
                    case 25: image = Properties.Resources.LedGreen32px25; break;
                    case 26: image = Properties.Resources.LedGreen32px26; break;
                    case 27: image = Properties.Resources.LedGreen32px27; break;
                    case 28: image = Properties.Resources.LedGreen32px28; break;
                    case 29: image = Properties.Resources.LedGreen32px29; break;
                    case 30: image = Properties.Resources.LedGreen32px30; break;
                    case 31: image = Properties.Resources.LedGreen32px31; break;
                    case 32: image = Properties.Resources.LedGreen32px32; break;
                    case 33: image = Properties.Resources.LedGreen32px33; break;
                    case 34: image = Properties.Resources.LedGreen32px34; break;
                    case 35: image = Properties.Resources.LedGreen32px35; break;
                    case 36: image = Properties.Resources.LedGreen32px36; break;
                    case 37: image = Properties.Resources.LedGreen32px37; break;
                    case 38: image = Properties.Resources.LedGreen32px38; break;
                    case 39: image = Properties.Resources.LedGreen32px39; break;
                    case 40: image = Properties.Resources.LedGreen32px40; break;
                    case 41: image = Properties.Resources.LedGreen32px41; break;
                    case 42: image = Properties.Resources.LedGreen32px42; break;
                    case 43: image = Properties.Resources.LedGreen32px43; break;
                    case 44: image = Properties.Resources.LedGreen32px44; break;
                    case 45: image = Properties.Resources.LedGreen32px45; break;
                    case 46: image = Properties.Resources.LedGreen32px46; break;
                    case 47: image = Properties.Resources.LedGreen32px47; break;
                    case 48: image = Properties.Resources.LedGreen32px48; break;
                    case 49: image = Properties.Resources.LedGreen32px49; break;
                    case 50: image = Properties.Resources.LedGreen32px50; break;
                    case 51: image = Properties.Resources.LedGreen32px51; break;
                    case 52: image = Properties.Resources.LedGreen32px52; break;
                    case 53: image = Properties.Resources.LedGreen32px53; break;
                    case 54: image = Properties.Resources.LedGreen32px54; break;
                    case 55: image = Properties.Resources.LedGreen32px55; break;
                    case 56: image = Properties.Resources.LedGreen32px56; break;
                    case 57: image = Properties.Resources.LedGreen32px57; break;
                    case 58: image = Properties.Resources.LedGreen32px58; break;
                    case 59: image = Properties.Resources.LedGreen32px59; break;
                    case 60: image = Properties.Resources.LedGreen32px60; break;
                    case 61: image = Properties.Resources.LedGreen32px61; break;
                    case 62: image = Properties.Resources.LedGreen32px62; break;
                    case 63: image = Properties.Resources.LedGreen32px63; break;
                    case 64: image = Properties.Resources.LedGreen32px64; break;
                    case 65: image = Properties.Resources.LedGreen32px65; break;
                    case 66: image = Properties.Resources.LedGreen32px66; break;
                    case 67: image = Properties.Resources.LedGreen32px67; break;
                    case 68: image = Properties.Resources.LedGreen32px68; break;
                    case 69: image = Properties.Resources.LedGreen32px69; break;
                    case 70: image = Properties.Resources.LedGreen32px70; break;
                    case 71: image = Properties.Resources.LedGreen32px71; break;
                    case 72: image = Properties.Resources.LedGreen32px72; break;
                    case 73: image = Properties.Resources.LedGreen32px73; break;
                    case 74: image = Properties.Resources.LedGreen32px74; break;
                    case 75: image = Properties.Resources.LedGreen32px75; break;
                    case 76: image = Properties.Resources.LedGreen32px76; break;
                    case 77: image = Properties.Resources.LedGreen32px77; break;
                    case 78: image = Properties.Resources.LedGreen32px78; break;
                    case 79: image = Properties.Resources.LedGreen32px79; break;
                    case 80: image = Properties.Resources.LedGreen32px80; break;
                    case 81: image = Properties.Resources.LedGreen32px81; break;
                    case 82: image = Properties.Resources.LedGreen32px82; break;
                    case 83: image = Properties.Resources.LedGreen32px83; break;
                    case 84: image = Properties.Resources.LedGreen32px84; break;
                    case 85: image = Properties.Resources.LedGreen32px85; break;
                    case 86: image = Properties.Resources.LedGreen32px86; break;
                    case 87: image = Properties.Resources.LedGreen32px87; break;
                    case 88: image = Properties.Resources.LedGreen32px88; break;
                    case 89: image = Properties.Resources.LedGreen32px89; break;
                    case 90: image = Properties.Resources.LedGreen32px90; break;
                    case 91: image = Properties.Resources.LedGreen32px91; break;
                    case 92: image = Properties.Resources.LedGreen32px92; break;
                    case 93: image = Properties.Resources.LedGreen32px93; break;
                    case 94: image = Properties.Resources.LedGreen32px94; break;
                    case 95: image = Properties.Resources.LedGreen32px95; break;
                    case 96: image = Properties.Resources.LedGreen32px96; break;
                    case 97: image = Properties.Resources.LedGreen32px97; break;
                    case 98: image = Properties.Resources.LedGreen32px98; break;
                    case 99: image = Properties.Resources.LedGreen32px99; break;
                    case 100: image = Properties.Resources.LedGreen32px100; break;
                    case 101: image = Properties.Resources.LedGreen32px101; break;
                    case 102: image = Properties.Resources.LedGreen32px102; break;
                    case 103: image = Properties.Resources.LedGreen32px103; break;
                    case 104: image = Properties.Resources.LedGreen32px104; break;
                    case 105: image = Properties.Resources.LedGreen32px105; break;
                    case 106: image = Properties.Resources.LedGreen32px106; break;
                    case 107: image = Properties.Resources.LedGreen32px107; break;
                    case 108: image = Properties.Resources.LedGreen32px108; break;
                    case 109: image = Properties.Resources.LedGreen32px109; break;
                    case 110: image = Properties.Resources.LedGreen32px110; break;
                    case 111: image = Properties.Resources.LedGreen32px111; break;
                    case 112: image = Properties.Resources.LedGreen32px112; break;
                    case 113: image = Properties.Resources.LedGreen32px113; break;
                    case 114: image = Properties.Resources.LedGreen32px114; break;
                    case 115: image = Properties.Resources.LedGreen32px115; break;
                    case 116: image = Properties.Resources.LedGreen32px116; break;
                    case 117: image = Properties.Resources.LedGreen32px117; break;
                    case 118: image = Properties.Resources.LedGreen32px118; break;
                    case 119: image = Properties.Resources.LedGreen32px119; break;
                    case 120: image = Properties.Resources.LedGreen32px120; break;
                    case 121: image = Properties.Resources.LedGreen32px121; break;
                    case 122: image = Properties.Resources.LedGreen32px122; break;
                    case 123: image = Properties.Resources.LedGreen32px123; break;
                    case 124: image = Properties.Resources.LedGreen32px124; break;
                    case 125: image = Properties.Resources.LedGreen32px125; break;
                    case 126: image = Properties.Resources.LedGreen32px126; break;
                    case 127: image = Properties.Resources.LedGreen32px127; break;
                    case 128: image = Properties.Resources.LedGreen32px128; break;
                    case 129: image = Properties.Resources.LedGreen32px129; break;
                    case 130: image = Properties.Resources.LedGreen32px130; break;
                    case 131: image = Properties.Resources.LedGreen32px131; break;
                    case 132: image = Properties.Resources.LedGreen32px132; break;
                    case 133: image = Properties.Resources.LedGreen32px133; break;
                    case 134: image = Properties.Resources.LedGreen32px134; break;
                    case 135: image = Properties.Resources.LedGreen32px135; break;
                    case 136: image = Properties.Resources.LedGreen32px136; break;
                    case 137: image = Properties.Resources.LedGreen32px137; break;
                    case 138: image = Properties.Resources.LedGreen32px138; break;
                    case 139: image = Properties.Resources.LedGreen32px139; break;
                    case 140: image = Properties.Resources.LedGreen32px140; break;
                    case 141: image = Properties.Resources.LedGreen32px141; break;
                    case 142: image = Properties.Resources.LedGreen32px142; break;
                    case 143: image = Properties.Resources.LedGreen32px143; break;
                    case 144: image = Properties.Resources.LedGreen32px144; break;
                    case 145: image = Properties.Resources.LedGreen32px145; break;
                    case 146: image = Properties.Resources.LedGreen32px146; break;
                    case 147: image = Properties.Resources.LedGreen32px147; break;
                    case 148: image = Properties.Resources.LedGreen32px148; break;
                    case 149: image = Properties.Resources.LedGreen32px149; break;
                    case 150: image = Properties.Resources.LedGreen32px150; break;
                    case 151: image = Properties.Resources.LedGreen32px151; break;
                    case 152: image = Properties.Resources.LedGreen32px152; break;
                    case 153: image = Properties.Resources.LedGreen32px153; break;
                    case 154: image = Properties.Resources.LedGreen32px154; break;
                    case 155: image = Properties.Resources.LedGreen32px155; break;
                    case 156: image = Properties.Resources.LedGreen32px156; break;
                    case 157: image = Properties.Resources.LedGreen32px157; break;
                    case 158: image = Properties.Resources.LedGreen32px158; break;
                    case 159: image = Properties.Resources.LedGreen32px159; break;
                    case 160: image = Properties.Resources.LedGreen32px160; break;
                    case 161: image = Properties.Resources.LedGreen32px161; break;
                    case 162: image = Properties.Resources.LedGreen32px162; break;
                    case 163: image = Properties.Resources.LedGreen32px163; break;
                    case 164: image = Properties.Resources.LedGreen32px164; break;
                    case 165: image = Properties.Resources.LedGreen32px165; break;
                    case 166: image = Properties.Resources.LedGreen32px166; break;
                    case 167: image = Properties.Resources.LedGreen32px167; break;
                    case 168: image = Properties.Resources.LedGreen32px168; break;
                    case 169: image = Properties.Resources.LedGreen32px169; break;
                    case 170: image = Properties.Resources.LedGreen32px170; break;
                    case 171: image = Properties.Resources.LedGreen32px171; break;
                    case 172: image = Properties.Resources.LedGreen32px172; break;
                    case 173: image = Properties.Resources.LedGreen32px173; break;
                    case 174: image = Properties.Resources.LedGreen32px174; break;
                    case 175: image = Properties.Resources.LedGreen32px175; break;
                    case 176: image = Properties.Resources.LedGreen32px176; break;
                    case 177: image = Properties.Resources.LedGreen32px177; break;
                    case 178: image = Properties.Resources.LedGreen32px178; break;
                    case 179: image = Properties.Resources.LedGreen32px179; break;
                    case 180: image = Properties.Resources.LedGreen32px180; break;
                    case 181: image = Properties.Resources.LedGreen32px181; break;
                    case 182: image = Properties.Resources.LedGreen32px182; break;
                    case 183: image = Properties.Resources.LedGreen32px183; break;
                    case 184: image = Properties.Resources.LedGreen32px184; break;
                    case 185: image = Properties.Resources.LedGreen32px185; break;
                    case 186: image = Properties.Resources.LedGreen32px186; break;
                    case 187: image = Properties.Resources.LedGreen32px187; break;
                    case 188: image = Properties.Resources.LedGreen32px188; break;
                    case 189: image = Properties.Resources.LedGreen32px189; break;
                    case 190: image = Properties.Resources.LedGreen32px190; break;
                    case 191: image = Properties.Resources.LedGreen32px191; break;
                    case 192: image = Properties.Resources.LedGreen32px192; break;
                    case 193: image = Properties.Resources.LedGreen32px193; break;
                    case 194: image = Properties.Resources.LedGreen32px194; break;
                    case 195: image = Properties.Resources.LedGreen32px195; break;
                    case 196: image = Properties.Resources.LedGreen32px196; break;
                    case 197: image = Properties.Resources.LedGreen32px197; break;
                    case 198: image = Properties.Resources.LedGreen32px198; break;
                    case 199: image = Properties.Resources.LedGreen32px199; break;
                    case 200: image = Properties.Resources.LedGreen32px200; break;
                    case 201: image = Properties.Resources.LedGreen32px201; break;
                    case 202: image = Properties.Resources.LedGreen32px202; break;
                    case 203: image = Properties.Resources.LedGreen32px203; break;
                    case 204: image = Properties.Resources.LedGreen32px204; break;
                    case 205: image = Properties.Resources.LedGreen32px205; break;
                    case 206: image = Properties.Resources.LedGreen32px206; break;
                    case 207: image = Properties.Resources.LedGreen32px207; break;
                    case 208: image = Properties.Resources.LedGreen32px208; break;
                    case 209: image = Properties.Resources.LedGreen32px209; break;
                    case 210: image = Properties.Resources.LedGreen32px210; break;
                    case 211: image = Properties.Resources.LedGreen32px211; break;
                    case 212: image = Properties.Resources.LedGreen32px212; break;
                    case 213: image = Properties.Resources.LedGreen32px213; break;
                    case 214: image = Properties.Resources.LedGreen32px214; break;
                    case 215: image = Properties.Resources.LedGreen32px215; break;
                    case 216: image = Properties.Resources.LedGreen32px216; break;
                    case 217: image = Properties.Resources.LedGreen32px217; break;
                    case 218: image = Properties.Resources.LedGreen32px218; break;
                    case 219: image = Properties.Resources.LedGreen32px219; break;
                    case 220: image = Properties.Resources.LedGreen32px220; break;
                    case 221: image = Properties.Resources.LedGreen32px221; break;
                    case 222: image = Properties.Resources.LedGreen32px222; break;
                    case 223: image = Properties.Resources.LedGreen32px223; break;
                    case 224: image = Properties.Resources.LedGreen32px224; break;
                    case 225: image = Properties.Resources.LedGreen32px225; break;
                    case 226: image = Properties.Resources.LedGreen32px226; break;
                    case 227: image = Properties.Resources.LedGreen32px227; break;
                    case 228: image = Properties.Resources.LedGreen32px228; break;
                    case 229: image = Properties.Resources.LedGreen32px229; break;
                    case 230: image = Properties.Resources.LedGreen32px230; break;
                    case 231: image = Properties.Resources.LedGreen32px231; break;
                    case 232: image = Properties.Resources.LedGreen32px232; break;
                    case 233: image = Properties.Resources.LedGreen32px233; break;
                    case 234: image = Properties.Resources.LedGreen32px234; break;
                    case 235: image = Properties.Resources.LedGreen32px235; break;
                    case 236: image = Properties.Resources.LedGreen32px236; break;
                    case 237: image = Properties.Resources.LedGreen32px237; break;
                    case 238: image = Properties.Resources.LedGreen32px238; break;
                    case 239: image = Properties.Resources.LedGreen32px239; break;
                    case 240: image = Properties.Resources.LedGreen32px240; break;
                    case 241: image = Properties.Resources.LedGreen32px241; break;
                    case 242: image = Properties.Resources.LedGreen32px242; break;
                    case 243: image = Properties.Resources.LedGreen32px243; break;
                    case 244: image = Properties.Resources.LedGreen32px244; break;
                    case 245: image = Properties.Resources.LedGreen32px245; break;
                    case 246: image = Properties.Resources.LedGreen32px246; break;
                    case 247: image = Properties.Resources.LedGreen32px247; break;
                    case 248: image = Properties.Resources.LedGreen32px248; break;
                    case 249: image = Properties.Resources.LedGreen32px249; break;
                    case 250: image = Properties.Resources.LedGreen32px250; break;
                    case 251: image = Properties.Resources.LedGreen32px251; break;
                    case 252: image = Properties.Resources.LedGreen32px252; break;
                    case 253: image = Properties.Resources.LedGreen32px253; break;
                    case 254: image = Properties.Resources.LedGreen32px254; break;
                    case 255: image = Properties.Resources.LedGreen32px255; break;

                    default: image = Properties.Resources.LedGreen32px; break;
                }
            }

            else if (colour == LedColour.RED)
            {
                switch (number)
                {
                    case 1: image = Properties.Resources.LedRed32px1; break;
                    case 2: image = Properties.Resources.LedRed32px2; break;
                    case 3: image = Properties.Resources.LedRed32px3; break;
                    case 4: image = Properties.Resources.LedRed32px4; break;
                    case 5: image = Properties.Resources.LedRed32px5; break;
                    case 6: image = Properties.Resources.LedRed32px6; break;
                    case 7: image = Properties.Resources.LedRed32px7; break;
                    case 8: image = Properties.Resources.LedRed32px8; break;
                    case 9: image = Properties.Resources.LedRed32px9; break;
                    case 10: image = Properties.Resources.LedRed32px10; break;
                    case 11: image = Properties.Resources.LedRed32px11; break;
                    case 12: image = Properties.Resources.LedRed32px12; break;
                    case 13: image = Properties.Resources.LedRed32px13; break;
                    case 14: image = Properties.Resources.LedRed32px14; break;
                    case 15: image = Properties.Resources.LedRed32px15; break;
                    case 16: image = Properties.Resources.LedRed32px16; break;
                    case 17: image = Properties.Resources.LedRed32px17; break;
                    case 18: image = Properties.Resources.LedRed32px18; break;
                    case 19: image = Properties.Resources.LedRed32px19; break;
                    case 20: image = Properties.Resources.LedRed32px20; break;
                    case 21: image = Properties.Resources.LedRed32px21; break;
                    case 22: image = Properties.Resources.LedRed32px22; break;
                    case 23: image = Properties.Resources.LedRed32px23; break;
                    case 24: image = Properties.Resources.LedRed32px24; break;
                    case 25: image = Properties.Resources.LedRed32px25; break;
                    case 26: image = Properties.Resources.LedRed32px26; break;
                    case 27: image = Properties.Resources.LedRed32px27; break;
                    case 28: image = Properties.Resources.LedRed32px28; break;
                    case 29: image = Properties.Resources.LedRed32px29; break;
                    case 30: image = Properties.Resources.LedRed32px30; break;
                    case 31: image = Properties.Resources.LedRed32px31; break;
                    case 32: image = Properties.Resources.LedRed32px32; break;
                    case 33: image = Properties.Resources.LedRed32px33; break;
                    case 34: image = Properties.Resources.LedRed32px34; break;
                    case 35: image = Properties.Resources.LedRed32px35; break;
                    case 36: image = Properties.Resources.LedRed32px36; break;
                    case 37: image = Properties.Resources.LedRed32px37; break;
                    case 38: image = Properties.Resources.LedRed32px38; break;
                    case 39: image = Properties.Resources.LedRed32px39; break;
                    case 40: image = Properties.Resources.LedRed32px40; break;
                    case 41: image = Properties.Resources.LedRed32px41; break;
                    case 42: image = Properties.Resources.LedRed32px42; break;
                    case 43: image = Properties.Resources.LedRed32px43; break;
                    case 44: image = Properties.Resources.LedRed32px44; break;
                    case 45: image = Properties.Resources.LedRed32px45; break;
                    case 46: image = Properties.Resources.LedRed32px46; break;
                    case 47: image = Properties.Resources.LedRed32px47; break;
                    case 48: image = Properties.Resources.LedRed32px48; break;
                    case 49: image = Properties.Resources.LedRed32px49; break;
                    case 50: image = Properties.Resources.LedRed32px50; break;
                    case 51: image = Properties.Resources.LedRed32px51; break;
                    case 52: image = Properties.Resources.LedRed32px52; break;
                    case 53: image = Properties.Resources.LedRed32px53; break;
                    case 54: image = Properties.Resources.LedRed32px54; break;
                    case 55: image = Properties.Resources.LedRed32px55; break;
                    case 56: image = Properties.Resources.LedRed32px56; break;
                    case 57: image = Properties.Resources.LedRed32px57; break;
                    case 58: image = Properties.Resources.LedRed32px58; break;
                    case 59: image = Properties.Resources.LedRed32px59; break;
                    case 60: image = Properties.Resources.LedRed32px60; break;
                    case 61: image = Properties.Resources.LedRed32px61; break;
                    case 62: image = Properties.Resources.LedRed32px62; break;
                    case 63: image = Properties.Resources.LedRed32px63; break;
                    case 64: image = Properties.Resources.LedRed32px64; break;
                    case 65: image = Properties.Resources.LedRed32px65; break;
                    case 66: image = Properties.Resources.LedRed32px66; break;
                    case 67: image = Properties.Resources.LedRed32px67; break;
                    case 68: image = Properties.Resources.LedRed32px68; break;
                    case 69: image = Properties.Resources.LedRed32px69; break;
                    case 70: image = Properties.Resources.LedRed32px70; break;
                    case 71: image = Properties.Resources.LedRed32px71; break;
                    case 72: image = Properties.Resources.LedRed32px72; break;
                    case 73: image = Properties.Resources.LedRed32px73; break;
                    case 74: image = Properties.Resources.LedRed32px74; break;
                    case 75: image = Properties.Resources.LedRed32px75; break;
                    case 76: image = Properties.Resources.LedRed32px76; break;
                    case 77: image = Properties.Resources.LedRed32px77; break;
                    case 78: image = Properties.Resources.LedRed32px78; break;
                    case 79: image = Properties.Resources.LedRed32px79; break;
                    case 80: image = Properties.Resources.LedRed32px80; break;
                    case 81: image = Properties.Resources.LedRed32px81; break;
                    case 82: image = Properties.Resources.LedRed32px82; break;
                    case 83: image = Properties.Resources.LedRed32px83; break;
                    case 84: image = Properties.Resources.LedRed32px84; break;
                    case 85: image = Properties.Resources.LedRed32px85; break;
                    case 86: image = Properties.Resources.LedRed32px86; break;
                    case 87: image = Properties.Resources.LedRed32px87; break;
                    case 88: image = Properties.Resources.LedRed32px88; break;
                    case 89: image = Properties.Resources.LedRed32px89; break;
                    case 90: image = Properties.Resources.LedRed32px90; break;
                    case 91: image = Properties.Resources.LedRed32px91; break;
                    case 92: image = Properties.Resources.LedRed32px92; break;
                    case 93: image = Properties.Resources.LedRed32px93; break;
                    case 94: image = Properties.Resources.LedRed32px94; break;
                    case 95: image = Properties.Resources.LedRed32px95; break;
                    case 96: image = Properties.Resources.LedRed32px96; break;
                    case 97: image = Properties.Resources.LedRed32px97; break;
                    case 98: image = Properties.Resources.LedRed32px98; break;
                    case 99: image = Properties.Resources.LedRed32px99; break;
                    case 100: image = Properties.Resources.LedRed32px100; break;
                    case 101: image = Properties.Resources.LedRed32px101; break;
                    case 102: image = Properties.Resources.LedRed32px102; break;
                    case 103: image = Properties.Resources.LedRed32px103; break;
                    case 104: image = Properties.Resources.LedRed32px104; break;
                    case 105: image = Properties.Resources.LedRed32px105; break;
                    case 106: image = Properties.Resources.LedRed32px106; break;
                    case 107: image = Properties.Resources.LedRed32px107; break;
                    case 108: image = Properties.Resources.LedRed32px108; break;
                    case 109: image = Properties.Resources.LedRed32px109; break;
                    case 110: image = Properties.Resources.LedRed32px110; break;
                    case 111: image = Properties.Resources.LedRed32px111; break;
                    case 112: image = Properties.Resources.LedRed32px112; break;
                    case 113: image = Properties.Resources.LedRed32px113; break;
                    case 114: image = Properties.Resources.LedRed32px114; break;
                    case 115: image = Properties.Resources.LedRed32px115; break;
                    case 116: image = Properties.Resources.LedRed32px116; break;
                    case 117: image = Properties.Resources.LedRed32px117; break;
                    case 118: image = Properties.Resources.LedRed32px118; break;
                    case 119: image = Properties.Resources.LedRed32px119; break;
                    case 120: image = Properties.Resources.LedRed32px120; break;
                    case 121: image = Properties.Resources.LedRed32px121; break;
                    case 122: image = Properties.Resources.LedRed32px122; break;
                    case 123: image = Properties.Resources.LedRed32px123; break;
                    case 124: image = Properties.Resources.LedRed32px124; break;
                    case 125: image = Properties.Resources.LedRed32px125; break;
                    case 126: image = Properties.Resources.LedRed32px126; break;
                    case 127: image = Properties.Resources.LedRed32px127; break;
                    case 128: image = Properties.Resources.LedRed32px128; break;
                    case 129: image = Properties.Resources.LedRed32px129; break;
                    case 130: image = Properties.Resources.LedRed32px130; break;
                    case 131: image = Properties.Resources.LedRed32px131; break;
                    case 132: image = Properties.Resources.LedRed32px132; break;
                    case 133: image = Properties.Resources.LedRed32px133; break;
                    case 134: image = Properties.Resources.LedRed32px134; break;
                    case 135: image = Properties.Resources.LedRed32px135; break;
                    case 136: image = Properties.Resources.LedRed32px136; break;
                    case 137: image = Properties.Resources.LedRed32px137; break;
                    case 138: image = Properties.Resources.LedRed32px138; break;
                    case 139: image = Properties.Resources.LedRed32px139; break;
                    case 140: image = Properties.Resources.LedRed32px140; break;
                    case 141: image = Properties.Resources.LedRed32px141; break;
                    case 142: image = Properties.Resources.LedRed32px142; break;
                    case 143: image = Properties.Resources.LedRed32px143; break;
                    case 144: image = Properties.Resources.LedRed32px144; break;
                    case 145: image = Properties.Resources.LedRed32px145; break;
                    case 146: image = Properties.Resources.LedRed32px146; break;
                    case 147: image = Properties.Resources.LedRed32px147; break;
                    case 148: image = Properties.Resources.LedRed32px148; break;
                    case 149: image = Properties.Resources.LedRed32px149; break;
                    case 150: image = Properties.Resources.LedRed32px150; break;
                    case 151: image = Properties.Resources.LedRed32px151; break;
                    case 152: image = Properties.Resources.LedRed32px152; break;
                    case 153: image = Properties.Resources.LedRed32px153; break;
                    case 154: image = Properties.Resources.LedRed32px154; break;
                    case 155: image = Properties.Resources.LedRed32px155; break;
                    case 156: image = Properties.Resources.LedRed32px156; break;
                    case 157: image = Properties.Resources.LedRed32px157; break;
                    case 158: image = Properties.Resources.LedRed32px158; break;
                    case 159: image = Properties.Resources.LedRed32px159; break;
                    case 160: image = Properties.Resources.LedRed32px160; break;
                    case 161: image = Properties.Resources.LedRed32px161; break;
                    case 162: image = Properties.Resources.LedRed32px162; break;
                    case 163: image = Properties.Resources.LedRed32px163; break;
                    case 164: image = Properties.Resources.LedRed32px164; break;
                    case 165: image = Properties.Resources.LedRed32px165; break;
                    case 166: image = Properties.Resources.LedRed32px166; break;
                    case 167: image = Properties.Resources.LedRed32px167; break;
                    case 168: image = Properties.Resources.LedRed32px168; break;
                    case 169: image = Properties.Resources.LedRed32px169; break;
                    case 170: image = Properties.Resources.LedRed32px170; break;
                    case 171: image = Properties.Resources.LedRed32px171; break;
                    case 172: image = Properties.Resources.LedRed32px172; break;
                    case 173: image = Properties.Resources.LedRed32px173; break;
                    case 174: image = Properties.Resources.LedRed32px174; break;
                    case 175: image = Properties.Resources.LedRed32px175; break;
                    case 176: image = Properties.Resources.LedRed32px176; break;
                    case 177: image = Properties.Resources.LedRed32px177; break;
                    case 178: image = Properties.Resources.LedRed32px178; break;
                    case 179: image = Properties.Resources.LedRed32px179; break;
                    case 180: image = Properties.Resources.LedRed32px180; break;
                    case 181: image = Properties.Resources.LedRed32px181; break;
                    case 182: image = Properties.Resources.LedRed32px182; break;
                    case 183: image = Properties.Resources.LedRed32px183; break;
                    case 184: image = Properties.Resources.LedRed32px184; break;
                    case 185: image = Properties.Resources.LedRed32px185; break;
                    case 186: image = Properties.Resources.LedRed32px186; break;
                    case 187: image = Properties.Resources.LedRed32px187; break;
                    case 188: image = Properties.Resources.LedRed32px188; break;
                    case 189: image = Properties.Resources.LedRed32px189; break;
                    case 190: image = Properties.Resources.LedRed32px190; break;
                    case 191: image = Properties.Resources.LedRed32px191; break;
                    case 192: image = Properties.Resources.LedRed32px192; break;
                    case 193: image = Properties.Resources.LedRed32px193; break;
                    case 194: image = Properties.Resources.LedRed32px194; break;
                    case 195: image = Properties.Resources.LedRed32px195; break;
                    case 196: image = Properties.Resources.LedRed32px196; break;
                    case 197: image = Properties.Resources.LedRed32px197; break;
                    case 198: image = Properties.Resources.LedRed32px198; break;
                    case 199: image = Properties.Resources.LedRed32px199; break;
                    case 200: image = Properties.Resources.LedRed32px200; break;
                    case 201: image = Properties.Resources.LedRed32px201; break;
                    case 202: image = Properties.Resources.LedRed32px202; break;
                    case 203: image = Properties.Resources.LedRed32px203; break;
                    case 204: image = Properties.Resources.LedRed32px204; break;
                    case 205: image = Properties.Resources.LedRed32px205; break;
                    case 206: image = Properties.Resources.LedRed32px206; break;
                    case 207: image = Properties.Resources.LedRed32px207; break;
                    case 208: image = Properties.Resources.LedRed32px208; break;
                    case 209: image = Properties.Resources.LedRed32px209; break;
                    case 210: image = Properties.Resources.LedRed32px210; break;
                    case 211: image = Properties.Resources.LedRed32px211; break;
                    case 212: image = Properties.Resources.LedRed32px212; break;
                    case 213: image = Properties.Resources.LedRed32px213; break;
                    case 214: image = Properties.Resources.LedRed32px214; break;
                    case 215: image = Properties.Resources.LedRed32px215; break;
                    case 216: image = Properties.Resources.LedRed32px216; break;
                    case 217: image = Properties.Resources.LedRed32px217; break;
                    case 218: image = Properties.Resources.LedRed32px218; break;
                    case 219: image = Properties.Resources.LedRed32px219; break;
                    case 220: image = Properties.Resources.LedRed32px220; break;
                    case 221: image = Properties.Resources.LedRed32px221; break;
                    case 222: image = Properties.Resources.LedRed32px222; break;
                    case 223: image = Properties.Resources.LedRed32px223; break;
                    case 224: image = Properties.Resources.LedRed32px224; break;
                    case 225: image = Properties.Resources.LedRed32px225; break;
                    case 226: image = Properties.Resources.LedRed32px226; break;
                    case 227: image = Properties.Resources.LedRed32px227; break;
                    case 228: image = Properties.Resources.LedRed32px228; break;
                    case 229: image = Properties.Resources.LedRed32px229; break;
                    case 230: image = Properties.Resources.LedRed32px230; break;
                    case 231: image = Properties.Resources.LedRed32px231; break;
                    case 232: image = Properties.Resources.LedRed32px232; break;
                    case 233: image = Properties.Resources.LedRed32px233; break;
                    case 234: image = Properties.Resources.LedRed32px234; break;
                    case 235: image = Properties.Resources.LedRed32px235; break;
                    case 236: image = Properties.Resources.LedRed32px236; break;
                    case 237: image = Properties.Resources.LedRed32px237; break;
                    case 238: image = Properties.Resources.LedRed32px238; break;
                    case 239: image = Properties.Resources.LedRed32px239; break;
                    case 240: image = Properties.Resources.LedRed32px240; break;
                    case 241: image = Properties.Resources.LedRed32px241; break;
                    case 242: image = Properties.Resources.LedRed32px242; break;
                    case 243: image = Properties.Resources.LedRed32px243; break;
                    case 244: image = Properties.Resources.LedRed32px244; break;
                    case 245: image = Properties.Resources.LedRed32px245; break;
                    case 246: image = Properties.Resources.LedRed32px246; break;
                    case 247: image = Properties.Resources.LedRed32px247; break;
                    case 248: image = Properties.Resources.LedRed32px248; break;
                    case 249: image = Properties.Resources.LedRed32px249; break;
                    case 250: image = Properties.Resources.LedRed32px250; break;
                    case 251: image = Properties.Resources.LedRed32px251; break;
                    case 252: image = Properties.Resources.LedRed32px252; break;
                    case 253: image = Properties.Resources.LedRed32px253; break;
                    case 254: image = Properties.Resources.LedRed32px254; break;
                    case 255: image = Properties.Resources.LedRed32px255; break;
                    default: image = Properties.Resources.LedRed32px; break;
                }
            }

            else if (colour == LedColour.YELLOW)
            {
                switch (number)
                {
                    case 1: image = Properties.Resources.LedYellow32px1; break;
                    case 2: image = Properties.Resources.LedYellow32px2; break;
                    case 3: image = Properties.Resources.LedYellow32px3; break;
                    case 4: image = Properties.Resources.LedYellow32px4; break;
                    case 5: image = Properties.Resources.LedYellow32px5; break;
                    case 6: image = Properties.Resources.LedYellow32px6; break;
                    case 7: image = Properties.Resources.LedYellow32px7; break;
                    case 8: image = Properties.Resources.LedYellow32px8; break;
                    case 9: image = Properties.Resources.LedYellow32px9; break;
                    case 10: image = Properties.Resources.LedYellow32px10; break;
                    case 11: image = Properties.Resources.LedYellow32px11; break;
                    case 12: image = Properties.Resources.LedYellow32px12; break;
                    case 13: image = Properties.Resources.LedYellow32px13; break;
                    case 14: image = Properties.Resources.LedYellow32px14; break;
                    case 15: image = Properties.Resources.LedYellow32px15; break;
                    case 16: image = Properties.Resources.LedYellow32px16; break;
                    case 17: image = Properties.Resources.LedYellow32px17; break;
                    case 18: image = Properties.Resources.LedYellow32px18; break;
                    case 19: image = Properties.Resources.LedYellow32px19; break;
                    case 20: image = Properties.Resources.LedYellow32px20; break;
                    case 21: image = Properties.Resources.LedYellow32px21; break;
                    case 22: image = Properties.Resources.LedYellow32px22; break;
                    case 23: image = Properties.Resources.LedYellow32px23; break;
                    case 24: image = Properties.Resources.LedYellow32px24; break;
                    case 25: image = Properties.Resources.LedYellow32px25; break;
                    case 26: image = Properties.Resources.LedYellow32px26; break;
                    case 27: image = Properties.Resources.LedYellow32px27; break;
                    case 28: image = Properties.Resources.LedYellow32px28; break;
                    case 29: image = Properties.Resources.LedYellow32px29; break;
                    case 30: image = Properties.Resources.LedYellow32px30; break;
                    case 31: image = Properties.Resources.LedYellow32px31; break;
                    case 32: image = Properties.Resources.LedYellow32px32; break;
                    case 33: image = Properties.Resources.LedYellow32px33; break;
                    case 34: image = Properties.Resources.LedYellow32px34; break;
                    case 35: image = Properties.Resources.LedYellow32px35; break;
                    case 36: image = Properties.Resources.LedYellow32px36; break;
                    case 37: image = Properties.Resources.LedYellow32px37; break;
                    case 38: image = Properties.Resources.LedYellow32px38; break;
                    case 39: image = Properties.Resources.LedYellow32px39; break;
                    case 40: image = Properties.Resources.LedYellow32px40; break;
                    case 41: image = Properties.Resources.LedYellow32px41; break;
                    case 42: image = Properties.Resources.LedYellow32px42; break;
                    case 43: image = Properties.Resources.LedYellow32px43; break;
                    case 44: image = Properties.Resources.LedYellow32px44; break;
                    case 45: image = Properties.Resources.LedYellow32px45; break;
                    case 46: image = Properties.Resources.LedYellow32px46; break;
                    case 47: image = Properties.Resources.LedYellow32px47; break;
                    case 48: image = Properties.Resources.LedYellow32px48; break;
                    case 49: image = Properties.Resources.LedYellow32px49; break;
                    case 50: image = Properties.Resources.LedYellow32px50; break;
                    case 51: image = Properties.Resources.LedYellow32px51; break;
                    case 52: image = Properties.Resources.LedYellow32px52; break;
                    case 53: image = Properties.Resources.LedYellow32px53; break;
                    case 54: image = Properties.Resources.LedYellow32px54; break;
                    case 55: image = Properties.Resources.LedYellow32px55; break;
                    case 56: image = Properties.Resources.LedYellow32px56; break;
                    case 57: image = Properties.Resources.LedYellow32px57; break;
                    case 58: image = Properties.Resources.LedYellow32px58; break;
                    case 59: image = Properties.Resources.LedYellow32px59; break;
                    case 60: image = Properties.Resources.LedYellow32px60; break;
                    case 61: image = Properties.Resources.LedYellow32px61; break;
                    case 62: image = Properties.Resources.LedYellow32px62; break;
                    case 63: image = Properties.Resources.LedYellow32px63; break;
                    case 64: image = Properties.Resources.LedYellow32px64; break;
                    case 65: image = Properties.Resources.LedYellow32px65; break;
                    case 66: image = Properties.Resources.LedYellow32px66; break;
                    case 67: image = Properties.Resources.LedYellow32px67; break;
                    case 68: image = Properties.Resources.LedYellow32px68; break;
                    case 69: image = Properties.Resources.LedYellow32px69; break;
                    case 70: image = Properties.Resources.LedYellow32px70; break;
                    case 71: image = Properties.Resources.LedYellow32px71; break;
                    case 72: image = Properties.Resources.LedYellow32px72; break;
                    case 73: image = Properties.Resources.LedYellow32px73; break;
                    case 74: image = Properties.Resources.LedYellow32px74; break;
                    case 75: image = Properties.Resources.LedYellow32px75; break;
                    case 76: image = Properties.Resources.LedYellow32px76; break;
                    case 77: image = Properties.Resources.LedYellow32px77; break;
                    case 78: image = Properties.Resources.LedYellow32px78; break;
                    case 79: image = Properties.Resources.LedYellow32px79; break;
                    case 80: image = Properties.Resources.LedYellow32px80; break;
                    case 81: image = Properties.Resources.LedYellow32px81; break;
                    case 82: image = Properties.Resources.LedYellow32px82; break;
                    case 83: image = Properties.Resources.LedYellow32px83; break;
                    case 84: image = Properties.Resources.LedYellow32px84; break;
                    case 85: image = Properties.Resources.LedYellow32px85; break;
                    case 86: image = Properties.Resources.LedYellow32px86; break;
                    case 87: image = Properties.Resources.LedYellow32px87; break;
                    case 88: image = Properties.Resources.LedYellow32px88; break;
                    case 89: image = Properties.Resources.LedYellow32px89; break;
                    case 90: image = Properties.Resources.LedYellow32px90; break;
                    case 91: image = Properties.Resources.LedYellow32px91; break;
                    case 92: image = Properties.Resources.LedYellow32px92; break;
                    case 93: image = Properties.Resources.LedYellow32px93; break;
                    case 94: image = Properties.Resources.LedYellow32px94; break;
                    case 95: image = Properties.Resources.LedYellow32px95; break;
                    case 96: image = Properties.Resources.LedYellow32px96; break;
                    case 97: image = Properties.Resources.LedYellow32px97; break;
                    case 98: image = Properties.Resources.LedYellow32px98; break;
                    case 99: image = Properties.Resources.LedYellow32px99; break;
                    case 100: image = Properties.Resources.LedYellow32px100; break;
                    case 101: image = Properties.Resources.LedYellow32px101; break;
                    case 102: image = Properties.Resources.LedYellow32px102; break;
                    case 103: image = Properties.Resources.LedYellow32px103; break;
                    case 104: image = Properties.Resources.LedYellow32px104; break;
                    case 105: image = Properties.Resources.LedYellow32px105; break;
                    case 106: image = Properties.Resources.LedYellow32px106; break;
                    case 107: image = Properties.Resources.LedYellow32px107; break;
                    case 108: image = Properties.Resources.LedYellow32px108; break;
                    case 109: image = Properties.Resources.LedYellow32px109; break;
                    case 110: image = Properties.Resources.LedYellow32px110; break;
                    case 111: image = Properties.Resources.LedYellow32px111; break;
                    case 112: image = Properties.Resources.LedYellow32px112; break;
                    case 113: image = Properties.Resources.LedYellow32px113; break;
                    case 114: image = Properties.Resources.LedYellow32px114; break;
                    case 115: image = Properties.Resources.LedYellow32px115; break;
                    case 116: image = Properties.Resources.LedYellow32px116; break;
                    case 117: image = Properties.Resources.LedYellow32px117; break;
                    case 118: image = Properties.Resources.LedYellow32px118; break;
                    case 119: image = Properties.Resources.LedYellow32px119; break;
                    case 120: image = Properties.Resources.LedYellow32px120; break;
                    case 121: image = Properties.Resources.LedYellow32px121; break;
                    case 122: image = Properties.Resources.LedYellow32px122; break;
                    case 123: image = Properties.Resources.LedYellow32px123; break;
                    case 124: image = Properties.Resources.LedYellow32px124; break;
                    case 125: image = Properties.Resources.LedYellow32px125; break;
                    case 126: image = Properties.Resources.LedYellow32px126; break;
                    case 127: image = Properties.Resources.LedYellow32px127; break;
                    case 128: image = Properties.Resources.LedYellow32px128; break;
                    case 129: image = Properties.Resources.LedYellow32px129; break;
                    case 130: image = Properties.Resources.LedYellow32px130; break;
                    case 131: image = Properties.Resources.LedYellow32px131; break;
                    case 132: image = Properties.Resources.LedYellow32px132; break;
                    case 133: image = Properties.Resources.LedYellow32px133; break;
                    case 134: image = Properties.Resources.LedYellow32px134; break;
                    case 135: image = Properties.Resources.LedYellow32px135; break;
                    case 136: image = Properties.Resources.LedYellow32px136; break;
                    case 137: image = Properties.Resources.LedYellow32px137; break;
                    case 138: image = Properties.Resources.LedYellow32px138; break;
                    case 139: image = Properties.Resources.LedYellow32px139; break;
                    case 140: image = Properties.Resources.LedYellow32px140; break;
                    case 141: image = Properties.Resources.LedYellow32px141; break;
                    case 142: image = Properties.Resources.LedYellow32px142; break;
                    case 143: image = Properties.Resources.LedYellow32px143; break;
                    case 144: image = Properties.Resources.LedYellow32px144; break;
                    case 145: image = Properties.Resources.LedYellow32px145; break;
                    case 146: image = Properties.Resources.LedYellow32px146; break;
                    case 147: image = Properties.Resources.LedYellow32px147; break;
                    case 148: image = Properties.Resources.LedYellow32px148; break;
                    case 149: image = Properties.Resources.LedYellow32px149; break;
                    case 150: image = Properties.Resources.LedYellow32px150; break;
                    case 151: image = Properties.Resources.LedYellow32px151; break;
                    case 152: image = Properties.Resources.LedYellow32px152; break;
                    case 153: image = Properties.Resources.LedYellow32px153; break;
                    case 154: image = Properties.Resources.LedYellow32px154; break;
                    case 155: image = Properties.Resources.LedYellow32px155; break;
                    case 156: image = Properties.Resources.LedYellow32px156; break;
                    case 157: image = Properties.Resources.LedYellow32px157; break;
                    case 158: image = Properties.Resources.LedYellow32px158; break;
                    case 159: image = Properties.Resources.LedYellow32px159; break;
                    case 160: image = Properties.Resources.LedYellow32px160; break;
                    case 161: image = Properties.Resources.LedYellow32px161; break;
                    case 162: image = Properties.Resources.LedYellow32px162; break;
                    case 163: image = Properties.Resources.LedYellow32px163; break;
                    case 164: image = Properties.Resources.LedYellow32px164; break;
                    case 165: image = Properties.Resources.LedYellow32px165; break;
                    case 166: image = Properties.Resources.LedYellow32px166; break;
                    case 167: image = Properties.Resources.LedYellow32px167; break;
                    case 168: image = Properties.Resources.LedYellow32px168; break;
                    case 169: image = Properties.Resources.LedYellow32px169; break;
                    case 170: image = Properties.Resources.LedYellow32px170; break;
                    case 171: image = Properties.Resources.LedYellow32px171; break;
                    case 172: image = Properties.Resources.LedYellow32px172; break;
                    case 173: image = Properties.Resources.LedYellow32px173; break;
                    case 174: image = Properties.Resources.LedYellow32px174; break;
                    case 175: image = Properties.Resources.LedYellow32px175; break;
                    case 176: image = Properties.Resources.LedYellow32px176; break;
                    case 177: image = Properties.Resources.LedYellow32px177; break;
                    case 178: image = Properties.Resources.LedYellow32px178; break;
                    case 179: image = Properties.Resources.LedYellow32px179; break;
                    case 180: image = Properties.Resources.LedYellow32px180; break;
                    case 181: image = Properties.Resources.LedYellow32px181; break;
                    case 182: image = Properties.Resources.LedYellow32px182; break;
                    case 183: image = Properties.Resources.LedYellow32px183; break;
                    case 184: image = Properties.Resources.LedYellow32px184; break;
                    case 185: image = Properties.Resources.LedYellow32px185; break;
                    case 186: image = Properties.Resources.LedYellow32px186; break;
                    case 187: image = Properties.Resources.LedYellow32px187; break;
                    case 188: image = Properties.Resources.LedYellow32px188; break;
                    case 189: image = Properties.Resources.LedYellow32px189; break;
                    case 190: image = Properties.Resources.LedYellow32px190; break;
                    case 191: image = Properties.Resources.LedYellow32px191; break;
                    case 192: image = Properties.Resources.LedYellow32px192; break;
                    case 193: image = Properties.Resources.LedYellow32px193; break;
                    case 194: image = Properties.Resources.LedYellow32px194; break;
                    case 195: image = Properties.Resources.LedYellow32px195; break;
                    case 196: image = Properties.Resources.LedYellow32px196; break;
                    case 197: image = Properties.Resources.LedYellow32px197; break;
                    case 198: image = Properties.Resources.LedYellow32px198; break;
                    case 199: image = Properties.Resources.LedYellow32px199; break;
                    case 200: image = Properties.Resources.LedYellow32px200; break;
                    case 201: image = Properties.Resources.LedYellow32px201; break;
                    case 202: image = Properties.Resources.LedYellow32px202; break;
                    case 203: image = Properties.Resources.LedYellow32px203; break;
                    case 204: image = Properties.Resources.LedYellow32px204; break;
                    case 205: image = Properties.Resources.LedYellow32px205; break;
                    case 206: image = Properties.Resources.LedYellow32px206; break;
                    case 207: image = Properties.Resources.LedYellow32px207; break;
                    case 208: image = Properties.Resources.LedYellow32px208; break;
                    case 209: image = Properties.Resources.LedYellow32px209; break;
                    case 210: image = Properties.Resources.LedYellow32px210; break;
                    case 211: image = Properties.Resources.LedYellow32px211; break;
                    case 212: image = Properties.Resources.LedYellow32px212; break;
                    case 213: image = Properties.Resources.LedYellow32px213; break;
                    case 214: image = Properties.Resources.LedYellow32px214; break;
                    case 215: image = Properties.Resources.LedYellow32px215; break;
                    case 216: image = Properties.Resources.LedYellow32px216; break;
                    case 217: image = Properties.Resources.LedYellow32px217; break;
                    case 218: image = Properties.Resources.LedYellow32px218; break;
                    case 219: image = Properties.Resources.LedYellow32px219; break;
                    case 220: image = Properties.Resources.LedYellow32px220; break;
                    case 221: image = Properties.Resources.LedYellow32px221; break;
                    case 222: image = Properties.Resources.LedYellow32px222; break;
                    case 223: image = Properties.Resources.LedYellow32px223; break;
                    case 224: image = Properties.Resources.LedYellow32px224; break;
                    case 225: image = Properties.Resources.LedYellow32px225; break;
                    case 226: image = Properties.Resources.LedYellow32px226; break;
                    case 227: image = Properties.Resources.LedYellow32px227; break;
                    case 228: image = Properties.Resources.LedYellow32px228; break;
                    case 229: image = Properties.Resources.LedYellow32px229; break;
                    case 230: image = Properties.Resources.LedYellow32px230; break;
                    case 231: image = Properties.Resources.LedYellow32px231; break;
                    case 232: image = Properties.Resources.LedYellow32px232; break;
                    case 233: image = Properties.Resources.LedYellow32px233; break;
                    case 234: image = Properties.Resources.LedYellow32px234; break;
                    case 235: image = Properties.Resources.LedYellow32px235; break;
                    case 236: image = Properties.Resources.LedYellow32px236; break;
                    case 237: image = Properties.Resources.LedYellow32px237; break;
                    case 238: image = Properties.Resources.LedYellow32px238; break;
                    case 239: image = Properties.Resources.LedYellow32px239; break;
                    case 240: image = Properties.Resources.LedYellow32px240; break;
                    case 241: image = Properties.Resources.LedYellow32px241; break;
                    case 242: image = Properties.Resources.LedYellow32px242; break;
                    case 243: image = Properties.Resources.LedYellow32px243; break;
                    case 244: image = Properties.Resources.LedYellow32px244; break;
                    case 245: image = Properties.Resources.LedYellow32px245; break;
                    case 246: image = Properties.Resources.LedYellow32px246; break;
                    case 247: image = Properties.Resources.LedYellow32px247; break;
                    case 248: image = Properties.Resources.LedYellow32px248; break;
                    case 249: image = Properties.Resources.LedYellow32px249; break;
                    case 250: image = Properties.Resources.LedYellow32px250; break;
                    case 251: image = Properties.Resources.LedYellow32px251; break;
                    case 252: image = Properties.Resources.LedYellow32px252; break;
                    case 253: image = Properties.Resources.LedYellow32px253; break;
                    case 254: image = Properties.Resources.LedYellow32px254; break;
                    case 255: image = Properties.Resources.LedYellow32px255; break;
  

                    default: image = Properties.Resources.LedYellow32px; break;
                }
            }
            image = resizeImage(image, new Size(120, 120));
            return image;
        }

        public void UpdateLedStatus(ItemInfor item)
        {
            if (item.Status == ItemInfor.ItemStatus.DISCONNECT)
            {
                item.ButtonItem.Image = LedDisplay(LedColour.BLACK, item.ID);
            }
            else if (item.Status == ItemInfor.ItemStatus.NORMAL)
            {
                item.ButtonItem.Image = LedDisplay(LedColour.GREEN, item.ID);
            }
            else if (item.Status == ItemInfor.ItemStatus.ERROR)
            {
                item.ButtonItem.Image = LedDisplay(LedColour.RED, item.ID);
            }
            else if (item.Status == ItemInfor.ItemStatus.BUSY)
            {
                item.ButtonItem.Image = LedDisplay(LedColour.YELLOW, item.ID);
            }
        }  

        public void RemoveItem(ItemInfor item)
        {
            this.pictureBox1.Controls.Remove(item.ButtonItem);
            mlstItemInfor.Remove(item);
        }

        public void ResetAll()
        {
            fileName = "";

            int itemCount = mlstItemInfor.Count;
            for (int i = 0; i < itemCount; i++)
            {
                this.pictureBox1.Controls.Remove(mlstItemInfor[i].ButtonItem);
                //RemoveItem(mlstItemInfor[i]);
            }

            mlstItemInfor.Clear();
            ItemIndex = 0;
            openInforFileDialog.FileName = "";
            saveInforFileDialog.FileName = "";
            imagePath = null;

            pictureBox1.Image = pictureBox1.InitialImage;
            this.Text = " ";

        }

        public void UpdateStatus()
        {
            int iCount = mlstItemInfor.Count;

            for (int i = 0; i < iCount; i++)
            {
                //mlstItemInfor[i].ButtonItem.Image = LedDisplay(0, mlstItemInfor[i].ID);

            }

        }

        #endregion    

        public void UpdateUIControls()
        {
            this.Text = mMainResourceManager.GetString("MainTitle");
            fileToolStripMenuItem.Text = mMainResourceManager.GetString("FileMenu");
            newToolStripMenuItem.Text = mMainResourceManager.GetString("NewMenu");
            saveToolStripMenuItem.Text = mMainResourceManager.GetString("SaveMenu");
            saveAsToolStripMenuItem.Text = mMainResourceManager.GetString("SaveAsMenu");
            openToolStripMenuItem.Text = mMainResourceManager.GetString("OpenMenu");
            recentToolStripMenuItem.Text = mMainResourceManager.GetString("RecentMenu");
            exitToolStripMenuItem.Text = mMainResourceManager.GetString("ExitMenu");
            
            editToolStripMenuItem.Text = mMainResourceManager.GetString("EditMenu");
            connectToolStripMenuItem.Text = mMainResourceManager.GetString("ConnectMenu");
            disconnectToolStripMenuItem.Text = mMainResourceManager.GetString("DisconnectMenu");
            runToolStripMenuItem.Text = mMainResourceManager.GetString("RunMenu");
            stopToolStripMenuItem.Text = mMainResourceManager.GetString("StopMenu");
            viewToolStripMenuItem.Text = mMainResourceManager.GetString("ViewMenu");
            languageToolStripMenuItem.Text = mMainResourceManager.GetString("LanguageMenu");
            englishToolStripMenuItem.Text = mMainResourceManager.GetString("EnglishLanguageMenu");
            vietnameseToolStripMenuItem.Text = mMainResourceManager.GetString("VietnameseLanguageMenu");
            helpToolStripMenuItem.Text = mMainResourceManager.GetString("HelpMenu");
            aboutToolStripMenuItem.Text = mMainResourceManager.GetString("AboutMenu");
            viewToolStripMenuItem.Text = mMainResourceManager.GetString("ViewMenu");
            deviceListToolStripMenuItem.Text = mMainResourceManager.GetString("DeviceListMenu");
            nameToolStripMenuItem.Text = mMainResourceManager.GetString("NameMenu");
            setUpToolStripMenuItem.Text = mMainResourceManager.GetString("EnterSetupMenu");
            demoModeToolStripMenuItem.Text = mMainResourceManager.GetString("DemoModeMenu");
            //documentToolStripMenuItem.Text = mMainResourceManager.GetString("DocumentMenu");
            changePasswordToolStripMenuItem.Text = mMainResourceManager.GetString("ChangePasswordMenu");
            
            toolStripButtonNew.Text = mMainResourceManager.GetString("NewToolTip");
            toolStripButtonOpen.Text = mMainResourceManager.GetString("OpenToolTip");
            toolStripButtonSave.Text = mMainResourceManager.GetString("SaveToolTip");
            toolStripButtonAdd.Text = mMainResourceManager.GetString("AddToolTip");
            toolStripButtonConnect.Text = mMainResourceManager.GetString("ConnectToolTip");
            toolStripButtonDisconnect.Text = mMainResourceManager.GetString("DisconnectToolTip");
            toolStripButtonLoad.Text = mMainResourceManager.GetString("LoadToolTip");
            toolStripButtonRun.Text = mMainResourceManager.GetString("RunToolTip");
            toolStripButtonStop.Text = mMainResourceManager.GetString("StopToolTip");
            toolStripButtonAddImage.Text = mMainResourceManager.GetString("AddImageToolTip");

            if(!EditEnable)
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonSave.Enabled = false;
                toolStripButtonAddImage.Enabled = false;
                changePasswordToolStripMenuItem.Enabled = false;
            }
        }

        private void ImportTusFile(string filename)
        {
            int x;
            int y;
            ushort id;
            string ten;
            string vitritinhieu;
            byte index;
            string note;
            byte iLength;
            byte[] iValue;

            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            UnicodeEncoding encoding = new UnicodeEncoding();

            ResetAll();

            // doc thong tin so luong item
            int itemCount;
            itemCount = stream.ReadByte() * 256;
            itemCount += stream.ReadByte();

            if (itemCount > 0)
            {

                for (int i = 0; i < itemCount; i++)
                {
                    // lay vi tri tao do X
                    x = (stream.ReadByte() * 256 * 256 * 256);
                    x += (stream.ReadByte() * 256 * 256);
                    x += (stream.ReadByte() * 256);
                    x += stream.ReadByte();

                    // lay vi tri tao do Y
                    y = (stream.ReadByte() * 256 * 256 * 256);
                    y += (stream.ReadByte() * 256 * 256);
                    y += (stream.ReadByte() * 256);
                    y += stream.ReadByte();

                    // lay id cua item
                    id = (ushort)(stream.ReadByte() * 256);
                    id += (ushort)(stream.ReadByte());

                    // lay ten cua item
                    iLength = (byte)stream.ReadByte();
                    iValue = new byte[iLength];
                    stream.Read(iValue, 0, iLength);
                    ten = encoding.GetString(iValue);

                    // lay string vi tri led bao tin hieu
                    iLength = (byte)stream.ReadByte();
                    iValue = new byte[iLength];
                    stream.Read(iValue, 0, iLength);
                    vitritinhieu = encoding.GetString(iValue);

                    // lay vi tri led bao tin hieu(index)
                    index = (byte)stream.ReadByte();

                    // lay ghi chu
                    iLength = (byte)stream.ReadByte();
                    iValue = new byte[iLength];
                    stream.Read(iValue, 0, iLength);
                    note = encoding.GetString(iValue);

                    AddNewItem(x, y, id, ten, vitritinhieu, index, note);
                }

                // Read path image information

                iLength = (byte)stream.ReadByte();
                if (iLength > 0)
                {
                    iValue = new byte[iLength];
                    stream.Read(iValue, 0, iLength);
                    imagePath = encoding.GetString(iValue);
                    if (!File.Exists(imagePath))
                    {
                        MessageBox.Show(mMainResourceManager.GetString("ErrorBackgroundImageNotExsist"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                    else
                        pictureBox1.Image = Image.FromFile(imagePath);
                }
            }

            stream.Close();
            fileName = filename;
            this.Text = System.IO.Path.GetFileName(fileName);
        }

        public void ExportTusFile()
        {
            byte iLength;

            FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            UnicodeEncoding encoding = new UnicodeEncoding();

            // ghi so luong item
            byte[] iNumber = new byte[2];
            int itemCount = mlstItemInfor.Count;
            iNumber[0] = (byte)(itemCount / 256);
            iNumber[1] = (byte)(itemCount % 256);
            stream.Write(iNumber, 0, 2);

            for (int i = 0; i < itemCount; i++)
            {
                iNumber = new byte[4];

                // ghi vi tri toa do X cua item tren form
                int value = mlstItemInfor[i].ButtonItem.Location.X;
                iNumber[0] = (byte)(value / (256 * 256 * 256));
                iNumber[1] = (byte)((value / (256 * 256)) % 256);
                iNumber[2] = (byte)((value / 256) % 256);
                iNumber[3] = (byte)(value % 256);
                stream.Write(iNumber, 0, 4);

                // ghi vi tri toa do Y cua item tren form
                value = mlstItemInfor[i].ButtonItem.Location.Y;
                iNumber[0] = (byte)(value / (256 * 256 * 256));
                iNumber[1] = (byte)((value / (256 * 256)) % 256);
                iNumber[2] = (byte)((value / 256) % 256);
                iNumber[3] = (byte)(value % 256);
                stream.Write(iNumber, 0, 4);

                // ghi dia chi cua Item (ID)
                iNumber = new byte[2];
                ushort address = mlstItemInfor[i].ID;
                iNumber[0] = (byte)(address / 256);
                iNumber[1] = (byte)(address % 256);
                stream.Write(iNumber, 0, 2);

                
                // ghi Ten cua Item
                iLength = (byte)encoding.GetByteCount(mlstItemInfor[i].Ten);
                stream.WriteByte(iLength);
                stream.Write(encoding.GetBytes(mlstItemInfor[i].Ten), 0, (int)iLength);

                // ghi Vi tri hien thi cua tin hieu bao trang thai
                iLength = (byte)encoding.GetByteCount(mlstItemInfor[i].VitriTinhieu);
                stream.WriteByte(iLength);
                stream.Write(encoding.GetBytes(mlstItemInfor[i].VitriTinhieu), 0, (int)iLength);

                // ghi vi tri led bao tin hieu(index)
                stream.WriteByte(mDevieTinhieuIndex);

                // ghi chu
                iLength = (byte)encoding.GetByteCount(mlstItemInfor[i].Note);
                stream.WriteByte(iLength);
                stream.Write(encoding.GetBytes(mlstItemInfor[i].Note), 0, (int)iLength);

            }

            //Write image iformation

            if (imagePath != null)
            {
                iLength = (byte)encoding.GetByteCount(imagePath);
                stream.WriteByte(iLength);
                stream.Write(encoding.GetBytes(imagePath), 0, (int)iLength);
            }

            else
            {
                stream.WriteByte(0);
            }

            stream.Close();

            this.Text = System.IO.Path.GetFileName(fileName);

        }

        public void FileSave()
        {
            if (mlstItemInfor.Count <= 0)
            {
                DialogResult dialog = MessageBox.Show(mMainResourceManager.GetString("WarningNoDevice"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    // save 
                    if (Path.GetExtension(fileName) == ".tus")
                        ExportTusFile();

                    else if (Path.GetExtension(fileName) == ".xlsx")
                        ExportExcel();
                }
            }

            else
            {
                // save 
                if (Path.GetExtension(fileName) == ".tus")
                    ExportTusFile();

                else if (Path.GetExtension(fileName) == ".xlsx")
                    ExportExcel();
            }

            SaveRecentFile(fileName); //insert to list so that opened file will shown on the list

        }

        public void FileSaveAs()
        {
            if (mlstItemInfor.Count <= 0)
            {
                DialogResult dialog = MessageBox.Show(mMainResourceManager.GetString("WarningNoDevice"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    // save as
                    if (saveInforFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveInforFileDialog.FileName;
                        if (Path.GetExtension(fileName) == ".tus")
                            ExportTusFile();

                        else if (Path.GetExtension(fileName) == ".xlsx")
                            ExportExcel();
                    }
                }
            }

            else
            {
                // save as
                if (saveInforFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveInforFileDialog.FileName;
                    if (Path.GetExtension(fileName) == ".tus")
                        ExportTusFile();

                    else if (Path.GetExtension(fileName) == ".xlsx")
                        ExportExcel();
                }
            }

            SaveRecentFile(fileName); //insert to list so that opened file will shown on the list
        }

        public void FileOpen(string filename)
        {
            //string load filename
            if (Path.GetExtension(filename) == ".tus")
            {
                ImportTusFile(filename);
            }

            else // excelFile
            {
                DeviceInformation checkFile = CheckExcelFile(filename);
                if (checkFile == DeviceInformation.SAME_ID)
                {
                    DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("ErrorFileConflictAddress"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                else if (checkFile == DeviceInformation.SAME_LOCATION)
                {
                    DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("ErrorDeviceSameLocation"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                else if(checkFile == DeviceInformation.SAME_ID_LOCATION)
                {
                    DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("ErrorDeviceSameIdAndLocation"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                ImportExcel(filename);
            }               
       }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                    closeDevice();
                    ResetAllControl();
                if (fileName != "")
                {
                    //DialogResult dialogResult = MessageBox.Show("Lưu file lại?", "Thông báo",MessageBoxButtons.OKCancel);
                    //if (dialogResult == DialogResult.OK)
                    //{

                    //    // luu file lai
                    //    FileSaveAs();
                    //}

                    FileSave();
                }

                ResetAll();
                //ShowName = true;
                nameToolStripMenuItem.Checked = true;
            }

            else
            {

                PasswordForm frmNew = new PasswordForm();

                frmNew.CalledApplication = this;

                DialogResult dialogResult = frmNew.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    
                        closeDevice();
                        ResetAllControl();

                    EditEnable = true;
                    toolStripButtonAdd.Enabled = true;
                    toolStripButtonSave.Enabled = true;
                    toolStripButtonAddImage.Enabled = true;
                    changePasswordToolStripMenuItem.Enabled = true;

                    //ShowName = true;
                    nameToolStripMenuItem.Checked = true;

                    ResetAll();

                    
                }
                else
                {
                    return;
                }
            }
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            if (openInforFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = openInforFileDialog.FileName;

                if ((Path.GetExtension(filename) != ".tus") && (Path.GetExtension(filename) != ".xlsx"))
                {
                    MessageBox.Show(MainResourceManager.GetString("OpenFileMessage"), MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }


                    closeDevice();
                    ResetAllControl();
                
                    //ShowName = true;
                    nameToolStripMenuItem.Checked = true;
                    FileOpen(filename);
                    SaveRecentFile(filename); //insert to list so that opened file will shown on the list  
            
            }

            openInforFileDialog.Dispose();
            this.Text = System.IO.Path.GetFileName(fileName);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                if (fileName == "")
                {
                    FileSaveAs();
                }
                else
                {
                    FileSave();
                }

                //this.Text = System.IO.Path.GetFileName(fileName);
            }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            CauhinhThietbi frmNew = new CauhinhThietbi();
            frmNew.CalledApplication = this;
            DialogResult dialogResult = frmNew.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                AddNewItem();
            }
            else
            {
                return;
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            DanhsachThietbi frmNew = new DanhsachThietbi();
            frmNew.CalledApplication = this;
            DialogResult dialogResult = frmNew.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {

            }
            else
            {
                return;
            }
        }

        private void toolStripButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (openDevice())
                {
                    toolStripButtonNew.Enabled = false;
                    toolStripButtonOpen.Enabled = false;
                    toolStripButtonSave.Enabled = false;
                    toolStripButtonLoad.Enabled = false;
                    toolStripButtonAdd.Enabled = false;
                    toolStripButtonConnect.Enabled = false;
                    toolStripButtonDisconnect.Enabled = true;
                    toolStripButtonRun.Enabled = true;
                    toolStripButtonStop.Enabled = false;
                    toolStripButtonAddImage.Enabled = false;

                }
                else
                {
                    MessageBox.Show(mMainResourceManager.GetString("ErrorConnectionNotOpen"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

                if (!db.Connect())
                {
                    MessageBox.Show("Error connect DataBase");
                }
            }

            catch
            {


            }
        }

        private void toolStripButtonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                closeDevice();
                ResetAllControl();
                //toolStripButtonNew.Enabled = true;
                //toolStripButtonOpen.Enabled = true;
                //toolStripButtonSave.Enabled = true;
                //toolStripButtonLoad.Enabled = true;
                //toolStripButtonAdd.Enabled = true;
                //toolStripButtonConnect.Enabled = true;
                //toolStripButtonDisconnect.Enabled = false;
                //toolStripButtonRun.Enabled = false;
                //toolStripButtonStop.Enabled = false;
                //toolStripButtonAddImage.Enabled = true;

            }

            catch
            {

            }
        }

        private void toolStripButtonRun_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripButtonRun.Enabled = false;
                toolStripButtonStop.Enabled = true;

                //ScanSysStatus();
                ReadSysStatus();
                //update trang thai cua he thong
                int iCount = mlstItemInfor.Count;

                for (int i = 0; i < iCount; i++)
                {
                    UpdateLedStatus(mlstItemInfor[i]);
                    // update database
                    if (!db.CheckDeviceExist(mlstItemInfor[i].ID.ToString()))
                    {
                        db.CreateNewDevice(mlstItemInfor[i].ID.ToString(), "Device_" + i, "Test", 0, (mlstItemInfor[i].Status.ToString()));
                    }
                    db.UpdateDevice(mlstItemInfor[i].ID.ToString(), "Device_" + i, "Test", 0, (mlstItemInfor[i].Status.ToString()));
                }

                timer1.Enabled = true;
            }
            catch
            {

            }
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripButtonRun.Enabled = true;
                toolStripButtonStop.Enabled = false;
                timer1.Enabled = false;
            }
            catch
            {

            }
        }

        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                if (fileName != "")
                {
                    DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("SaveFileChangeMessage"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        // luu file lai
                        FileSaveAs();
                    }
                }

                //ShowName = true;
                nameToolStripMenuItem.Checked = true;

                ResetAll();
            }

            else
            {
                PasswordForm frmNew = new PasswordForm();

                frmNew.CalledApplication = this;

                DialogResult dialogResult = frmNew.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    EditEnable = true;
                    toolStripButtonAdd.Enabled = true;
                    toolStripButtonSave.Enabled = true;
                    toolStripButtonAddImage.Enabled = true;
                    changePasswordToolStripMenuItem.Enabled = true;

                    //ShowName = true;
                    nameToolStripMenuItem.Checked = true;

                    ResetAll();
                }
                else
                {
                    return;
                }
            }
   
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openInforFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filename = openInforFileDialog.FileName;

                if ((Path.GetExtension(filename) != ".tus") && (Path.GetExtension(filename) != ".xlsx"))
                {
                    MessageBox.Show(MainResourceManager.GetString("OpenFileMessage"), MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                
                    closeDevice();
                    ResetAllControl();
                
  
                    //ShowName = true;
                    nameToolStripMenuItem.Checked = true;
                    FileOpen(filename);
                    SaveRecentFile(filename); //insert to list so that opened file will shown on the list  

            }

            openInforFileDialog.Dispose();
            this.Text = System.IO.Path.GetFileName(fileName);
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                if (fileName == "")
                {
                    FileSaveAs();
                }
                else
                {
                    FileSave();
                }
            }
        }

        private void toolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            if(EditEnable)
                FileSaveAs();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == (Keys.Control | Keys.N))
            //{
            //    toolStripButtonNew.PerformClick();
            //}

            //else if (e.KeyData == (Keys.Control | Keys.O))
            //{
            //    toolStripButtonOpen.PerformClick();
            //}

            //else if (e.KeyData == (Keys.Control | Keys.S))
            //{
            //    toolStripButtonSave.PerformClick();
            //}

            //else if (e.KeyData == (Keys.Control | Keys.Shift|Keys.S))
            //{
            //    FileSaveAs();
            //}

            //else if (e.KeyData == (Keys.Alt | Keys.F4))
            //{
            //    DialogResult dialogResult = MessageBox.Show("Lưu file lại?", "Thông báo", MessageBoxButtons.OKCancel);
            //    if (dialogResult == DialogResult.OK)
            //    {
            //        toolStripButtonSave.PerformClick();
            //    }
            //}
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeDevice();

            if (EditEnable)
            {
                if (mlstItemInfor.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("SaveFileChangeMessage"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel);

                    if (dialogResult == DialogResult.OK)
                    {
                        toolStripButtonSave.PerformClick();
                    }
                    //toolStripButtonSave.PerformClick();
                }
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show(mMainResourceManager.GetString("SaveFileChangeMessage"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel);
  
            //if (dialogResult == DialogResult.OK)
            //{
            //    FileSaveAs();
            //}

        }

        private void Main_Load(object sender, EventArgs e)
        {
            string path;

            EditEnable = false;
            Password = "";
            ShowName = true;

            nameToolStripMenuItem.Checked = true;

            //LoadPassword();

            this.WindowState = FormWindowState.Maximized;
            LoadRecentList();
            if (mRecentFileList.Count >0)
            {
                foreach (string item in mRecentFileList)
                {
                    ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);  //create new menu for each item in list
                    recentToolStripMenuItem.DropDownItems.Add(fileRecent); //add the menu to "recent" menu
                }

                path = mRecentFileList[0];
                if (File.Exists(path))
                {
                    fileName = path;
                    FileOpen(fileName);
                }
            }
            
        }

        private void ResetAllControl()
        {
            toolStripButtonAdd.Enabled = true;
            toolStripButtonConnect.Enabled = true;
            toolStripButtonDisconnect.Enabled = true;
            toolStripButtonLoad.Enabled = true;
            toolStripButtonNew.Enabled = true;
            toolStripButtonOpen.Enabled = true;
            toolStripButtonRun.Enabled = true;
            toolStripButtonSave.Enabled = true;
            toolStripButtonStop.Enabled = true;
            toolStripButtonAddImage.Enabled = true;

            if (!EditEnable)
            {
                toolStripButtonAdd.Enabled = false;
                toolStripButtonDisconnect.Enabled = false;
                toolStripButtonStop.Enabled = false;
                toolStripButtonRun.Enabled = false;
                toolStripButtonAddImage.Enabled = false;

            }
            
        }

        #region Giao tiep module


        private bool openDevice()
        {
            var Device = DeviceDiscovery.FindHidDevices(new VidPidMatcher(0x4000, 0x5FFA));
            device = new UsbHidDevice(Device[0].Key);
            device.DataReceived += DeviceDataReceived;
            return device.Connect();
        }

        private void DeviceDataReceived(byte[] data_receive)
        {
            int crcValue = 0;

            crcValue = data_receive[1];

            int iCount = data_receive[1];

            // Kiem tra so luong du lieu tra ve co bang so item khong?

            int[] data = new int[iCount];

            int index = 2;
            // read data 
            for (int i = 0; i < iCount; i++)
            {
                data[i] = data_receive[index];
                crcValue += data_receive[index];
                index++;
            }
                            
            // data[i] la trang thai cua cac thiet bi trong he thong,
            //public enum ItemStatus{NONE, NORMAL, ERROR, BUSY, DISCONNECT}
            /**
                * NONE         = 0
                * NORMAL       = 1
                * ERROR        = 2
                * BUSY         = 3
                * DISCONNECT   = 4
                **/
            // check sum OK
            if (crcValue == data_receive[index] * 256 + data_receive[index + 1])
            {
                for (int i = 0; i < iCount; i++)
                {
                    if (data[i] == 1) mlstItemInfor[i].Status = ItemInfor.ItemStatus.NORMAL;
                    else if (data[i] == 2) mlstItemInfor[i].Status = ItemInfor.ItemStatus.ERROR;
                    else if (data[i] == 3) mlstItemInfor[i].Status = ItemInfor.ItemStatus.BUSY;
                    else if (data[i] == 4) mlstItemInfor[i].Status = ItemInfor.ItemStatus.DISCONNECT;

                    //UpdateLedStatus(mlstItemInfor[i]);
                }

                // update trang thai cua he thong
                //for (int i = 0; i < iCount; i++)
                //{
                //    UpdateLedStatus(mlstItemInfor[i]);
                //}
                             
            }
            //MessageBox.Show("Read finished.", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private void closeDevice()
        {
            device.Disconnect();

        }

        private void ReadSysStatus()
        {
            try
            {
                if (device != null)
                {
                    if (device.IsDeviceConnected)
                    {
                        int index = 0;
                        int crcValue = 0;

                        int iCount = mlstItemInfor.Count;
                        byte[] writeBuffer = new byte[64];
                        byte cmd;
                        sendCommand = SendCommand.READ_SYS_STATUS;
                        //writeBuffer[index] = (byte)sendCommand;
                        cmd = (byte)sendCommand;
                        crcValue += cmd;
                        writeBuffer[index] = (byte)iCount;
                        crcValue += writeBuffer[index];
                        index++;

                        for (int i = 0; i < iCount; i++)
                        {
                            writeBuffer[index] = (byte)mlstItemInfor[i].ID;
                            crcValue += writeBuffer[index];
                            index++;
                        }

                        writeBuffer[index] = (byte)(crcValue / 256); // high byte
                        writeBuffer[index++] = (byte)(crcValue % 256); // low byte
                        
                        var command = new UsbHid.USB.Classes.Messaging.CommandMessage(cmd, writeBuffer, (ushort)(writeBuffer.Length + 2));


                        bool status = device.SendMessage(command);

                        if (status)
                        {

                        } 
                        else 
                        {
                            MessageBox.Show(mMainResourceManager.GetString("ErrorReadingData"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            closeDevice();
                            ResetAllControl();
                            return;

                        }
                    }
                }
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                closeDevice();
                ResetAllControl();
            }
        }

        //private void ScanSysStatus()
        //{
        //    try
        //    {
        //        if (mUsbDevice != null)
        //        {
        //            if (mUsbDevice.IsOpen)
        //            {
        //                int index = 0;
        //                int crcValue = 0;

        //                int iCount = mlstItemInfor.Count;
        //                byte[] writeBuffer = new byte[64];

        //                sendCommand = SendCommand.SCAN_SYS_STATUS;
        //                writeBuffer[index] = (byte)sendCommand;
        //                crcValue += writeBuffer[index];

        //                index++;
        //                writeBuffer[index] = (byte)iCount;
        //                crcValue += writeBuffer[index];
        //                index++;

        //                for (int i = 0; i < iCount; i++)
        //                {
        //                    writeBuffer[index] = (byte)mlstItemInfor[i].ID;
        //                    crcValue += writeBuffer[index];
        //                    index++;
        //                }

        //                writeBuffer[index] = (byte)(crcValue / 256); // high byte
        //                writeBuffer[index++] = (byte)(crcValue % 256); // low byte

        //                int uiTransmitted;
        //                if (mEpWriter.Write(writeBuffer, 1000, out uiTransmitted) == ErrorCode.None)
        //                {
        //                }
        //                else
        //                {
        //                    MessageBox.Show(mMainResourceManager.GetString("ErrorReadingData"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //                    closeDevice();
        //                    ResetAllControl();
        //                    return;

        //                }

        //                byte[] readBuffer = new byte[64];

        //                ErrorCode eReturn;
        //                if ((eReturn = mEpReader.Read(readBuffer, 1000, out uiTransmitted)) == ErrorCode.None)
        //                {
        //                    crcValue = 0;

        //                    crcValue = readBuffer[0];

        //                    iCount = readBuffer[0];

        //                    // Kiem tra so luong du lieu tra ve co bang so item khong?

        //                    int[] data = new int[iCount];

        //                    index = 1;
        //                    // read data 
        //                    for (int i = 0; i < iCount; i++)
        //                    {
        //                        data[i] = readBuffer[index];
        //                        crcValue += readBuffer[index];
        //                        index++;
        //                    }

        //                    // data[i] la trang thai cua cac thiet bi trong he thong,
        //                    //public enum ItemStatus{NONE, NORMAL, ERROR, BUSY, DISCONNECT}
        //                    /**
        //                     * NONE         = 0
        //                     * NORMAL       = 1
        //                     * ERROR        = 2
        //                     * BUSY         = 3
        //                     * DISCONNECT   = 4
        //                     **/
        //                    // check sum OK
        //                    if (crcValue == readBuffer[index] * 256 + readBuffer[index + 1])
        //                    {
        //                        for (int i = 0; i < iCount; i++)
        //                        {
        //                            if (data[i] == 1) mlstItemInfor[i].Status = ItemInfor.ItemStatus.NORMAL;
        //                            else if (data[i] == 2) mlstItemInfor[i].Status = ItemInfor.ItemStatus.ERROR;
        //                            else if (data[i] == 3) mlstItemInfor[i].Status = ItemInfor.ItemStatus.BUSY;
        //                            else if (data[i] == 4) mlstItemInfor[i].Status = ItemInfor.ItemStatus.DISCONNECT;

        //                            //UpdateLedStatus(mlstItemInfor[i]);
        //                        }

        //                        // update trang thai cua he thong
        //                        //for (int i = 0; i < iCount; i++)
        //                        //{
        //                        //    UpdateLedStatus(mlstItemInfor[i]);
        //                        //}

        //                    }
        //                    //MessageBox.Show("Read finished.", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //                }
        //                else
        //                {
        //                    MessageBox.Show(mMainResourceManager.GetString("ErrorReadingData"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //                    closeDevice();
        //                    ResetAllControl();
        //                }

        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.ToString());
        //        closeDevice();
        //        ResetAllControl();
        //    }
        //}

        #endregion

        #region Luu file excel

        /////////////////////////////////////////////////////////////////////////////////////////////
        // Example shows you:
        // 1. Setting Excel Workbook properties
        // 2. Merge Excel Columns
        // 3. Setting Excel Cell background color
        // 4. Setting Excel Cell Border
        // 5. Setting Excel Formula
        // 6. Add Comments in Excel Cell
        // 7. Add Image in Excel Sheet
        // 8. Add Custom objects in Excel Sheet
        ////////////////////////////////////////////////////////////////////////////////////////////
        public void ExportExcel()
        {
          // save as
                FileInfo newFile = new FileInfo(fileName);
                
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new FileInfo(fileName);
                }

                using (ExcelPackage excelPkg = new ExcelPackage(newFile))
                {
                    // 1. Setting Excel Workbook Properties
                    excelPkg.Workbook.Properties.Author = "Chinh.TM";
                    excelPkg.Workbook.Properties.Title = mMainResourceManager.GetString("ExcelWorkbookTitle");

                    excelPkg.Workbook.Properties.Subject = mMainResourceManager.GetString("ExcelWorkbookTitle");
                    excelPkg.Workbook.Properties.Keywords = "Office Open XML";
                    excelPkg.Workbook.Properties.Category = "";
                    excelPkg.Workbook.Properties.Comments = "";

                    // set some extended property values
                    excelPkg.Workbook.Properties.Company = "TULA SOLUTION COMPANY";
                    excelPkg.Workbook.Properties.HyperlinkBase = new Uri("http://www.tula.vn");

                    // set some custom property values
                    excelPkg.Workbook.Properties.SetCustomPropertyValue("Checked by", "QUANG LE");
                    excelPkg.Workbook.Properties.SetCustomPropertyValue("EmployeeID", "1147");
                    excelPkg.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "ExcelPackage");

                    //// Creating Excel Worksheet
                    ExcelWorksheet oSheet = CreateSheet(excelPkg, mMainResourceManager.GetString("ExcelWorkSheetName"));

                    //oSheet.Cells["A1:K20"].AutoFitColumns();
                    oSheet.Column(1).Width = 8;
                    oSheet.Column(2).Width = 12;
                    oSheet.Column(3).Width = 12;
                    oSheet.Column(4).Width = 25;
                    oSheet.Column(5).Width = 12;
                    oSheet.Column(6).Width = 25;
                    oSheet.Column(7).Width = 30;

                    oSheet.Cells[1, 1].Value = mMainResourceManager.GetString ("ExcelWorkSheetTitle");
                    oSheet.Cells[1, 1, 1, 7].Merge = true;

                    // Setting Font and Alignment for Header
                    oSheet.Cells[1, 1, 1, 7].Style.Font.Bold = true;
                    oSheet.Cells[1, 1, 1, 7].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


                    int rowIndex = 2;

                    // 3. Setting Excel Cell Backgournd Color during Header Creation
                    // 4. Setting Excel Cell Border during Header Creation

                    //Creating Header
                    CreateHeader(oSheet, ref rowIndex);

                    //Putting Data into Cells
                    CreateData(oSheet, ref rowIndex);

                    // 5. Setting Excel Formula during Footer Creation
                    // Creating Footer
                    //CreateFooter(oSheet, ref rowIndex, dt);

                    //// 6. Add Comments in Excel Cell
                    //AddComment(oSheet, 5, 5, "Sample Comment", "Debopam Pal");

                    //// 7. Add Image in Excel Sheet
                    //string imagePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), "debopam.jpg");
                    //AddImage(oSheet, 1, 10, imagePath);

                    //// 8. Add Custom Objects in Excel Sheet
                    //AddCustomObject(oSheet, 7, 10, eShapeStyle.Ellipse, "Text inside Ellipse");

                    // Writting bytes by bytes in Excel File
                    Byte[] content = excelPkg.GetAsByteArray();
                    //string fileName = "Sample Excel using EPPlus.xlsx";
                    //string filename = dlg.FileName;

                    string filePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), fileName);
                    File.WriteAllBytes(filePath, content);

                    // Openning the created excel file using MS Excel Application
                    //ProcessStartInfo pi = new ProcessStartInfo(filePath);
                    //Process.Start(pi);
                }
            //}
        }

        /// <summary>
        /// ImportExcel 
        /// Read Information of Excel file and save to ListItem
        /// </summary>   
        private void ImportExcel(string filename)
        {
            using (ExcelPackage excelPkg = new ExcelPackage())
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                excelPkg.Load(stream);

                //ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets["Thong tin"];
                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[mMainResourceManager.GetString("ExcelWorkSheetName")];

                ResetAll();
                WorksheetToListItem(oSheet);
            }

            fileName = filename;
        }
        /// <summary>
        /// Creating Excel Worksheet   
        /// </summary>   
        /// /// <param name="excelPkg"></param>
        /// <param name="sheetName">sheet name</param>
        private ExcelWorksheet CreateSheet(ExcelPackage excelPkg, string sheetName)
        {
            ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets.Add(sheetName);
            // Setting default font for whole sheet
            //oSheet.Cells.Style.Font.Name = "Calibri";
            //// Setting font size for whole sheet
            //oSheet.Cells.Style.Font.Size = 11;

            oSheet.Cells.Style.Font.Name = "Time New Roman";
            // Setting font size for whole sheet
            oSheet.Cells.Style.Font.Size = 12;

            return oSheet;
        }

        /// <summary>
        /// Creating some data table
        /// </summary>
        /// <param name="row">number row of table</param>
        /// <param name="column">number column of table</param>
        private DataTable CreateDataTable(int row, int column)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < column; i++)
                dt.Columns.Add(i.ToString());
            for (int i = 0; i < row; i++)
            {
                DataRow dr = dt.Rows.Add();
                foreach (DataColumn dc in dt.Columns)
                    dr[dc.ColumnName] = i;
            }
            return dt;
        }

        /// <summary>
        /// Creating formatted header of excel sheet
        /// </summary>
        /// <param name="oSheet">The ExcelWorksheet object</param>
        /// <param name="rowIndex">The row number where the header will put</param>
        /// <param name="dt">The DataTable object from where header values will come</param>
        private void CreateHeader(ExcelWorksheet oSheet, ref int rowIndex)
        {

            rowIndex = 2;

            //oSheet.Cells[2, 1].Value = "STT";
            //oSheet.Cells[2, 2].Value = "Tọa độ X";
            //oSheet.Cells[2, 3].Value = "Tọa độ Y";
            //oSheet.Cells[2, 4].Value = "Tên";
            //oSheet.Cells[2, 5].Value = "ID";
            //oSheet.Cells[2, 6].Value = "Vị trí tín hiệu";
            //oSheet.Cells[2, 7].Value = "Ghi chú";


            oSheet.Cells[2, 1].Value = mMainResourceManager.GetString("HeaderSTT");
            oSheet.Cells[2, 2].Value = mMainResourceManager.GetString("HeaderLocationX");
            oSheet.Cells[2, 3].Value = mMainResourceManager.GetString("HeaderLocationY");
            oSheet.Cells[2, 4].Value = mMainResourceManager.GetString("HeaderName");
            oSheet.Cells[2, 5].Value = mMainResourceManager.GetString("HeaderID");
            oSheet.Cells[2, 6].Value = mMainResourceManager.GetString("HeaderSignalPosition");
            oSheet.Cells[2, 7].Value = mMainResourceManager.GetString("HeaderNote");

            for (int colIndex = 1; colIndex <= 7; colIndex++)
            {
                var cell = oSheet.Cells[rowIndex, colIndex];

                // Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Gray);

                // Setting top/left, right/bottom border of header cells
                var border = cell.Style.Border;
                border.Top.Style = border.Left.Style = border.Bottom.Style = border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            }
        }

        /// <summary>
        /// Creating formatted footer in the excel sheet
        /// </summary>
        /// <param name="oSheet">The ExcelWorksheet object</param>
        /// <param name="rowIndex">The row number where the footer will put</param>
        /// <param name="dt">The DataTable object from where footer values will come</param>
        private void CreateFooter(ExcelWorksheet oSheet, ref int rowIndex, DataTable dt)
        {
            int colIndex = 0;
            // Creating Formula in Footer
            foreach (DataColumn dc in dt.Columns)
            {
                colIndex++;
                var cell = oSheet.Cells[rowIndex, colIndex];

                // Setting Sum Formula for each cell
                // Usage: Sum(From_Addres:To_Address)
                // e.g. - Sum(A3:A6) -> Sums the value of Column 'A' From Row 3 to Row 6
                cell.Formula = "Sum(" + oSheet.Cells[3, colIndex].Address + ":" + oSheet.Cells[rowIndex - 1, colIndex].Address + ")";

                // Setting Background Fill color to Gray
                cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.Gray);
            }
        }

        /// <summary>
        /// Putting Data into Excel Cells
        /// </summary>
        /// <param name="oSheet">The ExcelWorksheet object</param>
        /// <param name="rowIndex">The row number from where data will put</param>
        /// <param name="dt">The DataTable object from where data will come</param>
        private void CreateData(ExcelWorksheet oSheet, ref int rowIndex)
        {
            int itemCount = ListItemInfor.Count;

            rowIndex = 2;

            for (int i = 0; i < itemCount; i++)
            {
                rowIndex++;
                ItemInfor item = ListItemInfor[i];
                {
                    oSheet.Cells[rowIndex, 1].Value = i + 1;
                    oSheet.Cells[rowIndex, 2].Value = item.ButtonItem.Location.X;
                    oSheet.Cells[rowIndex, 3].Value = item.ButtonItem.Location.Y;
                    oSheet.Cells[rowIndex, 4].Value = item.Ten;
                    oSheet.Cells[rowIndex, 5].Value = item.ID;
                    oSheet.Cells[rowIndex, 6].Value = item.VitriTinhieu;
                    oSheet.Cells[rowIndex, 7].Value = item.Note;
                    oSheet.Cells[rowIndex, 7].Style.WrapText = true;
                    
                }
            }
        }

        /// <summary>
        ///WorksheetToListItem  
        ///
        /// </summary> 
        private void WorksheetToListItem(ExcelWorksheet oSheet)
        {
            int x;
            int y;
            ushort id;
            string ten;
            string vitriTH;
            byte index = 0;
            string note;

            int totalRows = oSheet.Dimension.End.Row;
            int totalCols = oSheet.Dimension.End.Column;

            int rowIndex = 2;

            for (int i = rowIndex; i < totalRows; i++)
            {
                rowIndex++;

                x = Convert.ToInt32(oSheet.Cells[rowIndex, 2].Value);
                y = Convert.ToInt32(oSheet.Cells[rowIndex, 3].Value);
                ten = oSheet.Cells[rowIndex, 4].Value.ToString();
                id = Convert.ToUInt16(oSheet.Cells[rowIndex, 5].Value);
                vitriTH = oSheet.Cells[rowIndex, 6].Value.ToString();
                note = oSheet.Cells[rowIndex, 7].Value.ToString();

                if ((vitriTH == "Top") || (vitriTH == "Phía trên")) index = 0;
                else if ((vitriTH == "Bottom") || (vitriTH == "Phía dưới")) index = 1;
                else if ((vitriTH == "Right") || (vitriTH == "Bên phải")) index = 2;
                else if ((vitriTH == "Left") || (vitriTH == "Bên trái")) index = 3;

                AddNewItem(x, y, id, ten, vitriTH, index, note);
            }
        }

        private DeviceInformation CheckExcelFile(string filename)
        {
            DeviceInformation checkFile = DeviceInformation.OK;

            using (ExcelPackage excelPkg = new ExcelPackage())
            using (FileStream stream = new FileStream(filename, FileMode.Open))
            {
                excelPkg.Load(stream);

                //ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets["Thong tin"];
                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[mMainResourceManager.GetString("ExcelWorkSheetName")];

                int totalRows = oSheet.Dimension.End.Row;
                int totalCols = oSheet.Dimension.End.Column;


                int[] idValue = new int[totalRows - 2];
                int[] xLocation = new int[totalRows - 2];
                int[] yLocation = new int[totalRows - 2];

                int rowIndex = 2;
                for (int i = 0; i < (totalRows - 2); i++)
                {
                    rowIndex++;
                    idValue[i] = Convert.ToInt32(oSheet.Cells[rowIndex, 5].Value);
                    xLocation[i] = Convert.ToInt32(oSheet.Cells[rowIndex,2].Value);
                    yLocation[i] = Convert.ToInt32(oSheet.Cells[rowIndex, 3].Value);
                }

                for (int i = 0 ; i < (totalRows - 3); i++)
                {
                    int id = idValue[i];
                    int x = xLocation[i];
                    int y = yLocation[i];

                    for (int j = i + 1; j < (totalRows - 2); j++)
                    {
                        if (idValue[j] == id)
                        {
                            if (checkFile == DeviceInformation.SAME_LOCATION)
                            {
                                checkFile = DeviceInformation.SAME_ID_LOCATION;
                                return checkFile;
                            }

                            else
                                checkFile = DeviceInformation.SAME_ID;

                                
                        }
                        else if ((xLocation[j] == x) || (yLocation[j] == y))
                        {
                            if (checkFile == DeviceInformation.SAME_ID)
                            {
                                checkFile = DeviceInformation.SAME_ID_LOCATION;
                                return checkFile;
                            }

                            else
                                checkFile = DeviceInformation.SAME_LOCATION;
                        }
                    }
                }

                return checkFile;
            }
        }


        #endregion

        public string GetTimeStamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            ReadSysStatus();
            //update trang thai cua he thong
            int iCount = mlstItemInfor.Count;

            for (int i = 0; i < iCount; i++)
            {
                UpdateLedStatus(mlstItemInfor[i]);
                if (db.ReadDeviceStatus(mlstItemInfor[i].ID.ToString()) != mlstItemInfor[i].Status.ToString())
                {
                    db.UpdateDevice(mlstItemInfor[i].ID.ToString(), "Device_" + (i+1).ToString(), "Test", 0, (mlstItemInfor[i].Status.ToString()));
                    db.UpdateDeviceStatus(mlstItemInfor[i].ID.ToString(), mlstItemInfor[i].Status.ToString(), GetTimeStamp());
                }
            }
            timer1.Enabled = true;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = true;
            vietnameseToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = mEnglishCultureInfo;

            LoadDisplayList();
        }

        private void vietnameseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vietnameseToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;
            Thread.CurrentThread.CurrentUICulture = mVietnameseCultureInfo;

            LoadDisplayList();
        }

        private void LoadDisplayList()
        {
            UpdateUIControls();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmNew = new AboutBox();
            frmNew.Show();
        }

        private void demoModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (demoModeToolStripMenuItem.CheckState == CheckState.Unchecked)
                demoModeToolStripMenuItem.Checked = true;
            else
                demoModeToolStripMenuItem.Checked = false;
        }

        private void toolStripButtonAddImage_Click(object sender, EventArgs e)
        {
            if (openFileImageDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileImageDialog.FileName;

                pictureBox1 .Image = Image.FromFile(imagePath);
            }

        }

        #region Save&Load recent files

        /// <summary>
        /// load recent file list from file
        /// </summary>
        private void LoadRecentList()
        {//try to load file. If file isn't found, do nothing
            mRecentFileList.Clear();
            try
            {
                //StreamReader listToRead = new StreamReader(System.Environment.CurrentDirectory + "\\Recent.txt"); //read file stream
                //StreamReader listToRead = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Recent.txt");

                StreamReader listToRead = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat" + "\\Recent.txt");

                string line;
                while ((line = listToRead.ReadLine()) != null) //read each line until end of file
                    mRecentFileList.Add(line); //insert to list
                listToRead.Close(); //close the stream
            }
            catch (Exception)
            {
                return;
                //throw;
            }

        }

        /// <summary>
        /// store a list to file and refresh list
        /// </summary>
        /// <param name="path"></param>
        private void SaveRecentFile(string path)
        {
            recentToolStripMenuItem.DropDownItems.Clear(); //clear all recent list from menu
            LoadRecentList(); //load list from file

            if (!(mRecentFileList.Contains(path))) //prevent duplication on recent list
            {
                mRecentFileList.Add(""); //insert given path into list
                for (int i = mRecentFileList.Count-1; i > 0; i--)
                {
                    mRecentFileList[i] = mRecentFileList[i - 1];
                }
                mRecentFileList[0] = path;
            }

            else
            {
                mRecentFileList.RemoveAt(mRecentFileList.IndexOf(path));
                mRecentFileList.Add(""); //insert given path into list
                for (int i = mRecentFileList.Count - 1; i > 0; i--)
                {
                    mRecentFileList[i] = mRecentFileList[i - 1];
                }
                mRecentFileList[0] = path;
            }
               
            while (mRecentFileList.Count > mRecentFileNumber) //keep list number not exceeded given value
            {
                mRecentFileList.RemoveAt(mRecentFileList.Count - 1);
            }
            foreach (string item in mRecentFileList)
            {
                ToolStripMenuItem fileRecent = new ToolStripMenuItem(item, null, RecentFile_click);  //create new menu for each item in list
                recentToolStripMenuItem.DropDownItems.Add(fileRecent); //add the menu to "recent" menu
            }

            //writing menu list to file
            //StreamWriter stringToWrite = new StreamWriter(System.Environment.CurrentDirectory + "\\Recent.txt"); //create file called "Recent.txt" located on app folder

            bool exists = System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat");

            if(!exists)
            {
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat");
            }

            StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat" + "\\Recent.txt");

            //StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Recent.txt");

            foreach (string item in mRecentFileList)
            {
                stringToWrite.WriteLine(item); //write list to stream
            }
            stringToWrite.Flush(); //write stream to file
            stringToWrite.Close(); //close the stream and reclaim memory
        }

        /// <summary>
        /// click menu handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecentFile_click(object sender, EventArgs e)
        {
            string filepath = sender.ToString();
            if (!File.Exists(filepath))
            {
                MessageBox.Show(mMainResourceManager.GetString("ErrorFileNotExit"), mMainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
               
                return;
            }

            else
            {
               
                    closeDevice();
                    ResetAllControl();
                
                //ShowName = true;
                nameToolStripMenuItem.Checked = true;

                FileOpen(filepath);
                SaveRecentFile(filepath); //insert to list so that opened file will shown on the list  
            }
                
            //    SaveRecentFile(filepath); //insert to list so that opened file will shown on the list          
            this.Text = System.IO.Path.GetFileName(fileName);
            
        }

        #endregion

        private bool ShowLoginDlg()
        {
            PasswordForm logindlg = new PasswordForm();
            logindlg.CalledApplication = this;

            DialogResult dr = logindlg.ShowDialog(this);
            if (dr != DialogResult.OK)
                return false;
            return true;
        }
     
        public LoginResult LogUserIn(string strPass)
        {
            if (strPass.Length <= 0)
                return LoginResult.LoginWrongUsername;
#if true
            //TODO: Remove this code after complete testing
            //if (strPass == "tuongmanhchinh")
            {
                return LoginResult.LoginOK;
            }
            //TODO: End
#endif
            
            if (CheckPassword(strPass) == false)
                return LoginResult.LoginWrongPassword;

            Password = CreatePassword(strPass);
            return LoginResult.LoginOK;
        }

        #region Create & Save password
        /// <summary>
        /// store a list to file and refresh list
        /// </summary>
        /// <param name="path"></param>
       public void SavePassword()
        {

            //writing menu list to file
            //StreamWriter stringToWrite = new StreamWriter(System.Environment.CurrentDirectory + "\\Password.txt"); //create file called "Recent.txt" located on app folder
            //StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Password.txt");

            //StreamWriter stringToWrite = new StreamWriter(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\Password.txt");

            bool exists = System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat");

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat");
            }

            StreamWriter stringToWrite = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat" + "\\Password.txt");

           stringToWrite.WriteLine(Password);
            
            stringToWrite.Flush(); //write stream to file
            stringToWrite.Close(); //close the stream and reclaim memory
        }

        public void LoadPassword()
        {
           
            System.Collections.Generic.List<string> mListToRead = new List<string>();
        //try to load file. If file isn't found, do nothing
            try
            {

                //StreamReader AccountToRead = new StreamReader(System.Environment.CurrentDirectory + "\\Password.txt"); //read file stream
                //StreamReader AccountToRead = new StreamReader(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()) + "\\Password.txt");

                StreamReader AccountToRead = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GiamSat" + "\\Password.txt");

                string line;

                while ((line = AccountToRead.ReadLine()) != null) //read each line until end of file
                    Password = line;

                AccountToRead.Close(); //close the stream
            }
            catch (Exception)
            {

                //throw;
                return;
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (EditEnable)
            {
                frmCreatePassword frmNew = new frmCreatePassword();
                frmNew.CalledApplication = this;

                DialogResult dialogResult = frmNew.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    SavePassword();
                }
                else
                {
                    return;
                }
            }

            else
            {
                
                
            }
        }

        public string CreatePassword(string strPlainPassword)
        {
            string pass = GetMD5Hash(strPlainPassword);

            return pass;
        }

        public static string GetMD5Hash(string input)
        {
            if (input.Length <= 0)
                return "";
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

        public bool CheckPassword(string strPassword)
        {
            LoadPassword();

            string strMD5Pass = GetMD5Hash(strPassword);
            if (strMD5Pass.Equals(this.Password, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        #endregion

        private void setUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EditEnable)
                {
                    PasswordForm frmNew = new PasswordForm();

                    frmNew.CalledApplication = this;

                    DialogResult dialogResult = frmNew.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        EditEnable = true;
                        toolStripButtonAdd.Enabled = true;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonAddImage.Enabled = true;
                        changePasswordToolStripMenuItem.Enabled = true;

                     
                            closeDevice();
                            ResetAllControl();
                        

                        FileOpen(fileName);
                    }
                    else
                    {
                        return;
                    }
                }
            }

            catch
            {

            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            this.Close();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nameToolStripMenuItem.Checked)
            {
                nameToolStripMenuItem.Checked = false;
                ShowName = false;
                for (int i = 0; i < mlstItemInfor.Count; i++)
                {
                        mlstItemInfor[i].ButtonItem.Text = "  ";
                }

            }

            else
            {
                nameToolStripMenuItem.Checked = true;
                ShowName = true;
                for (int i = 0; i < mlstItemInfor.Count; i++)
                {
                    mlstItemInfor[i].ButtonItem.Text = mlstItemInfor[i].Ten;
                }
            }

            //FileOpen(fileName);
        }

        private void deviceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhsachThietbi frmNew = new DanhsachThietbi();
            frmNew.CalledApplication = this;
            DialogResult dialogResult = frmNew.ShowDialog();
        }


    }
}
