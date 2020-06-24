
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
    public partial class FrmDanToc : Form
    {
        DataTable tblDanToc;
        public FrmDanToc()
        {
            InitializeComponent();
        }

        private void FrmDanToc_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            txtMaDanToc.Enabled = false;
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
                sql = "SELECT * FROM DanToc";
                tblDanToc = DAO.GetDataToTable(sql);
                GridViewDanToc.DataSource = tblDanToc;
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

        private void GridViewDanToc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO.OpenConnection();
            txtMaDanToc.Text = GridViewDanToc.CurrentRow.Cells["clmMaDanToc"].Value.ToString();
            txtTenDanToc.Text = GridViewDanToc.CurrentRow.Cells["clmTenDanToc"].Value.ToString();
            txtMaDanToc.Enabled = false;
        }

        private void ResetValues()
        {
            txtMaDanToc.Text = "";
            txtTenDanToc.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaDanToc.Enabled = true;
            txtMaDanToc.Focus();
            return;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDanToc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDanToc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDanToc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dân tộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanToc.Focus();
                return;
            }
            sql = "UPDATE DanToc SET TenDanToc=N'" + txtTenDanToc.Text.ToString() + "' WHERE MaDanToc=N'" + txtMaDanToc.Text + "'";
            DAO.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDanToc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDanToc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE DanToc WHERE MaDanToc=N'" + txtMaDanToc.Text + "'";
                DAO.RunSql(sql);
                Load_DataGridView();
                ResetValues();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (txtMaDanToc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã dân tộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDanToc.Focus();
                return;
            }
            if (txtTenDanToc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dân tộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanToc.Focus();
                return;
            }

            sql = "SELECT MaDanToc FROM DanToc WHERE MaDanToc=N'" + txtMaDanToc.Text.Trim() + "'";
            if (DAO.CheckKeyExist(sql))
            {
                MessageBox.Show("Mã dân tộc này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDanToc.Focus();
                txtMaDanToc.Text = "";
                return;
            }
            sql = "INSERT INTO DanToc(MaDanToc,TenDanToc) VALUES(N'" + txtMaDanToc.Text.Trim() + "',N'" + txtTenDanToc.Text.Trim() + "')";
            DAO.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = false;
            txtMaDanToc.Enabled = false;
            DAO.CloseConnection();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValues();
            GridViewDanToc.Enabled = true;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaDanToc.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
