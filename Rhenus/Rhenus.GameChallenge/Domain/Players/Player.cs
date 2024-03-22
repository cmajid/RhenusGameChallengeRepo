using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rhenus.GameChallenge.Domain.Players
{
    public class Player
    {
        private Player(PlayerId playerId, string username, int totalPoint)
        {
            Id = playerId;
            Username = username;
            TotalPoint = totalPoint;
        }

        public PlayerId Id { get; }
        public string Username { get; }
        public int TotalPoint { get; }

        public static Player Create(PlayerId playerId, string username, int totalPoint)
        {
            return new Player(playerId, username, totalPoint);
        }
    }
}