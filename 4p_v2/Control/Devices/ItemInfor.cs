using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GiamSat
{
    public class ItemInfor
    {
        #region MemberVariable

        public enum ItemStatus { NONE, NORMAL, ERROR, BUSY, DISCONNECT }

        private ushort      mID;
        private string      mTen;

        private ButtonX     mButtonItem;

        private string      mVitriTinhieu;
        private byte        mTinhieuIndex; // co 4 vi tri tương ung gia tri = 0->3
        private string      mNote;
        private ItemStatus mStatus;

        #endregion

        #region Properties

        public ushort ID
        {
            get { return mID; }

            set { mID = value; }
        }

        public string Ten
        {
            get { return mTen; }

            set { mTen = value; }
        }

        public string VitriTinhieu
        {
            get { return mVitriTinhieu; }

            set { mVitriTinhieu = value; }
        }

        public byte TinhieuIndex
        {
            get { return mTinhieuIndex; }

            set { mTinhieuIndex = value; }
        }

        public string Note
        {
            get { return mNote; }

            set { mNote = value; }
        }

        public ItemStatus Status
        {
            get { return mStatus; }

            set { mStatus = value; }
        }

        public ButtonX ButtonItem
        {
            get { return mButtonItem; }

            set { mButtonItem = value; }
        }
        #endregion

        #region constructor
        public ItemInfor()
        {
            mID = 0;
            mTen = "";
            mNote = "";
            mTinhieuIndex = 0;
            mStatus = ItemStatus.NONE;
            mButtonItem= new ButtonX();

        }

        #endregion
    }
}
