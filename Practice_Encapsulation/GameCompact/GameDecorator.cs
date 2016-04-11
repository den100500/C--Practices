using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameCompact
{
    public class GameDecorator
    {
        Game game;
        Dictionary<int, Point> shifts;

        public GameDecorator(Game game)
        {
            this.game = game;
            shifts = new Dictionary<int, Point>();
        }

        public GameDecorator(GameDecorator source)
        {
            game = source.game;
            shifts = new Dictionary<int, Point>();
            foreach (var pair in source.shifts)
                shifts.Add(pair.Key, pair.Value);
        }

        public int this[int x, int y]
        {
            get
            {
                if (y < 0 || y >= game.fieldSize || x < 0 || x >= game.fieldSize)
                    throw new IndexOutOfRangeException();
                var shift = shifts.Where(s => s.Value.X == x && s.Value.Y == y);
                return shift.Count() == 0 ? game[x, y] : shift.Last().Key;
            }
        }

        public Point GetLocation(int value)
        {
            if (value < 0 || value >= game.fieldSize * game.fieldSize)
                throw new ArgumentOutOfRangeException();
            var locations = shifts.Where(s => s.Key == value);
            return locations.Count() == 0 ? game.GetLocation(value) : locations.Last().Value;
        }

        public GameDecorator Shift(int value)
        {
            if (value <= 0 || value >= game.fieldSize * game.fieldSize)
                throw new ArgumentOutOfRangeException();

            Point p1 = GetLocation(0);
            Point p2 = GetLocation(value);
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            if (Math.Abs(dx) == 1 ^ Math.Abs(dy) == 1)
            {
                GameDecorator decorator = new GameDecorator(this);
                decorator.shifts.Add(value, GetLocation(0));
                decorator.shifts.Add(0, GetLocation(value));
                return decorator;
            }
            else
                throw new InvalidOperationException();
        }
    }
}