using Grpc.Core;

namespace GrpcTests
{
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
}
