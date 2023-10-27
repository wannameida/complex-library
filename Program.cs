using System.ComponentModel.Design.Serialization;

namespace ComplexoCirculo;

// See https://aka.ms/new-console-template for more information

class Program {
    public static void Main(string[] args) {
        // int centroX = 500;
        // int centroY = 500;

        Complex numero1 = (4, 5);

        var valor = numero1;
        
        Console.WriteLine(valor.Arg + "\n");

        // int diameter = (int) numero1.AbsRoot(3) * 2 * 100;
        // e.Graphics.DrawEllipse(pen, centroX, centroY, diameter, diameter);

        foreach (var root in numero1.Sqrt) {
            Console.WriteLine($"abs: {root.Abs:F2}; arg: {root.ArgDegree:F2}");
            Console.WriteLine(root);
            Console.WriteLine(root.Pow(2));
            Console.WriteLine();
            
            // g.DrawLine(centroX, centroY, x, y);
        }
    }
}
