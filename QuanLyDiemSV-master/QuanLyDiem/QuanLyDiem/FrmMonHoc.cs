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
    public partial class FrmMonHoc : Form
    {
        DataTable tblMonHoc;
        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaMon.Enabled = false;
            LoadDataToTable();
        }
        private void LoadDataToTable()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select * from MonHoc";
                tblMonHoc = DAO.GetDataToTable(sql);
                GridViewMonHoc.DataSource = tblMonHoc;
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
        private void Reset()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtDVHT.Text = "";
            GridViewMonHoc.Enabled = true;
            btnHuy.Enabled = false;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaMon.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMon.Focus();
                return;
            }

            if (txtTenMon.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }
            if (txtDVHT.Text.Trim() == "")
            {
                MessageBox.Show("Số tín chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDVHT.Focus();
                return;
            }
            string s1 = "select MaMon from MonHoc where MaMon = N'" + txtMaMon.Text.Trim() + "'";
            if (DAO.CheckKeyExist(s1))
            {
                MessageBox.Show("Mã môn này đã tồn tại. Nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.OpenConnection();
                txtMaMon.Text = "";
                txtMaMon.Focus();
                return;
            }
            else
            {
                string sql = "insert into MonHoc values (N'" + txtMaMon.Text.Trim() + "',N'" + txtTenMon.Text.Trim() + "'," + txtDVHT.Text.Trim() + ")";
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
                txtMaMon.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset();
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaMon.Enabled = false;
            GridViewMonHoc.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblMonHoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "update MonHoc set TenMon=N'" + txtTenMon.Text.Trim() + "',DVHT='" + txtDVHT.Text.Trim() + "' where MaMon=N'" + txtMaMon.Text.Trim() + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            LoadDataToTable();
            GridViewMonHoc.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblMonHoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "select MaMon from Diem where MaMon='" + txtMaMon.Text.Trim() + "'";
            if (DAO.CheckKeyExist(sql) == true)
                MessageBox.Show("Bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    sql = "delete from MonHoc where MaMon=N'" + txtMaMon.Text.Trim() + "'";
                    DAO.OpenConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;
                    cmd.Connection = DAO.con;
                    cmd.ExecuteNonQuery();
                    DAO.CloseConnection();
                    LoadDataToTable();
                    Reset();
                    txtMaMon.Enabled = false;
                }
            }    
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
            GridViewMonHoc.Enabled = false;
        }

        private void GridViewMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaMon.Text = GridViewMonHoc.CurrentRow.Cells["clmMaMon"].Value.ToString();
            txtTenMon.Text = GridViewMonHoc.CurrentRow.Cells["clmTenMon"].Value.ToString();
            txtDVHT.Text = GridViewMonHoc.CurrentRow.Cells["clmDVHT"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void txtDVHT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;

        }
    }
}
