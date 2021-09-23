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
    public partial class Register : Form
    {
        private SaludVidaEntities db = new SaludVidaEntities();
        
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var docType = cmbTypeDocument.Text;
            var doc = txtDocument.Text;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;

            if (docType == "" || doc == "" || firstName == "" || lastName == "")
            {
                MessageBox.Show("Document type, document number, first name and last name are required fields, please complete them.");
            } else
            {
                Client c = db.Client.Find(doc);
                if (c != null)
                {
                    MessageBox.Show("Cannot register a user, already exists in the system.");
                }
                else
                {
                    Client client = new Client();
                    client.typeDocument = cmbTypeDocument.Text;
                    client.documentNumber = txtDocument.Text;
                    client.firstName = txtFirstName.Text;
                    client.lastName = txtLastName.Text;
                    client.address = txtAddress.Text;
                    client.phone = txtPhone.Text;
                    client.email = txtEmail.Text;
                    client.city = txtCity.Text;
                    client.fechaNacimiento = dateFecha.Value;

                    db.Client.Add(client);
                    db.SaveChanges();
                    MessageBox.Show("User successfully registered");
                    this.cleanFields();
                }
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalPage principalPage = new PrincipalPage();
            principalPage.Show();
        }

        private void cleanFields()
        {
            cmbTypeDocument.Text = string.Empty;
            txtDocument.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            dateFecha.Value = DateTime.Now;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
