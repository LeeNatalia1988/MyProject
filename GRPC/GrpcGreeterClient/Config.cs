using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcGreeterClient
{
    public class Config
    {
        public int TotalPackets { get; set; } //общее количество пакетов, которые нужно послать на сервер
        public int RecordsInPacket { get; set; } //общее количество записей в одном пакете
        public int TimeInterval { get; set; } //интервал в секундах между отправкой пакетов
        public string gRPCServerAddr { get; set; } //адрес сервера
        public int gRPCServerPort { get; set; } //порт сервера
    }
}
