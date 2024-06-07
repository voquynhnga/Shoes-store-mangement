﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using PBL3_qnv.GUI_CCH;
using PBL3_qnv;
using PBL3.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using PBL3.GUI_NV;
using PBL3.GUI_CCH;

namespace PBL3

{

    public partial class Loginform : Form
    {
        private bool showPassword = false;
        Main_NV mf = new Main_NV();
        Main_2 mf2 = new Main_2();
        public TaiKhoan currentuser = new TaiKhoan
        {
            TaiKhoan1 = "",
            MatKhau = ""
        };


        public Loginform()
        {
            InitializeComponent();
            txtuser.KeyPress += new KeyPressEventHandler(Loginform_KeyPress);
            txtPass.KeyPress += new KeyPressEventHandler(Loginform_KeyPress);

            labelControl1.ForeColor = System.Drawing.Color.Red;
            labelControl1.BackColor = System.Drawing.Color.Transparent;
            labelControl1.Hide();

            Load += Loginform_Load;

        }


        public TaiKhoan GetUser()
        {
            return currentuser;
        }

        private void bLogin_Click_1(object sender, EventArgs e)
        {
            Controller.Instance.SetUser(currentuser, txtuser.Text, txtPass.Text);
            TaiKhoan t = GetUser();

            int check = Controller.Instance.Check_user(t);
            int check_type = Controller.Instance.Check_type(t);
            if (check == 0)
            {
                if (check_type == 1)
                {
                    currentuser.Loai_TK = "Nhân viên";
                    this.Hide();
                    mf.Show();

                }
                else
                {
                    currentuser.Loai_TK = "Chủ cửa hàng";
                    this.Hide();
                    mf2.Show();
                }


            }
            if (check == 1)
            {
                labelControl1.Text = "Vui lòng nhập mật khẩu có độ dài 8 kí tự và chỉ chứa số!";
                labelControl1.ForeColor = System.Drawing.Color.Red;
                labelControl1.Show();
                txtPass.Focus();

            }
            if (check == 2)
            {
                labelControl1.Text = "Mật khẩu không đúng!";
                labelControl1.ForeColor = System.Drawing.Color.Red;
                labelControl1.Show();
                txtPass.Focus();
            }
            if (check == 3)
            {
                labelControl1.Text = "Tên người dùng không tồn tại!";
                labelControl1.ForeColor = System.Drawing.Color.Red;
                labelControl1.Show();
                txtuser.Text = "";
                txtuser.Focus();
                txtPass.Text = "";
            }

        }

        private void Loginform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender is TextBox)
                {
                    TextBox currentTextBox = sender as TextBox;

                    if (currentTextBox != null)
                    {
                        SelectNextControl(currentTextBox, true, true, true, true);
                    }

                    e.Handled = true;
                }
                else
                {
                    bLogin_Click_1(sender, new EventArgs());
                    e.Handled = true;
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            showPassword = !showPassword;

            if (showPassword)
            {
                txtPass.PasswordChar = '\0';

                    pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\eye_flaticon.png");
                
            }
            else
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\eye.png");
                txtPass.PasswordChar = '*';
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
            txtPass.ForeColor = System.Drawing.Color.Black;

        }
        private void Loginform_Load(object sender, EventArgs e)
        {
            labelControl1.ForeColor = System.Drawing.Color.Red;
            labelControl1.BackColor = System.Drawing.Color.Transparent;
        }



        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            //if (txtuser.Text == "Tên người dùng")
            //{
                //txtuser.Text = "";
                txtuser.ForeColor = System.Drawing.Color.Black;
           // }
        }

    }
}
