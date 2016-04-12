using System.Collections.Generic;
using System.Drawing;

namespace PingPong2
{
    public class AreaSelection : Selection
    {
        public List<Unit> SelectedUnits { get; }

        public AreaSelection(int Radius)
        {
            Point Center = Point.Empty;
            SelectedUnits = new List<Unit>();
            List<Unit> AllUnits = Unit.GetAllUnits();
            foreach (var unit in AllUnits)
            {
                int dx = unit.Position.X - Center.X;
                int dy = unit.Position.Y - Center.Y;
                if (dx * dx + dy * dy <= Radius * Radius)
                    SelectedUnits.Add(unit);
            }
        }
    }
}