using CloudNative.CloudEvents.Protobuf;
using CloudNative.CloudEvents.V1;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace CloudEventProtobufSample
{
    public class Service : SampleAppGrpcService.SampleAppGrpcServiceBase
    {
        public override async Task<Empty> SendEvents(IAsyncStreamReader<CloudEvent> requestStream, ServerCallContext context)
        {
            await foreach (var proto in requestStream.ReadAllAsync(context.CancellationToken))
            {
                try
                {
                    var formatter = new ProtobufEventFormatter();
                    CloudNative.CloudEvents.CloudEvent cloudEvent = formatter.ConvertFromProto(proto, null);
                }
                catch (Exception e)
                {
                }
            }

            return new Empty();
        }
    }
}
