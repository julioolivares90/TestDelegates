using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDelegates.ControlUser;
using static TestDelegates.ControlUser.ucRowNote;

namespace TestDelegates
{
    public partial class Form1 : Form
    {
       

        private DB DataBase;

        public Form1()
        {
            InitializeComponent();

            DataBase = DB.GetInstance();

            LoadData();

        }

        private void LoadData()
        {
            var notes = DataBase.GetNotes();

            foreach (var item in notes)
            {
                var row = new ucRowNote(item.Date, item.Text,item.Id);
                row.OnNeedReloadData += new NeedReloadData(ReloadData);
                flowLayoutPanel1.Controls.Add(row);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //var row = new ucRowNote(DateTime.Now,"algoalgoalgoalgoalgoalgoalgaoglaoglaogalogagogogdgsgs");
            //flowLayoutPanel1.Controls.Add(row);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.VerticalScroll.Enabled = true;

        }


        public void ReloadData(bool reload)
        {
            if (reload)
            {
                this.flowLayoutPanel1.Controls.Clear();
                LoadData();
            }
        }
    }
}
