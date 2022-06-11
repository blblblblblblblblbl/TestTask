using System;


namespace TestTask
{
    class Segment3D
    {
        private Vector3D _start;
        private Vector3D _end;

        public Vector3D Start
        {
            get => _start;
        }
        public Vector3D End
        {
            get => _end;
        }
        public Segment3D(Vector3D start, Vector3D end)
        {
            _start = start;
            _end = end;
        }

        public override string ToString()
        {
            return
                $"start: x = {_start.X}; y = {_start.Y}; z = {_start.Z} \nend :x = {_end.X}; y = {_end.Y}; z = {_end.Z}";
        }
        public double Legth()
        {
            return (_end - _start).Legth();
        }
        public static double Dot(Segment3D seg1, Segment3D seg2)
        {
            return (seg1.End.X - seg1.Start.X) * (seg2.End.X - seg2.Start.X) +
                   (seg1.End.Y - seg1.Start.Y) * (seg2.End.Y - seg2.Start.Y) +
                   (seg1.End.Z - seg1.Start.Z) * (seg2.End.Z - seg2.Start.Z);
        }
        public static Vector3D Intersect(Segment3D segment1, Segment3D segment2, bool areLines = false, double acc = 0.00001)
        {
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

            if ((segment1.Legth() < double.Epsilon) || (segment2.Legth() < double.Epsilon))
            {
                return null;
            }

            double d3134 = Dot(new Segment3D(p3, p1), new Segment3D(p3, p4));
            double d3412 = Dot(new Segment3D(p3, p4), new Segment3D(p1, p2));
            double d3112 = Dot(new Segment3D(p3, p1), new Segment3D(p1, p2));
            double d3434 = Dot(new Segment3D(p3, p4), new Segment3D(p3, p4));
            double d1212 = Dot(new Segment3D(p1, p2), new Segment3D(p1, p2));
            double div = (d1212 * d3434 - d3412 * d3412);
            if (div < double.Epsilon)
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
            if ((pa - pb).Legth() > acc)
            {
                return null;
            }
#if debug
            Console.WriteLine(pa.ToString());
            Console.WriteLine(pb.ToString());
            Console.WriteLine((pb - pa).Legth());
#endif
            return pa;
        }
    }
}