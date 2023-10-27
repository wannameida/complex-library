namespace ComplexoCirculo;

public readonly struct Complex {
    public readonly double real;
    public readonly double imaginary;

    public Complex(double real, double imaginary) {
        this.real = real;
        this.imaginary = imaginary;
    }

    public (double x, double y) Point {
        get => (real, imaginary);
    }

    public static Complex FromPolar(double abs, double arg) {
        return new Complex(abs * Math.Cos(arg),
                           abs * Math.Sin(arg));
    }

    public (double abs, double arg) Polar => (Abs, Arg);

    public double Abs => Math.Sqrt(real * real + imaginary * imaginary);

    public double Arg {
        get {
            var arg = Math.Atan2(imaginary, real);
            return arg >= 0 ? arg : arg + Math.PI * 2;
        }
    }

    public double ArgDegree => Arg * 180 / Math.PI;  

    public double AbsRoot(uint n) => Math.Pow(Abs, 1d / n);

    public IEnumerable<Complex> Sqrt {
        get {
            var polar = Polar;
            List<Complex> list = new(2);

            var abs = Math.Sqrt(polar.abs);
            
            list.Add(FromPolar(abs, polar.arg / 2));
            list.Add(FromPolar(abs, polar.arg / 2 + Math.PI));

            return list; 
        }
    }

    public IEnumerable<Complex> Root(uint n) {
        var polar = Polar;
        var abs = Math.Pow(polar.abs, 1d / n);

        for (int i = 0; i < n; i++) {
            var theta = (polar.arg / n) + ((Math.PI * 2 * i) / n);
            yield return FromPolar(abs, theta);
        }
    }

    public Complex Pow(uint n) {
        var polar = Polar;
        var abs = Math.Pow(polar.abs, n);
        var theta = polar.arg * n;

        return FromPolar(abs, theta);
    }

    public Complex Conjugate => new(real, -imaginary);

    public static implicit operator Complex((double, double) point) {
        return new Complex(point.Item1, point.Item2);
    }

    public static explicit operator Complex(double real) {
        return new Complex(real, 0);
    }

    public static explicit operator (double, double)(Complex c) {
        return (c.real, c.imaginary);
    }

    public static Complex operator +(Complex a, Complex b) {
        return new Complex(a.real + b.real, a.imaginary + b.imaginary);
    }

    public static Complex operator -(Complex a, Complex b) {
        return new Complex(a.real - b.real, a.imaginary - b.imaginary);
    }

    public static Complex operator *(Complex a, Complex b) {
        return new Complex(a.real * b.real - a.imaginary * b.imaginary,
                           a.real * b.imaginary + a.imaginary * b.real);
    }

    public static Complex operator /(Complex a, Complex b) {
        double denominator = b.real * b.real + b.imaginary * b.imaginary;
        return new Complex((a.real * b.real + a.imaginary * b.imaginary) / denominator,
                           (a.imaginary * b.real - a.real * b.imaginary) / denominator);
    }

    public static Complex operator -(Complex a) {
        return new Complex(-a.real, -a.imaginary);
    }

    public static bool operator ==(Complex a, Complex b) {
        return a.real == b.real && a.imaginary == b.imaginary;
    }

    public static bool operator !=(Complex a, Complex b) {
        return a.real != b.real || a.imaginary != b.imaginary;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(real, imaginary);
    }

    public override bool Equals(object? obj)
    {
        if (obj is Complex c) {
            return this == c;
        }

        return false;
    }

    public override string ToString()
    {
        if (imaginary == 0 && real == 0) {
            return "0";
        } else if (imaginary == 0) {
            return $"{real:F2}";
        } else if (real == 0) {
            return $"{imaginary:F2}i";
        } else if (imaginary > 0) {
            return $"{real:F2} + {imaginary:F2}i";
        } else if (imaginary < 0) {
            return $"{real:F2} - {-imaginary:F2}i";
        } else {
            return "0";
        }
    }
}
