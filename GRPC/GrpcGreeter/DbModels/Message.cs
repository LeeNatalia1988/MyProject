namespace GrpcGreeter.DbModels
{
    public class Message
    {
        
        public string PRSeqNum { get; set; } //уникальный номер = PacketSeqNum и RecordSeqNum образуют уникальный идентификатор строки в grpc_data???
        public int PacketSeqNum { get; set; } //номер пакета
        public int RecordSeqNum { get; set; } //порядковый номер записи в пакете
        public string PacketTimestamp { get; set; } //время формирования пакета на стороне клиента
        public double Decimal1 { get; set; } //данные
        public double Decimal2 { get; set; } //данные
        public double Decimal3 { get; set; } //данные
        public double Decimal4 { get; set; } //данные
        public string RecordTimestamp { get; set; } //временная метка
    }
}
