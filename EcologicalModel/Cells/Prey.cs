using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcologicalModel
{
    abstract class Prey:Cell,IMovable,IReproducable,IProcessable
    {
        public byte TimeToReproduce { get; set; }
        public bool Processed { get; set; }
        protected static byte InitTimeToReproduce ;

        protected Prey(Coordinate coord, byte timeToReproduce, char prayImage):base(coord, prayImage)
        {
            TimeToReproduce = timeToReproduce;
            InitTimeToReproduce = timeToReproduce;
            Processed = false;
        }

       
#region

        public abstract void Process();
        
        public virtual void MoveTo(Coordinate initCoord, Coordinate newCoord)
        {
            OffSet = (Coordinate)newCoord.Clone();      
            Ocean1[newCoord] = (Cell)Clone();
            Ocean1[initCoord] = null;
        }

        public abstract void Reproduce(Coordinate initCoord);

        #endregion

    }
}
