using System;

namespace EmergentGameEngine.CharacterModel.Values
{
    public readonly struct Preference : IEquatable<Preference>, IComparable<Preference>
    {
        public Opinion Opinion => (Opinion)Math.Sign(_value);
        public int Magnitude => Math.Abs(_value);

        private readonly int _value;

        public Preference(Opinion opinion, int magnitude)
        {
            _value = (int)opinion * magnitude;
        }

        public override bool Equals(object obj)
        {
            return obj is Preference other && Equals(other);
        }

        public bool Equals(Preference other)
        {
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public int CompareTo(Preference other)
        {
            return other._value - _value;
        }

        public static bool operator ==(Preference a, Preference b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Preference a, Preference b)
        {
            return !a.Equals(b);
        }

        public static bool operator <(Preference a, Preference b)
        {
            return a._value < b._value;
        }

        public static bool operator >(Preference a, Preference b)
        {
            return a._value > b._value;
        }

        public static bool operator <=(Preference a, Preference b)
        {
            return a._value <= b._value;
        }

        public static bool operator >=(Preference a, Preference b)
        {
            return a._value >= b._value;
        }
    }
}
