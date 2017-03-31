namespace WarMachines.Tests
{
    using Interfaces;
    using Machines;
    using Machines.Mocks;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MachinesTests
    {
        [Test]
        public void Constructor_WhenThePassedParametersAreValid_ShouldAssignToTheProperFieldsCorrectly()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;

            // act
            var machine = new MachineMock(name,healthPoints,attPoints,defPoints);

            // assert
            Assert.AreEqual(name,machine.Name);
            Assert.AreEqual(healthPoints, machine.HealthPoints);
            Assert.AreEqual(attPoints, machine.AttackPoints);
            Assert.AreEqual(defPoints, machine.DefensePoints);

        }

        [Test]
        public void Constructor_WhenThePassedParametersAreValid_ShouldAssignTargetsListCorrectly()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;

            // act
            var machine = new MachineMock(name, healthPoints, attPoints, defPoints);

            // assert
            Assert.IsNotNull(machine.Targets);

        }

        [Test]
        public void SetAttackPoints_WhenThePassedParameterIsValid_ShouldAssignToTheProperFieldCorrectly()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;
                        
            var machine = new MachineMock(name, healthPoints, attPoints, defPoints);
            double anotherAttPoints = 10;
            
            // act
            machine.SetAttackPoints(anotherAttPoints);

            // assert
            Assert.AreEqual(anotherAttPoints, machine.AttackPoints);

        }

        [Test]
        public void SetPilot_WhenThePassedParameterIsValid_ShouldAssignToTheProperFieldCorrectly()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;

            var machine = new MachineMock(name, healthPoints, attPoints, defPoints);
            var pilot = new Mock<IPilot>();

            // act
            machine.Pilot = pilot.Object;

            // assert
            Assert.AreSame(pilot.Object, machine.Pilot);

        }

        [Test]
        public void SetPilot_WhenThePassedParameterIsInvalid_ShouldThrowArgumentNullException()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;

            var machine = new MachineMock(name, healthPoints, attPoints, defPoints);

            // act & assert
            Assert.Throws<ArgumentNullException>(() => machine.Pilot = null);
            
        }

        [Test]
        public void SetPilot_WhenThePassedParameterIsInvalid_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            // arrange
            string name = "validName";
            double healthPoints = 5;
            double attPoints = 5;
            double defPoints = 5;

            var machine = new MachineMock(name, healthPoints, attPoints, defPoints);

            // act & assert
            Assert.That(() => machine.Pilot = null,Throws.ArgumentNullException.With.Message.Contains("Pilot"));

        }
    }
}
