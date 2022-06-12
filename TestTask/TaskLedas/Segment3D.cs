using System;


namespace TaskLedas
{
    class Segment3D
    {
        private Vector3D _start;
        private Vector3D _end;
        /// <summary>
        /// return start point of segment
        /// </summary>
        public Vector3D Start
        {
            get => _start;
        }
        /// <summary>
        /// return end point of segment
        /// </summary>
        public Vector3D End
        {
            get => _end;
        }
        public Segment3D(Vector3D start, Vector3D end)
        {
            _start = start;
            _end = end;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>returns string of type $"start: x = {Start.X}; y = {Start.Y}; z = {Start.Z} \nend :x = {End.X}; y = {End.Y}; z = {End.Z}"</returns>
        public override string ToString()
        {
            return $"start: x = {_start.X}; y = {_start.Y}; z = {_start.Z} \nend :x = {_end.X}; y = {_end.Y}; z = {_end.Z}";
        }
        public double Length()
        {
            return (_end - _start).Magnitude();
        }
        /// <summary>
        /// Find intersection of segments or lines
        /// </summary>
        /// <param name="segment1"></param>
        /// <param name="segment2"></param>
        /// <param name="areLines"> set true if you want to find intersection for infinity lines</param>
        /// <param name="acc">accuracy</param>
        /// <returns>returns point of intersection as Vectror3D</returns>
        public static Vector3D Intersect(Segment3D segment1, Segment3D segment2, bool areLines = false, double acc = 0.00001)
        {
            // for understanding of variables names you need to look at scheme pdf on github
            //https://github.com/blblblblblblblblbl/TestTask/blob/main/scheme.pdf
            Vector3D p1 = segment1.Start;
            Vector3D p2 = segment1.End;
            Vector3D p3 = segment2.Start;
            Vector3D p4 = segment2.End;
            // fast check: vectors can't intersect because they are to far from each other
            if ((Math.Min(p1.X, p2.X) > Math.Max(p3.X, p4.X)) ||
                (Math.Min(p1.Y, p2.Y) > Math.Max(p3.Y, p4.Y)) ||
                (Math.Min(p1.Z, p2.Z) > Math.Max(p3.Z, p4.Z)) ||
                (Math.Max(p1.X, p2.X) < Math.Min(p3.X, p4.X)) ||
                (Math.Max(p1.Y, p2.Y) < Math.Min(p3.Y, p4.Y)) ||
                (Math.Max(p1.Z, p2.Z) < Math.Min(p3.Z, p4.Z)))
            {
                return null;
            }

            if ((segment1.Length() < acc) || (segment2.Length() < acc))
            {
                return null;
            }
            double d3134 = Vector3D.Dot(p1-p3,p4-p3);
            double d3412 = Vector3D.Dot(p4-p3,p2-p1);
            double d3112 = Vector3D.Dot(p1-p3,p2-p1);
            double d3434 = Vector3D.Dot(p4-p3,p4-p3);
            double d1212 = Vector3D.Dot(p2-p1,p2-p1);
            double div = (d1212 * d3434 - d3412 * d3412);
            if (div < acc)
            {
                return null;
            }
            double mua = (d3134 * d3412 - d3112 * d3434) / div;
            double mub = (d3134 + mua * d3412) / d3434;
            // for pa and pb to lie on segments, mua and mub can be only >=0 and <=1
            if ((!areLines) && (mua < 0 || mua > 1 || mub < 0 || mub > 1))
            {
                return null;
            }

            Vector3D pa = p1 + (p2 - p1) * mua;
            Vector3D pb = p3 + (p4 - p3) * mub;
            // check for computing error, let it be 10^-5 as default
            if ((pa - pb).Magnitude() > acc)
            {
                return null;
            }
#if debug
            Console.WriteLine(pa.ToString());
            Console.WriteLine(pb.ToString());
            Console.WriteLine((pb - pa).Length());
#endif
            return pa;
        }
    }
}