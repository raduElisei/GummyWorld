namespace GummyWorld.Domain.Entities.Models;

public class Response<T>
{
    public bool Success { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public T? Result { get; set; }
}
