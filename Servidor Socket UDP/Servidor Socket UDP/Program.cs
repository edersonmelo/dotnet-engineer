using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Servidor_Socket_UDP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criando servidor udp
            int porta = 11000;
            UdpClient udpServidor = new UdpClient(porta);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, porta);

            //Recebendo dados do cliente
            byte[] bufferRecebeDoCliente = new byte[256];
            bufferRecebeDoCliente = udpServidor.Receive(ref endpoint);
            Console.WriteLine("Dados recebidos do cliente: " + Encoding.ASCII.GetString(bufferRecebeDoCliente, 0, bufferRecebeDoCliente.Length));

            //Enviando dados para o cliente
            byte[] bufferEnviaProCliente = Encoding.ASCII.GetBytes("Ola do servidor UDP!");
            udpServidor.Send(bufferEnviaProCliente, bufferEnviaProCliente.Length, endpoint);

            //Fechando conexão
            udpServidor.Close();

            Console.ReadKey();
        }
    }
}
