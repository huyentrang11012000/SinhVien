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
    public partial class FrmKhoa : Form
    {
        DataTable tblKhoa;
        public FrmKhoa()
        {
            InitializeComponent();
        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {
            LoadDataToGrivew();
        }
        public void LoadDataToGrivew()
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select * from Khoa";
                tblKhoa = DAO.GetDataToTable(sql);
                GridViewKhoa.DataSource = tblKhoa;

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
            txtMaKhoa.Enabled = true;
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtWebsite.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã khoa ");
                txtMaKhoa.Focus();
                return;
            }
            if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên khoa");
                txtTenKhoa.Focus();
                return;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("bạn chưa nhập số điện thoại ");
                txtDienThoai.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("bạn chưa nhập địa chỉ ");
                txtDiaChi.Focus();
                return;
            }
            if (txtWebsite.Text == "")
            {
                MessageBox.Show("bạn chưa nhập website ");
                txtWebsite.Focus();
                return;
            }

            string sqlCheckKey = "Select * from Khoa Where MaKhoa = '"
                                + txtMaKhoa.Text.ToString() + "'";
            DAO.OpenConnection();


            if (DAO.CheckKeyExist(sqlCheckKey))
            {
                MessageBox.Show("Mã khoa đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaKhoa.Focus();
                return;
            }
            else
            {
                string sql = "insert into Khoa values ('" +
                            txtMaKhoa.Text.ToString() + "' , N'" +
                            txtTenKhoa.Text.Trim() + "','" + txtDienThoai.Text.Trim() + "','" + txtDiaChi.Text.Trim() + "','" + txtWebsite.Text.Trim() + "')";
                MessageBox.Show("oke");
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGrivew();
                DAO.CloseConnection();
                btnLuu.Enabled = false;
                //cmbMaKhoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;

            if (tblKhoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return;
            }
            else
            {
                sql = "Update Khoa set TenKhoa = N'" + txtTenKhoa.Text.Trim() + "', DienThoai = N'" + txtDienThoai.Text.Trim() 
                    + "',DiaChi = N'" + txtDiaChi.Text.Trim() + "', Website = N'" + txtWebsite.Text.Trim() + "' where MaKhoa = '" 
                    + txtMaKhoa.Text.ToString() + "'";
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
            if (tblKhoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Khoa WHERE MaKhoa='" + txtMaKhoa.Text.ToString() + "'";
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
            txtMaKhoa.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void GridViewKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhoa.Text = GridViewKhoa.CurrentRow.Cells["clmMaKhoa"].Value.ToString();
            txtTenKhoa.Text = GridViewKhoa.CurrentRow.Cells["clmTenKhoa"].Value.ToString();
            txtDienThoai.Text = GridViewKhoa.CurrentRow.Cells["clmDienThoai"].Value.ToString();
            txtDiaChi.Text = GridViewKhoa.CurrentRow.Cells["clmDiaChi"].Value.ToString();
            txtWebsite.Text = GridViewKhoa.CurrentRow.Cells["clmWebsite"].Value.ToString();
            txtMaKhoa.Enabled = false;
        }
    }


}



