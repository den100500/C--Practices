using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameCompact
{
    public class Game
    {
        public readonly int fieldSize;
        int[,] gameField;
        public readonly Point[] locations;

        Game(int fieldSize, int[] values)
        {
            this.fieldSize = fieldSize;
            gameField = new int[fieldSize, fieldSize];
            locations = new Point[fieldSize * fieldSize];
            for (int y = 0; y < fieldSize; y++)
                for (int x = 0; x < fieldSize; x++)
                {
                    gameField[y, x] = values[y * fieldSize + x];
                    locations[gameField[y, x]] = new Point(x, y);
                }
        }

        Game(Game source)
        {
            fieldSize = source.fieldSize;
            gameField = new int[fieldSize, fieldSize];
            for (int y = 0; y < fieldSize; y++)
                for (int x = 0; x < fieldSize; x++)
                    gameField[y, x] = source.gameField[y, x];
            locations = new Point[fieldSize * fieldSize];
            source.locations.CopyTo(locations, 0);
        }

        public static Game Create(params int[] values)
        {
            int fieldSize = (int)Math.Sqrt(values.Length);
            if (fieldSize * fieldSize != values.Length)
                throw new Exception();
            else
            {
                SortedSet<int> containedValues = new SortedSet<int>();
                for (int i = 0; i < values.Length; i++)
                {

                    if (values[i] < 0 || values[i] >= values.Length)
                        throw new Exception();
                    if (containedValues.Contains(values[i]))
                        throw new Exception();
                    else
                        containedValues.Add(values[i]);
                }
            }
            return new Game(fieldSize, values);
        }

        public int this[int x, int y]
        {
            get
            {
                if (y < 0 || y >= fieldSize || x < 0 || x >= fieldSize)
                    throw new IndexOutOfRangeException();
                return gameField[y, x];
            }
        }

        public Point GetLocation(int value)
        {
            if (value < 0 || value >= fieldSize * fieldSize)
                throw new ArgumentOutOfRangeException();
            return locations[value];
        }

        public GameDecorator Shift(int value)
        {
            if (value <= 0 || value >= fieldSize * fieldSize)
                throw new ArgumentOutOfRangeException();

            int dx = locations[0].X - locations[value].X;
            int dy = locations[0].Y - locations[value].Y;
            if (Math.Abs(dx) == 1 ^ Math.Abs(dy) == 1)
            {
                GameDecorator decorator = new GameDecorator(this);
                return decorator.Shift(value);
            }
            else
                throw new InvalidOperationException();
        }
    }
}