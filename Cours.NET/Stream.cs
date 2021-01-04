using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class AnyDisposableClass : IDisposable
{
    public void Dispose() { }
}
class StreamClassReader : IDisposable
{
    private StreamReader streamReader;
    private NamedPipeClientStream pipeClient;
    private BinaryReader binaryReader;

    public StreamClassReader()
    {
        pipeClient = new NamedPipeClientStream("testpipe");
        pipeClient.Connect(100);
        Console.Out.WriteLine("Connecting to server");
        streamReader = new StreamReader(pipeClient, Encoding.UTF8, leaveOpen: true);
        binaryReader = new BinaryReader(pipeClient, Encoding.UTF8, leaveOpen: true);
    }
    public void Dispose()
    {
        Console.Out.WriteLine("Dipose StreamClassReader");
        streamReader.Dispose();
        pipeClient.Dispose();
        binaryReader.Dispose();
    }
    public string Read()
    {
        var size = pipeClient.ReadByte();
        if (size < 0)
        {
            return null;
        }
        //var buffer = new char[size];
        var buffer = binaryReader.ReadChars(size);
        //if (await streamReader.ReadBlockAsync(buffer, 0, size) == 0)
        //{
        //    return null;
        //}
        return new String(buffer);
    }
}

class AsyncStreamClassReader : IDisposable
{
    private StreamReader streamReader;
    private NamedPipeClientStream pipeClient;
    private BinaryReader binaryReader;

    public AsyncStreamClassReader()
    {
        pipeClient = new NamedPipeClientStream("testpipe");
        pipeClient.Connect(100);
        Console.Out.WriteLine("Connecting to server");
        streamReader = new StreamReader(pipeClient, Encoding.UTF8, leaveOpen: true);
        binaryReader = new BinaryReader(pipeClient, Encoding.UTF8, leaveOpen: true);
    }
    public void Dispose()
    {
        Console.Out.WriteLine("Dipose StreamClassReader");
        streamReader.Dispose();
        pipeClient.Dispose();
        binaryReader.Dispose();
    }
    public async IAsyncEnumerable<string> Read()
    {
        while (true)
        {
            var size = pipeClient.ReadByte();
            if (size < 0)
            {
                break;
            }
            var buffer = binaryReader.ReadChars(size);
            yield return await Task.FromResult(new String(buffer));
        }
    }

    public static void Main()
    {
        var t2 = Task.Run(async () =>
        {
            using (var scw = new StreamClassWriter())
            {
                for (int i = 0; i < 10; i++)
                {
                    await scw.Write($"Message {i}");
                    await Task.Delay(1000);
                }
            }
        });
        Thread.Sleep(100);
        var t1 = Task.Run(async () =>
        {
            var v = new AsyncStreamClassReader();
            using (var scr = v)
            {
                await foreach (var message in scr.Read())
                {
                    Console.Out.WriteLine(message);
                }
            }
        });

        using (var m = new MemoryStream())
        {

        }

        Task.WaitAll(t2, t1);
    }
}
class StreamClassWriter : IDisposable
{
    public static void Main()
    {
        var t2 = Task.Run(async () =>
        {
            using (var scw = new StreamClassWriter())
            {
                for (int i = 0; i < 10; i++)
                {
                    await scw.Write($"Message {i}");
                    await Task.Delay(1000);
                }
            }
        });
        Thread.Sleep(100);
        var t1 = Task.Run(() =>
        {
            var v = new StreamClassReader();
            using (var scr = v)
            {
                String res = "";
                while (res is not null)
                {
                    res = scr.Read();
                    Console.Out.WriteLine(res);
                }
            }
        });

        using (var m = new MemoryStream())
        {

        }

        Task.WaitAll(t2, t1);
    }

    private StreamWriter streamWriter;
    private bool disposedValue;
    private NamedPipeServerStream pipeServer;

    public StreamClassWriter()
    {
        pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut);
        Console.Out.WriteLine("Waiting For connection");
        pipeServer.WaitForConnection();
        streamWriter = new StreamWriter(pipeServer);
    }

    public async Task Write(String str)
    {
        pipeServer.WriteByte((byte)str.Length);
        await streamWriter.WriteAsync(str);
        streamWriter.Flush();
    }

    protected virtual void Dispose(bool disposing)
    {
        Console.Out.WriteLine("Dispose StreamClassWriter");
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: supprimer l'état managé (objets managés)
                streamWriter.Close();
                pipeServer.Close();
            }

            // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
            // TODO: affecter aux grands champs une valeur null
            disposedValue = true;
        }
    }

    // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
    // ~StreamClass()
    // {
    //     // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
