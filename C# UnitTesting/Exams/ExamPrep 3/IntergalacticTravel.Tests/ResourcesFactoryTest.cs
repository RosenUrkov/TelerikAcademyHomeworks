namespace IntergalacticTravel.Tests
{
    using Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ResourcesFactoryTest
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(30) silver(40)")]
        [TestCase("create resources silver(20) bronze(30) gold(40)")]
        [TestCase("create resources silver(20) gold(30) bronze(40)")]
        [TestCase("create resources bronze(20) gold(30) silver(40)")]
        [TestCase("create resources bronze(20) silver(30) gold(40)")]
        public void GetResources_WhenParametersAreValidNoMatterTheOrder_ShouldReturnNewlyCreatedResources(string command)
        {
            var factory = new ResourcesFactory();

            var resources = factory.GetResources(command);

            Assert.IsInstanceOf<IResources>(resources);

        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        public void GetResources_WhenTheStringInputRepresentsInvalidCommand_ShouldThrowInvalidOperationExceptionWithCorrectMessage(string command)
        {
            var factory = new ResourcesFactory();

            Assert.That(() => factory.GetResources(command), Throws.TypeOf<InvalidOperationException>().With.Message.Contains("command"));          

        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_WhenTheStringInputIsInCorrectFormatButAnyOfTheValuesIsLargerThanTypesMaxValue_ShouldThrowOverflowExceptionException(string command)
        {
            var factory = new ResourcesFactory();

            Assert.Throws<OverflowException>(() => factory.GetResources(command));

        }
    }
}
