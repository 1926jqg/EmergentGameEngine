using EmergentGameEngine.Abstraction.Entities;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Fakes;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Mocks;
using Xunit;

namespace EmergentGameEngine.Entities.UnitTests.EntityRegistryTests
{
    public class CreateEntityTests
    {
        private readonly IEntityRegistry _sut = new EntityRegistry();

        [Fact]
        public void TestCreateEntitySucceedsIfFactoryExists()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());

            //Act
            var result = _sut.TryCreateEntity(out AEntityMock _, ("A", "name"));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestCreateEntityFailsIfFactoryDoesNotExist()
        {
            //Arrange

            //Act
            var result = _sut.TryCreateEntity(out AEntityMock _, ("A", "name"));

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCreateEntityReturnsEntityIfFactoryExists()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());

            //Act
            _sut.TryCreateEntity(out AEntityMock result, ("A", "name"));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateEntityByCategorySucceedsIfFactoryExists()
        {
            //Arrange
            var factory = new AEntityFactoryFake();
            _sut.TryAddFactory(factory);

            //Act
            var result = _sut.TryCreateEntity(factory.Category, out IEntity _, ("A", "name"));

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestCreateEntityByCategoryFailsIfFactoryDoesNotExist()
        {
            //Arrange

            //Act
            var result = _sut.TryCreateEntity("A", out IEntity _, ("A", "name"));

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestCreateEntityByCategoryReturnsEntityIfFactoryExists()
        {
            //Arrange
            var factory = new AEntityFactoryFake();
            _sut.TryAddFactory(factory);

            //Act
            _sut.TryCreateEntity(factory.Category, out IEntity result, ("A", "name"));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestCreateEntityPassesParameters()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            string parameterValue = "name";

            //Act
            _sut.TryCreateEntity(out AEntityMock result, ("A", parameterValue));

            //Assert
            Assert.Equal(parameterValue, result.Name);
        }

        [Fact]
        public void TestCreateEntityByCategoryPassesParameters()
        {
            //Arrange
            var factory = new AEntityFactoryFake();
            _sut.TryAddFactory(factory);
            string parameterValue = "name";

            //Act
            _sut.TryCreateEntity(factory.Category, out IEntity result, ("A", parameterValue));

            //Assert
            Assert.Equal(parameterValue, result.Name);
        }

        [Fact]
        public void TestCreateEntityIncrementsId()
        {
            //Arrange
            var factory1 = new AEntityFactoryFake();
            var factory2 = new BEntityFactoryFake();
            _sut.TryAddFactory(factory1);
            _sut.TryAddFactory(factory2);

            //Act
            _sut.TryCreateEntity(out AEntityMock entity1, ("A", "name"));
            _sut.TryCreateEntity(out BEntityMock entity2, ("B", "name"));
            _sut.TryCreateEntity(out AEntityMock entity3, ("A", "name"));
            _sut.TryCreateEntity(factory2.Category, out IEntity entity4, ("B", "name"));
            _sut.TryCreateEntity(factory1.Category, out IEntity entity5, ("A", "name"));
            _sut.TryCreateEntity(factory2.Category, out IEntity entity6, ("B", "name"));

            //Assert
            Assert.Equal(0u, entity1.Id);
            Assert.Equal(1u, entity2.Id);
            Assert.Equal(2u, entity3.Id);
            Assert.Equal(3u, entity4.Id);
            Assert.Equal(4u, entity5.Id);
            Assert.Equal(5u, entity6.Id);
        }
    }
}
