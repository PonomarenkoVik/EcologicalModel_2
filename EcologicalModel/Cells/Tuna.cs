using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel.Cells
{
    class Tuna:Prey
    {
        public Tuna(Coordinate coord, byte timeToReproduce = 4, char prayImage = 't') : base(coord, timeToReproduce, prayImage)
        {
        }

        public override void Process()
        {
            Processed = true;
            Coordinate newCoord = GetEmptyNeighborCoord(OffSet);
            Coordinate initCoord = (Coordinate)OffSet.Clone();
            if (newCoord != null)
            {
                if (TimeToReproduce > 0)
                {
                    TimeToReproduce -= 1;
                }

                MoveTo(initCoord, newCoord);

                if (TimeToReproduce == 0)
                {
                    TimeToReproduce = InitTimeToReproduce;
                    Reproduce(initCoord);
                }
            }
        }


        public override void Reproduce(Coordinate initCoord)
        {
            Ocean1.NumBornPrey += 1;
            Ocean1[initCoord] = new Tuna(initCoord);
            Ocean1.NumTuna += 1;
        }

    }
}
