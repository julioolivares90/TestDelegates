using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDelegates.ControlUser
{
    public partial class ucRowNote : UserControl
    {
        private readonly DateTime date;
        private readonly string text;
        private readonly string id;

        public delegate void  RowDeleted();
        public event RowDeleted OnRowDeleted;

        public delegate void NeedReloadData(bool needReloadData);

        public event NeedReloadData OnNeedReloadData;

        DB DataBase = DB.GetInstance();

        public ucRowNote(DateTime date,string text,string id)
        {
            InitializeComponent();
            this.date = date;
            this.text = text;
            this.id = id;
            label1.Text = date.ToString("dd-MM-yyy");
            richTextBox1.Text = text;
            label2.Text = id;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void CallDelegate(NeedReloadData callback)
        {
            callback(true);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            var note = DB.GetInstance().GetNoteByID(id);

            var result = DataBase.DeleteNote(note);
            if (result)
            {
                OnNeedReloadData?.Invoke(true);
            }
            
        }

        public void RowDeletedM()
        {

        }
    }
}
