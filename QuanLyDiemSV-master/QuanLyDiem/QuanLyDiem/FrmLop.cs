using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace QuanLyDiem
{
    public partial class FrmLop : Form
    {
        DataTable tblLop;
        public FrmLop()
        {
            InitializeComponent();
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql = "select MaKhoa,TenKhoa from Khoa";
            DAO.FillDataToCombo(sql, cmbMaKhoa, "MaKhoa", "TenKhoa");
            txtSiSo.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaLop.Enabled = false;
            // cmbMaKhoa.Enabled = false;
            LoadDataToTable();
            Reset();
            cmbMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void LoadDataToTable()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select * from Lop";
                tblLop = DAO.GetDataToTable(sql);
                GridViewLop.DataSource = tblLop;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnection();
            }
        }

        private void GridViewLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLop.Text = GridViewLop.CurrentRow.Cells["clmMaLop"].Value.ToString();
            txtTenLop.Text = GridViewLop.CurrentRow.Cells["clmTenLop"].Value.ToString();
            txtKhoaHoc.Text = GridViewLop.CurrentRow.Cells["clmKhoaHoc"].Value.ToString();
            txtSiSo.Text = GridViewLop.CurrentRow.Cells["clmSiSo"].Value.ToString();
            cmbMaKhoa.Text = DAO.GetFieldValues("select  TenKhoa from Khoa where MaKhoa = N'" + GridViewLop.CurrentRow.Cells["clmMaKhoa"].Value.ToString() + "'");
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            // cmbMaKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
        }

        private void Reset()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
            txtSiSo.Text = "";
            cmbMaKhoa.SelectedIndex = -1;
            GridViewLop.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            txtMaLop.Enabled = true;
            //cmbMaKhoa.Enabled = true;
            txtMaLop.Focus();
            GridViewLop.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return;
            }

            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }
            if (cmbMaKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn tên khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtKhoaHoc.Text.Trim() == "")
            {
                MessageBox.Show("Khóa học không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhoaHoc.Focus();
                return;
            }

            string s1 = "select MaLop from Lop where MaLop = N'" + txtMaLop.Text.Trim() + "'";
            if (DAO.CheckKeyExist(s1))
            {
                MessageBox.Show("Mã lớp này đã tồn tại. Nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.OpenConnection();
                txtMaLop.Text = "";
                txtMaLop.Focus();
                return;
            }
            else
            {
                string sql = "insert into Lop values (N'" + txtMaLop.Text.Trim() + "',N'" + txtTenLop.Text.Trim() + "','" + cmbMaKhoa.SelectedValue.ToString() + "',N'" + txtKhoaHoc.Text.Trim() + "',0)";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                MessageBox.Show("Bạn đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataToTable();
                Reset();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                txtMaLop.Enabled = false;
                //cmbMaKhoa.Enabled = false;

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblLop.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "update Lop set TenLop=N'" + txtTenLop.Text.Trim() + "', MaKhoa='" + cmbMaKhoa.SelectedValue.ToString() + "', KhoaHoc=N'" + txtKhoaHoc.Text.Trim() + "',SiSo=" + txtSiSo.Text.Trim() + " where MaLop=N'" + txtMaLop.Text.Trim() + "'";
            // MessageBox.Show(sql);
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            LoadDataToTable();
            GridViewLop.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblLop.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "delete from Lop where MaLop='" + txtMaLop.Text.Trim() + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToTable();
                Reset();
                txtMaLop.Enabled = false;
                //cmbMaKhoa.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLop.Enabled = false;
            // cmbMaKhoa.Enabled = false;
            //GridViewLop.Enabled = true;
        }


    }
}
