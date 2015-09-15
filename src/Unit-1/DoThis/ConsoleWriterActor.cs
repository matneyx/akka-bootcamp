using System;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using Akka.Actor;

namespace WinTail
{
    /// <summary>
    /// Actor responsible for serializing message writes to the console.
    /// (write one message at a time, champ :)
    /// </summary>
    class ConsoleWriterActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message is Messages.InputError)
            {
                ConsoleWriter(message,ConsoleColor.Red);
            }
            else if (message is Messages.InputSuccess)
            {
                ConsoleWriter(message,ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine(message);
            }
         }

        public void ConsoleWriter(object message, ConsoleColor color)
        {
            dynamic msg = color == ConsoleColor.Green ? (dynamic) (Messages.InputSuccess) message : (dynamic) (Messages.InputError) message;

            Console.ForegroundColor = color;

            Console.WriteLine(msg.Reason);

            Console.ResetColor();

        }
    }
}
