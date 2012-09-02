using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Console.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = @".\private$\mensagem";

            using (MessageQueue fila = new MessageQueue(queue))
            {
                if (!MessageQueue.Exists(queue))
                    MessageQueue.Create(queue);

                foreach (var item in fila.GetAllMessages())
                {
                    item.Formatter = new XmlMessageFormatter(new []{typeof(string)});

                    System.Console.WriteLine(item.Body.ToString());
                }

                fila.Purge();
            }
            System.Console.ReadKey();

        }
    }
}
