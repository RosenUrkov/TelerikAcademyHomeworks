namespace WarMachines.Tests.Engine
{
    using NUnit.Framework;
    using Moq;
    using WarMachines.Engine;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class WarMachineEngineTests
    {
        private WarMachineEngine engine = WarMachineEngine.Instance;

        [SetUp]
        public void InitializeCollections()
        {
            engine.Pilots = new Dictionary<string, IPilot>();
            engine.Machines = new Dictionary<string, IMachine>();
            
        }

        [Test]
        public void InstanceGet_WhenTheInstanceIsCreatedCorrectly_ShouldReturnEngineInstance()
        {            
            // assert
            Assert.IsInstanceOf<WarMachineEngine>(this.engine);
        }

        [Test]
        public void InstanceGet_WhenTheSingletonIsCreatedCorrectly_ShouldReturnTheSameEngineInstance()
        {
            // arrange & act           
            var sameEngine = WarMachineEngine.Instance;

            // assert
            Assert.AreSame(this.engine, sameEngine);
        }

        [Test]
        public void InstanceGet_WhenTheInstanceIsCreatedCorrectly_ShouldInitializeFactoryFieldCorrectly()
        {
            // arrange & act            
            var privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(engine);
            var factory = privateObject.GetField("factory");

            // assert
            Assert.IsNotNull(factory);
        }

        [Test]
        public void InstanceGet_WhenTheInstanceIsCreatedCorrectly_ShouldInitializePilotsDictionaryCorrectly()
        {
            // arrange & act
            var engine = WarMachineEngine.Instance;
            var privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(engine);
            var pilotsDIctionary = privateObject.GetField("pilots");

            // assert
            Assert.IsNotNull(pilotsDIctionary);
        }

        [Test]
        public void InstanceGet_WhenTheInstanceIsCreatedCorrectly_ShouldInitializeMachinesDictionaryCorrectly()
        {
            // arrange & act
            var engine = WarMachineEngine.Instance;
            var privateObject = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(engine);
            var machinesDIctionary = privateObject.GetField("machines");

            // assert
            Assert.IsNotNull(machinesDIctionary);
        }

        [Test]
        public void Start_WithCommandThatIndicatesHirePilot_ShouldAddThePilotToThePilotsCollection()
        {
            var parametersList = new List<string>() { "Name" };
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("HirePilot");
            mockedCommand.Setup(x => x.Parameters).Returns(parametersList);

            var commandsList = new List<ICommand>() { mockedCommand.Object }; 
            var mockedCommandParser = new Mock<ICommandParser>();
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(commandsList);

            var mockedPilot = new Mock<IPilot>();

            var mockedFactory = new Mock<IMachineFactory>();
            mockedFactory.Setup(x => x.HirePilot(It.Is<string>(y => y == "Name"))).Returns(mockedPilot.Object);

            var engine = WarMachineEngine.Instance;
            engine.CommandParser = mockedCommandParser.Object;
            engine.Factory = mockedFactory.Object;

            engine.Start();

            Assert.IsTrue(engine.Pilots.ContainsKey("Name"));
        }

        [Test]
        public void Start_WithCommandThatIndicatesHirePilotAndThePilotIsAddedToContainingPilots_ShouldReportTheCorrectMessage()
        {
            var parametersList = new List<string>() { "Name" };
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("HirePilot");
            mockedCommand.Setup(x => x.Parameters).Returns(parametersList);

            var commandsList = new List<ICommand>() { mockedCommand.Object };
            var mockedCommandParser = new Mock<ICommandParser>();
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(commandsList);

            var mockedPilot = new Mock<IPilot>();
           
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.Write(It.IsAny<string>()));

            var engine = WarMachineEngine.Instance;
            engine.CommandParser = mockedCommandParser.Object;
            engine.Pilots.Add("Name", mockedPilot.Object);
            engine.Logger = mockedLogger.Object;

            engine.Start();

            mockedLogger.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void Start_WithCommandThatIndicatesDefenseMode_ShouldToggleTheCorrectMachinesDefenseMode()
        {
            var parametersList = new List<string>() { "Name" };
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("DefenseMode");
            mockedCommand.Setup(x => x.Parameters).Returns(parametersList);

            var commandsList = new List<ICommand>() { mockedCommand.Object };
            var mockedCommandParser = new Mock<ICommandParser>();
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(commandsList);

            var mockedTank = new Mock<ITank>();
            mockedTank.Setup(x => x.ToggleDefenseMode());                        

            var engine = WarMachineEngine.Instance;
            engine.CommandParser = mockedCommandParser.Object;
            engine.Machines.Add("Name", mockedTank.Object);

            engine.Start();

            mockedTank.Verify(x => x.ToggleDefenseMode(), Times.Once);
        }

        [Test]
        public void Start_WithCommandThatIndicatesEngage_ShouldEngagePilotToMachineCorrectly()
        {
            var parametersList = new List<string>() { "pilotName","machineName" };
            var mockedCommand = new Mock<ICommand>();
            mockedCommand.Setup(x => x.Name).Returns("Engage");
            mockedCommand.Setup(x => x.Parameters).Returns(parametersList);

            var commandsList = new List<ICommand>() { mockedCommand.Object };
            var mockedCommandParser = new Mock<ICommandParser>();
            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(commandsList);
                       
            var mockedTank = new Mock<ITank>();           
            var mockedPilot = new Mock<IPilot>();

            mockedPilot.Setup(x => x.AddMachine(mockedTank.Object));
            mockedTank.SetupSet(x => x.Pilot = It.Is<IPilot>(y => y == mockedPilot.Object));

            var engine = WarMachineEngine.Instance;
            engine.CommandParser = mockedCommandParser.Object;
            engine.Pilots.Add("pilotName", mockedPilot.Object);
            engine.Machines.Add("machineName", mockedTank.Object);

            engine.Start();

            mockedTank.VerifySet(x => x.Pilot = It.Is<IPilot>(y => y == mockedPilot.Object), Times.Once);
            mockedPilot.Verify(x => x.AddMachine(mockedTank.Object), Times.Once);
        }
    }
}
