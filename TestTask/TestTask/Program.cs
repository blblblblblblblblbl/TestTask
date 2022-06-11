using System;


namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D start1 = new Vector3D(0, 2, 0);
            Vector3D end1 = new Vector3D(5, -2, 0);
            Vector3D start2 = new Vector3D(0, 0, 0);
            Vector3D end2 = new Vector3D(5, 1, 0);
            Segment3D segment1 = new Segment3D(start1, end1);
            Segment3D segment2 = new Segment3D(start2, end2);
            Vector3D intersection = Segment3D.Intersect(segment1, segment2);
            if (intersection == null)
            {
                Console.WriteLine("segments don't intersect");
            }
            else
            {
                Console.WriteLine(intersection.ToString());
            }
            Console.ReadKey();
        }
    }
}
