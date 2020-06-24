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

    public partial class FrmQue : Form
    {
        DataTable tblQue;

        public FrmQue()
        {
            InitializeComponent();

        }

        private void FrmQue_Load(object sender, EventArgs e)
        {
            LoadDataToGrivew();

        }
        public void LoadDataToGrivew()
        {

            try
            {
                DAO.OpenConnection();
                string sql = "select * from Que";
                tblQue = DAO.GetDataToTable(sql);
                GridViewQue.DataSource = tblQue;
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

        private void GridViewQue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaQue.Text = GridViewQue.CurrentRow.Cells["clmMaQue"].Value.ToString();
            txtTenQue.Text = GridViewQue.CurrentRow.Cells["clmTenQue"].Value.ToString();
            txtMaQue.Enabled = false;

        }
        private void ResetValues()
        {
            txtMaQue.Enabled = true;
            txtMaQue.Text = "";
            txtTenQue.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;


        }



        private void btnSua_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblQue.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaQue.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenQue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenQue.Focus();
                return;
            }

            else
            {
                sql = "Update Que set TenQue = N'" + txtTenQue.Text.ToString() + "' + where MaQue = '" + txtMaQue.Text.ToString() + "'";
                MessageBox.Show("oke");

                DAO.OpenConnection();
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.CommandText = sql;
                cmd.Connection = DAO.con;
                cmd.ExecuteNonQuery();//thực thi câu lệnh
                DAO.CloseConnection();
                LoadDataToGrivew();
                btnHuy.Enabled = false;
                btnLuu.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnThoat.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaQue.Text == "")
            {
                MessageBox.Show("bạn chưa nhập mã quê ");
                txtMaQue.Focus();
                return;
            }
            if (txtTenQue.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên quê");
                txtTenQue.Focus();
                return;
            }
            string sqlCheckKey = "Select * from Que Where MaQue = '"
                                + txtMaQue.Text.Trim() + "'";
            DAO.OpenConnection();


            if (DAO.CheckKeyExist(sqlCheckKey))
            {
                MessageBox.Show("Mã quê đã tồn tại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DAO.CloseConnection();
                txtMaQue.Focus();
                return;
            }
            else
            {
                string sql = "insert into Que values ('" + txtMaQue.Text.Trim() + "' , N'" + txtTenQue.Text.Trim() + "')";
                SqlCommand cmd = new SqlCommand(sql, DAO.con);
                cmd.ExecuteNonQuery();
                DAO.CloseConnection();
                LoadDataToGrivew();
                DAO.CloseConnection();
                btnLuu.Enabled = false;
                txtMaQue.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblQue.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaQue.Text == "")
            {
                MessageBox.Show("Chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Que WHERE MaQue= N'" + txtMaQue.Text.Trim() + "'";

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
            txtMaQue.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn có chắc chắn muốn thoát chương trình không", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }

}



