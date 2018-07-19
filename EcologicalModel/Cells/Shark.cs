using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel.Cells
{
    class Shark:Predator
    {
        public Shark(Coordinate coord, char predImage = 'S', byte timeToFeed = 12, byte timeToReproduce = 7) : base(coord, predImage, timeToFeed, timeToReproduce)
        {
        }


        public override void Process()
        {
            Processed = true;
            if (TimeToFeed == 0)
            {
                Ocean1[OffSet] = null;
                Ocean1.NumShark -= 1;
            }
            else
            {

                Coordinate foodCoord = GetPreyNeighborCoord(OffSet);
                Coordinate initCoord = (Coordinate)OffSet.Clone();
                if (foodCoord != null)
                {
                    if (Ocean1[foodCoord] is Tuna)
                    {
                        Ocean1.NumTuna -= 1;
                    }
                    else
                    {
                        Ocean1.NumStingray -= 1;
                    }

                    Ocean1.NumEaten += 1;
                    TimeToFeed = InitTimeToFeed;
                    MoveTo(initCoord, foodCoord);
                    if (TimeToReproduce == 0)
                    {
                        Reproduce(initCoord);
                    }
                }
                else
                {
                    Coordinate newCoord = GetEmptyNeighborCoord(OffSet);
                    TimeToFeed -= 1;
                    if (newCoord != null)
                    {
                        TimeToReproduce -= 1;
                        MoveTo(initCoord, newCoord);
                        if (TimeToReproduce == 0)
                        {
                            Reproduce(initCoord);
                        }
                    }
                }
            }
        }
        

        public override void Reproduce(Coordinate initCoord)
        {
            Ocean1.NumBornPredators += 1;
            TimeToReproduce = InitTimeToReproduce;
            Ocean1[initCoord] = new Shark(initCoord);
            Ocean1.NumShark += 1;
        }
    }
}
