using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rhenus.GameChallenge.Application.Players.Commands;
using Rhenus.GameChallenge.Domain.Bets;
using Rhenus.GameChallenge.Domain.Players;
using Rhenus.GameChallenge.Domain.Players.Args;
using Rhenus.GameChallenge.Infrastructure.Authentication;

namespace Rhenus.GameChallenge.Application.Players;
public class AuthCommandHanlder(
    IPlayerRepository playerRepository,
    IJwtProvider jwtProvider)
{
    private const int defaultAccountValue = 10000;
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
            Account = defaultAccountValue
        }));
    }
}
