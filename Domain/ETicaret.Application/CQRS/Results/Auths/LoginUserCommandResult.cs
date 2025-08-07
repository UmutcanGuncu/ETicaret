using ETicaret.Application.DTOs;

namespace ETicaret.Application.CQRS.Results.Auths;

public class LoginUserCommandResult
{
    public bool Success { get; set; }
    public Guid? UserId { get; set; }
    public string Message { get; set; }
    public Token?  Token { get; set; } 
}