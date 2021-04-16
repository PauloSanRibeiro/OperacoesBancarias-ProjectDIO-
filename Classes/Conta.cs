using static System.Console;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        public string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //VALIDAÇÃO DE SALDO SUFICIENTE
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                WriteLine($"Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;

            WriteLine($"{this.Nome}, seu saldo atual é {this.Saldo:C2}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            WriteLine($"{this.Nome}, seu saldo atual é {this.Saldo:C2}");

        }

        public void Transferir(double valorTransferencia, Conta ContaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                ContaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += ($"Tipo Conta: {this.TipoConta} | ");
            retorno += ($"Nome: {this.Nome,-20} | ");
            retorno += ($"Saldo:  {this.Saldo:C2}  | ");
            retorno += ($"Crédito: {this.Credito:C2} |");
            return retorno;
        }
    }
}
