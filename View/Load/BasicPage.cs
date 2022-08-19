using Common.Attributes;
using Common.DTO;
using Common.Enums;
using Controller;
using Controller.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using View.ExForm;
using View.Extention;
using static View.ExForm.MessageYesNoPage;

namespace View.Load
{
    public partial class BasicPage : UserControl
    {
        IMESController MESController => ControllerFactory.Get<IMESController>();
        ILoadController LoadController => ControllerFactory.Get<ILoadController>();
        IUserController WhiteListController => ControllerFactory.Get<IUserController>();

        public delegate void NotifyChangedPreList();

        readonly Timer UpdateDGVTimer = new Timer();

        public string UID => WhiteListController.NowUID;

        static AutoSetRecipePage _AutoSetRecipePage;
        static StandAloneRecipePage _StandAloneRecipePage;

        public BasicPage()
        {
            InitializeComponent();
            DGV1.MakeDoubleBuffered();
            DGV2.MakeDoubleBuffered();
            DGV1.ColumnHeadersHeight = 36;
            DGV1.RowTemplate.Height = 36;
            DGV2.ColumnHeadersHeight = 36;
            DGV2.RowTemplate.Height = 36;

            this.Btn_StartRun.Text = LoadController.StatusType == Common.Enums.StatusTypes.Manual ? "Start" : "Stop";

            UpdateDGVTimer.Interval = 150;
            UpdateDGVTimer.Tick += UpdateDGVTimer_Tick;
            UpdateDGVTimer.Start();
            LoadController.PerListChanged += LoadController_PerListChanged;

            LoadController_PerListChanged(null,null);
        }

        private void UpdateDGVTimer_Tick(object sender, EventArgs e)
        {
            if (!LoadController.NeedUpdatePerList) return;

            LoadController_PerListChanged(null, null);
            LoadController.NeedUpdatePerList = false;
        }

        private void Btn_StartRun_Click(object sender, EventArgs e)
        {
            LoadController.ChangeStatusType();
            this.Btn_StartRun.Text = LoadController.StatusType == Common.Enums.StatusTypes.Manual ? "Start" : "Stop";

            //this.Btn_Add_MES.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;
            //this.Btn_Add_SA.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;

            this.Btn_Insert_MES.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;
            this.Btn_Insert_SA.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;

            this.Btn_Edit.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;
            this.Btn_Delete.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;
            this.Btn_DeleteAll.Enabled = LoadController.StatusType == Common.Enums.StatusTypes.Manual;
        }

        bool CheckUID()
        {
            if (!WhiteListController.IsLogging)
            {
                ExMessagePage.Show("工號為空值", "請先輸入工號再作後續操作");
                return false;
            }
            else
                return true;
        }
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;
            if (LoadController.StatusType == Common.Enums.StatusTypes.Auto)
            {
                ExMessagePage.Show("拒絕操作", "基台運轉中");
                return;
            }
            if (DGV1.SelectedRows.Count == 0)
            {
                ExMessagePage.Show("編輯LoadData發生錯誤", "尚未選擇編輯目標");
                return;
            }
            //if (!WhiteListController.Certification(UserAuthority.UseCustomMod))
            //{
            //    ExMessagePage.Show("警告", "工號權限不足");
            //    return;
            //}
            LoadDataDTO loadData;
            var selectID = DGV1.SelectedRows[0].Cells[nameof(loadData.ID)].Value.ToString();

            var newPage = new EditLoadDataPage(selectID, UID);
            newPage.Show();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;
            if (LoadController.StatusType == Common.Enums.StatusTypes.Auto)
            {
                ExMessagePage.Show("拒絕操作", "基台運轉中");
                return;
            }

            if (DGV1.SelectedRows.Count == 0)
            {
                ExMessagePage.Show("刪除LoadData發生錯誤", "尚未選擇刪除目標");
                return;
            }

            var Message = new MessageYesNoPage("警告", "是否要刪除該LoadData", Btn_Delete_RoadBack);
            Message.Show();
        }
        private void Btn_Delete_RoadBack(YesNo YesNo_)
        {
            if (YesNo_ == YesNo.No) return;

            LoadDataDTO loadData;
            var selectID = DGV1.SelectedRows[0].Cells[nameof(loadData.ID)].Value.ToString();

            var r1 = LoadController.ReMove(selectID, UID);
            if (!r1.Result)
            {
                ExMessagePage.Show("刪除LoadData發生錯誤", r1.Exception.Message);
                return;
            }
        }

        private void Btn_DeleteAll_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;
            if (LoadController.StatusType == Common.Enums.StatusTypes.Auto)
            {
                ExMessagePage.Show("拒絕操作", "基台運轉中");
                return;
            }

           var Message = new MessageYesNoPage("警告", "是否要刪除全部LoadData", Btn_DeleteAll_RoadBack);
            Message.Show();
        }

        private void Btn_DeleteAll_RoadBack(YesNo YesNo_)
        {
            if (YesNo_ == YesNo.No) return;
            var r1 = LoadController.RemoveAll(UID);
            if (!r1.Result)
                ExMessagePage.Show("刪除全部LoadData發生錯誤", r1.Exception.Message);
        }


        private void Btn_Insert_SA_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;
            if (LoadController.StatusType == Common.Enums.StatusTypes.Auto)
            {
                ExMessagePage.Show("拒絕操作", "基台運轉中");
                return;
            }
            if (!WhiteListController.Certification(UserAuthority.UseCustomMod))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }
            if (DGV1.SelectedRows.Count > 0)
            {
                var afterLoadDataSortTimeTicks_ = Convert.ToInt64(DGV1.SelectedRows[0].Cells[nameof(LoadDataDTO.SortTimeTicks)].Value.ToString());

                if (!(_StandAloneRecipePage is null))
                    if (!_StandAloneRecipePage.IsDisposed)
                    {
                        ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                        _StandAloneRecipePage.TopMost = true;
                        _StandAloneRecipePage.Show();
                        _StandAloneRecipePage.TopMost = false;
                        return;
                    }
                        

                _StandAloneRecipePage = new StandAloneRecipePage(afterLoadDataSortTimeTicks_, UID);
                _StandAloneRecipePage.Show();
            }
            else
            {
                if (!(_StandAloneRecipePage is null))
                    if (!_StandAloneRecipePage.IsDisposed)
                    {
                        ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                        _StandAloneRecipePage.TopMost = true;
                        _StandAloneRecipePage.Show();
                        _StandAloneRecipePage.TopMost = false;
                        return;
                    }

                _StandAloneRecipePage = new StandAloneRecipePage(UID);
                _StandAloneRecipePage.Show();
            }
        }

        private void Btn_Insert_MES_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;

            if (!MESController.IsConnect)
            {
                ExMessagePage.Show("拒絕操作", "無法與MES系統連線");
                return;
            }

            if (LoadController.StatusType == Common.Enums.StatusTypes.Auto)
            {
                ExMessagePage.Show("拒絕操作", "基台運轉中");
                return;
            }
            if (DGV1.SelectedRows.Count > 0)
            {
                var afterLoadDataSortTimeTicks_ = Convert.ToInt64(DGV1.SelectedRows[0].Cells[nameof(LoadDataDTO.SortTimeTicks)].Value.ToString());
                if (!(_AutoSetRecipePage is null))
                    if (!_AutoSetRecipePage.IsDisposed)
                    {
                        ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                        _AutoSetRecipePage.TopMost = true;
                        _AutoSetRecipePage.Show();
                        _AutoSetRecipePage.TopMost = false;
                        return;
                    }

                _AutoSetRecipePage = new AutoSetRecipePage(afterLoadDataSortTimeTicks_, UID) { TopMost = true };
                _AutoSetRecipePage.Show();
            }
            else
            {
                if (!(_AutoSetRecipePage is null))
                    if (!_AutoSetRecipePage.IsDisposed)
                    {
                        ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                        _AutoSetRecipePage.TopMost = true;
                        _AutoSetRecipePage.Show();
                        _AutoSetRecipePage.TopMost = false;
                        return;
                    }

                _AutoSetRecipePage = new AutoSetRecipePage(UID) { TopMost = true };
                _AutoSetRecipePage.Show();
            }
        }

        private void Btn_Add_SA_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;
            if (!WhiteListController.Certification(UserAuthority.UseCustomMod))
            {
                ExMessagePage.Show("警告", "工號權限不足");
                return;
            }
            if (!(_StandAloneRecipePage is null))
                if (!_StandAloneRecipePage.IsDisposed)
                {
                    ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                    _StandAloneRecipePage.TopMost = true;
                    _StandAloneRecipePage.Show();
                    _StandAloneRecipePage.TopMost = false;
                    return;
                }

            _StandAloneRecipePage = new StandAloneRecipePage(UID);
            _StandAloneRecipePage.Show();
        }

        private void Btn_Add_MES_Click(object sender, EventArgs e)
        {
            if (!CheckUID()) return;

            if (!MESController.IsConnect)
            {
                ExMessagePage.Show("拒絕操作", "無法與MES系統連線");
                return;
            }
            if (!(_AutoSetRecipePage is null))
                if (!_AutoSetRecipePage.IsDisposed)
                {
                    ExMessagePage.Show("警告", "請先關閉上一個執行的的視窗。");
                    _AutoSetRecipePage.TopMost = true;
                    _AutoSetRecipePage.Show();
                    _AutoSetRecipePage.TopMost = false;
                    return;
                }

            _AutoSetRecipePage = new AutoSetRecipePage(UID) { TopMost = true };
            _AutoSetRecipePage.Show();
        }

        private void LoadController_PerListChanged(object sender, EventArgs e)
        {
            var r1 = LoadController.GetPrepList();

            if (r1.Result)
            {
                var list = r1.Value;
                TextBoxTotalCount.Text = list.Count.ToString();

                if (list.Count > 0)
                    UpdateFirstLoadData(list[0]);
                else
                    UpdateFirstLoadData();

                DGV1.DataSource = null;
                DGV1.DataSource = list;
                DGV2.DataSource = null;
                DGV2.DataSource = list;

                foreach (DataGridViewColumn column in DGV1.Columns) column.Visible = true;
                foreach (DataGridViewColumn column in DGV2.Columns) column.Visible = true;

                foreach (var property in typeof(LoadDataDTO).GetProperties())
                {
                    DGV1.Columns[property.Name].HeaderText = property.GetCustomAttribute<DisplayAttribute>().ZHTW;
                    DGV2.Columns[property.Name].HeaderText = property.GetCustomAttribute<DisplayAttribute>().ZHTW;
                    DGV1.Columns[property.Name].Visible = true;
                    DGV2.Columns[property.Name].Visible = true;

                    switch (property.Name)
                    {
                        case nameof(LoadDataDTO.First_LotCode):
                            DGV1.Columns[property.Name].Width = 250;
                            break;
                        case nameof(LoadDataDTO.First_RecipeCode):
                            DGV1.Columns[property.Name].Width = 280;
                            break;
                        case nameof(LoadDataDTO.First_Quantity):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_Ni_WB_Current):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_Ni_B_Current):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_Au_WB_Current):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_Au_B_Current):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_AuSt_Current):
                            DGV1.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.First_Ni_PTime):
                            DGV1.Columns[property.Name].Width = 200;
                            break;
                        case nameof(LoadDataDTO.First_Au_PTime):
                            DGV1.Columns[property.Name].Width = 200;
                            break;
                        case nameof(LoadDataDTO.First_AuSt_PTime):
                            DGV1.Columns[property.Name].Width = 200;
                            break;
                        default:
                            DGV1.Columns[property.Name].Visible = false;
                            break;
                    }
                    switch (property.Name)
                    {
                        case nameof(LoadDataDTO.Second_LotCode):
                            DGV2.Columns[property.Name].Width = 250;
                            break;
                        case nameof(LoadDataDTO.Second_RecipeCode):
                            DGV2.Columns[property.Name].Width = 280;
                            break;
                        case nameof(LoadDataDTO.Second_Quantity):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_Ni_WB_Current):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_Ni_B_Current):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_Au_WB_Current):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_Au_B_Current):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_AuSt_Current):
                            DGV2.Columns[property.Name].Width = 120;
                            break;
                        case nameof(LoadDataDTO.Second_Ni_PTime):
                            DGV2.Columns[property.Name].Width = 200;
                            break;
                        case nameof(LoadDataDTO.Second_Au_PTime):
                            DGV2.Columns[property.Name].Width = 200;
                            break;
                        case nameof(LoadDataDTO.Second_AuSt_PTime):
                            DGV2.Columns[property.Name].Width = 200;
                            break;
                        default:
                            DGV2.Columns[property.Name].Visible = false;
                            break;
                    }
                }
            }
            else
            {
                ExMessagePage.Show("從資料庫取得LoadData失敗",r1.Exception.Message);
                return;
            }
        }

        public void UpdateFirstLoadData(LoadDataDTO LoadData_)
        {
            TextBox_1_LotNo.Text = LoadData_.First_LotCode;
            TextBox_1_PanelCode.Text = LoadData_.First_RecipeCode;
            TextBox_1_PMode.Text = LoadData_.First_PMode;
            TextBox_1_Quantity.Text = LoadData_.First_Quantity.ToString();

            TextBox_WB_Au_1.Text = LoadData_.First_Au_WB_Current.ToString();
            TextBox_B_Au_1.Text = LoadData_.First_Au_B_Current.ToString();
            TextBox_PTime_Au_1.Text = LoadData_.First_Au_PTime.ToString();

            TextBox_WB_Ni_1.Text = LoadData_.First_Ni_WB_Current.ToString();
            TextBox_B_Ni_1.Text = LoadData_.First_Ni_B_Current.ToString();
            TextBox_PTime_Ni_1.Text = LoadData_.First_Ni_PTime.ToString();

            TextBox_AuSt_1.Text = LoadData_.First_AuSt_Current.ToString();
            TextBox_PTime_AuSt_1.Text = LoadData_.First_AuSt_PTime.ToString();

            TextBox_2_LotNo.Text = LoadData_.Second_LotCode;
            TextBox_2_PanelCode.Text = LoadData_.Second_RecipeCode;
            TextBox_2_PMode.Text = LoadData_.Second_PMode;
            TextBox_2_Quantity.Text = LoadData_.Second_Quantity.ToString();

            TextBox_WB_Au_2.Text = LoadData_.Second_Au_WB_Current.ToString();
            TextBox_B_Au_2.Text = LoadData_.Second_Au_B_Current.ToString();
            TextBox_PTime_Au_2.Text = LoadData_.Second_Au_PTime.ToString();

            TextBox_WB_Ni_2.Text = LoadData_.Second_Ni_WB_Current.ToString();
            TextBox_B_Ni_2.Text = LoadData_.Second_Ni_B_Current.ToString();
            TextBox_PTime_Ni_2.Text = LoadData_.Second_Ni_PTime.ToString();

            TextBox_AuSt_2.Text = LoadData_.Second_AuSt_Current.ToString();
            TextBox_PTime_AuSt_2.Text = LoadData_.Second_AuSt_PTime.ToString();
        }

        public void UpdateFirstLoadData()
        {
            TextBox_1_LotNo.Text = String.Empty;
            TextBox_1_PanelCode.Text = String.Empty;
            TextBox_1_PMode.Text = String.Empty;
            TextBox_1_Quantity.Text = String.Empty;

            TextBox_WB_Au_1.Text = String.Empty;
            TextBox_B_Au_1.Text = String.Empty;
            TextBox_PTime_Au_1.Text = String.Empty;

            TextBox_WB_Ni_1.Text = String.Empty; ;
            TextBox_B_Ni_1.Text = String.Empty;
            TextBox_PTime_Ni_1.Text = String.Empty;

            TextBox_AuSt_1.Text = String.Empty;
            TextBox_PTime_AuSt_1.Text = String.Empty;

            TextBox_2_LotNo.Text = String.Empty;
            TextBox_2_PanelCode.Text = String.Empty;
            TextBox_2_PMode.Text = String.Empty;
            TextBox_2_Quantity.Text = String.Empty;

            TextBox_WB_Au_2.Text = String.Empty;
            TextBox_B_Au_2.Text = String.Empty;
            TextBox_PTime_Au_2.Text = String.Empty;

            TextBox_WB_Ni_2.Text = String.Empty;
            TextBox_B_Ni_2.Text = String.Empty;
            TextBox_PTime_Ni_2.Text = String.Empty;

            TextBox_AuSt_2.Text = String.Empty;
            TextBox_PTime_AuSt_2.Text = String.Empty;
        }

        private void DGV_Scroll(object sender, ScrollEventArgs e)
        {
            var dgv = (sender as DataGridView);
            if (dgv == this.DGV1)
            {
                this.DGV2.HorizontalScrollingOffset = dgv.HorizontalScrollingOffset;
                if (dgv.FirstDisplayedScrollingRowIndex != -1)
                    this.DGV2.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
            }
            else
            {
                this.DGV1.HorizontalScrollingOffset = dgv.HorizontalScrollingOffset;
                if (dgv.FirstDisplayedScrollingRowIndex != -1)
                    this.DGV1.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
            }
        }
        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            var selfDGV = (sender as DataGridView);
            var otherDGV = (sender == this.DGV1) ? this.DGV2 : this.DGV1;
            if (selfDGV.SelectedRows.Count == 0) return;
            var SelectIndex = selfDGV.SelectedRows[0].Index;

            if (otherDGV.Rows.Count <= SelectIndex) return;
            otherDGV.Rows[SelectIndex].Selected = true;
        }

    }
}
