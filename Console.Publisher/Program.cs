using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Console.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = @".\private$\mensagem";

            var mensagem = System.Console.ReadLine();

            using (MessageQueue _fila = new MessageQueue(queue))
            {
                if (!MessageQueue.Exists(queue))
                    MessageQueue.Create(queue);

                _fila.Send(mensagem);
            }

            System.Console.ReadKey();
        }
    }
}
