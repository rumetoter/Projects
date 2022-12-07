using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VizeOncesiSon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\personel.accdb");
            OleDbDataAdapter da1 = new OleDbDataAdapter("Select * from personel", con);
            OleDbDataAdapter da2 = new OleDbDataAdapter("Select * from bolum", con);
            OleDbDataAdapter da3 = new OleDbDataAdapter("Select * from maas", con);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataSet ds = new DataSet();
            da1.Fill(dt1);
            da2.Fill(dt2);
            da3.Fill(dt3);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt3);
            DataRelation dr1, dr2;
            dr1 = new DataRelation("Personelin Bölüm Bilgileri", dt1.Columns["Numara"], dt2.Columns["Numara"]);
            dr2 = new DataRelation("Personelin Maaş Bilgileri", dt1.Columns["Numara"], dt3.Columns["Numara"]);
            ds.Relations.Add(dr1);
            ds.Relations.Add(dr2);
            dataGrid1.DataSource = ds;
        }
    }
}
