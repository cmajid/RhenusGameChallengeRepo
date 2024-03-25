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
        if (player is null || player.Password != command.Password)
            throw new Exception("Username or password is wrong");

        return jwtProvider.Genrate(player);
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
