using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P520233_KeirynSandi.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void BtnVerContrsenia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrania.UseSystemPasswordChar = false;
        }

        private void BtnVerContrsenia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrania.UseSystemPasswordChar=true;
        }
    }
}
