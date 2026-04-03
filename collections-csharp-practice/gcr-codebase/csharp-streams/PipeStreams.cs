using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;

class PipeStreams
{
    static void Main()
    {
        AnonymousPipeServerStream server = new AnonymousPipeServerStream(
            PipeDirection.Out,
            HandleInheritability.Inheritable
        );

        AnonymousPipeClientStream client = new AnonymousPipeClientStream(
            PipeDirection.In,
            server.ClientSafePipeHandle
        );

        Thread writer = new Thread(() =>
        {
            using (StreamWriter sw = new StreamWriter(server))
            {
                sw.WriteLine("Hello from Writer Thread");
                sw.Flush();
            }
        });

        Thread reader = new Thread(() =>
        {
            using (StreamReader sr = new StreamReader(client))
            {
                string msg = sr.ReadLine();
                Console.WriteLine("Received: " + msg);
            }
        });

        writer.Start();
        reader.Start();

        writer.Join();
        reader.Join();
    }
}
