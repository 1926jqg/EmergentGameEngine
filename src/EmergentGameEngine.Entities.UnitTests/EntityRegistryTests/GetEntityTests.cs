using EmergentGameEngine.Abstraction.Entities;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Fakes;
using EmergentGameEngine.Entities.UnitTests.TestDoubles.Mocks;
using Xunit;

namespace EmergentGameEngine.Entities.UnitTests.EntityRegistryTests
{
    public class GetEntityTests
    {
        private readonly IEntityRegistry _sut = new EntityRegistry();

        [Fact]
        public void TestGetExistingEntitySucceeds()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            var result = _sut.TryGetEntity(entity.Id, out IEntity _);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestGetExistingByTypeEntitySucceeds()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            var result = _sut.TryGetEntity(entity.Id, out AEntityMock _);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestGetExistingEntityReturnsEntity()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            _sut.TryGetEntity(entity.Id, out IEntity result);

            //Assert
            Assert.Equal(entity, result);
        }        

        [Fact]
        public void TestGetExistingEntityByTypeReturnsEntity()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            _sut.TryGetEntity(entity.Id, out AEntityMock result);

            //Assert
            Assert.Equal(entity, result);
        }

        [Fact]
        public void TestGetExistingEntityWithUnregisteredTypeFails()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            var result = _sut.TryGetEntity(entity.Id, out BEntityMock _);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestGetExistingEntityWithWrongTypeFails()
        {
            //Arrange
            _sut.TryAddFactory(new AEntityFactoryFake());
            _sut.TryAddFactory(new BEntityFactoryFake());
            _sut.TryCreateEntity(out AEntityMock entity, ("A", "name"));

            //Act
            var result =_sut.TryGetEntity(entity.Id, out BEntityMock _);

            //Assert
            Assert.False(result);
        }
    }
}
