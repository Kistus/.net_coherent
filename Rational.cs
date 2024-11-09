public sealed class Rational : IComparable<Rational>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public Rational(int numerator, int denominator)
    {
        if (denominator == 0) { 
        throw new ArgumentException("cannot be zero.");
        }

        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        Numerator = numerator / gcd;
        Denominator = denominator / gcd;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

   private static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);


    public override bool Equals(object obj)
    {
        return obj is Rational other &&
               Numerator == other.Numerator &&
               Denominator == other.Denominator;
    }

    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public override string ToString() => $"{Numerator}/{Denominator}";

    public int CompareTo(Rational other) =>
        (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);

    public static Rational operator +(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

    public static Rational operator -(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);

    public static Rational operator *(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static Rational operator /(Rational r1, Rational r2)
    {
        if (r2.Numerator == 0) throw new DivideByZeroException("forbidden divide by zero.");
        return new(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
    }

    public static explicit operator double(Rational r) => (double)r.Numerator / r.Denominator;

    public static implicit operator Rational(int value) => new(value, 1);
}
