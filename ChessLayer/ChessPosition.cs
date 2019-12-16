using System;
using BoardLayer;

namespace ChessLayer
{
    class ChessPosition
    {
        public char Column { get; private set; }
        public int Line { get; private set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(8 - Line, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
