using SaludVida.models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SaludVida
{
    public partial class ImcCalculate : Form
    {
        private SaludVidaEntities db = new SaludVidaEntities();

        public ImcCalculate()
        {
            InitializeComponent();
        }

        private void ImcCalculate_Load(object sender, EventArgs e)
        {
            var client = from c in db.Client
                         select new
                         {
                             doc = c.documentNumber
                         };
            foreach (var item in client)
            {
                cmbDocument.Items.Add(item.doc);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalPage principalPage = new PrincipalPage();
            principalPage.Show();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var doc = cmbDocument.Text;
            if (doc == "")
            {
                MessageBox.Show("Por favor selecciones una cc");
            } else
            {
                double height = Double.Parse(txtHeight.Text);
                double weight = Double.Parse(txtWeight.Text);
                double heightMts = height / 100;

                var imcCalculate = this.imcCalculate(heightMts, weight);

                Imc imc = new Imc();
                imc.cliente_document = doc;
                imc.height = height;
                imc.weight = weight;
                imc.imcResult = imcCalculate;
                imc.diagnosis = this.diagnosis(imcCalculate);

                db.Imc.Add(imc);
                db.SaveChanges();

                MessageBox.Show("IMC: " + imcCalculate + "\n Diagnosis: " + imc.diagnosis);
            }            

        }

        private double imcCalculate(double height, double weight)
        {
            return weight / Math.Pow(height, 2);
        }

        private string diagnosis(double value)
        {
            var diagnosis = "";
            if (value < 18.5)
            {
                diagnosis = "Bajo peso";
            } 
            else if (value < 25)
            {
                diagnosis = "Peso normal";
            }
            else if (value < 30)
            {
                diagnosis = "Sobrepeso";
            }
            else if (value < 35)
            {
                diagnosis = "Obesidad";
            }
            return diagnosis;
        }

        
    }
}
