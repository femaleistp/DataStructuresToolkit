using Xunit;
using DataStructuresToolkit;
using DataStructuresToolkit.HashTables;

namespace DataStructuresToolkit.Tests
{
    public class SimpleHashTable_Tests
    {
        [Fact]
        public void Insert_CollidingKeys_AllShouldBeFound()
        {
            // Arrange
            var table = new SimpleHashTable(5);

            // Act
            table.Insert(12);  // Hashes to bucket 2
            table.Insert(22);  // Hashes to bucket 2 (collision with 12)
            table.Insert(37); // Hashes to bucket 2 (collision with 12 and 22)

            // Assert
            Assert.True(table.Contains(12));
            Assert.True(table.Contains(22));
            Assert.True(table.Contains(37));
        }
    }
}
