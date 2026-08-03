using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace KickBase.Domain;

public sealed class Result<TResult>
{
    private Result(bool isSuccess, TResult? result, Error? error)
    {
        ResultObject = result;
        Success = isSuccess;
        Error = error;
    }
    
    public TResult? ResultObject { get; } 
    public Error? Error { get; } 
    
    [MemberNotNullWhen(returnValue: false, nameof(Error))]
    [MemberNotNullWhen(returnValue: true, nameof(ResultObject))]
    public bool Success { get; }
    
    [MemberNotNullWhen(returnValue: true, nameof(Error))]
    [MemberNotNullWhen(returnValue: false, nameof(ResultObject))]
    public bool Failed => !Success;
   
    public static Result<TResult> CreateSuccess(TResult result) => new(true, result, null);
    public static Result<TResult> CreateError(Error error) => new(false, default, error);
    
    public static implicit operator Result<TResult>(Error error) => CreateError(error);
    public static implicit operator Result<TResult>(TResult value) => CreateSuccess(value);
    
}

[UsedImplicitly]
public sealed class Error
{
    public string? ErrorMessage { get; }
    
    public Error(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}