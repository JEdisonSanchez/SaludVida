using SaludVida.models;
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
    public partial class Search : Form
    {
        private SaludVidaEntities db = new SaludVidaEntities();
        public Search()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalPage principalPage = new PrincipalPage();
            principalPage.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var document = txtDocument.Text;
            Client client = db.Client.Find(document);
            if (client == null)
            {
                MessageBox.Show("There is no user associated with the document number entered. Please clic in REGISTER");
                this.cleanFields();
            } else
            {
                MessageBox.Show("A user already exists with the document number entered.");
                this.cleanFields();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register create = new Register();
            create.Show();
        }

        private void cleanFields()
        {
            cmbTypeDocument.Text = string.Empty;
            txtDocument.Text = string.Empty;            
        }
    }
}
