using Castle.Components.DictionaryAdapter.Xml;
using Google.Protobuf.WellKnownTypes;
using GrpcGreeter.Db;
using GrpcGreeter.DbModels;
using GrpcGreeter.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace GrpcGreeter
{
    public class Program
    {
        static private string _connectionString;
        
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();

            // Add services to the container.
            
            
                        
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }

        
    }
}