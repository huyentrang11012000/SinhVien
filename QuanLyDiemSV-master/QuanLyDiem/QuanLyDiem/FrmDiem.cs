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
    public partial class FrmDiem : Form
    {
        DataTable tblDiem;
        public FrmDiem()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()) > 10))
            {
                MessageBox.Show("Bạn nhập sai điểm.Nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }
            if (Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()) >= 5)
            {
                MessageBox.Show("Sinh viên này không phải thi lại lần " + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = "DELETE Diem WHERE MaSV=N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and LanThi='" + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1) + "'";
                //MessageBox.Show(ql);
                DAO.RunSql(sql);
            }
            if (Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()) < 5)
            {
                MessageBox.Show("Sinh viên này phải thi lại lần " + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = "INSERT INTO Diem VALUES(N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "',N'" + cmbMaLop.Text + "','" + cmbMonHoc.SelectedValue + "',"
                         + cmbHocKy.Text + "," + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1) + ",null)";
                //MessageBox.Show(sql);
                DAO.RunSql(sql);
            }
            sql = "UPDATE Diem SET Diem = ROUND(" + GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString() + ",1) WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
            //MaSV=N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() +"',
            DAO.RunSql(sql);
            DAO.CloseConnection();
            if (btnQuayLai.Enabled == false)
            {
                Load_DataGridView();
            }
            else
            {
                Load_DataGridView1();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Diem WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
                DAO.OpenConnection();
                DAO.RunSql(sql);
                DAO.OpenConnection();
                if (btnQuayLai.Enabled == false)
                {
                    Load_DataGridView();
                }
                else
                {
                    Load_DataGridView1();
                }
                txtMaSV.Text = "";
                txtDiem.Text = "";
                //txtDiem.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql;
            if (cmbMaLop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbHocKy.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLanThi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lần thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLanThi.Focus();
                return;
            }
            if (GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*if (Convert.ToInt32(txtLanThi.Text.Trim()) > 1)
            {
                sql = "UPDATE Diem SET Diem = " + GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim() + " WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
                //MessageBox.Show(sql);
                DAO.RunSql(sql);
            }*/

            /*string s1 = DAO.GetFieldValues("Select MaSV from Diem where MaSV = '"+ GridViewDiem.Rows[(tblDiem.Rows.Count-1)].Cells["clmMaSV"].Value + "'");
            string s2 = DAO.GetFieldValues("Select MaSV from Diem where MaSV = '" + GridViewDiem.Rows[tblDiem.Rows.Count].Cells["clmMaSV"].Value + "'");
            string s3 = DAO.GetFieldValues("Select Diem from Diem where MaSV = '" + GridViewDiem.Rows[tblDiem.Rows.Count].Cells["clmMaSV"].Value + "'");
            string s4 = "SELECT MaSV, MaLop, MaMon,HocKy,LanThi FROM Diem WHERE MaSV=N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
            ////MessageBox.Show(1);
            //MessageBox.Show(s2);
            if (Convert.ToInt32(txtLanThi.Text.Trim()) == 1&&s1 !=""&&s2==""&&s3==""&& DAO.CheckKeyExist(s4) == true)
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            /*if(GridViewDiem.Rows[tblDiem.Rows.Count].ToString() == "")
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên.....", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            if (Convert.ToInt32(txtLanThi.Text.Trim()) == 1)
            {
                sql = "SELECT MaSV, MaLop, MaMon,HocKy,LanThi FROM Diem WHERE MaSV=N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
                //MessageBox.Show(sql);
                if (DAO.CheckKeyExist(sql) == true)
                {
                    MessageBox.Show("Bạn đã nhập điểm cho sinh viên học lớp và môn này , bạn hãy nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }
            }

            sql = "SELECT MaSV FROM SinhVien WHERE MaSV=N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "'";
            if (DAO.CheckKeyExist(sql) == false)
            {
                MessageBox.Show("Mã sinh viên không tồn tại , bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /*if (GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString().Trim()=="")
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            if (GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()) > 10))
            {
                MessageBox.Show("Bạn nhập sai điểm.Nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiem.Focus();
                return;
            }
            if (Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()) < 5)
            {
                MessageBox.Show("Sinh viên này phải thi lại lần " + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sql = "INSERT INTO Diem VALUES(N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "',N'" + cmbMaLop.Text + "','" + cmbMonHoc.SelectedValue + "',"
                         + cmbHocKy.Text + "," + (Convert.ToInt32(txtLanThi.Text.Trim()) + 1) + ",null)";
                //MessageBox.Show(sql);
                DAO.RunSql(sql);
            }
            string str = DAO.GetFieldValues("Select Diem from Diem where MaSV = '" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "'and MaLop='" + cmbMaLop.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + (Convert.ToInt32(txtLanThi.Text.Trim()) - 1) + "'");
            //MessageBox.Show(str);
            if (Convert.ToInt32(txtLanThi.Text.Trim()) > 1 && Convert.ToInt32(str) < 5)
            {
                sql = "UPDATE Diem SET Diem = ROUND(" + GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString() + ",1) WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'AND MaLop=N'" + cmbMaLop.SelectedValue + "'AND MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
                //MessageBox.Show(sql);
                DAO.RunSql(sql);
                MessageBox.Show("Bạn đã thêm mới thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DataGridView1();
                txtMaSV.Text = "";
                txtDiem.Text = "";
            }
            else
            //sql = "INSERT INTO Diem VALUES(N'" + GridViewDiem.Rows[i].Cells["clmMaSV"].Value.ToString() + "',N'" + cmbMaLop.Text + "','" + cmbMonHoc.SelectedValue + "',"
            //+ cmbHocKy.Text + "," + txtLanThi.Text.Trim() + "," + GridViewDiem.Rows[i].Cells["clmDiem"].Value.ToString() + ")";

            {
                sql = "INSERT INTO Diem VALUES(N'" + GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString() + "',N'" + cmbMaLop.Text + "','" + cmbMonHoc.SelectedValue + "',"
                           + cmbHocKy.Text + "," + txtLanThi.Text.Trim() + ",ROUND(" + GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString() + ",1))";
                //MessageBox.Show(sql);
                DAO.RunSql(sql);

                MessageBox.Show("Bạn đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridViewDiem.CurrentRow.Cells["clmDiem"].Value = Math.Round(Convert.ToDouble(GridViewDiem.CurrentRow.Cells["clmDiem"].Value), 1);
                Load_DataGridView1();
                txtMaSV.Text = "";
                txtDiem.Text = "";
            }
            
            //txtDiem.Enabled = false;
            DAO.CloseConnection();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            if (btnQuayLai.Enabled == true)
            {
                txtMaSV.Text = "";
                txtDiem.Text = "";
                // GridViewDiem.Rows[tblDiem.Rows.Count].Selected = "";
            }
            else
            {
                ResetValues();
            }

            btnHuy.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDiem_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql = "select MaLop from Lop";
            DAO.FillDataToCombo(sql, cmbMaLop, "MaLop", "MaLop");
            sql = "select MaMon, TenMon from MonHoc";
            DAO.FillDataToCombo(sql, cmbMonHoc, "MaMon", "TenMon");
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            //btnXoa.Enabled = false;
            //btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            txtMaSV.Enabled = false;
            txtTenSV.Enabled = false;
            txtDiem.Enabled = false;
            Load_DataGridView();
            ResetValues();
            cmbMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //GridViewDiem.Enabled = false;
            //GridViewDiem.Cells[0].Selected = false;

        }
        private void Load_DataGridView()
        {
            try
            {
                DAO.OpenConnection();
                string str;
                str = "select * from Diem";
                tblDiem = DAO.GetDataToTable(str);
                GridViewDiem.DataSource = tblDiem;
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
            txtMaSV.Text = "";
            txtDiem.Text = "";
            txtLanThi.Text = "";
            txtTenSV.Text = ""; //---------
            cmbMaLop.SelectedIndex = -1;
            cmbMonHoc.SelectedIndex = -1;
            cmbHocKy.SelectedIndex = -1;
            // //GridViewDiem.Enabled = true;
        }

        private void cmbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            str = "select Thoi_Khoa_Bieu.MaMon,TenMon from Thoi_Khoa_Bieu inner join MonHoc on Thoi_Khoa_Bieu.MaMon = MonHoc.MaMon where MaLop = '" + cmbMaLop.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' group by Thoi_Khoa_Bieu.MaMon,TenMon";
            //MessageBox.Show(str);
            DAO.FillDataToCombo(str, cmbMonHoc, "MaMon", "TenMon");

        }

        private void cmbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            /*str = "select Thoi_Khoa_Bieu.MaMon,TenMon from Thoi_Khoa_Bieu inner join MonHoc on Thoi_Khoa_Bieu.MaMon = MonHoc.MaMon where MaLop = '" + cmbMaLop.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' group by Thoi_Khoa_Bieu.MaMon,TenMon";
            //MessageBox.Show(str);
            DAO.FillDataToCombo(str, cmbMonHoc, "MaMon", "TenMon"); */
            str = "select HocKy from Thoi_Khoa_Bieu where MaLop = '" + cmbMaLop.SelectedValue + "'";
            DAO.FillDataToCombo(str, cmbHocKy, "HocKy", "HocKy");
            cmbHocKy.SelectedIndex = -1;
        }
        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            /*if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Lớp này chưa được nhập điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/

            //GridViewDiem.Enabled = true;
            if (cmbMaLop.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbHocKy.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn học kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtLanThi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lần thi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLanThi.Focus();
                return;
            }
            string str;
            str = " select MaSV,Diem from Diem where MaLop='" + cmbMaLop.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
            //MessageBox.Show(str);
            tblDiem = DAO.GetDataToTable(str);
            GridViewDiem.DataSource = tblDiem;
            btnLuu.Enabled = true;
            //btnHuy.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnQuayLai.Enabled = true;
            txtMaSV.Text = "";
            txtDiem.Text = "";
            //txtDiem.Enabled = false;
        }
        public void cell1()
        {
            txtMaSV.Text = GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString();
            txtDiem.Text = GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString();
            btnHuy.Enabled = true;
            // string s2 = DAO.GetFieldValues("Select MaSV from Diem where MaSV = '" + GridViewDiem.Rows[tblDiem.Rows.Count].Cells["clmMaSV"].Value + "'");
            if (Convert.ToInt32(txtLanThi.Text.Trim()) > 1)
            {
                GridViewDiem.CurrentRow.Cells["clmMaSV"].ReadOnly = true;
                GridViewDiem.Rows[tblDiem.Rows.Count].ReadOnly = true;
            }
        }
        public void cell2()
        {
            GridViewDiem.CurrentRow.Cells["MaLop"].ReadOnly = true;
            GridViewDiem.CurrentRow.Cells["HocKy"].ReadOnly = true;
            GridViewDiem.CurrentRow.Cells["MaMon"].ReadOnly = true;
            GridViewDiem.CurrentRow.Cells["LanThi"].ReadOnly = true;
            txtLanThi.Text = GridViewDiem.CurrentRow.Cells["LanThi"].Value.ToString();
            txtMaSV.Text = GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString();
            txtDiem.Text = GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString();
            string ma = GridViewDiem.CurrentRow.Cells["MaLop"].Value.ToString();
            cmbMaLop.Text = ma;
            ma = GridViewDiem.CurrentRow.Cells["MaMon"].Value.ToString();
            cmbMonHoc.Text = DAO.GetFieldValues("select TenMon from MonHoc where MaMon = N'" + ma + "'");
            ma = GridViewDiem.CurrentRow.Cells["HocKy"].Value.ToString();
            cmbHocKy.Text = ma;
            GridViewDiem.Rows[tblDiem.Rows.Count].ReadOnly = true;
            btnHuy.Enabled = true;
            //txtLanThi.Enabled = true;
        }
        private void GridViewDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnQuayLai.Enabled == false)
            {
                cell2();
            }
            else
            {
                cell1();
            }
            if (txtMaSV.Text.Trim() != "")
            {
                //txtDiem.Enabled = true;
            }
            else
            {
                //txtDiem.Enabled = false;
            }
            /* if( GridViewDiem.CurrentRow.Cells["clmMaSV"].Value.ToString().Trim()==""&&GridViewDiem.CurrentRow.Cells["clmDiem"].Value.ToString().Trim()=="")
             {
                // GridViewDiem.CurrentCell = null;
                 btnLuu.Enabled = true;
             }
             else
             {
                 btnLuu.Enabled = false;
             }*/
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (txtMaSV.Text == "")
            {
                txtTenSV.Text = "";
            }
            str = "Select TenSV from SinhVien where MaSV = '" + txtMaSV.Text.Trim() + "'";
            txtTenSV.Text = DAO.GetFieldValues(str);
        }
        private void Load_DataGridView1()
        {
            try
            {
                DAO.OpenConnection();
                string str;
                str = " select MaSV,Diem from Diem where MaLop='" + cmbMaLop.SelectedValue + "' and HocKy = '" + cmbHocKy.Text + "' and MaMon='" + cmbMonHoc.SelectedValue + "' and LanThi='" + txtLanThi.Text.Trim() + "'";
                // str = "select SinhVien.MaSV,Diem from Diem right outer join SinhVien on Diem.MaLop=SinhVien.MaLop inner join Thoi_Khoa_Bieu on SinhVien.MaLop=Thoi_Khoa_Bieu.MaLop where Thoi_Khoa_Bieu.MaLop = '" + cmbMaLop.SelectedValue + "' and Thoi_Khoa_Bieu.HocKy = '" + cmbHocKy.Text + "' and Thoi_Khoa_Bieu.MaMon='" + cmbMonHoc.SelectedValue + "'";
                // str = "select * from MaSV";
                tblDiem = DAO.GetDataToTable(str);
                GridViewDiem.DataSource = tblDiem;
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            Load_DataGridView();
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            // btnXoa.Enabled = false;
            // btnSua.Enabled = false;
            btnQuayLai.Enabled = false;
            //txtDiem.Enabled = false;
            //GridViewDiem.Enabled = false;
        }
    }
}
