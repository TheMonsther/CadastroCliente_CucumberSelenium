using CadastroClientes_Selenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace CadastroCliente_SpecFlowSelenium.Steps
{
    [Binding]
    public class CadastrarUsuarioSteps
    {
        IWebDriver driver;
        CadastroCliente cadastroCliente;

        [Given(@"que eu esteja na tela de cadastro de usuário")]
        public void DadoQueEuEstejaNaTelaDeCadastroDeUsuario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("http://prova.stefanini-jgr.com.br/teste/qa/");

            cadastroCliente = new CadastroCliente(driver);
        }
        
        [Given(@"insira meus (.*) nomes")]
        public void DadoInsiraMeusNomes(string p0)
        {
            cadastroCliente.TxtNome.Text = p0;
        }
        
        [Given(@"insira meu (.*)")]
        public void DadoInsiraMeu(string p0)
        {
            cadastroCliente.TxtEmail.Text = p0;
        }
        
        [Given(@"insira uma senha com (.*) caracter")]
        public void DadoInsiraUmaSenhaComCaracter(string p0)
        {
            cadastroCliente.TxtSenha.Text = p0;
        }
        
        [When(@"clicar em no botão Cadastrar")]
        public void QuandoClicarEmNoBotaoCadastrar()
        {
            cadastroCliente.SetDatas();
            cadastroCliente.BtnCadastrar.Click();
        }
        
        [Then(@"a página (.*) meu cadastro feito em uma tabela")]
        public void EntaoAPaginaMeuCadastroFeitoEmUmaTabela(string p0)
        {
            if(p0.Equals("sim"))
            {
                if (!(cadastroCliente.ValidaCadastro())) Debug.Assert(true);
            }
            else
            {
                if (cadastroCliente.ValidaCadastro()) Debug.Assert(true);
            }

            driver.Close();
        }
    }
}
