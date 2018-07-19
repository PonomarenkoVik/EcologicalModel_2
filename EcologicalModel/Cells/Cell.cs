using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcologicalModel.Cells;

namespace EcologicalModel
{
    abstract class Cell:ICloneable
    {
        protected static Ocean Ocean1;

#region Properties
        public char Image { get; protected set; }
        public Coordinate OffSet { get; protected set; }
#endregion

        protected Cell(Coordinate coord, char image = '-')
        {
            OffSet = (Coordinate)coord.Clone();
            Image = image;
        }

#region Member methods
        public virtual object Clone()
        {
            Cell result = (Cell)MemberwiseClone();
            result.OffSet = (Coordinate)OffSet.Clone();
            return result;
        }
#endregion


#region Static methods

        public static void Initialize()
        {
            Ocean1 = new Ocean();
            Ocean1.InitCells();
        }

        public static void Step()
        {
            Ocean1.Process();
        }

        protected static Coordinate GetEmptyNeighborCoord(Coordinate source)
        {
            Coordinate result = null;
            if (CheckCoordinate(source.X, (short)(source.Y - 1)) && Ocean1[new Coordinate(source.X, (byte)(source.Y - 1))] == null)
            {
                result = new Coordinate(source.X, (byte)(source.Y - 1));
            }

            if (result == null && CheckCoordinate(source.X, (short)(source.Y + 1)) && Ocean1[new Coordinate(source.X, (byte)(source.Y + 1))] == null)
            {
                result = new Coordinate(source.X, (byte)(source.Y + 1));
            }

            if (result == null && CheckCoordinate((short)(source.X + 1), source.Y) && Ocean1[new Coordinate((byte)(source.X + 1), source.Y)] == null)
            {
                result = new Coordinate((byte)(source.X + 1), source.Y);
            }

            if (result == null && CheckCoordinate((short)(source.X - 1), source.Y) && Ocean1[new Coordinate((byte)(source.X - 1), source.Y)] == null)
            {
                result = new Coordinate((byte)(source.X - 1), source.Y);
            }

            return result;
        }

        protected static Coordinate GetPreyNeighborCoord(Coordinate source)
        {
            Coordinate result = null;

            if (CheckCoordinate(source.X, (short)(source.Y - 1)))
            {
                Coordinate tempCoor = new Coordinate(source.X, (byte) (source.Y - 1));
                if (Ocean1[tempCoor] is Prey)
                {
                    result = tempCoor;
                }              
            }

            if (result == null && CheckCoordinate(source.X, (short)(source.Y + 1)))
            {
                Coordinate tempCoor = new Coordinate(source.X, (byte)(source.Y + 1));
                if (Ocean1[tempCoor] is Prey)
                {
                    result = tempCoor;
                }
            }

            if (result == null && CheckCoordinate((short)(source.X + 1), source.Y))
            {
                Coordinate tempCoor = new Coordinate((byte)(source.X + 1), source.Y);
                if (Ocean1[tempCoor] is Prey)
                {
                    result = tempCoor;
                }
            }

            if (result == null && CheckCoordinate((short)(source.X - 1), source.Y))
            {
                Coordinate tempCoor = new Coordinate((byte)(source.X - 1), source.Y);
                if (Ocean1[tempCoor] is Prey)
                {
                    result = tempCoor;
                }
            }

            return result;
        }

        protected static Coordinate GetSharkNeighborCoord(Coordinate source)
        {
            Coordinate result = null;

            if (CheckCoordinate(source.X, (short)(source.Y - 1)))
            {
                Coordinate tempCoor = new Coordinate(source.X, (byte)(source.Y - 1));
                if (Ocean1[tempCoor] is Shark)
                {
                    result = tempCoor;
                }
            }

            if (result == null && CheckCoordinate(source.X, (short)(source.Y + 1)))
            {
                Coordinate tempCoor = new Coordinate(source.X, (byte)(source.Y + 1));
                if (Ocean1[tempCoor] is Shark)
                {
                    result = tempCoor;
                }
            }

            if (result == null && CheckCoordinate((short)(source.X + 1), source.Y))
            {
                Coordinate tempCoor = new Coordinate((byte)(source.X + 1), source.Y);
                if (Ocean1[tempCoor] is Shark)
                {
                    result = tempCoor;
                }
            }

            if (result == null && CheckCoordinate((short)(source.X - 1), source.Y))
            {
                Coordinate tempCoor = new Coordinate((byte)(source.X - 1), source.Y);
                if (Ocean1[tempCoor] is Shark)
                {
                    result = tempCoor;
                }
            }

            return result;
        }

        private static bool CheckCoordinate(short x, short y)
        {
            return x < Ocean1.NumCols && y < Ocean1.NumRows && x >= 0 && y >= 0;
        }


        public static Ocean GetOcean()
        {
            return (Ocean)Ocean1.Clone();
        }

#endregion

    }
}
