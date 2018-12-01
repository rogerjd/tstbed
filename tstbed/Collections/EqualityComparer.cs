using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tstbed.Collections
{

    class Box
    {
        public int Height { get; }
        public int Length { get; }
        public int Width { get; }

        public int Volume => Height * Width * Length;
    }

    class BoxVolume : EqualityComparer<Box>
    {
        public override bool Equals(Box x, Box y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (x is null || y is null)
            {
                return false;
            }

            return x.Volume == y.Volume;
        }

        public override int GetHashCode(Box obj) => obj.Volume.GetHashCode();
    }
}
