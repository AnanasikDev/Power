using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    void Start()
    {
        Network network = new Network();
        
        Node n1 = new Node();
        Node n2 = new Node();
        Node n3 = new Node();
        Node n4 = new Node();
        Node n5 = new Node();

        n1.Connect(n2);
        n2.Connect(n3);
        n4.Connect(n5);

        network.AddNode(n1);
        network.AddNode(n2);
        network.AddNode(n3);
        network.AddNode(n4);
        network.AddNode(n5);

        var a = network.DFS(n4);

        EasyDebug.LogCollection(a);
    }
}
