using EmergentGameEngine.CharacterModel.UnitTests.TestData.TestDataGenerators;
using EmergentGameEngine.CharacterModel.Values;
using System;
using Xunit;

namespace EmergentGameEngine.CharacterModel.UnitTests.ValueTests
{
    public class PreferenceTests
    {
        [Fact]
        public void TestPreferenceOpinionInitialization()
        {
            //Arrange
            var opinion = Opinion.Like;
            //Act
            var preference = new Preference(opinion, 5);
            //Assert
            Assert.Equal(opinion, preference.Opinion);
        }

        [Fact]
        public void TestPreferenceMagnitudeInitialization()
        {
            //Arrange
            var magnitude = 5;
            //Act
            var preference = new Preference(Opinion.Like, magnitude);
            //Assert
            Assert.Equal(magnitude, preference.Magnitude);
        }

        [Fact]
        public void TestPreferenceMagnitudeInitializationNeutralAlwaysZero()
        {
            //Arrange
            //Act
            var preference = new Preference(Opinion.Neutral, 10);
            //Assert
            Assert.Equal(0, preference.Magnitude);
        }

        [Theory]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestEqualReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 == pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(NotEqualPreferenceTestDataGenerator))]
        public void TestEqualReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 == pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestGenericEqualReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            object pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1.Equals(pref2);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(NotEqualPreferenceTestDataGenerator))]
        public void TestGenericEqualReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            object pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1.Equals(pref2);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestGenericEqualReturnsFalseSecondNotPreference()
        {
            //Arrange
            var pref1 = new Preference(Opinion.Like, 5);
            int pref2 = 5;
            //Act
            var result = pref1.Equals(pref2);
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(NotEqualPreferenceTestDataGenerator))]
        public void TestNotEqualReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 != pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestNotEqualReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 != pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(LessThanPreferenceTestDataGenerator))]
        public void TestLessThanReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 < pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(GreaterThanPreferenceTestDataGenerator))]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestLessThanReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 < pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(GreaterThanPreferenceTestDataGenerator))]
        public void TestGreaterThanReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 > pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(LessThanPreferenceTestDataGenerator))]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestGreaterThanReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 > pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(LessThanPreferenceTestDataGenerator))]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestLessThanOrEqualReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 <= pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(GreaterThanPreferenceTestDataGenerator))]
        public void TestLessThanOrEqualReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 <= pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(GreaterThanPreferenceTestDataGenerator))]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestGreaterThanOrEqualReturnsTrue(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 >= pref2;
            //Assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(LessThanPreferenceTestDataGenerator))]        
        public void TestGreaterThanOrEqualReturnsFalse(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var result = pref1 >= pref2;
            //Assert
            Assert.False(result);
        }

        [Theory]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestHashCodeEqual(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var hash1 = pref1.GetHashCode();
            var hash2 = pref2.GetHashCode();
            //Assert
            Assert.Equal(hash1, hash2);
        }

        [Theory]
        [ClassData(typeof(NotEqualPreferenceTestDataGenerator))]
        public void TestHashCodeNotEqual(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var hash1 = pref1.GetHashCode();
            var hash2 = pref2.GetHashCode();
            //Assert
            Assert.NotEqual(hash1, hash2);
        }

        [Theory]
        [ClassData(typeof(GreaterThanPreferenceTestDataGenerator))]
        public void TestCompareToGreaterThan(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var comparison = pref1.CompareTo(pref2);
            //Assert
            Assert.Equal(-1, Math.Sign(comparison));
        }

        [Theory]
        [ClassData(typeof(LessThanPreferenceTestDataGenerator))]
        public void TestCompareToLessThan(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var comparison = pref1.CompareTo(pref2);
            //Assert
            Assert.Equal(1, Math.Sign(comparison));
        }

        [Theory]
        [ClassData(typeof(EqualPreferenceTestDataGenerator))]
        public void TestCompareToEqual(Opinion opinion1, int magnitude1, Opinion opinion2, int magnitude2)
        {
            //Arrange
            var pref1 = new Preference(opinion1, magnitude1);
            var pref2 = new Preference(opinion2, magnitude2);
            //Act
            var comparison = pref1.CompareTo(pref2);
            //Assert
            Assert.Equal(0, Math.Sign(comparison));
        }
    }
}
