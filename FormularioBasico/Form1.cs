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

        int cd_func = 0; //variavel que vai guardar o código
        string funcionario = "";
        string cpf = "";
        string sql; //Variavel que vai guardar o comando sql que vai ler a db

        SqlConnection cn = new SqlConnection("Data Source=lab1-20;Initial Catalog=bd_turmaB;User ID=sa;password=1234567"); //Conecta com o bd no sqlserver
        SqlCommand cm = new SqlCommand(); //Faz os comandos sql
        SqlDataReader rd; //lê o bd
        private void Funcionario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //btnDelete
        private void button4_Click(object sender, EventArgs e)
        {
            /*cd_func = TrataCodigo(cd_func);
            try
            {
                bool confirma_exclusao = MessageBox.Show("Deseja mesmo DELETAR ESTE REGISTRO?")
                sql = "delete from tbl_funcionario where cd_func = " + cd_func;

                cn.Open();
                cm.Connection = cn;
                cm.CommandText = sql;
                rd = cm.ExecuteReader();

                if (rd.IsClosed)
                    rd.Close();
                else
                {
                    if()
                }



            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }*/

        }

        //btnChange
        private void button3_Click(object sender, EventArgs e)
        {


        }
        // =====TRATA OS ERROS DO CÓDIGO ========
        public int TrataCodigo(int cod) 
        {
           

            //Se nao for um inteiro maior que zero ele da as mensagens de erro
            if (!int.TryParse(txtCodigo.Text, out cod))
            {
                MessageBox.Show("Código inválido !! Digitar um valor inteiro", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus(); //Deixa o cursor do mouse na textbox q deu erro.
            }
            else if (cod == 0)
            {
                MessageBox.Show("Código inválido, por favor inserir um valor inteiro maior que zero.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
            }
 
            return cod;
        }

        // =====TRATA OS ERROS DO CÓDIGO ========
        public string TrataFunc(string func)
        {
            
            // Ve se o campo ta vazio
            if (txtFunc.Text == "")
            {
                MessageBox.Show("O Campo FUNCIONARIO está vazio !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();
            }
            //ve se ele digitou o nome completo
            else if(txtFunc.Text.Length < 8)
            {
                MessageBox.Show("Informe o nome completo do funcionário !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();

            }
            else
            {
                func = txtFunc.Text;
            }
            return func;
        }
        // ==== TRATA ERRO DO CPF ===
        public string TrataCpf(string cpf)
        {
            if (txtCpf.Text == "")
            {
                MessageBox.Show("O Campo CPF está vazio !!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFunc.Focus();
            }
            else
            {
                cpf = txtCpf.Text;
            }
            return cpf;
        }
        //btnRegister
        private void button2_Click(object sender, EventArgs e)
        {

            //Trata os erros do formulário
            cd_func = TrataCodigo(cd_func);
            funcionario = TrataFunc(funcionario);
            cpf = TrataCpf(cpf);

            //lendo bd
            try
            {
                sql = "select cd_func from tbl_funcionario where cd_func = " + cd_func;
                cn.Open(); // abre o db
                cm.Connection = cn; //Conexão db aberto
                cm.CommandText = sql;//Comando sql que será inserido no db
                rd = cm.ExecuteReader(); //Executa  o comando

                if(rd.HasRows) //has how ve se tem um registro do código no banco de dados
                {
                    MessageBox.Show("Código já cadastrada !!", "ERRO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                    cn.Close();
                }

                else
                { 
                    if (!rd.IsClosed)
                        rd.Close(); //reader 

                        sql = "insert into tbl_funcionario(cd_func, nm_func, NO_cpf)values(@Cod, @Nome, @CPF)";
                        //parameters add adiciona o conteudo das variaveis nos campos do banco de dados

                        cm.Parameters.Clear(); //Limpa todos os parametros

                        cm.Parameters.Add("@Cod", SqlDbType.Int).Value = cd_func;
                        cm.Parameters.Add("@Nome", SqlDbType.VarChar).Value = funcionario;
                        cm.Parameters.Add("@CPF", SqlDbType.Char).Value = cpf;

                        cm.Connection = cn;
                        cm.CommandText = sql;
                        cm.ExecuteNonQuery();
                        MessageBox.Show("Dados inseridos com sucesso");
                        LimparCampos();
                        cn.Close(); //fecha a conexão                   
                }
               

            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void LimparCampos()
        {
            txtCodigo.Clear();
            txtFunc.Clear();
            txtCpf.Clear();
        }

        //btnSearch
        private void button1_Click(object sender, EventArgs e)
        {
            cd_func = TrataCodigo(cd_func);//Pegando o código
            try
            {
                sql = "select * from tbl_funcionario where cd_func = " + cd_func.ToString();

                cn.Open(); //abre bd
                cm.Connection = cn; //fala que o comando vai ser usado nessa conexão
                cm.CommandText = sql; //usa a string da variavel pra dar o comando sql
                rd = cm.ExecuteReader(); //Executa o comando no db

                if(!rd.HasRows)
                {
                    MessageBox.Show("Código não cadastrado !!", "ERRO !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cn.Close();
                }

                else
                {
                    rd.Read(); //Lê  o registro digitado na tabela
                    txtFunc.Text = rd["nm_func"].ToString();
                    txtCpf.Text = rd["no_CPF"].ToString();
                    cn.Close();
                }


            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
