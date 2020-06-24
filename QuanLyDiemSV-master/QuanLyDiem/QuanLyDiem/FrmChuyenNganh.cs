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
    public partial class FrmChuyenNganh : Form
    {
        DataTable tblChuyenNganh;
        public FrmChuyenNganh()
        {
            InitializeComponent();
        }

        private void FrmChuyenNganh_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            txtMaChuyenNganh.Enabled = false;
            cmbKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtTenKhoa.Enabled = false;
            LoadDataToGridView();
            DAO.FillDataToCombo("select * from Khoa", cmbKhoa, "MaKhoa", "MaKhoa");
            ResetValues();
            DAO.CloseConnection();

        }
        private void LoadDataToGridView()
        {
            try
            {
                DAO.OpenConnection();
                string sql;
                sql = "SELECT * FROM ChuyenNganh";
                tblChuyenNganh = DAO.GetDataToTable(sql);
                GridViewChuyenNganh.DataSource = tblChuyenNganh;
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

        private void ResetValues()
        {
            txtMaChuyenNganh.Text = "";
            txtTenChuyenNganh.Text = "";
            cmbKhoa.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaChuyenNganh.Enabled = true;
            txtMaChuyenNganh.Focus();

            ResetValues();
            cmbKhoa.SelectedIndex = -1;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update ChuyenNganh set TenChuyenNganh = N'" + txtTenChuyenNganh.Text.Trim() + "' where MaChuyenNganh = '" + txtMaChuyenNganh.Text + "';";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            LoadDataToGridView();
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string sql = "delete from ChuyenNganh where MaChuyenNganh = '" + txtMaChuyenNganh.Text + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGridView();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiem tra DL
            //Các trường không được trống
            if (txtMaChuyenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mã Chuyên Ngành!");
                txtMaChuyenNganh.Focus();
                return;
            }
            if (txtTenChuyenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Chuyên Ngành!");
                txtTenChuyenNganh.Focus();
                return;
            }

            if (cmbKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn chưa chọn Khoa!");
                return;
            }
            //
            string sql = "select * from ChuyenNganh where MaChuyenNganh='" + txtMaChuyenNganh.Text.Trim() + "'";
            DAO.OpenConnection();
            if (DAO.CheckKeyExist(sql))
            {
                MessageBox.Show("Mã Chuyên Ngành đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaChuyenNganh.Focus();
                return;
            }
            else
            {
                sql = "insert into ChuyenNganh (MaChuyenNganh,TenChuyenNganh,MaKhoa) " +
                    " values ('" + txtMaChuyenNganh.Text.Trim() + "',N'" + txtTenChuyenNganh.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGridView();
            }
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChuyenNganh.Enabled = false;
            btnHuy.Enabled = false;


        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChuyenNganh.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void GridViewChuyenNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaChuyenNganh.Text = GridViewChuyenNganh.CurrentRow.Cells["MaChuyenNganh"].Value.ToString();
            txtTenChuyenNganh.Text = GridViewChuyenNganh.CurrentRow.Cells["TenChuyenNganh"].Value.ToString();
            string ma = GridViewChuyenNganh.CurrentRow.Cells["MaKhoa"].Value.ToString();
            cmbKhoa.Text = ma;
            txtMaChuyenNganh.Enabled = false;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select TenKhoa from Khoa where MaKhoa='" + cmbKhoa.SelectedValue + "'";
            txtTenKhoa.Text = DAO.GetFieldValues(sql);
        }
    }
}
