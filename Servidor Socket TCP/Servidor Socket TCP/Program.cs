using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Servidor_Socket_TCP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criando servidor socket TCP
            TcpListener listener = new TcpListener(IPAddress.Any, 13);
            listener.Start();
            Console.WriteLine("Esperando conexão...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Conexão estabelecida");
            NetworkStream ns = client.GetStream();

            try
            {
                //Ler dados do cliente
                byte[] bufferRecebeDoCliente = new byte[256];
                int bytesLidos = ns.Read(bufferRecebeDoCliente, 0, bufferRecebeDoCliente.Length);
                Console.WriteLine("Dados recebidos do cliente: " + Encoding.ASCII.GetString(bufferRecebeDoCliente, 0, bytesLidos));

                //Enviando dados pro cliente
                byte[] bufferEnviaProCliente = Encoding.ASCII.GetBytes("Ola do servidor!");
                ns.Write(bufferEnviaProCliente, 0, bufferEnviaProCliente.Length);

                //Encerrar a comunicação
                ns.Close();
                client.Close();
                listener.Stop();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
