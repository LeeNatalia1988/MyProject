using Grpc.Net.Client;
using System.Diagnostics;
using System.Text.Json;

namespace GrpcGreeterClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            string jsonConfig = File.ReadAllText("..\\..\\..\\tsconfig.json");
            Config config = JsonSerializer.Deserialize<Config>(jsonConfig);
            int TotalPackets = config.TotalPackets;
            int RecordsInPacket = config.RecordsInPacket; //общее количество записей в одном пакете
            int TimeInterval = config.TimeInterval; //интервал в секундах между отправкой пакетов
            string gRPCServerAddr = config.gRPCServerAddr; //адрес сервера
            int gRPCServerPort = config.gRPCServerPort; //порт сервера

            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var httpClient = new HttpClient(handler) { Timeout = Timeout.InfiniteTimeSpan };

            using var channel = GrpcChannel.ForAddress(gRPCServerAddr + ":" + gRPCServerPort.ToString(), new GrpcChannelOptions
            {
                HttpClient = new HttpClient(handler)
            });

            var client = new Greeter.GreeterClient(channel);

            for (int i = 1; i <= TotalPackets; i++)
            {
                Messages message = new Messages();
                message.PacketSeqNum = i;
                message.NRecords = RecordsInPacket;
                message.PacketTimestamp = DateTime.Now.ToString();
                Random rnd = new Random();
                for (int j = 1; j <= RecordsInPacket; j++)
                {
                    Data data = new Data();
                    data.RecordSeqNum = j;
                    data.Decimal1 = rnd.NextDouble();
                    data.Decimal2 = rnd.NextDouble();
                    data.Decimal3 = rnd.NextDouble();
                    data.Decimal4 = rnd.NextDouble();
                    data.RecordTimestamp = DateTime.Now.ToString();
                    message.PacketData.Add(data);
                }
                try
                {
                    var reply = await client.SayHelloAsync(request: new HelloRequest { Messages = message });
                    Console.WriteLine($"Ответ сервера: {reply.Message}");
                }
                catch (Grpc.Core.RpcException)
                {
                    Console.WriteLine("Сервер не отвечает.");
                }
                Thread.Sleep(TimeInterval);
            }
            //Process.GetCurrentProcess().Kill();
        }
    }
}
