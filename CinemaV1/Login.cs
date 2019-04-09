﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaV1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //botao pra sair e fechar o aplicativo
            Application.Exit();
        }

      
        private void BtnLogin_Click(object sender, EventArgs e)
        {


            try
            {
                String strConexao = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Users\JR TECH\source\repos\CinemaV1\CinemaV1\bdCadastro.mdb";
                //cria a conexao
                OleDbConnection conn = new OleDbConnection(strConexao);

                OleDbCommand comm = new OleDbCommand("select * from Cadastros where Nome = @user and Senha = @senha",conn);

                comm.Parameters.Add("@user", OleDbType.VarChar).Value = TxtBoxUser.Text;
                comm.Parameters.Add("@senha", OleDbType.VarChar).Value = TxtBoxPass.Text;

                conn.Open();

                
                int i = int.Parse(comm.ExecuteScalar().ToString());

                if (i > 0)
                {
                    
                    //Abre o form Home e esconde o form1
                    Home frmHome = new Home();
                   
                    frmHome.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error");

                }
                conn.Close();
            }
            catch (Exception  )
            {

                MessageBox.Show("Error, Usuario ou Senha invalidos");
               

            }
            

        }

        private void btncadastroLOGIN_Click(object sender, EventArgs e)
        {
            
            //Abre o Form Cadastro e esconde o form1

            Cadastros frmcadastro = new Cadastros();
            frmcadastro.Show();
            this.Hide();
            //----------------------------------------------------------------------------//



        }
    }
}