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
    public partial class FrmTimKiem : Form
    {
        DataTable tblSV;
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            cmbKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbQue.DropDownStyle = ComboBoxStyle.DropDownList;
            DAO.OpenConnection();
            LoadDataToGridView();
            DAO.FillDataToCombo("SELECT MaKhoa,TenKhoa FROM Khoa", cmbKhoa, "MaKhoa", "TenKhoa");
            DAO.FillDataToCombo("SELECT MaChuyenNganh,TenChuyenNganh  FROM ChuyenNganh", cmbChuyenNganh, "MaChuyenNganh", "MaChuyenNganh");
            DAO.FillDataToCombo("SELECT MaQue,TenQue FROM Que", cmbQue, "MaQue", "TenQue");
            ResetValues();
            DAO.CloseConnection(); 
        }
        private void LoadDataToGridView()
        {
            try
            {
                DAO.OpenConnection();
                string sql;
                sql = "SELECT * FROM SinhVien";
                tblSV = DAO.GetDataToTable(sql);
                GridViewTimKiem.DataSource = tblSV;
                GridViewTimKiem.AllowUserToAddRows = false;
                GridViewTimKiem.EditMode = DataGridViewEditMode.EditProgrammatically;
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
            cmbKhoa.SelectedIndex = -1;
            cmbChuyenNganh.SelectedIndex = -1;
            cmbQue.SelectedIndex = -1;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cmbKhoa.Text == "") && (cmbChuyenNganh.Text == "") && (cmbQue.Text == ""))
            {
                MessageBox.Show("Hãy chọn một điều kiện tìm kiếm!!!", "Yêu cầu nhập Khoa,Chuyên Ngành,Quê", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select  a.MaSV,a.TenSV,a.MaKhoa,a.MaLop,a.NgaySinh,a.GioiTinh,a.MaQue,a.MaDanToc,a.MaChuyenNganh,a.MaHDT,a.MaChucVu" +
                " from SinhVien a join ChuyenNganh b on a.MaChuyenNganh=b.MaChuyenNganh join Que c on a.MaQue=c.MaQue where 1=1";
            if (cmbKhoa.Text != "")
            {
                sql = sql + " AND a.MaKhoa Like '%" + cmbKhoa.SelectedValue + "%'";
            }
            if (cmbChuyenNganh.Text != "")
            {
                sql = sql + " AND b.MaChuyenNganh Like '%" + cmbChuyenNganh.SelectedValue + "%'";
            }
            if (cmbQue.Text != "")
            {
                sql = sql + " AND c.MaQue Like '%" + cmbQue.SelectedValue + "%'";
            }

            tblSV = DAO.GetDataToTable(sql);
            if (tblSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblSV.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridViewTimKiem.DataSource = tblSV;
            //LoadDataToGridView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Hỏi Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from ChuyenNganh where MaKhoa=N'" + cmbKhoa.SelectedValue + "'";
            DAO.FillDataToCombo(sql, cmbChuyenNganh, "MaChuyenNganh", "TenChuyenNganh");
        }


    }
}
