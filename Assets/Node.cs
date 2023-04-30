using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node
{
    public ENode eNode;

    public static int ID = 0;
    public int id = 0;

    public List<Node> neighbours = new List<Node>();
    public int connections { get { return neighbours.Count; } }

    public Node()
    {
        id = ID++;
    }
    public Node(ENode eNode)
    {
        this.eNode = eNode;
        id = ID++;
        EasyDebug.Log(id);
    }

    public void Connect(Node node)
    {
        neighbours.Add(node);
        node.neighbours.Add(this);
    }

    public void Unconnect(Node node)
    {
        if (neighbours.Contains(node))
        {
            node.neighbours.Remove(this);
            neighbours.Remove(node);
        }
    }

    public override string ToString()
    {
        return $"Node {id}";
    }
}
