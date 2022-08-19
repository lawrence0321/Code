using Common;
using Common.DTO;
using Common.Enums;
using Common.Extension;
using Controller;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using View.Extention;
using static View.Load.BasicPage;

namespace View.Load
{
    public partial class AutoSetRecipePage : Form
    {

        IMESController MESController => ControllerFactory.Get<IMESController>();
        ILoadController LoadController => ControllerFactory.Get<ILoadController>();
        IDeviceController DeviceController => ControllerFactory.Get<IDeviceController>();

        string LotNo => this.TextBox_LotNo.Text.Replace(" ","").Replace("　","");
        bool IsSpecialMode => CheckBox_SpecialCrane.Checked;
        bool IsdRackOnly => CheckBox_RockOnly.Checked;

        int Quantity => Convert.ToInt32(NumUpDown_TotalQuantity.Value);
        int CraneQuantity => Convert.ToInt32(NumUpDown_CarQuantity.Value);

        readonly AddLoadDataTypes AddLoadDataType;
        readonly string UID;
        readonly long AfterLoadDataSortTimeTicks_;

        public AutoSetRecipePage()
        {
            InitializeComponent();

            CheckBox_RockOnly_CheckedChanged(null,null);

            CheckBox_RockOnly.Checked = false;
        }

        public AutoSetRecipePage(long AfterLoadDataSortTimeTicks_, string UID_) : this()
        {
            AddLoadDataType = AddLoadDataTypes.PlugIn;
            this.AfterLoadDataSortTimeTicks_ = AfterLoadDataSortTimeTicks_;
            UID = UID_;
            Label_ShowMod.Text = "插入模式";
        }

        public AutoSetRecipePage(string UID_) : this()
        {
            AddLoadDataType = AddLoadDataTypes.Enqueue;
            UID = UID_;
            Label_ShowMod.Text = "加入模式(新增在最後一筆)";
        }

        /// <summary>
        /// 加入Recipe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AutoEnter_Click(object sender, EventArgs e)
        {
            Btn_AutoEnter.Enabled = false;
            try
            {
                List<LoadDataDTO> loadDatas = new List<LoadDataDTO>();

                if (IsdRackOnly)
                {
                    if (CraneQuantity == 0)
                    {
                        ExMessagePage.Show("警告", "總車數為0.");
                        Btn_AutoEnter.Enabled = true;
                        return;
                    }
                    var r0 = LoadController.CreateDummyLoadData(CraneQuantity, UID);
                    if (!r0.Result)
                    {
                        ExMessagePage.Show("產生空掛LoadData失敗", r0.Exception.Message);
                        Btn_AutoEnter.Enabled = true;
                        return;
                    }

                    loadDatas.AddRange(r0.Value);
                }
                else
                {
                    this.Btn_Close.Enabled = false;

                    var rL = LoadController.CreateLoadDataByMES(IsSpecialMode, Quantity, LotNo, UID);

                    this.Btn_Close.Enabled = true;
                    if (!rL.Result)
                    {
                        ExMessagePage.Show("取得LoadData失敗", rL.Exception.Message);
                        Btn_AutoEnter.Enabled = true;
                        return;
                    }
                    loadDatas.AddRange(rL.Value);
                }

                ActResult r4 = null;
                switch (this.AddLoadDataType)
                {
                    case AddLoadDataTypes.Enqueue:
                        r4 = LoadController.Enqueue(loadDatas, UID);
                        break;
                    case AddLoadDataTypes.PlugIn:
                        r4 = LoadController.PlugIn(loadDatas, AfterLoadDataSortTimeTicks_, UID);
                        break;
                }
                if (!r4.Result)
                {
                    ExMessagePage.Show("取得LoadData失敗", r4.Exception.Message);
                    Btn_AutoEnter.Enabled = true;
                    return;
                }
                Btn_AutoEnter.Enabled = true;
                Btn_Close.PerformClick();
            }
            catch 
            {
                this.Btn_Close.Enabled = true;
                Btn_AutoEnter.Enabled = true;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckBox_RockOnly_CheckedChanged(object sender, EventArgs e)
        {
            TextBox_LotNo.Clear();
            TextBox_LotNo.Enabled = !CheckBox_RockOnly.Checked;
            TextBox_LotNo.ReadOnly = CheckBox_RockOnly.Checked;
            NumUpDown_TotalQuantity.Value = 0;
            NumUpDown_TotalQuantity.Enabled = !CheckBox_RockOnly.Checked;
            NumUpDown_TotalQuantity.ReadOnly = CheckBox_RockOnly.Checked;
            NumUpDown_CarQuantity.Value = 0;
            NumUpDown_CarQuantity.Enabled = CheckBox_RockOnly.Checked;
            NumUpDown_CarQuantity.ReadOnly = !CheckBox_RockOnly.Checked;   
        }
    }
}
