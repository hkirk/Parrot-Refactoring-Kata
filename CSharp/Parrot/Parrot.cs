using System;

namespace Parrot
{
    public abstract class Parrot
    {
        private readonly bool _isNailed;
        private readonly int _numberOfCoconuts;
        private readonly ParrotTypeEnum _type;
        private readonly double _voltage;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
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

        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return GetBaseSpeed();
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, GetBaseSpeed() - GetLoadFactor() * _numberOfCoconuts);
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return _isNailed ? 0 : GetBaseSpeed(_voltage);
            }

            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }

        private double GetBaseSpeed()
        {
            return 12.0;
        }
    }

    public class EuropeanParrot : Parrot
    {
        public EuropeanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(type, numberOfCoconuts, voltage, isNailed)
        {
        }
    }

    public class AfricanParrot : Parrot
    {
        public AfricanParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(type, numberOfCoconuts, voltage, isNailed)
        {
        }
    }

    public class NorwegianBlueParrot : Parrot
    {
        public NorwegianBlueParrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed) : base(type, numberOfCoconuts, voltage, isNailed)
        {
            
        }
    }
}