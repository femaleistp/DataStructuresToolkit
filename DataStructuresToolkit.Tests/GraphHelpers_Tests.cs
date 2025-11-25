using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit.Graph;

namespace DataStructuresToolkit.Tests
{
    public class GraphHelpers_Tests
    {
        [Fact]
        public void BFS_ReturnsEmpty_WhenGraphEmpty()
        {
            // Arrange
            var graph = new GraphHelpers();

            // Act
            var result = graph.BFS("A");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void AddEdge_ShouldAddBothDirections_WhenUndirected()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");

            // Act
            g.AddEdge("A", "B");

            // Assert
            var neighborsOfA = g.GetNeighbors("A");
            var neighborsOfB = g.GetNeighbors("B");

            Assert.Contains("B", neighborsOfA);
            Assert.Contains("A", neighborsOfB);
        }
    }
}
