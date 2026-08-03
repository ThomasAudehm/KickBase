using System.Net.Http.Json;
using System.Text.Json;

namespace KickBase.Domain;

public static class HttpExtensions
{
    public static async Task<Result<T>> DeserializeToResultAsync<T>(
        this Task<HttpResponseMessage> response, 
        JsonSerializerOptions? options, 
        CancellationToken cancellationToken = default) => await DeserializeToResultAsync<T>(await response, options, cancellationToken);
    
    public static async Task<Result<T>> DeserializeToResultAsync<T>(
        this HttpResponseMessage response, 
        JsonSerializerOptions? options, 
        CancellationToken cancellationToken = default)
    {
        if (!response.IsSuccessStatusCode)
        {
            return new Error(response.ReasonPhrase);

        }

        var obj = await response
            .Content
            .ReadFromJsonAsync<T>(options, cancellationToken)
            .ConfigureAwait(false);

        return obj is not null
            ? obj
            : new
                Error($"The Content can´t Convert in Type {typeof(T).FullName}. The Content wars {response.Content.ReadAsStreamAsync(cancellationToken)}");
    }
}