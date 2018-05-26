using System.Collections.Generic;

namespace Redc.Browser.Utils
{
    internal abstract class Tokenizer
    {
        private readonly string _source;

        private readonly Stack<int> _cols;

        private int _line;
        private int _col;
        private int _index;

        private char _current;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public Tokenizer(string source)
        {
            _source = source;

            _cols = new Stack<int>();

            _line = 1;
            _col = 1;
            _index = 0;

            _current = Symbols.Null;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Line
        {
            get { return _line; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Col
        {
            get { return _col; }
        }

        /// <summary>
        /// 
        /// </summary>
        public char Current
        {
            get { return _current; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected char Consume()
        {
            Advance();
            return _current;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Advance()
        {
            if (_current == Symbols.EndOfFileMarker)
            {
                return;
            }

            if (_current == Symbols.LineFeed)
            {
                _cols.Push(_col);
                _col = 1;
                _line += 1;
            }
            else
            {
                _col += 1;
            }

            _current = _source[_index++];
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Back()
        {
            if (_index <= 0)
            {
                return;
            }

            _index -= 1;

            if (_index == 0)
            {
                _col = 1;
                _current = Symbols.Null;
                return;
            }

            if (_source[_index] == Symbols.LineFeed)
            {
                _col = (_cols.Count > 0) ? _cols.Pop() : 1;
                _line -= 1;
            }
            else
            {
                _col -= 1;
            }

            _current = _source[_index];
        }
    }
}
