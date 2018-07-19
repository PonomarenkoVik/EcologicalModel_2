using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    abstract class Predator : Cell, IMovable, IReproducable, IProcessable
    {

        public byte TimeToReproduce { get; set; }
        public bool Processed { get; set; }
        protected static byte InitTimeToReproduce;
        protected Predator(Coordinate coord,  char predImage, byte timeToFeed, byte timeToReproduce):base(coord, predImage)
        {
            TimeToReproduce = timeToReproduce;
            InitTimeToReproduce = timeToReproduce;
            TimeToFeed = timeToFeed;
            InitTimeToFeed = timeToFeed;
        }

        public abstract void Process();
        
        public abstract void Reproduce(Coordinate initCoord);
        
        public virtual void MoveTo(Coordinate initCoord, Coordinate newCoord)
        {
            OffSet = (Coordinate)newCoord.Clone();
            Ocean1[newCoord] = (Cell)Clone();
            Ocean1[initCoord] = null;
        }
        protected static byte InitTimeToFeed;
        protected byte TimeToFeed;
    }
}
