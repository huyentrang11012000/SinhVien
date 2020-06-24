using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows;

namespace QuanLyDiem
{
    public partial class FrmChucVu : Form
    {
        DataTable tblChucVu;
        public FrmChucVu()
        {
            InitializeComponent();
        }

        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            LoadDataToGrivew();
        }
        public void LoadDataToGrivew()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select * from ChucVu";
                tblChucVu = DAO.GetDataToTable(sql);
                GridViewChucVu.DataSource = tblChucVu;
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

        private void GridViewChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaChucVu.Text = GridViewChucVu.CurrentRow.Cells["clmMaChucVu"].Value.ToString();
            txtTenChucVu.Text = GridViewChucVu.CurrentRow.Cells["clmTenChucVu"].Value.ToString();
            txtMaChucVu.Enabled = false;
        }
        private void ResetValues()
        {
            txtMaChucVu.Enabled = true;
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaChucVu.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã chức vụ ");
                txtMaChucVu.Focus();
                return;
            }
            if (txtTenChucVu.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên chức vụ");
                txtTenChucVu.Focus();
                return;
            }
            string sqlCheckKey = "Select * from ChucVu Where MaChucVu = '"
                                + txtMaChucVu.Text.Trim() + "'";
            DAO.OpenConnection();


            if (DAO.CheckKeyExist(sqlCheckKey))
            {
                MessageBox.Show("Mã chức vụ đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaChucVu.Focus();
                return;
            }
            else
            {
                string sql = "insert into ChucVu values ('" + txtMaChucVu.Text.Trim() + "' , N'" + txtTenChucVu.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGrivew();
                DAO.CloseConnection();
                btnLuu.Enabled = false;
                txtMaChucVu.Enabled = false;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblChucVu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChucVu.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChucVu.Focus();
                return;
            }
            else
            {
                sql = "Update ChucVu set TenChucVu = N'" + txtTenChucVu.Text.Trim() + "' where MaChucVu = '" + txtMaChucVu.Text.Trim() + "'";

                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();//thực thi câu lệnh
                DAO.CloseConnection();
                LoadDataToGrivew();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblChucVu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChucVu.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE ChucVu WHERE MaChucVu= N'" + txtMaChucVu.Text.Trim() + "'";

                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                ResetValues();
                LoadDataToGrivew();

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChucVu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
