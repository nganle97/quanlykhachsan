﻿namespace QLY_KS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rbQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbbQualyphong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barbtnsodophong = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnds = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnDatp = new DevExpress.XtraBars.BarButtonItem();
            this.ribnQLkh = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barbtnDanhSachkh = new DevExpress.XtraBars.BarButtonItem();
            this.ribHoadon = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barbtnHoadon = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnBaocao = new DevExpress.XtraBars.BarButtonItem();
            this.ribInfAccount = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barBtnInfAccount = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // rbQuanLy
            // 
            this.rbQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbbQualyphong,
            this.ribnQLkh,
            this.ribHoadon,
            this.ribInfAccount});
            this.rbQuanLy.Name = "rbQuanLy";
            this.rbQuanLy.Text = "Quản Lý";
            // 
            // rbbQualyphong
            // 
            this.rbbQualyphong.AllowTextClipping = false;
            this.rbbQualyphong.ItemLinks.Add(this.barbtnsodophong);
            this.rbbQualyphong.ItemLinks.Add(this.barbtnds);
            this.rbbQualyphong.ItemLinks.Add(this.barbtnDatp);
            this.rbbQualyphong.Name = "rbbQualyphong";
            this.rbbQualyphong.Text = "Quản Lý Phòng";
            // 
            // barbtnsodophong
            // 
            this.barbtnsodophong.Caption = "Sơ Đồ Phòng";
            this.barbtnsodophong.Id = 1;
            this.barbtnsodophong.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.icnSoDo;
            this.barbtnsodophong.LargeWidth = 100;
            this.barbtnsodophong.Name = "barbtnsodophong";
            this.barbtnsodophong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnsodophong_ItemClick);
            // 
            // barbtnds
            // 
            this.barbtnds.Caption = "Danh Sách Phòng";
            this.barbtnds.Id = 5;
            this.barbtnds.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.icnDS;
            this.barbtnds.LargeWidth = 100;
            this.barbtnds.Name = "barbtnds";
            this.barbtnds.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barbtnds.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnds_ItemClick);
            // 
            // barbtnDatp
            // 
            this.barbtnDatp.Caption = "Đặt Phòng";
            this.barbtnDatp.Id = 6;
            this.barbtnDatp.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.icncheck;
            this.barbtnDatp.LargeWidth = 100;
            this.barbtnDatp.Name = "barbtnDatp";
            this.barbtnDatp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDatp_ItemClick);
            // 
            // ribnQLkh
            // 
            this.ribnQLkh.ItemLinks.Add(this.barbtnDanhSachkh);
            this.ribnQLkh.Name = "ribnQLkh";
            this.ribnQLkh.Text = "Quản Lý Khách Hàng";
            // 
            // barbtnDanhSachkh
            // 
            this.barbtnDanhSachkh.Caption = "Danh Sách Khách Hàng";
            this.barbtnDanhSachkh.Id = 7;
            this.barbtnDanhSachkh.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.icnListkh;
            this.barbtnDanhSachkh.LargeWidth = 200;
            this.barbtnDanhSachkh.Name = "barbtnDanhSachkh";
            this.barbtnDanhSachkh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnDanhSachkh_ItemClick);
            // 
            // ribHoadon
            // 
            this.ribHoadon.ItemLinks.Add(this.barbtnHoadon);
            this.ribHoadon.ItemLinks.Add(this.barbtnBaocao);
            this.ribHoadon.Name = "ribHoadon";
            this.ribHoadon.Text = "Hóa Đơn Và Báo Cáo";
            // 
            // barbtnHoadon
            // 
            this.barbtnHoadon.Caption = "Hóa Đơn";
            this.barbtnHoadon.Id = 8;
            this.barbtnHoadon.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.imgBG;
            this.barbtnHoadon.LargeWidth = 100;
            this.barbtnHoadon.Name = "barbtnHoadon";
            this.barbtnHoadon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnHoadon_ItemClick);
            // 
            // barbtnBaocao
            // 
            this.barbtnBaocao.Caption = "Báo Cáo";
            this.barbtnBaocao.Id = 9;
            this.barbtnBaocao.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.icnReport;
            this.barbtnBaocao.Name = "barbtnBaocao";
            this.barbtnBaocao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnBaocao_ItemClick);
            // 
            // ribInfAccount
            // 
            this.ribInfAccount.AllowMinimize = false;
            this.ribInfAccount.Glyph = global::QLY_KS.Properties.Resources.Office_Customer_Male_Light_icon;
            this.ribInfAccount.ItemLinks.Add(this.barBtnInfAccount);
            this.ribInfAccount.Name = "ribInfAccount";
            this.ribInfAccount.Text = "Thông tin tài khoản";
            // 
            // barBtnInfAccount
            // 
            this.barBtnInfAccount.Caption = "Thông tin tài khoản";
            this.barBtnInfAccount.Id = 13;
            this.barBtnInfAccount.ImageOptions.LargeImage = global::QLY_KS.Properties.Resources.Office_Customer_Male_Light_icon;
            this.barBtnInfAccount.LargeWidth = 110;
            this.barBtnInfAccount.Name = "barBtnInfAccount";
            this.barBtnInfAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnInfAccount_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 12;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barbtnsodophong,
            this.barbtnds,
            this.barbtnDatp,
            this.barbtnDanhSachkh,
            this.barbtnHoadon,
            this.barbtnBaocao,
            this.barButtonItem1,
            this.barBtnInfAccount});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbQuanLy});
            this.ribbonControl1.Size = new System.Drawing.Size(798, 143);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // Form1
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 429);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.ShowIcon = false;
            this.Text = "Quản Lý Khách Sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage rbQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbbQualyphong;
        private DevExpress.XtraBars.BarButtonItem barbtnsodophong;
        private DevExpress.XtraBars.BarButtonItem barbtnds;
        private DevExpress.XtraBars.BarButtonItem barbtnDatp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribnQLkh;
        private DevExpress.XtraBars.BarButtonItem barbtnDanhSachkh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribHoadon;
        private DevExpress.XtraBars.BarButtonItem barbtnHoadon;
        private DevExpress.XtraBars.BarButtonItem barbtnBaocao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribInfAccount;
        private DevExpress.XtraBars.BarButtonItem barBtnInfAccount;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}

