namespace ContentApi.Modules.Shared.DTOs;

public record LoginDto(string Username, string Password);
public record LoginResponseDto(string Token, object User);
public record CreateUserDto(
    string Username,
    string Password,
    string DisplayName,
    string Email,
    string Role,
    List<string> Permissions
);
