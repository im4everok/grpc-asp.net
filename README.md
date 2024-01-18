# gRPC Learning Project in .NET

## Overview
This project is designed to help you grasp the fundamentals of gRPC in .NET. It consists of two main components: the client and the server.

### Server
The server component includes a proto file defining the communication contract and a `MathService` with a `Calculate()` method. This method is the core functionality that performs mathematical calculations.

#### Proto File
```protobuf
syntax = "proto3";

option csharp_namespace = "GrpcTests";

package math;

service Math {
	rpc Calculate(MathRequest) returns (MathResponse);
}

message MathRequest {
	int32 a = 1;
	int32 b = 2;
	Operation operation = 3;
}

enum Operation {
	Add = 0;
	Multiply = 1;
}

message MathResponse {
	int32 result = 1;
}
```

#### MathService
```csharp
public class MathService : Math.MathBase
    {
        public MathService()
        {

        }

        public override Task<MathResponse> Calculate(MathRequest request, ServerCallContext context)
        {
            int result = 0;

            if(request.Operation == Operation.Add)
            {
                result = request.A + request.B;
            }

            if (request.Operation == Operation.Multiply)
            {
                result = request.A * request.B;
            }

            var response = new MathResponse
            {
                Result = result
            };

            return Task.FromResult(response);
        }
    }
```

### Client
The client utilizes the `MathClient` to interact with the server and executes the `Calculate()` method with various input values.

#### MathClient Usage
```csharp
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

var client = new GrpcClient.Math.MathClient(GrpcChannel.ForAddress("https://localhost:7119"));

for(int i = 1; i <= 10; i++)
{
    var addResult = client.Calculate(new GrpcClient.MathRequest { A = i, B = i + i, Operation = GrpcClient.Operation.Add });

    var multiplyResult = client.Calculate(new GrpcClient.MathRequest { A = i, B = i + i, Operation = GrpcClient.Operation.Multiply });

    Console.WriteLine($"Addition result: {addResult}. Mulptiplication: {multiplyResult}");
}
```

## Getting Started
To get started with this project, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution in your preferred .NET development environment.
3. Run the server project.
4. Run the client project with different input values to observe the behavior.

## Additional Notes
Feel free to explore and extend this project to deepen your understanding of gRPC in .NET. Experiment with various proto file configurations, service methods, and client interactions to enhance your skills.

Happy coding! 🚀

![image](https://github.com/im4everok/grpc-asp.net/assets/52084198/8a08c883-ffd2-4ca5-83f5-3132f44e0e52)
