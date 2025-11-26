using System;
using System.Collections.Generic;
using Xunit;
using DataStructuresToolkit.Graph;

namespace DataStructuresToolkit.Tests
{
    public class GraphHelpers_Tests
    {
        /// <summary>
        /// Tests that BFS returns an empty list when the graph is empty.
        /// </summary>
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

        /// <summary>
        /// Tests that adding an edge in an undirected graph adds both directions.
        /// </summary>
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

        /// <summary>
        /// Tests that BFS returns only the start vertex when it exists but has no edges.
        /// </summary>
        [Fact]
        public void BFS_ReturnsStart_WhenStartVertexExistsButNoEdges()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");

            // Act
            var result = g.BFS("A");

            // Assert
            Assert.Equal(new List<string> { "A" }, result);
        }
    }
}
