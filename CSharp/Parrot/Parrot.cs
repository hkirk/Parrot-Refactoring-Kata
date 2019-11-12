using System;

namespace Parrot
{
    public abstract class Parrot
    {
        protected readonly bool _isNailed;
        protected readonly int _numberOfCoconuts;
        protected readonly double _voltage;

        public Parrot(int numberOfCoconuts, double voltage, bool isNailed)
        {
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public static Parrot CreateParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot(type, numberOfCoconuts, voltage, isNailed);
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(type, numberOfCoconuts, voltage, isNailed);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(type, numberOfCoconuts, voltage, isNailed);
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
        public EuropeanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(numberOfCoconuts, voltage, isNailed)
        {
        }

        public override double GetSpeed() => GetBaseSpeed();
    }

    public class AfricanParrot : Parrot
    {
        public AfricanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(numberOfCoconuts, voltage, isNailed)
        {
        }

        public override double GetSpeed() => Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
    }

    public class NorwegianBlueParrot : Parrot
    {
        public NorwegianBlueParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(numberOfCoconuts, voltage, isNailed)
        {
            
        }

        public override double GetSpeed() => _isNailed ? 0 : GetBaseSpeed(_voltage);
    }
}