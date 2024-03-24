using Rhenus.GameChallenge.Application.Autentication.Commands;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Domain.Players.Args;
using Rhenus.GameChallenge.Infrastructure.Authentication;

namespace Rhenus.GameChallenge.Application.Autentication;
public class AuthCommandHanlder(
    IPlayerRepository playerRepository,
    IJwtProvider jwtProvider)
{
    public string Handle(LoginPlayerCommand command)
    {
        var player = playerRepository.GetBy(command.Username);
        if (player is null)
            throw new Exception($"Player could not found with username: {command.Username}");

        string token = jwtProvider.Genrate(player);
        return token;
    }

    public void Handle(RegisterPlayerCommand command)
    {
        var player = playerRepository.GetBy(command.Username);
        if (player is not null)
            throw new Exception($"Player is already registered with username: {command.Username}");

        playerRepository.Add(Player.Create(new CreatePlayerArg
        {
            Username = command.Username,
            Password = command.Password,
            PlayerId = PlayerId.New(),
            Account = Constants.DefaultAccountValue
        }));
    }
}
