namespace QuanLyDiem
{
    partial class FrmThoiKhoaBieu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThoiKhoaBieu));
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.GridViewTKB = new System.Windows.Forms.DataGridView();
            this.MaLop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrbHK = new System.Windows.Forms.GroupBox();
            this.rdohk8 = new System.Windows.Forms.RadioButton();
            this.rdohk4 = new System.Windows.Forms.RadioButton();
            this.rdohk6 = new System.Windows.Forms.RadioButton();
            this.rdohk7 = new System.Windows.Forms.RadioButton();
            this.rdohk2 = new System.Windows.Forms.RadioButton();
            this.rdohk3 = new System.Windows.Forms.RadioButton();
            this.rdohk5 = new System.Windows.Forms.RadioButton();
            this.rdohk1 = new System.Windows.Forms.RadioButton();
            this.GrbThu = new System.Windows.Forms.GroupBox();
            this.rdothu7 = new System.Windows.Forms.RadioButton();
            this.rdothu6 = new System.Windows.Forms.RadioButton();
            this.rdothu5 = new System.Windows.Forms.RadioButton();
            this.rdothu4 = new System.Windows.Forms.RadioButton();
            this.rdothu3 = new System.Windows.Forms.RadioButton();
            this.rdothu2 = new System.Windows.Forms.RadioButton();
            this.rdoca5 = new System.Windows.Forms.RadioButton();
            this.rdoca4 = new System.Windows.Forms.RadioButton();
            this.rdoca3 = new System.Windows.Forms.RadioButton();
            this.rdoca2 = new System.Windows.Forms.RadioButton();
            this.rdoca1 = new System.Windows.Forms.RadioButton();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.cmbPhong = new System.Windows.Forms.ComboBox();
            this.GrbCa = new System.Windows.Forms.GroupBox();
            this.txtid = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTKB)).BeginInit();
            this.GrbHK.SuspendLayout();
            this.GrbThu.SuspendLayout();
            this.GrbCa.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(42, 580);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 63);
            this.btnThem.TabIndex = 62;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(212, 580);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(94, 63);
            this.btnSua.TabIndex = 63;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(387, 580);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(94, 63);
            this.btnXoa.TabIndex = 64;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(548, 580);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(93, 63);
            this.btnLuu.TabIndex = 65;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(716, 580);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(93, 63);
            this.btnHuy.TabIndex = 66;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(868, 580);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 63);
            this.btnThoat.TabIndex = 67;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(18, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 68;
            this.label1.Text = "Mã Lớp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(342, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 30);
            this.label2.TabIndex = 68;
            this.label2.Text = "Mã Môn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightYellow;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(394, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 40);
            this.label3.TabIndex = 68;
            this.label3.Text = "Thời khóa biểu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(693, 82);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 30);
            this.label7.TabIndex = 68;
            this.label7.Text = "Mã Phòng";
            // 
            // GridViewTKB
            // 
            this.GridViewTKB.BackgroundColor = System.Drawing.Color.White;
            this.GridViewTKB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewTKB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLop,
            this.MaMon,
            this.HocKy,
            this.ThuHoc,
            this.CaHoc,
            this.MaPhong,
            this.id});
            this.GridViewTKB.Location = new System.Drawing.Point(42, 335);
            this.GridViewTKB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GridViewTKB.Name = "GridViewTKB";
            this.GridViewTKB.RowHeadersWidth = 62;
            this.GridViewTKB.Size = new System.Drawing.Size(963, 237);
            this.GridViewTKB.TabIndex = 69;
            this.GridViewTKB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewTKB_CellClick);
            // 
            // MaLop
            // 
            this.MaLop.DataPropertyName = "MaLop";
            this.MaLop.HeaderText = "Mã lớp";
            this.MaLop.MinimumWidth = 8;
            this.MaLop.Name = "MaLop";
            this.MaLop.Width = 150;
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã môn";
            this.MaMon.MinimumWidth = 8;
            this.MaMon.Name = "MaMon";
            this.MaMon.Width = 150;
            // 
            // HocKy
            // 
            this.HocKy.DataPropertyName = "HocKy";
            this.HocKy.HeaderText = "Học kỳ";
            this.HocKy.MinimumWidth = 8;
            this.HocKy.Name = "HocKy";
            this.HocKy.Width = 150;
            // 
            // ThuHoc
            // 
            this.ThuHoc.DataPropertyName = "ThuHoc";
            this.ThuHoc.HeaderText = "Thứ học";
            this.ThuHoc.MinimumWidth = 8;
            this.ThuHoc.Name = "ThuHoc";
            this.ThuHoc.Width = 150;
            // 
            // CaHoc
            // 
            this.CaHoc.DataPropertyName = "CaHoc";
            this.CaHoc.HeaderText = "Ca học";
            this.CaHoc.MinimumWidth = 8;
            this.CaHoc.Name = "CaHoc";
            this.CaHoc.Width = 150;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã phòng";
            this.MaPhong.MinimumWidth = 8;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.Width = 150;
            // 
            // GrbHK
            // 
            this.GrbHK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.GrbHK.Controls.Add(this.rdohk8);
            this.GrbHK.Controls.Add(this.rdohk4);
            this.GrbHK.Controls.Add(this.rdohk6);
            this.GrbHK.Controls.Add(this.rdohk7);
            this.GrbHK.Controls.Add(this.rdohk2);
            this.GrbHK.Controls.Add(this.rdohk3);
            this.GrbHK.Controls.Add(this.rdohk5);
            this.GrbHK.Controls.Add(this.rdohk1);
            this.GrbHK.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbHK.Location = new System.Drawing.Point(24, 180);
            this.GrbHK.Name = "GrbHK";
            this.GrbHK.Size = new System.Drawing.Size(356, 120);
            this.GrbHK.TabIndex = 70;
            this.GrbHK.TabStop = false;
            this.GrbHK.Text = "Học Kỳ";
            // 
            // rdohk8
            // 
            this.rdohk8.AutoSize = true;
            this.rdohk8.Location = new System.Drawing.Point(300, 55);
            this.rdohk8.Name = "rdohk8";
            this.rdohk8.Size = new System.Drawing.Size(50, 34);
            this.rdohk8.TabIndex = 16;
            this.rdohk8.TabStop = true;
            this.rdohk8.Text = "8";
            this.rdohk8.UseVisualStyleBackColor = true;
            // 
            // rdohk4
            // 
            this.rdohk4.AutoSize = true;
            this.rdohk4.Location = new System.Drawing.Point(300, 26);
            this.rdohk4.Name = "rdohk4";
            this.rdohk4.Size = new System.Drawing.Size(50, 34);
            this.rdohk4.TabIndex = 17;
            this.rdohk4.TabStop = true;
            this.rdohk4.Text = "4";
            this.rdohk4.UseVisualStyleBackColor = true;
            // 
            // rdohk6
            // 
            this.rdohk6.AutoSize = true;
            this.rdohk6.Location = new System.Drawing.Point(166, 55);
            this.rdohk6.Name = "rdohk6";
            this.rdohk6.Size = new System.Drawing.Size(50, 34);
            this.rdohk6.TabIndex = 18;
            this.rdohk6.TabStop = true;
            this.rdohk6.Text = "6";
            this.rdohk6.UseVisualStyleBackColor = true;
            // 
            // rdohk7
            // 
            this.rdohk7.AutoSize = true;
            this.rdohk7.Location = new System.Drawing.Point(234, 55);
            this.rdohk7.Name = "rdohk7";
            this.rdohk7.Size = new System.Drawing.Size(50, 34);
            this.rdohk7.TabIndex = 19;
            this.rdohk7.TabStop = true;
            this.rdohk7.Text = "7";
            this.rdohk7.UseVisualStyleBackColor = true;
            // 
            // rdohk2
            // 
            this.rdohk2.AutoSize = true;
            this.rdohk2.Location = new System.Drawing.Point(166, 26);
            this.rdohk2.Name = "rdohk2";
            this.rdohk2.Size = new System.Drawing.Size(50, 34);
            this.rdohk2.TabIndex = 20;
            this.rdohk2.TabStop = true;
            this.rdohk2.Text = "2";
            this.rdohk2.UseVisualStyleBackColor = true;
            // 
            // rdohk3
            // 
            this.rdohk3.AutoSize = true;
            this.rdohk3.Location = new System.Drawing.Point(234, 26);
            this.rdohk3.Name = "rdohk3";
            this.rdohk3.Size = new System.Drawing.Size(50, 34);
            this.rdohk3.TabIndex = 21;
            this.rdohk3.TabStop = true;
            this.rdohk3.Text = "3";
            this.rdohk3.UseVisualStyleBackColor = true;
            // 
            // rdohk5
            // 
            this.rdohk5.AutoSize = true;
            this.rdohk5.Location = new System.Drawing.Point(99, 55);
            this.rdohk5.Name = "rdohk5";
            this.rdohk5.Size = new System.Drawing.Size(50, 34);
            this.rdohk5.TabIndex = 22;
            this.rdohk5.TabStop = true;
            this.rdohk5.Text = "5";
            this.rdohk5.UseVisualStyleBackColor = true;
            // 
            // rdohk1
            // 
            this.rdohk1.AutoSize = true;
            this.rdohk1.Location = new System.Drawing.Point(99, 26);
            this.rdohk1.Name = "rdohk1";
            this.rdohk1.Size = new System.Drawing.Size(50, 34);
            this.rdohk1.TabIndex = 23;
            this.rdohk1.TabStop = true;
            this.rdohk1.Text = "1";
            this.rdohk1.UseVisualStyleBackColor = true;
            // 
            // GrbThu
            // 
            this.GrbThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GrbThu.Controls.Add(this.rdothu7);
            this.GrbThu.Controls.Add(this.rdothu6);
            this.GrbThu.Controls.Add(this.rdothu5);
            this.GrbThu.Controls.Add(this.rdothu4);
            this.GrbThu.Controls.Add(this.rdothu3);
            this.GrbThu.Controls.Add(this.rdothu2);
            this.GrbThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbThu.Location = new System.Drawing.Point(402, 180);
            this.GrbThu.Name = "GrbThu";
            this.GrbThu.Size = new System.Drawing.Size(309, 120);
            this.GrbThu.TabIndex = 71;
            this.GrbThu.TabStop = false;
            this.GrbThu.Text = "Thứ Học";
            // 
            // rdothu7
            // 
            this.rdothu7.AutoSize = true;
            this.rdothu7.Location = new System.Drawing.Point(190, 55);
            this.rdothu7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu7.Name = "rdothu7";
            this.rdothu7.Size = new System.Drawing.Size(73, 34);
            this.rdothu7.TabIndex = 5;
            this.rdothu7.TabStop = true;
            this.rdothu7.Text = "Bảy";
            this.rdothu7.UseVisualStyleBackColor = true;
            // 
            // rdothu6
            // 
            this.rdothu6.AutoSize = true;
            this.rdothu6.Location = new System.Drawing.Point(116, 55);
            this.rdothu6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu6.Name = "rdothu6";
            this.rdothu6.Size = new System.Drawing.Size(73, 34);
            this.rdothu6.TabIndex = 4;
            this.rdothu6.TabStop = true;
            this.rdothu6.Text = "Sáu";
            this.rdothu6.UseVisualStyleBackColor = true;
            // 
            // rdothu5
            // 
            this.rdothu5.AutoSize = true;
            this.rdothu5.Location = new System.Drawing.Point(32, 55);
            this.rdothu5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu5.Name = "rdothu5";
            this.rdothu5.Size = new System.Drawing.Size(84, 34);
            this.rdothu5.TabIndex = 3;
            this.rdothu5.TabStop = true;
            this.rdothu5.Text = "Năm";
            this.rdothu5.UseVisualStyleBackColor = true;
            // 
            // rdothu4
            // 
            this.rdothu4.AutoSize = true;
            this.rdothu4.Location = new System.Drawing.Point(190, 26);
            this.rdothu4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu4.Name = "rdothu4";
            this.rdothu4.Size = new System.Drawing.Size(63, 34);
            this.rdothu4.TabIndex = 2;
            this.rdothu4.TabStop = true;
            this.rdothu4.Text = "Tư";
            this.rdothu4.UseVisualStyleBackColor = true;
            // 
            // rdothu3
            // 
            this.rdothu3.AutoSize = true;
            this.rdothu3.Location = new System.Drawing.Point(116, 26);
            this.rdothu3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu3.Name = "rdothu3";
            this.rdothu3.Size = new System.Drawing.Size(62, 34);
            this.rdothu3.TabIndex = 1;
            this.rdothu3.TabStop = true;
            this.rdothu3.Text = "Ba";
            this.rdothu3.UseVisualStyleBackColor = true;
            // 
            // rdothu2
            // 
            this.rdothu2.AutoSize = true;
            this.rdothu2.Location = new System.Drawing.Point(32, 26);
            this.rdothu2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdothu2.Name = "rdothu2";
            this.rdothu2.Size = new System.Drawing.Size(70, 34);
            this.rdothu2.TabIndex = 0;
            this.rdothu2.TabStop = true;
            this.rdothu2.Text = "Hai";
            this.rdothu2.UseVisualStyleBackColor = true;
            // 
            // rdoca5
            // 
            this.rdoca5.AutoSize = true;
            this.rdoca5.Location = new System.Drawing.Point(147, 69);
            this.rdoca5.Name = "rdoca5";
            this.rdoca5.Size = new System.Drawing.Size(50, 34);
            this.rdoca5.TabIndex = 18;
            this.rdoca5.TabStop = true;
            this.rdoca5.Text = "5";
            this.rdoca5.UseVisualStyleBackColor = true;
            // 
            // rdoca4
            // 
            this.rdoca4.AutoSize = true;
            this.rdoca4.Location = new System.Drawing.Point(86, 69);
            this.rdoca4.Name = "rdoca4";
            this.rdoca4.Size = new System.Drawing.Size(50, 34);
            this.rdoca4.TabIndex = 22;
            this.rdoca4.TabStop = true;
            this.rdoca4.Text = "4";
            this.rdoca4.UseVisualStyleBackColor = true;
            // 
            // rdoca3
            // 
            this.rdoca3.AutoSize = true;
            this.rdoca3.Location = new System.Drawing.Point(208, 26);
            this.rdoca3.Name = "rdoca3";
            this.rdoca3.Size = new System.Drawing.Size(50, 34);
            this.rdoca3.TabIndex = 21;
            this.rdoca3.TabStop = true;
            this.rdoca3.Text = "3";
            this.rdoca3.UseVisualStyleBackColor = true;
            // 
            // rdoca2
            // 
            this.rdoca2.AutoSize = true;
            this.rdoca2.Location = new System.Drawing.Point(147, 26);
            this.rdoca2.Name = "rdoca2";
            this.rdoca2.Size = new System.Drawing.Size(50, 34);
            this.rdoca2.TabIndex = 20;
            this.rdoca2.TabStop = true;
            this.rdoca2.Text = "2";
            this.rdoca2.UseVisualStyleBackColor = true;
            // 
            // rdoca1
            // 
            this.rdoca1.AutoSize = true;
            this.rdoca1.Location = new System.Drawing.Point(88, 26);
            this.rdoca1.Name = "rdoca1";
            this.rdoca1.Size = new System.Drawing.Size(50, 34);
            this.rdoca1.TabIndex = 23;
            this.rdoca1.TabStop = true;
            this.rdoca1.Text = "1";
            this.rdoca1.UseVisualStyleBackColor = true;
            // 
            // cmbLop
            // 
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(111, 80);
            this.cmbLop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(180, 28);
            this.cmbLop.TabIndex = 72;
            // 
            // cmbMon
            // 
            this.cmbMon.FormattingEnabled = true;
            this.cmbMon.Location = new System.Drawing.Point(459, 80);
            this.cmbMon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(180, 28);
            this.cmbMon.TabIndex = 72;
            // 
            // cmbPhong
            // 
            this.cmbPhong.FormattingEnabled = true;
            this.cmbPhong.Location = new System.Drawing.Point(824, 80);
            this.cmbPhong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbPhong.Name = "cmbPhong";
            this.cmbPhong.Size = new System.Drawing.Size(180, 28);
            this.cmbPhong.TabIndex = 72;
            // 
            // GrbCa
            // 
            this.GrbCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GrbCa.Controls.Add(this.rdoca5);
            this.GrbCa.Controls.Add(this.rdoca1);
            this.GrbCa.Controls.Add(this.rdoca2);
            this.GrbCa.Controls.Add(this.rdoca4);
            this.GrbCa.Controls.Add(this.rdoca3);
            this.GrbCa.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrbCa.Location = new System.Drawing.Point(738, 180);
            this.GrbCa.Name = "GrbCa";
            this.GrbCa.Size = new System.Drawing.Size(267, 120);
            this.GrbCa.TabIndex = 73;
            this.GrbCa.TabStop = false;
            this.GrbCa.Text = "Ca Học";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(20, 20);
            this.txtid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(25, 26);
            this.txtid.TabIndex = 74;
            // 
            // FrmThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1068, 654);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.GrbCa);
            this.Controls.Add(this.cmbMon);
            this.Controls.Add(this.cmbPhong);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.GrbThu);
            this.Controls.Add(this.GrbHK);
            this.Controls.Add(this.GridViewTKB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmThoiKhoaBieu";
            this.Text = "FrmThoiKhoaBieu";
            this.Load += new System.EventHandler(this.FrmThoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewTKB)).EndInit();
            this.GrbHK.ResumeLayout(false);
            this.GrbHK.PerformLayout();
            this.GrbThu.ResumeLayout(false);
            this.GrbThu.PerformLayout();
            this.GrbCa.ResumeLayout(false);
            this.GrbCa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView GridViewTKB;
        private System.Windows.Forms.GroupBox GrbHK;
        private System.Windows.Forms.RadioButton rdohk8;
        private System.Windows.Forms.RadioButton rdohk4;
        private System.Windows.Forms.RadioButton rdohk6;
        private System.Windows.Forms.RadioButton rdohk7;
        private System.Windows.Forms.RadioButton rdohk2;
        private System.Windows.Forms.RadioButton rdohk3;
        private System.Windows.Forms.RadioButton rdohk5;
        private System.Windows.Forms.RadioButton rdohk1;
        private System.Windows.Forms.GroupBox GrbThu;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.ComboBox cmbMon;
        private System.Windows.Forms.ComboBox cmbPhong;
        private System.Windows.Forms.GroupBox GrbCa;
        private System.Windows.Forms.RadioButton rdoca5;
        private System.Windows.Forms.RadioButton rdoca2;
        private System.Windows.Forms.RadioButton rdoca3;
        private System.Windows.Forms.RadioButton rdoca4;
        private System.Windows.Forms.RadioButton rdoca1;
        private System.Windows.Forms.RadioButton rdothu7;
        private System.Windows.Forms.RadioButton rdothu6;
        private System.Windows.Forms.RadioButton rdothu5;
        private System.Windows.Forms.RadioButton rdothu4;
        private System.Windows.Forms.RadioButton rdothu3;
        private System.Windows.Forms.RadioButton rdothu2;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLop;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
    }
}