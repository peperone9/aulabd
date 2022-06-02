using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FormularioBasico
{
    public partial class func : Form
    {
       
        public func()
        {
            InitializeComponent();
        }
        //Conecta com o bd no sqlserver
        SqlConnection cn = new SqlConnection(@"Data Source=LAB1-20;Initial Catalog=db_turmaB;integrated security=false; User Id=sa; password=1234567");
        //Faz os comandos sql
        SqlCommand cm = new SqlCommand();
        //lê o bd
        SqlDataReader rd; 
        private void Funcionario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //btnDelete
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //btnChange
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //btnRegister
        private void button2_Click(object sender, EventArgs e)
        {
            int cd_func; //variavel que vai guardar o código

            //Se nao for um inteiro maior que zero ele da as mensagens de erro
            if(!int.TryParse(txtCodigo.Text, out cd_func))
            {
                MessageBox.Show("Código inválido !! Digitar um valor inteiro", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus(); //Deixa o cursor do mouse na textbox q deu erro.
            }
            else if(cd_func == 0)
            {
                MessageBox.Show("Código inválido, por favor inserir um valor inteiro maior que zero.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
            }

            txtCodigo.Text = "";//Reseta a textbox
   
        }

        //btnSearch
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
