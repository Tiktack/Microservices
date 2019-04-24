// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: greeter.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Greet {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class Greeter
  {
    static readonly string __ServiceName = "Greet.Greeter";

    static readonly grpc::Marshaller<global::Greet.ByeRequest> __Marshaller_Greet_ByeRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.ByeRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.ByeReply> __Marshaller_Greet_ByeReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.ByeReply.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.StreamRequest> __Marshaller_Greet_StreamRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.StreamRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.StreamResponse> __Marshaller_Greet_StreamResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.StreamResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.HelloRequest> __Marshaller_Greet_HelloRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.HelloRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::Greet.HelloReply> __Marshaller_Greet_HelloReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Greet.HelloReply.Parser.ParseFrom);

    static readonly grpc::Method<global::Greet.ByeRequest, global::Greet.ByeReply> __Method_SayBye = new grpc::Method<global::Greet.ByeRequest, global::Greet.ByeReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SayBye",
        __Marshaller_Greet_ByeRequest,
        __Marshaller_Greet_ByeReply);

    static readonly grpc::Method<global::Greet.StreamRequest, global::Greet.StreamResponse> __Method_BeStreaming = new grpc::Method<global::Greet.StreamRequest, global::Greet.StreamResponse>(
        grpc::MethodType.DuplexStreaming,
        __ServiceName,
        "BeStreaming",
        __Marshaller_Greet_StreamRequest,
        __Marshaller_Greet_StreamResponse);

    static readonly grpc::Method<global::Greet.HelloRequest, global::Greet.StreamResponse> __Method_ServerStreaming = new grpc::Method<global::Greet.HelloRequest, global::Greet.StreamResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "ServerStreaming",
        __Marshaller_Greet_HelloRequest,
        __Marshaller_Greet_StreamResponse);

    static readonly grpc::Method<global::Greet.StreamRequest, global::Greet.HelloReply> __Method_ClientStreaming = new grpc::Method<global::Greet.StreamRequest, global::Greet.HelloReply>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "ClientStreaming",
        __Marshaller_Greet_StreamRequest,
        __Marshaller_Greet_HelloReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Greet.GreeterReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Greeter</summary>
    public partial class GreeterClient : grpc::ClientBase<GreeterClient>
    {
      /// <summary>Creates a new client for Greeter</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public GreeterClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Greeter that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public GreeterClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected GreeterClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected GreeterClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Greet.ByeReply SayBye(global::Greet.ByeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayBye(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Greet.ByeReply SayBye(global::Greet.ByeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SayBye, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Greet.ByeReply> SayByeAsync(global::Greet.ByeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SayByeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Greet.ByeReply> SayByeAsync(global::Greet.ByeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SayBye, null, options, request);
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Greet.StreamRequest, global::Greet.StreamResponse> BeStreaming(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return BeStreaming(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncDuplexStreamingCall<global::Greet.StreamRequest, global::Greet.StreamResponse> BeStreaming(grpc::CallOptions options)
      {
        return CallInvoker.AsyncDuplexStreamingCall(__Method_BeStreaming, null, options);
      }
      public virtual grpc::AsyncServerStreamingCall<global::Greet.StreamResponse> ServerStreaming(global::Greet.HelloRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ServerStreaming(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::Greet.StreamResponse> ServerStreaming(global::Greet.HelloRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_ServerStreaming, null, options, request);
      }
      public virtual grpc::AsyncClientStreamingCall<global::Greet.StreamRequest, global::Greet.HelloReply> ClientStreaming(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ClientStreaming(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncClientStreamingCall<global::Greet.StreamRequest, global::Greet.HelloReply> ClientStreaming(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_ClientStreaming, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override GreeterClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new GreeterClient(configuration);
      }
    }

  }
}
#endregion