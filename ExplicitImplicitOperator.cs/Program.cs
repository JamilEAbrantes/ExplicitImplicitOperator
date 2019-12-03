using System;

public class Program
{
    public static void Main()
    {
        var texto01 = "36501178456ROMEU ROMERO        0088";
        var objExplicit01 = (ClienteA)texto01;
        Console.WriteLine("EXPLICIT -> " + objExplicit01);

        var clienteC01 = new ClienteC("39704458705", "JOAO MENDES", 29);
        var objExplict02 = (ClienteA)clienteC01;
        Console.WriteLine("EXPLICIT -> " + objExplict02);

        var texto02 = "36501178456MARIA ZEFREDO        0088";
        ClienteB clienteB = texto02;
        Console.WriteLine("IMPLICIT -> " + clienteB);

        var clienteC02 = new ClienteC("39704458705", "ZECA MARINHO", 29);
        ClienteB clienteB2 = clienteC02;
        Console.WriteLine("IMPLICIT -> " + clienteB2);

        Console.ReadKey();
    }

    public class ClienteA
    {
        public ClienteA(string documento, string nome, double idade)
        {
            Documento = documento;
            Nome = nome;
            Idade = idade;
        }

        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public double Idade { get; private set; }

        public static explicit operator ClienteA(string texto)
        {
            return new ClienteA(texto.Substring(0, 11), texto.Substring(11, 20).Trim(), Convert.ToDouble(texto.Substring(31, 4)));
        }

        public static explicit operator ClienteA(ClienteC clienteC)
        {
            return new ClienteA(clienteC.Documento, clienteC.Nome, Convert.ToDouble(clienteC.Idade));
        }

        public override string ToString()
        {
            return "[ " + GetType().Name + " - " + Documento + " " + Nome + " - Idade: " + Idade + "]";
        }
    }

    public class ClienteB
    {
        public ClienteB(string documento, string nome, double idade)
        {
            Documento = documento;
            Nome = nome;
            Idade = idade;
        }

        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public double Idade { get; private set; }

        public static implicit operator ClienteB(string texto)
        {
            return new ClienteB(texto.Substring(0, 11), texto.Substring(11, 20).Trim(), Convert.ToDouble(texto.Substring(31, 4)));
        }

        public static implicit operator ClienteB(ClienteC clienteC)
        {
            return new ClienteB(clienteC.Documento, clienteC.Nome, Convert.ToDouble(clienteC.Idade));
        }

        public override string ToString()
        {
            return "[ " + GetType().Name + " - " + Documento + " " + Nome + " - Idade: " + Idade + "]";
        }
    }

    public class ClienteC
    {
        public ClienteC(string documento, string nome, double idade)
        {
            Documento = documento;
            Nome = nome;
            Idade = idade;
        }

        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public double Idade { get; private set; }

        public override string ToString()
        {
            return "[ " + GetType().Name + " - " + Documento + " " + Nome + " - Idade: " + Idade + "]";
        }
    }
}
