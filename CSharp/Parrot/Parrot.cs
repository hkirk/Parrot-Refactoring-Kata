using System;

namespace Parrot
{
    public abstract class Parrot
    {
        protected readonly int _numberOfCoconuts;

        public Parrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public static Parrot CreateParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot(numberOfCoconuts);
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(numberOfCoconuts, voltage, isNailed);
            }
            throw new Exception("Should be unreachable");
        }

        public abstract double GetSpeed();

        protected double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        protected double GetLoadFactor()
        {
            return 9.0;
        }

        protected double GetBaseSpeed()
        {
            return 12.0;
        }
    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot(int numberOfCoconuts) : base(numberOfCoconuts)
        {
        }

        public override double GetSpeed() => GetBaseSpeed();
    }

    public class AfricanParrot : Parrot
    {
        public AfricanParrot(int numberOfCoconuts) : base(numberOfCoconuts)
        {
        }

        public override double GetSpeed() => Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
    }

    public class NorwegianBlueParrot : Parrot
    {
        private readonly bool _isNailed;
        protected readonly double _voltage;

        public NorwegianBlueParrot(int numberOfCoconuts, double voltage, bool isNailed) : base(numberOfCoconuts)
        {
            _isNailed = isNailed;
            _voltage = voltage;
        }

        public override double GetSpeed() => _isNailed ? 0 : GetBaseSpeed(_voltage);
    }
}