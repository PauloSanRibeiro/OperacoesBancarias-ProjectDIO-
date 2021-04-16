using System;
using static System.Console;
using System.Collections.Generic;
using System.Threading;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();


        static void Main(string[] args)
        {
            string opcaoUsuario = ObertOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InsirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObertOpcaoUsuario();
                Thread.Sleep(2000);
                
            }

            WriteLine("Obrigado por utilizar nossos serviços.");
            ReadLine();
        }

        private static void ListarContas()
        {
            //throw new NotImplementedException();

            WriteLine("==== Lista de Contas Ativas ====");
            WriteLine();

            if(listContas.Count == 0)
            {
                WriteLine("Nenhuma Conta Ativa Encontrada!!");
            }

            for(int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Write("-> #{0} - ", i);
                WriteLine(conta);
            }
        }

        private static void InsirConta()
        {
            //throw new NotImplementedException();
            WriteLine("==== Cadastro de Nova Conta ====");
            WriteLine();
            WriteLine("-> Opção 1 - Pessoa Física");
            WriteLine("-> Opção 2 - Pessoa Jurídica");

            //Ler a opção de tipo de conta desejada para abertura da mesma, PARSE convert a string de REDLINE para int
            Write("-> Informe uma opção: ");
            int entradaTipoConta = int.Parse(ReadLine());       

            //Ler o nome do títular responsável pela conta que está sendo aberta
            Write("-> Nome do Títular: ");
            string entradaNomeTitular = ReadLine();             

            //Ler o saldo inicial para abertura da conta, PARSE convert a string de REDLINE para float
            Write("-> Saldo Inicial: R$");
            float entradaSaldoInicial = float.Parse(ReadLine());

            //Ler o cheque especial inicial para a conta que será oferecida, PARSE convert a string de REDLINE para float
            Write("-> Informe o Crédito Inicial: R$");
            float entradaCreditoInicial = float.Parse(ReadLine());

            /*Cria o objeto (istancia) novaConta;
            * (TipoConta)entradaTipoConta, convert de forma implicita a entrada para o ENUM TipoConta;
            *Os demais parametros realiza o insert das entradas em suas respectivas variaveis
            */
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo:entradaSaldoInicial, 
                                                                                credito: entradaCreditoInicial,
                                                                                 nome: entradaNomeTitular);

            //lista de contas; ADD = metodos; A lista recebe a novaConta como objeto
            listContas.Add(novaConta);
        }
        private static void Transferir()

        {
            WriteLine("==== Transferência Bancária ====");
            WriteLine();

            //Numero conta de origem
            Write("-> Conta de Origem: ");
            int indContaOrigem = int.Parse(ReadLine());

            //Numero conta de destino
            Write("-> Conta de Destino: ");
            int indContaDestino = int.Parse(ReadLine());
            
            //Valor a ser transferido
            Write("-> Valor de Transferência: R$");
            double valorTransferencia = double.Parse(ReadLine());
            
            /*indice conta indexado pega o objeto origem e tranfere para o indice conta destino
            *Classe transferir saca do origem e deposita na destino, através da classes
            */
            listContas[indContaOrigem].Transferir(valorTransferencia, listContas[indContaDestino]); 
        }
        private static void Sacar()
        {
            WriteLine("==== Realizar Saque ====");
            WriteLine();

            //Verifica o número da conta que será realizado o saque
            Write("-> Número da Conta: ");
            int indConta = int.Parse(ReadLine());

            //Verifica o valor desejado para saque
            Write("-> Valor de Saque: R$");
            double valorSaque = double.Parse(ReadLine());

            /*Indice com indConta realiza a classe sacar
            */
            listContas[indConta].Sacar(valorSaque);            
            
        }
        private static void Depositar()
        {
            WriteLine("=== Deposito Bancário ===");
            WriteLine();

            //Verifica a conta para deposito
            Write("-> Número da conta: ");
            int indConta = int.Parse(ReadLine());

            //Verifica o valor de deposito
            Write("-> Valor de Depósito: R$");
            double valorDeposito = double.Parse(ReadLine());

            listContas[indConta].Depositar(valorDeposito);

        }
        private static string ObertOpcaoUsuario()
        {
            WriteLine();
            WriteLine("----------------------------");
            WriteLine("Olá! DIO BANK A SEU DISPOR!!");
            WriteLine("----------------------------");
            WriteLine();

            WriteLine("==== MENU DE SERVIÇOS ====");
            WriteLine("1 - Listar Contas ");
            WriteLine("2 - Registrar Nova Conta");
            WriteLine("3 - Realizar transferência");
            WriteLine("4 - Realizar Saque");
            WriteLine("5 - Realizar Deposito");
            WriteLine("6 - Limpar Tela");
            WriteLine("X - SAIR");
            WriteLine("-------------------------");
            Write("Informe o código do serviço: ");

            string opcaoUsuario = ReadLine().ToUpper();
            WriteLine();
            return opcaoUsuario;



        }
    }
}
