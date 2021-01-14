using EmergentGameEngine.Abstraction.Entities;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Fakes;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Stubs;
using Xunit;

namespace EmergentGameEngine.Entities.UnitTests.EntityRegistryTests
{
    public class AddFactoryTests
    {
        private readonly IEntityRegistry _sut = new EntityRegistry();

        [Fact]
        public void TestAddFactoryByTypeSucceeds()
        {
            //Arrange
            var factory = new AEntityFactoryFake();

            //Act
            var result = _sut.TryAddFactory(factory);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestAddFactoryByCategorySucceeds()
        {
            //Arrange
            var factory = new EntityFactoryStub("Category");

            //Act
            var result = _sut.TryAddFactory(factory);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestAddFactorySameTypeFails()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            var factory = new AEntityFactoryFake();            

            //Act            
            var result = _sut.TryAddFactory(factory);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestAddFactoryDifferentTypeSucceeds()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            var factory = new BEntityFactoryFake();            

            //Act
            var result = _sut.TryAddFactory(factory);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestAddFactoryDifferentTypeSameCategoryFails()
        {
            //Arrange
            var factory1 = new AEntityFactoryFake();
            var factory2 = new EntityFactoryStub(factory1.Category);
            _sut.TryAddFactory(factory1);

            //Act
            var result = _sut.TryAddFactory(factory2);

            //Assert
            Assert.False(result);
        }
    }
}
