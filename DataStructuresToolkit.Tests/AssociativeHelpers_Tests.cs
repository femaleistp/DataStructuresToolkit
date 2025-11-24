using Xunit;
using DataStructuresToolkit;
using DataStructuresToolkit.HashTables;

namespace DataStructuresToolkit.Tests
{
    public class AssociativeHelpers_Tests
    {
        [Fact]
        public void PhoneBook_ShouldContainAlice_NotDavid()
        {
            // Arrange and Act
            var phoneBook = AssociativeHelpers.BuildPhoneBook();
            // Assert
            Assert.True(phoneBook.ContainsKey("Alice"));
            Assert.False(phoneBook.ContainsKey("David"));
        }

        [Fact]
        public void FruitSet_ShouldNotAllowDuplicates()
        {
            // Arrange and Act
            var fruits = AssociativeHelpers.BuildFruitSet();
            // Assert
            Assert.Contains("Apple", fruits);
            Assert.Equal(3, fruits.Count); // Assuming only 3 unique fruits were added
        }
    }
}
