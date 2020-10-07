using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDbBackup
{
    public partial class FMain : Form
    {
        internal static FMain instance;
        const string SAT = "SAT", SUN = "SUN", MON = "MON", TUE = "TUE", WED = "WED", THU = "THU", FRI = "FRI";
        public FMain()
        {
            InitializeComponent();
            instance = this;
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            Log("log file is initialized");
            SetServiceOptions();
            StartBackupScheduler();
        }

        void SetServiceOptions()
        {
            var days = Config.Instance.Read<string>("BackupDays");
            daysCheckbox.ClearSelected();
            if (!string.IsNullOrWhiteSpace(days))
            {
                var dayList = days.Split(',').ToList();
                dayList.ForEach(day =>
                {
                    int index;
                    switch (day)
                    {
                        case SAT:
                            index = 0;
                            break;
                        case SUN:
                            index = 1;
                            break;
                        case MON:
                            index = 2;
                            break;
                        case TUE:
                            index = 3;
                            break;
                        case WED:
                            index = 4;
                            break;
                        case THU:
                            index = 5;
                            break;
                        case FRI:
                            index = 6;
                            break;
                        default: return;
                    }
                    daysCheckbox.SetItemChecked(index, true);
                });
            }

            txtHour.Text = Config.Instance.Read<string>("BackupHour");
            txtMin.Text = Config.Instance.Read<string>("BackupMinute");
            txtBackupDir.Text = Config.Instance.Read<string>("BackupDir");

            lv_Dbs.Clear();
            Config.Instance.Databases.Distinct().ToList().ForEach(db =>
            {
                lv_Dbs.Items.Add(db);
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void FMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnAddDatabase_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDatabaseName.Text) && !lv_Dbs.Items.ContainsKey(txtDatabaseName.Text))
            {
                lv_Dbs.Items.Add(txtDatabaseName.Text);
            }
        }

        private void btnManualBackup_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDatabase.Text))
                BackupHelper.ExecuteMongoDump(txtDatabase.Text, Log);
            else MessageBox.Show("database is empty", "ERROR", MessageBoxButtons.OK);
        }

        internal void Log(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ls_Messages.Items.Add($"({DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}) {message}");
            });
        }

        Task StartBackupScheduler()
        {
            try
            {
                var days = Config.Instance.Read<string>("BackupDays");
                BackupScheduler.Start(days, txtHour.Text, txtMin.Text).GetAwaiter();
                Log("backup scheduler started successfully");
            }
            catch (Exception ex)
            {
                Log($"cannot start backup scheduler => {ex.Message}");
            }

            return Task.FromResult(true);
        }

        Task StopBackupScheduler()
        {
            try
            {
                BackupScheduler.Stop().GetAwaiter();
                Log("backup scheduler stopped successfully");
            }
            catch (Exception ex)
            {
                Log($"cannot stop backup scheduler => {ex.Message}");
            }

            return Task.FromResult(true);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ResetConfigs();
        }

        private void ResetConfigs()
        {
            try
            {
                Config.Instance.Write<string>("BackupHour", txtHour.Text);
                Config.Instance.Write<string>("BackupMinute", txtMin.Text);
                Config.Instance.Write<string>("BackupDir", txtBackupDir.Text);

                var dbs = new StringBuilder();
                foreach (ListViewItem db in lv_Dbs.Items)
                {
                    dbs.Append(db.Text);
                    if (lv_Dbs.Items.IndexOf(db) != lv_Dbs.Items.Count - 1)
                        dbs.Append(",");
                }
                Config.Instance.Write<string>("Databases", dbs.ToString());

                var days = new StringBuilder();
                foreach (var day in daysCheckbox.CheckedItems)
                {
                    days.Append(day.ToString());
                    if (daysCheckbox.CheckedItems.IndexOf(day) != daysCheckbox.CheckedItems.Count - 1)
                        days.Append(",");
                }
                Config.Instance.Write<string>("BackupDays", days.ToString());

                Log("changes are successfully applied to config file");
            }
            catch (Exception)
            {
                Log("cannot apply changes to app.config file");
                return;
            }

            StopBackupScheduler();
            StartBackupScheduler();
        }
    }
}
