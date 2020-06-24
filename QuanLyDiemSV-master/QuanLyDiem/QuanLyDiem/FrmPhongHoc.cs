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
    public partial class FrmPhongHoc : Form
    {
        DataTable tblPhongHoc;
        public FrmPhongHoc()
        {
            InitializeComponent();
        }

        private void FrmPhongHoc_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaPhong.Enabled = false;
            LoadDataToTable();
        }

        private void LoadDataToTable()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select * from PhongHoc";
                tblPhongHoc = DAO.GetDataToTable(sql);
                GridViewPhongHoc.DataSource = tblPhongHoc;
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

        private void GridViewPhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = GridViewPhongHoc.CurrentRow.Cells["clmMaPhong"].Value.ToString();
            txtTenPhong.Text = GridViewPhongHoc.CurrentRow.Cells["clmTenPhong"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void Reset()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
            GridViewPhongHoc.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            txtMaPhong.Enabled = true;
            txtMaPhong.Focus();
            GridViewPhongHoc.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Mã phòng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

            if (txtTenPhong.Text.Trim() == "")
            {
                MessageBox.Show("Tên phòng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }

            string s1 = "select MaPhong from PhongHoc where MaPhong = N'" + txtMaPhong.Text.Trim() + "'";
            if (DAO.CheckKeyExist(s1))
            {
                MessageBox.Show("Mã phòng này đã tồn tại. Nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.OpenConnection();
                txtMaPhong.Text = "";
                txtMaPhong.Focus();
                return;
            }
            else
            {
                string sql = "insert into PhongHoc values (N'" + txtMaPhong.Text.Trim() + "',N'" + txtTenPhong.Text.Trim() + "')";
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
                txtMaPhong.Enabled = false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblPhongHoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = "update PhongHoc set TenPhong=N'" + txtTenPhong.Text.Trim() + "' where MaPhong=N'" + txtMaPhong.Text.Trim() + "'";
            DAO.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = DAO.con;
            cmd.ExecuteNonQuery();
            DAO.CloseConnection();
            LoadDataToTable();
            GridViewPhongHoc.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblPhongHoc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                string sql = "delete from PhongHoc where MaPhong=N'" + txtMaPhong.Text.Trim() + "'";
                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToTable();
                Reset();
                txtMaPhong.Enabled = false;
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
            txtMaPhong.Enabled = false;
            GridViewPhongHoc.Enabled = true;
        }


    }
}
