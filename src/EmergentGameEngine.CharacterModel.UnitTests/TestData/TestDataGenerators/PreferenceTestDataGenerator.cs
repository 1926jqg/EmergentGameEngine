using EmergentGameEngine.CharacterModel.Values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EmergentGameEngine.CharacterModel.UnitTests.TestData.TestDataGenerators
{
    internal class EqualPreferenceTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Opinion.Like, 5, Opinion.Like, 5},
            new object[] {Opinion.Dislike, 5, Opinion.Dislike, 5},
            new object[] {Opinion.Neutral, 5, Opinion.Neutral, 5}
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class NotEqualPreferenceTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Opinion.Like, 5, Opinion.Dislike, 5},
            new object[] {Opinion.Like, 5, Opinion.Like, 4},
            new object[] {Opinion.Like, 5, Opinion.Dislike, 4},
            new object[] {Opinion.Dislike, 5, Opinion.Dislike, 4},
            new object[] {Opinion.Dislike, 5, Opinion.Neutral, 0},
            new object[] {Opinion.Like, 5, Opinion.Neutral, 0}
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class GreaterThanPreferenceTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Opinion.Like, 6, Opinion.Like, 5},
            new object[] {Opinion.Like, 6, Opinion.Dislike, 10},
            new object[] {Opinion.Like, 6, Opinion.Dislike, 5},
            new object[] {Opinion.Like, 1, Opinion.Neutral, 0},
            new object[] {Opinion.Neutral, 0, Opinion.Dislike, 1}
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class LessThanPreferenceTestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {Opinion.Like, 5, Opinion.Like, 6},
            new object[] {Opinion.Dislike, 10, Opinion.Like, 6},
            new object[] {Opinion.Dislike, 5, Opinion.Like, 6},
            new object[] {Opinion.Neutral, 0, Opinion.Like, 1},
            new object[] {Opinion.Dislike, 1, Opinion.Neutral, 0}
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
