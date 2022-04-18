using System.Net;
using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs;

public class CustomResponseDto<T>
{
    public T Data { get; set; }
    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }
    public List<String> Errors { get; set; }

    public static CustomResponseDto<T> Success(HttpStatusCode statusCode, T data)
    {
        return new CustomResponseDto<T> {Data = data, StatusCode = statusCode};
    }
    
    public static CustomResponseDto<T> Success(HttpStatusCode statusCode)
    {
        return new CustomResponseDto<T> {StatusCode = statusCode};
    }

    public static CustomResponseDto<T> Fail(List<String> errors,HttpStatusCode statusCode)
    {
        return new CustomResponseDto<T> {Errors = errors,StatusCode = statusCode};
    }

    public static CustomResponseDto<T> Fail(string error,HttpStatusCode statusCode)
    {
        return new CustomResponseDto<T> {Errors = new List<string>{ error },StatusCode = statusCode};
    }




}