using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowersOfHanoi
{
    enum PositionName { SOURCE,AUXILARY,DESTIONATION};
    class Position
    {
        PositionName _source;
        PositionName _auxilary;
        PositionName _destination;
        public PositionName Source
        {
            get{
                return _source;
            }
            set{
             this._source=value;
            }
        }
        public PositionName Auxilary
        {
            get
            {
                return _auxilary;
            }
            set
            {
                this._auxilary = value;
            }
        }
        public PositionName Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                this._destination = value;
            }
        }

        public override string ToString()
        {
            return "\n \t Position { Source:" + Source + ", Auxilary: " + Auxilary + ", Destination: " + Destination+" }" ;
        }
    }

}
