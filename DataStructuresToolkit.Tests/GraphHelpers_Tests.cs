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

        /// <summary>
        /// Tests that adding an edge does not create duplicate entries.
        /// </summary>
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

        /// <summary>
        /// Tests that GetNeighbors returns an empty list for an unknown vertex.
        /// </summary>
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

        /// <summary>
        /// Tests that BFS only returns reachable vertices from the start vertex.
        /// </summary>
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
            Assert.Equal(new List<string> { "A", "B" }, result);
        }

        /// <summary>
        /// Tests that DFS visits nodes in depth-first order.
        /// </summary>
        [Fact]
        public void DFS_VisitsNodesInDepthFirstOrder()
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
            var result = g.DFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "D", "C" }, result);
        }

        /// <summary>
        /// Tests that CountEdges returns the correct number of edges in an undirected graph.
        /// </summary>
        [Fact]
        public void CountEdges_ShouldReturnCorrectUndirectedEdgeCount()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("B", "C");

            // Act
            var result = g.CountEdges();

            // Assert
            Assert.Equal(2, result); // A-B and B-C
        }

        /// <summary>
        /// Tests that DegreeCounts returns correct degree counts for each vertex.
        /// </summary>
        [Fact]
        public void DegreeCounts_ShouldReturnCorrectDegrees()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");  // A degree 1, B degree 1
            g.AddEdge("B", "C");  // B degree 2, C degree 1

            // Act
            var degrees = g.DegreeCounts();

            // Assert
            Assert.Equal(1, degrees["A"]);
            Assert.Equal(2, degrees["B"]);
            Assert.Equal(1, degrees["C"]);
        }

        /// <summary>
        /// Tests that OrderBFS returns vertices in breadth-first order.
        /// </summary>
        [Fact]
        public void OrderBFS_ShouldReturnVerticesInBreadthFirstOrder()
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
            var result = g.OrderBFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result);
        }

        /// <summary>
        /// Tests that OrderDFS returns vertices in depth-first order.
        /// </summary>
        [Fact]
        public void OrderDFS_ShouldReturnDepthFirstOrder()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");

            g.AddEdge("A", "B");
            g.AddEdge("A", "C");
            g.AddEdge("B", "D");
            g.AddEdge("C", "E");

            // Act
            var result = g.OrderDFS("A");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "D", "C", "E" }, result);
        }

        /// <summary>
        /// Tests that DegreeCounts returns an empty dictionary when the graph is empty.
        /// </summary>
        [Fact] 
        public void DegreeCounts_ShouldReturnEmptyDictionary_WhenGraphIsEmpty()
        {
            // Arrange
            var g = new GraphHelpers();
            // Act
            var result = g.DegreeCounts();
            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        /// <summary>
        /// Tests that DegreeCounts includes vertices with zero degrees.
        /// </summary>
        [Fact]
        public void DegreeCounts_ShouldIncludeVErticesWithZeroDegrees()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");  // C will remain isolated

            g.AddEdge("A", "B");  // A degree 1, B degree 1

            // Act
            var result = g.DegreeCounts();

            // Assert
            Assert.Equal(1, result["A"]);
            Assert.Equal(1, result["B"]);
            Assert.Equal(0, result["C"]); // C should have degree 0


        }

        /// <summary>
        /// Tests that UniqueVertices returns all vertices without duplicates.
        /// </summary>
        [Fact]
        public void UniqueVertices_ShouldReturnAllVerticesWithoutDuplicates()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("A");  // Duplicate add should not create duplicate
            g.AddVertex("C");

            // Act
            var result = g.UniqueVertices();

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C" }, result);
        }

        /// <summary>
        /// Tests that UniqueVertices returns sorted vertices even after adding edges.
        /// </summary>
        [Fact]
        public void UniqueVertices_ShouldReturnSortedVerticesEvenAfterEdges()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("B");
            g.AddVertex("A");
            g.AddVertex("D");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("C", "D");

            // Act
            var result = g.UniqueVertices();

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, result);
        }

        /// <summary>
        /// Tests that AddVertex ignores empty or whitespace names.
        /// </summary>
        [Fact]
        public void AddVertex_ShouldIgnoreEmptyOrWhiteSpaceNames()
        {
            // Arrange
            var g = new GraphHelpers();

            // Act
            g.AddVertex("");  // invalid
            g.AddVertex("   ");  // invalid
            g.AddVertex("A");  // valid

            var vertices = g.UniqueVertices();

            // Assert
            Assert.Equal(new List<string> { "A" }, vertices);
        }

        /// <summary>
        /// Tests that BuildAdjacencyList returns correct adjacency lists for all vertices.
        /// </summary>
        [Fact]
        public void BuildAdjacencyList_ShouldIncludeAllEdges()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("B", "C");
            g.AddEdge("A", "C");

            // Act
            var adj = g.BuildAdjacencyList();

            // Assert
            Assert.Equal(new List<string> { "B", "C" }, adj["A"]);
            Assert.Equal(new List<string> { "A", "C" }, adj["B"]);
            Assert.Equal(new List<string> { "B", "A" }, adj["C"]);
        }

        /// <summary>
        /// Tests that BuildAdjacencyList returns a deep copy of the adjacency lists.
        /// </summary>
        [Fact]
        public void BuildAdjacencyList_ShouldReturnDeepCopy_NotReferenceOriginalLists()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddEdge("A", "B");

            // Act
            var adj = g.BuildAdjacencyList();
            adj["A"].Add("Z"); // Mutate returned list = should not mutate original graph

            // Assert
            Assert.DoesNotContain("Z", g.GetNeighbors("A"));
        }

        /// <summary>
        /// Tests that BuildAdjacencyList deep copies all neighbor lists.
        /// </summary>
        [Fact]
        public void BuildAdjacencyList_ShouldDeepCopyAllNeighborLists()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");

            g.AddEdge("A", "B");
            g.AddEdge("B", "C");

            // Act
            var adj = g.BuildAdjacencyList();

            adj["A"].Add("X"); // Mutate returned list = should not mutate original graph
            adj["B"].Remove("C"); // Mutate returned list = should not mutate original graph
            // Assert - original graph should remain unchanged
            Assert.DoesNotContain("X", g.GetNeighbors("A"));
            Assert.Contains("C", g.GetNeighbors("B"));  // C must still be present
        }

        /// <summary>
        /// Tests that BuildAdjacencyList returns an empty dictionary when the graph is empty.
        /// </summary>
        [Fact]
        public void BuildAdjacencyList_ShouldReturnEmptyDictionary_WhenGraphIsEmpty()
        {
            // Arrange
            var g = new GraphHelpers();

            // Act
            var adj = g.BuildAdjacencyList();

            // Assert
            Assert.NotNull(adj);
            Assert.Empty(adj);
        }

        /// <summary>
        /// Tests that BuildAdjacencyList includes vertices with no edges.
        /// </summary>
        [Fact]
        public void BuildAdjacencyList_ShouldIncludeVerticesWithNoEdges()
        {
            // Arrange
            var g = new GraphHelpers();
            g.AddVertex("A");
            g.AddVertex("B"); // no edges

            g.AddEdge("A", "A"); // self-loop possible but not relevant

            // Act
            var adj = g.BuildAdjacencyList();

            // Assert
            Assert.True(adj.ContainsKey("A"));
            Assert.True(adj.ContainsKey("B"));

            Assert.NotNull(adj["B"]);
            Assert.Empty(adj["B"]); // no neighbors
        }

    }
}
