using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

public class Network
{
    public readonly List<Node> nodes = new List<Node>();
    public int length { get { return nodes.Count; } }

    public void AddNode(Node node)
    {
        nodes.Add(node);
    }
    public void AddNodes(Node[] nodes)
    {
        foreach (Node node in nodes) AddNode(node);
    }

    /// <summary>
    /// Converts list of nodes {nodes} to a dictionary with an array of neighbours for each node in the graph
    /// </summary>
    public Dictionary<Node, Node[]> GetAdjacencyList()
    {
        Dictionary<Node, Node[]> adjacencyList = new Dictionary<Node, Node[]>();
        for (int i = 0; i < length; i++)
        {
            Node node = nodes[i];

            adjacencyList.Add(node, node.neighbours.ToArray());
        }

        return adjacencyList;
    }
    
    /// <summary>
    /// Recurring algorithm that goes through each node in {graph} and calls itself for each of its neighbour
    /// Modifies {visited} list which in result represents a set of nodes accessible from the start node
    /// Start node is set as {node} when this function is initially called (not by itself)
    /// </summary>
    /// <param name="visited">List of all visited nodes. It is being expanded throughout the process of searching through the graph</param>
    /// <param name="graph">Adjacency list of the graph</param>
    /// <param name="node">Node which the algorithm works with on the current iteration</param>
    private void __dfs(List<Node> visited, Dictionary<Node, Node[]> graph, Node node)
    {
        if (!visited.Contains(node))
        {
            visited.Add(node);
            foreach (Node neighbour in graph[node])
            {
                __dfs(visited, graph, neighbour);
            }
        }
    }

    public Node[] DFS(Node startNode)
    {
        List<Node> visited = new List<Node>();
        Dictionary<Node, Node[]> adjacencyList = GetAdjacencyList();
        __dfs(visited, adjacencyList, startNode);
        return visited.ToArray();
    }

    public Dictionary<Node, int> BFS(Node startNode)
    {
        Dictionary<Node, int> visited = new Dictionary<Node, int>() { { startNode, 0 } };
        List<Node> queue = new List<Node>() { startNode };

        Dictionary<Node, Node[]> adjacencyList = GetAdjacencyList();

        int depth = 0;

        while (queue.Count > 0)
        {
            Node node = queue[0];
            queue.RemoveAt(0);

            depth++;

            foreach (Node neighbour in adjacencyList[node])
            {
                if (visited.ContainsKey(neighbour)) continue;

                visited.Add(neighbour, depth);
                queue.Add(neighbour);
            }
        }

        return visited;
    }

    public List<Node> FindConsumers(Node startNode)
    {
        Node[] _nodes = DFS(startNode);
        return _nodes.Where(node => node.eNode is IConsumer).ToList();
    }

    public List<Node> FindProducers(Node startNode)
    {
        Node[] _nodes = DFS(startNode);
        return _nodes.Where(node => node.eNode is IGenerator).ToList();
    }

    public (int, int) CalculateConsumptionAndProduction(Node startNode)
    {
        List<Node> consumers = FindConsumers(startNode);
        List<Node> producers = FindProducers(startNode);
        return (consumers.Select(consumer => consumer.eNode.consumer.Consumption).Sum(),
                producers.Select(producer => producer.eNode.producer.Production ).Sum());
    }
}
