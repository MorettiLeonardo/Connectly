using System.Text.Json.Serialization;

namespace Connectly.Application.Configurations
{
    public record ApiResponse<T>
    {
        private readonly int _code;
        public string Message { get; init; } = string.Empty;
        public T? Data { get; init; }

        [JsonConstructor]
        public ApiResponse(int V) => _code = 200;

        public ApiResponse(int code, string message, T? data)
        {
            _code = code;
            Message = message;
            Data = data;
        }

        [JsonIgnore]
        public bool IsSuccess => _code is >= 200 and <= 299;
    }
}
