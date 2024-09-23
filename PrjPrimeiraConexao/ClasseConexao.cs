using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


    public class ClasseConexao
    {
        SqlConnection conexao = new SqlConnection();

        public SqlConnection conectar(){
            try{
            /*
            * Password=etesp -> Senha do banco, 
            * User ID=sa -> Nome do usuario do banco
            * Initial Catalog=teste -> nome do banco (CREATE DATABASE teste)
            * Data Source=" + Environment.MachineName -> Busca automaticamento o nome da maquina do usuario
            * SQLEXPRESS -> Nome da instancia (pode receber outro nome caso o usuario mude na instalaçao)
            * String strConexao = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=teste; Data Source=" + Environment.MachineName + //SQLEXPRESS;
            */
            String strConexao = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=teste; Data Source=" + Environment.MachineName;
                conexao.ConnectionString = strConexao;
                conexao.Open();
                return conexao;
            }catch (Exception){
                desconectar();
                return null;
            }
        }

        public void desconectar(){
            try{
                if ((conexao.State == ConnectionState.Open)){
                    conexao.Close();
                    conexao.Dispose(); // destroi o objeto criado porem o windows mantem esse arquivo por alguns minutos
                    conexao = null; // quando atribuido null logo em seguida o windows destroi instantaneamente.
            }
        }
        catch (Exception) { }
        }

        public DataTable executarSQL(String comando_sql){
            try{
                conectar();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando_sql, conexao);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                return ds.Tables[0];
            }catch (Exception){
                return null;
            }finally{
            // finally = faca de qualquer jeito idependente de estar certo ou errado
            desconectar();
            }
        }

        public bool manutencaoDB(String comando_sql) //incluir, alterar, excluir
        {
            try
            {
                conectar();
                SqlCommand comando = new SqlCommand();
                comando.CommandText = comando_sql;
                comando.Connection = conexao;
                comando.ExecuteScalar();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
            // finally = faca de qualquer jeito idependente de estar certo ou errado
            desconectar();
            }
        }//fim do método manutençãoDB

        public int manutencaoDB_Parametros(SqlCommand comando) //incluir, alterar, excluir com parâmetros
        {
            int retorno = 0;
            try
            {
                comando.Connection = conectar();  //adiciona a conexão ao SQLCommand
                retorno = comando.ExecuteNonQuery(); //devolve o número de linhas afetadas no banco
            }
            catch (Exception) { }
            desconectar();
            return retorno;
        }//fim do método manutençãoDB com parâmetros

    }//fim da classeConexao

