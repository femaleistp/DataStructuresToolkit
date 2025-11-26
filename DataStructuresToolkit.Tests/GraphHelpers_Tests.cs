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

        /// <summary>
        /// Tests that BFS visits neighbors in breadth-first order.
        /// </summary>
        [Fact]
        public void BFS_VisitsNeighborsInBreadthFirstOrder()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");

            g.AddEdge("A", "B");
            g.AddEdge("A", "C");
            g.AddEdge("B", "D");

            // Act
            var result = g.BFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result);
        }

        /// <summary>
        /// Tests that BFS does not revisit nodes in a cycle graph.
        /// </summary>
        [Fact]
        public void BFS_DoesNotRevisitNodes_InCycleGraph()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("B", "C");
            g.AddEdge("C", "A"); // Creates a cycle

            // Act
            var result = g.BFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C" }, result);
        }

        [Fact]
        public void AddEdge_ShouldNotCreateDuplicateEntries()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");

            // Act
            g.AddEdge("A", "B");
            g.AddEdge("A", "B"); // Adding the same edge again

            // Assert
            var neighborsOfA = g.GetNeighbors("A");
            var neighborsOfB = g.GetNeighbors("B");

            Assert.Single(neighborsOfA, "B");
            Assert.Single(neighborsOfB, "A");
        }

        [Fact]
        public void GetNeighbors_ShouldReturnEmptyList_WhenVertexUnknown()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");

            // Act
            var result = g.GetNeighbors("Z"); // Z does not exist

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void BFS_ShouldOnlyReturnReachableVertices()
        { 
            // Arrange 
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C"); // unreachable
            g.AddVertex("D"); // unreachable

            g.AddEdge("A", "B");

            //Act
            var result = g.BFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result);    
        }
    }
}
