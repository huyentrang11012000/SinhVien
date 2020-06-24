using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDiem
{
    public partial class FrmHeDaoTao : Form
    {
        DataTable tblHeDaoTao;
        public FrmHeDaoTao()
        {
            InitializeComponent();
        }

        private void FrmHeDaoTao_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            txtMaHDT.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            Load_DataGridView();
            DAO.CloseConnection();
        }
        private void Load_DataGridView()
        {
            try
            {
                DAO.OpenConnection();
                string sql;
                sql = "SELECT * FROM HeDaoTao";
                tblHeDaoTao = DAO.GetDataToTable(sql);
                GridViewHeDaoTao.DataSource = tblHeDaoTao;
                DAO.CloseConnection();
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

        private void GridViewHeDaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO.OpenConnection();
            txtMaHDT.Text = GridViewHeDaoTao.CurrentRow.Cells["clmMaHDT"].Value.ToString();
            txtTenHDT.Text = GridViewHeDaoTao.CurrentRow.Cells["clmTenHDT"].Value.ToString();
            txtMaHDT.Enabled = false;
        }
        private void ResetValues()
        {
            txtMaHDT.Text = "";
            txtTenHDT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            GridViewHeDaoTao.Enabled = false;
            txtMaHDT.Enabled = true;
            txtMaHDT.Focus();
            return;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (tblHeDaoTao.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hệ đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHDT.Focus();
                return;
            }
            sql = "UPDATE HeDaoTao SET TenHDT=N'" + txtTenHDT.Text.ToString() + "' WHERE MaHDT=N'" + txtMaHDT.Text + "'";
            DAO.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnHuy.Enabled = false;
            DAO.CloseConnection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHeDaoTao.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE HeDaoTao WHERE MaHDT=N'" + txtMaHDT.Text + "'";
                DAO.RunSql(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (txtMaHDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hệ đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDT.Focus();
                return;
            }
            if (txtTenHDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hệ đào tạo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHDT.Focus();
                return;
            }

            sql = "SELECT MaHDT FROM HeDaoTao WHERE MaHDT=N'" + txtMaHDT.Text.Trim() + "'";
            if (DAO.CheckKeyExist(sql))
            {
                MessageBox.Show("Mã hệ đào tạo này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHDT.Focus();
                txtMaHDT.Text = "";
                return;
            }
            sql = "INSERT INTO HeDaoTao(MaHDT,TenHDT) VALUES('" + txtMaHDT.Text.Trim() + "',N'" + txtTenHDT.Text.Trim() + "')";
            DAO.RunSql(sql);
            Load_DataGridView();
            GridViewHeDaoTao.Enabled = true;
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHDT.Enabled = false;
            DAO.CloseConnection();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            GridViewHeDaoTao.Enabled = true;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHDT.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
