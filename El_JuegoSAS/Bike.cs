using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_JuegoSAS
{
    public class Bike
    {
        public FrontWheel FrontWheel { get; set; }
        public BackWheel BackWheel { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Muffler Muffler { get; set; }

        public double Speed { get; set; }
        public double Acceleration { get; set; }
        public double Handling { get; set; }
        public double Grip { get; set; }

        public Bike()
        {
            Chassis = new Chassis();
            Speed = Acceleration = Handling = Grip = 1.0;
        }

        public bool CanBeUsedInRace()
        {
            // Verificar que la moto tenga todas las partes necesarias y que ningún parámetro sea 0.0
            return FrontWheel != null && BackWheel != null && Chassis != null && Engine != null && Muffler != null &&
                   Speed > 0.0 && Acceleration > 0.0 && Handling > 0.0 && Grip > 0.0;
        }

        public void EquipPart(Part part)
        {
            // Implementar lógica para equipar una parte y actualizar los parámetros
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part), "Part cannot be null");
            }

            if (part is FrontWheel)
            {
                FrontWheel = part as FrontWheel;
            }
            else if (part is BackWheel)
            {
                BackWheel = part as BackWheel;
            }
            else if (part is Engine)
            {
                Engine = part as Engine;
            }
            else if (part is Muffler)
            {
                Muffler = part as Muffler;
            }
            else
            {
                throw new InvalidOperationException("Cannot equip this part");
            }

            CalculateParameters();
        }

        public void RemovePart(Part part)
        {
            if (part == null)
            {
                throw new ArgumentNullException(nameof(part), "Part cannot be null");
            }

            if (part == FrontWheel)
            {
                FrontWheel = null;
            }
            else if (part == BackWheel)
            {
                BackWheel = null;
            }
            else if (part == Engine)
            {
                Engine = null;
            }
            else if (part == Muffler)
            {
                Muffler = null;
            }

            CalculateParameters();
        }

        private void CalculateParameters()
        {
            double totalSpeed = (Engine?.SpeedModifier ?? 0.0) + (FrontWheel?.SpeedModifier ?? 0.0) + (BackWheel?.SpeedModifier ?? 0.0);
            double totalAcceleration = (Engine?.AccelerationModifier ?? 0.0) + (FrontWheel?.AccelerationModifier ?? 0.0) + (BackWheel?.AccelerationModifier ?? 0.0) + (Muffler?.AccelerationModifier ?? 0.0);
            double totalHandling = Chassis?.HandlingModifier ?? 0.0;
            double totalGrip = (FrontWheel?.GripModifier ?? 0.0) + (BackWheel?.GripModifier ?? 0.0);

            Speed = Math.Max(1.0, totalSpeed + 1.0);
            Acceleration = Math.Max(1.0, totalAcceleration + 1.0);
            Handling = Math.Max(1.0, totalHandling + 1.0);
            Grip = Math.Max(1.0, totalGrip + 1.0);
        }
    }

    public abstract class Part
    {
        public double SpeedModifier { get; protected set; }
        public double AccelerationModifier { get; protected set; }
        public double HandlingModifier { get; protected set; }
        public double GripModifier { get; protected set; }
    }

    // Clases para las partes concretas (FrontWheelPart, BackWheelPart, etc.) que heredan de Part.

    public class FrontWheel : Part
    {
        public FrontWheel()
        {
            SpeedModifier = 1.0;
            AccelerationModifier = 0.5;
            HandlingModifier = 1.0;
            GripModifier = 1.0;
        }
    }

    public class BackWheel : Part
    {
        public BackWheel()
        {
            SpeedModifier = 1.0;
            AccelerationModifier = 0.5;
            HandlingModifier = 1.0;
            GripModifier = 1.0;
        }
    }

    public class Chassis : Part
    {
        public Chassis()
        {
            SpeedModifier = 0.0;
            AccelerationModifier = 0.0;
            HandlingModifier = 0.0;
            GripModifier = 0.0;
        }
    }

    public class Engine : Part
    {
        public Engine()
        {
            SpeedModifier = 2.0;
            AccelerationModifier = 1.0;
            HandlingModifier = 1.0;
            GripModifier = 1.0;
        }
    }

    public class Muffler : Part
    {
        public Muffler()
        {
            SpeedModifier = 0.0;
            AccelerationModifier = 0.5;
            HandlingModifier = 0.0;
            GripModifier = 0.0;
        }
    }

}
