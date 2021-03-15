using System;
using System.Collections.Generic;
using System.Text;

namespace cv6
{
    public abstract class Objekt3D : GrObjekt
    {
        public abstract double SpoctiPovrch();
        public abstract double SpoctiObjem();
    }
}
