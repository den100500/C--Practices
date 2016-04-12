using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong2
{
    public class Team
    {
        int TeamNumber { get; }

        public static bool AreAllies(Unit u1, Unit u2)
        {
            return u1.Team.TeamNumber == u2.Team.TeamNumber;
        }

        public static bool AreEnemies(Unit u1, Unit u2)
        {
            return u1.Team.TeamNumber != u2.Team.TeamNumber;
        }
    }
}