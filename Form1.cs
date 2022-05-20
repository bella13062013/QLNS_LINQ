using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
namespace QLNV_LINQ
{
    public partial class Form1 : Form
    {
        QLNSDataContext dt = new QLNSDataContext();
        Table<NHANVIEN> nhanViens;
        Table<PHONGBAN> phongBans;
        public Form1()
        {
            InitializeComponent();
        }

        public void loadPB()
        {
            phongBans = dt.GetTable<PHONGBAN>();
            var query = from pb in phongBans
                        select new { mapb = pb.Mã_phòng_ban, tenpb = pb.Tên_phòng_ban };
            cboPB.DataSource = query;
            cboPB.DisplayMember = "tenpb";
            cboPB.ValueMember = "mapb";
        }
        public void loadData()
        {
            nhanViens = dt.GetTable<NHANVIEN>();
            var query = from nv in nhanViens
                        select nv;
            data.DataSource = query;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadPB();
            loadData();
        }
        // them mot nhan vien moi
        private void btnThem_Click(object sender, EventArgs e)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.Mã_nhân_viên = txtMNV.Text;
            nv.Họ_tên = txtHT.Text;
            nv.Ngày_sinh = Convert.ToDateTime(dateTimePicker1.Text);
            nv.Giới_tính = rdoNam.Checked == true ? true : false;
            nv.Số_điện_thoại = txtHT.Text;
            nv.Phòng_ban = cboPB.SelectedValue.ToString();

            nhanViens.InsertOnSubmit(nv);
            dt.SubmitChanges();
            loadData();
        }
        

    }
}
