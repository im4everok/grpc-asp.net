// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

var client = new GrpcClient.Math.MathClient(GrpcChannel.ForAddress("https://localhost:7119"));

for(int i = 1; i <= 10; i++)
{
    var addResult = client.Calculate(new GrpcClient.MathRequest { A = i, B = i + i, Operation = GrpcClient.Operation.Add });

    var multiplyResult = client.Calculate(new GrpcClient.MathRequest { A = i, B = i + i, Operation = GrpcClient.Operation.Multiply });

    Console.WriteLine($"Addition result: {addResult}. Mulptiplication: {multiplyResult}");
}