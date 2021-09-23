using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludVida
{
    public partial class PrincipalPage : Form
    {
        public PrincipalPage()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register create = new Register();
            create.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            Search search = new Search();
            search.Show();
        }

        private void btnImc_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImcCalculate imc = new ImcCalculate();
            imc.Show();
        }
    }
}
