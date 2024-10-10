using Grpc.Core;
using GrpcGreeter;
using GrpcGreeter.Db;
using GrpcGreeter.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GrpcGreeter.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            using (MessageContext messageContext = new MessageContext())
            {
                Message message = new Message();
                message.PacketSeqNum = request.Messages.PacketSeqNum;
                message.PacketTimestamp = request.Messages.PacketTimestamp;
                for (int i = 0; i < request.Messages.PacketData.Count; i++)
                {                    
                    message.RecordSeqNum = request.Messages.PacketData[i].RecordSeqNum;
                    message.PRSeqNum = request.Messages.PacketSeqNum.ToString() + " " + request.Messages.PacketData[i].RecordSeqNum.ToString();
                    message.Decimal1 = request.Messages.PacketData[i].Decimal1;
                    message.Decimal2 = request.Messages.PacketData[i].Decimal2;
                    message.Decimal3 = request.Messages.PacketData[i].Decimal3;
                    message.Decimal4 = request.Messages.PacketData[i].Decimal4;
                    message.RecordTimestamp = request.Messages.PacketData[i].RecordTimestamp;
                    try
                    {
                        await messageContext.Messages.AddAsync(message);
                        await messageContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    };
                    
                }
                
            }
            return await Task.FromResult(new HelloReply
            {
                Message = "finished"
            });

        }
    }
}