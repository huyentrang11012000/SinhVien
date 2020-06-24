using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace QuanLyDiem
{
    public partial class FrmThoiKhoaBieu : Form
    {
        public FrmThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void FrmThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();

            cmbLop.Enabled = false;
            cmbMon.Enabled = false;
            cmbPhong.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataToGridView();
            DAO.FillDataToCombo("SELECT MaLop FROM Lop", cmbLop,"MaLop", "MaLop");
            cmbLop.SelectedIndex = -1;
            DAO.FillDataToCombo("SELECT MaPhong  FROM PhongHoc",cmbPhong, "MaPhong", "MaPhong");
            cmbPhong.SelectedIndex = -1;
            DAO.FillDataToCombo("SELECT MaMon FROM MonHoc", cmbMon,"MaMon", "MaMon");
            cmbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;


            DAO.CloseConnection();
        }
        private void LoadDataToGridView()
        {
            string sql = "select * from Thoi_Khoa_Bieu";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.con);
            DataTable table = new DataTable();
            adapter.Fill(table);
            GridViewTKB.DataSource = table;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            cmbLop.Enabled = true;
            cmbMon.Enabled = true;
            cmbPhong.Enabled = true;
            cmbLop.SelectedIndex = -1;
            cmbMon.SelectedIndex = -1;
            cmbPhong.SelectedIndex = -1;
            rdohk1.Checked = false;
            rdohk2.Checked = false;
            rdohk3.Checked = false;
            rdohk4.Checked = false;
            rdohk5.Checked = false;
            rdohk6.Checked = false;
            rdohk7.Checked = false;
            rdohk8.Checked = false;
            rdoca1.Checked = false;
            rdoca2.Checked = false;
            rdoca3.Checked = false;
            rdoca4.Checked = false;
            rdoca5.Checked = false;
            rdothu2.Checked = false;
            rdothu3.Checked = false;
            rdothu4.Checked = false;
            rdothu5.Checked = false;
            rdothu6.Checked = false;
            rdothu7.Checked = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra DL
            //Các trường không được trống

            if (cmbLop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Lớp!");
                return;
            }
            if (cmbPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Phòng!");

                return;
            }
            if (cmbMon.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Môn học!");

                return;
            }
            int strHK = -1;

            if (rdohk1.Checked == true)
                strHK = Convert.ToInt32(rdohk1.Text);
            if (rdohk2.Checked == true)
                strHK = Convert.ToInt32(rdohk2.Text);
            if (rdohk3.Checked == true)
                strHK = Convert.ToInt32(rdohk3.Text);
            if (rdohk4.Checked == true)
                strHK = Convert.ToInt32(rdohk4.Text);
            if (rdohk5.Checked == true)
                strHK = Convert.ToInt32(rdoca5.Text);
            if (rdohk6.Checked == true)
                strHK = Convert.ToInt32(rdohk6.Text);
            if (rdohk7.Checked == true)
                strHK = Convert.ToInt32(rdohk7.Text);
            if (rdohk8.Checked == true)
                strHK = Convert.ToInt32(rdohk8.Text);
            if (strHK == -1)
            {
                MessageBox.Show("Bạn chưa chọn Học Kỳ!");
                return;
            }
            int strCa = -1;
            if (rdoca1.Checked == true)
                strCa = Convert.ToInt32(rdoca1.Text);
            if (rdoca2.Checked == true)
                strCa = Convert.ToInt32(rdoca2.Text);
            if (rdoca3.Checked == true)
                strCa = Convert.ToInt32(rdoca3.Text);
            if (rdoca4.Checked == true)
                strCa = Convert.ToInt32(rdoca4.Text);
            if (rdoca5.Checked == true)
                strCa = Convert.ToInt32(rdoca5.Text);
            if (strCa == -1)
            {
                MessageBox.Show("Bạn chưa chọn Ca học!");
                return;
            }

            string strThu = "";
            if (rdothu2.Checked == true)
                strThu += rdothu2.Text;
            if (rdothu3.Checked == true)
                strThu += rdothu3.Text;
            if (rdothu4.Checked == true)
                strThu += rdothu4.Text;
            if (rdothu5.Checked == true)
                strThu += rdothu5.Text;
            if (rdothu6.Checked == true)
                strThu += rdothu6.Text;
            if (rdothu7.Checked == true)
                strThu += rdothu7.Text;
            if (strThu == "")
            {
                MessageBox.Show("Bạn chưa chọn Thứ học!");
                return;
            }

            string sql = "select * from Thoi_Khoa_Bieu where MaLop='" + cmbLop.SelectedValue.ToString() + "' and MaMon=N'" + cmbMon.SelectedValue.ToString() + "' and  HocKy=" + strHK + " and ThuHoc=N'" + strThu.ToString() + "' and CaHoc=" + strCa + " and MaPhong='" + cmbPhong.SelectedValue.ToString() + "'";

            DAO.OpenConnection();
            if (DAO.CheckKeyExist(sql))
            {
                MessageBox.Show("Mã Lớp và Mã Môn đã trùng lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();

                return;
            }
            string sql1 = "select * from Thoi_Khoa_Bieu where HocKy=" + strHK + " and ThuHoc=N'" + strThu.ToString() + "' and CaHoc=" + strCa + " and MaPhong='" + cmbPhong.SelectedValue.ToString() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExist(sql1))
            {
                MessageBox.Show("Phòng học đã có lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                sql = "insert into Thoi_Khoa_Bieu (MaLop,MaMon,HocKy,ThuHoc,CaHoc,MaPhong) " +
                    " values ('" + cmbLop.SelectedValue.ToString() + "','" + cmbMon.SelectedValue.ToString() + "'," + strHK.ToString() + ",N'" + strThu.ToString() + "'," + strCa.ToString() + ",'" + cmbPhong.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGridView();
                cmbLop.Enabled = false;
                cmbMon.Enabled = false;
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int strHK = -1;

            if (rdohk1.Checked == true)
                strHK = Convert.ToInt32(rdohk1.Text);
            if (rdohk2.Checked == true)
                strHK = Convert.ToInt32(rdohk2.Text);
            if (rdohk3.Checked == true)
                strHK = Convert.ToInt32(rdohk3.Text);
            if (rdohk4.Checked == true)
                strHK = Convert.ToInt32(rdohk4.Text);
            if (rdohk5.Checked == true)
                strHK = Convert.ToInt32(rdoca5.Text);
            if (rdohk6.Checked == true)
                strHK = Convert.ToInt32(rdohk6.Text);
            if (rdohk7.Checked == true)
                strHK = Convert.ToInt32(rdohk7.Text);
            if (rdohk8.Checked == true)
                strHK = Convert.ToInt32(rdohk8.Text);

            int strCa = -1;
            if (rdoca1.Checked == true)
                strCa = Convert.ToInt32(rdoca1.Text);
            if (rdoca2.Checked == true)
                strCa = Convert.ToInt32(rdoca2.Text);
            if (rdoca3.Checked == true)
                strCa = Convert.ToInt32(rdoca3.Text);
            if (rdoca4.Checked == true)
                strCa = Convert.ToInt32(rdoca4.Text);
            if (rdoca5.Checked == true)
                strCa = Convert.ToInt32(rdoca5.Text);


            string strThu = "";
            if (rdothu2.Checked == true)
                strThu += rdothu2.Text;
            if (rdothu3.Checked == true)
                strThu += rdothu3.Text;
            if (rdothu4.Checked == true)
                strThu += rdothu4.Text;
            if (rdothu5.Checked == true)
                strThu += rdothu5.Text;
            if (rdothu6.Checked == true)
                strThu += rdothu6.Text;
            if (rdothu7.Checked == true)
                strThu += rdothu7.Text;

            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from Thoi_Khoa_Bieu where MaLop = '" + cmbLop.SelectedValue.ToString() + "' and MaMon='" + cmbMon.SelectedValue.ToString() + "' and HocKy=" + strHK + " and ThuHoc=N'" + strThu.ToString() + "' and CaHoc=" + strCa + " and MaPhong='" + cmbPhong.SelectedValue.ToString() + "' ";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGridView();
                cmbLop.Enabled = false;
                cmbMon.Enabled = false;
            }
        }

        private void GridViewTKB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = GridViewTKB.CurrentRow.Cells["id"].Value.ToString();
            string ma = GridViewTKB.CurrentRow.Cells["MaLop"].Value.ToString();
            cmbLop.Text = DAO.GetFieldValues("select MaLop from Lop where MaLop = '" + ma + "'");
            string na = GridViewTKB.CurrentRow.Cells["MaMon"].Value.ToString();
            cmbMon.Text = DAO.GetFieldValues("select MaMon from MonHoc where MaMon = '" + na + "'");
            string la = GridViewTKB.CurrentRow.Cells["MaPhong"].Value.ToString();
            cmbPhong.Text = DAO.GetFieldValues("select MaPhong from PhongHoc where MaPhong = '" + la + "'");
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "1")
                rdohk1.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "2")
                rdohk2.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "3")
                rdohk3.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "4")
                rdohk4.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "5")
                rdohk5.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "6")
                rdohk6.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "7")
                rdohk7.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["HocKy"].Value.ToString() == "8")
                rdohk8.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Hai")
                rdothu2.Checked = true;


            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Ba")
                rdothu3.Checked = true;

            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Tư")
                rdothu4.Checked = true;

            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Năm")
                rdothu5.Checked = true;

            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Sáu")
                rdothu6.Checked = true;


            if (GridViewTKB.CurrentRow.Cells["ThuHoc"].Value.ToString() == "Bảy")
                rdothu7.Checked = true;

            if (GridViewTKB.CurrentRow.Cells["CaHoc"].Value.ToString() == "1")
                rdoca1.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["CaHoc"].Value.ToString() == "2")
                rdoca2.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["CaHoc"].Value.ToString() == "3")
                rdoca3.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["CaHoc"].Value.ToString() == "4")
                rdoca4.Checked = true;
            if (GridViewTKB.CurrentRow.Cells["CaHoc"].Value.ToString() == "5")
                rdoca5.Checked = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            int strHK = -1;

            if (rdohk1.Checked == true)
                strHK = Convert.ToInt32(rdohk1.Text);
            if (rdohk2.Checked == true)
                strHK = Convert.ToInt32(rdohk2.Text);
            if (rdohk3.Checked == true)
                strHK = Convert.ToInt32(rdohk3.Text);
            if (rdohk4.Checked == true)
                strHK = Convert.ToInt32(rdohk4.Text);
            if (rdohk5.Checked == true)
                strHK = Convert.ToInt32(rdoca5.Text);
            if (rdohk6.Checked == true)
                strHK = Convert.ToInt32(rdohk6.Text);
            if (rdohk7.Checked == true)
                strHK = Convert.ToInt32(rdohk7.Text);
            if (rdohk8.Checked == true)
                strHK = Convert.ToInt32(rdohk8.Text);

            string strThu = "";
            if (rdothu2.Checked == true)
                strThu += rdothu2.Text;
            if (rdothu3.Checked == true)
                strThu += rdothu3.Text;
            if (rdothu4.Checked == true)
                strThu += rdothu4.Text;
            if (rdothu5.Checked == true)
                strThu += rdothu5.Text;
            if (rdothu6.Checked == true)
                strThu += rdothu6.Text;
            if (rdothu7.Checked == true)
                strThu += rdothu7.Text;
            int strCa = -1;
            if (rdoca1.Checked == true)
                strCa = Convert.ToInt32(rdoca1.Text);
            if (rdoca2.Checked == true)
                strCa = Convert.ToInt32(rdoca2.Text);
            if (rdoca3.Checked == true)
                strCa = Convert.ToInt32(rdoca3.Text);
            if (rdoca4.Checked == true)
                strCa = Convert.ToInt32(rdoca4.Text);
            if (rdoca5.Checked == true)
                strCa = Convert.ToInt32(rdoca5.Text);

            if (cmbLop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLop.Focus();
                return;

            }
            if (cmbMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbMon.Focus();
                return;
            }
            if (cmbPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Phòng!", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                cmbPhong.Focus();
                return;
            }
            if (strHK == -1)
            {
                MessageBox.Show("Bạn phải chọn Học Kỳ!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (strCa == -1)
            {
                MessageBox.Show("Bạn phải chọn Ca học!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (strThu == "")
            {
                MessageBox.Show("Bạn phải chọn Thứ học!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            string sql = "update Thoi_Khoa_Bieu set  MaPhong = '" + cmbPhong.SelectedValue.ToString() + "',  HocKy=" + strHK + ", ThuHoc=N'" + strThu.ToString() + "',CaHoc=" + strCa + "  where id = " + txtid.Text + "";

            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            LoadDataToGridView();
            cmbLop.Enabled = false;
            cmbMon.Enabled = false;
            btnHuy.Enabled = false;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cmbLop.SelectedIndex = -1;
            cmbMon.SelectedIndex = -1;
            cmbPhong.SelectedIndex = -1;

            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            cmbLop.Enabled = false;
            cmbMon.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                this.Close();
        }
    }
}


