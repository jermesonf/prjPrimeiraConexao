using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjPrimeiraConexao
{
    public partial class Form1 : Form
    {
        //Declaracoes publicas ainda nao aplicado - new NomeClasse;
        ClasseConexao con;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new ClasseConexao();
            dt = new DataTable();
            //Executar comando SQL
            dt = con.executarSQL("SELECT * FROM contatos1");

            //Mostrando o resultado do comando sql
            //dt.Rows[numero da linha de 0,N][numero ou nome da coluna]

            /*
                MessageBox.Show(dt.Rows[0][0].ToString());
                MessageBox.Show(dt.Rows[0][1].ToString());
                MessageBox.Show(dt.Rows[0][2].ToString());

                MessageBox.Show(dt.Rows[1]["id"].ToString());
                MessageBox.Show(dt.Rows[1]["nome"].ToString());
                MessageBox.Show(dt.Rows[1]["fone"].ToString());
            */

            txtId.Text = dt.Rows[2]["id"].ToString();
            txtNome.Text = dt.Rows[2]["nome"].ToString();
            txtFone.Text = dt.Rows[2]["fone"].ToString();
        }
    }
}
