using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowersOfHanoi
{
    class Node
    {
        Position _first;
        public Position First   
        {
            get
            {
                return _first;
            }
            set
            {
                this._first = value;
            }
        }
        Position _middle;
        public Position Middle
        {
            get
            {
                return _middle;
            }
            set
            {
                this._middle = value;
            }
        }
        Position _last;
        public Position Last
        {
            get
            {
                return _last;
            }
            set
            {
                this._last = value;
            }
        }
        int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                this._size = value;
            }
        }
        public override string ToString()
        {
            return "\n Node Size: " + Size + " [ \n First:" + First + " \n Middle: " + Middle + "\n Last: " + Last + " ]";
        }

    }
}
