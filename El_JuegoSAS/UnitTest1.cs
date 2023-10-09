using NUnit.Framework;
using System;

namespace El_JuegoSAS
{
    public class Tests
    {
        private Bike bike;

        [SetUp]
        public void SetUp()
        {
            bike = new Bike(); // Crea una nueva moto para cada prueba

            // Inicializar las partes de la moto
            bike.FrontWheel = new FrontWheel();
            bike.BackWheel = new BackWheel();
            bike.Chassis = new Chassis();
            bike.Engine = new Engine();
            bike.Muffler = new Muffler();
        }

        [Test]
        public void BikeCanBeCreated()
        {
            // Verificar que una moto pueda ser creada correctamente
            Assert.NotNull(bike);
        }

        [Test]
        public void BikesCanBeUsed()
        {
            // Verificar que una selección de motos puede ser usada o no en una carrera

            // Una moto con todas sus partes debe ser usable
            Assert.IsTrue(bike.CanBeUsedInRace());

            // Quitar el motor y verificar que la moto no sea usable
            bike.RemovePart(bike.Engine);
            Assert.IsFalse(bike.CanBeUsedInRace());

            // Quitar la llanta trasera y verificar que la moto no sea usable
            bike.RemovePart(bike.BackWheel);
            Assert.IsFalse(bike.CanBeUsedInRace());

            // Quitar el mofle y verificar que la moto no sea usable
            bike.RemovePart(bike.Muffler);
            Assert.IsFalse(bike.CanBeUsedInRace());
        }

        [Test]
        public void PartCanBeAdded()
        {
            // Verificar que una selección de partes puede ser agregada a una selección de motos según las condiciones especificadas

            // Crear una moto sin llanta delantera y equipar una llanta delantera sin problemas.
            var frontWheel = new FrontWheel();
            bike.EquipPart(frontWheel);
            Assert.AreEqual(bike.FrontWheel, frontWheel);

            // Crear una moto con llanta trasera y equipar la llanta trasera nueva reemplazando la anterior.
            var backWheel1 = new BackWheel();
            var backWheel2 = new BackWheel();
            bike.EquipPart(backWheel1);
            bike.EquipPart(backWheel2);
            Assert.AreEqual(bike.BackWheel, backWheel2);

            // Crear una moto sin mofle y equipar el mofle.
            var muffler = new Muffler();
            bike.RemovePart(bike.Muffler);
            bike.EquipPart(muffler);
            Assert.AreEqual(bike.Muffler, muffler);

            // Intentar reemplazar el chasis, lo que no debe ser posible.
            var chassis = new Chassis();
            Assert.Throws<InvalidOperationException>(() => bike.EquipPart(chassis));
        }

        [Test]
        public void PartsModifyParameters()
        {
            // Verificar que la adición de partes modifica los parámetros según se especifica

            // Crear una moto sin partes y probar el valor inicial de los parámetros
            Assert.AreEqual(1.0, bike.Speed);
            Assert.AreEqual(1.0, bike.Acceleration);
            Assert.AreEqual(1.0, bike.Handling);
            Assert.AreEqual(1.0, bike.Grip);

            // Crear partes con modificación de parámetros 0.
            var frontWheel = new FrontWheel();
            var engine = new Engine();
            var muffler = new Muffler();

            // Agregar partes a la moto y probar los valores de cada parámetro
            bike.EquipPart(frontWheel);
            bike.EquipPart(engine);
            bike.EquipPart(muffler);

            Assert.AreEqual(2.0, bike.Speed); // (1.0 + 1.0 de engine)
            Assert.AreEqual(1.5, bike.Acceleration); // (1.0 + 0.5 de frontWheel + 0.5 de muffler)
            Assert.AreEqual(1.0, bike.Handling); // No se modifica
            Assert.AreEqual(1.0, bike.Grip); // No se modifica

            // Completar todas las partes y verificar que todos los parámetros satisfagan los valores según la descripción
            var backWheel = new BackWheel();
            var chassis = new Chassis();

            bike.EquipPart(backWheel);
            bike.EquipPart(chassis);

            Assert.AreEqual(6.0, bike.Speed); // (1.0 + 1.0 de engine + 1.0 de backWheel + 3.0 de chassis)
            Assert.AreEqual(4.0, bike.Acceleration); // (1.0 + 0.5 de frontWheel + 0.5 de muffler + 0.5 de backWheel + 1.5 de chassis)
            Assert.AreEqual(1.0, bike.Handling); // No se modifica
            Assert.AreEqual(1.0, bike.Grip); // No se modifica
        }

        [Test]
        public void MaxParameterValueOnConstructor()
        {
            // Verificar que el valor que agrega cada parte a la moto se inicialice correctamente al crear una instancia de cada parte

            var frontWheel = new FrontWheel();
            var backWheel = new BackWheel();
            var chassis = new Chassis();
            var engine = new Engine();
            var muffler = new Muffler();

            Assert.AreEqual(1.0, frontWheel.SpeedModifier);
            Assert.AreEqual(0.5, frontWheel.AccelerationModifier);
            Assert.AreEqual(1.0, frontWheel.HandlingModifier);
            Assert.AreEqual(1.0, frontWheel.GripModifier);

            Assert.AreEqual(1.0, backWheel.SpeedModifier);
            Assert.AreEqual(0.5, backWheel.AccelerationModifier);
            Assert.AreEqual(1.0, backWheel.HandlingModifier);
            Assert.AreEqual(1.0, backWheel.GripModifier);

            Assert.AreEqual(0.0, chassis.SpeedModifier);
            Assert.AreEqual(0.0, chassis.AccelerationModifier);
            Assert.AreEqual(0.0, chassis.HandlingModifier);
            Assert.AreEqual(0.0, chassis.GripModifier);

            Assert.AreEqual(2.0, engine.SpeedModifier);
            Assert.AreEqual(1.0, engine.AccelerationModifier);
            Assert.AreEqual(1.0, engine.HandlingModifier);
            Assert.AreEqual(1.0, engine.GripModifier);

            Assert.AreEqual(0.0, muffler.SpeedModifier);
            Assert.AreEqual(0.5, muffler.AccelerationModifier);
            Assert.AreEqual(0.0, muffler.HandlingModifier);
            Assert.AreEqual(0.0, muffler.GripModifier);
        }
    }
}