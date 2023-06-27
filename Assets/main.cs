using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class main : MonoBehaviour
{
    public int index = 0;
    void Start()
    {
        var a = PowerEngine.Create(new Vector3(0, 0, 0), Electricity.network);
        var b = Transmitter.Create(new Vector3(0, 0, 1), Electricity.network, new List<ENode> { a });
        var c = Transmitter.Create(new Vector3(0, 0, 2), Electricity.network, new List<ENode> { b });
        var d = Transmitter.Create(new Vector3(1, 0, 1), Electricity.network, new List<ENode> { b });
        var e = Transmitter.Create(new Vector3(2, 0, 1), Electricity.network, new List<ENode> { d });
        var f = LightBulb.Create(new Vector3(2, 1, 1), Electricity.network, 200, new List<ENode> { d });
        var g = LightBulb.Create(new Vector3(2, 1, 2), Electricity.network, 200, new List<ENode> { d });
        var h = Transmitter.Create(new Vector3(3, 0, 0.5f), Electricity.network, new List<ENode> { e });
        var i = Transmitter.Create(new Vector3(3, 0, 1.5f), Electricity.network, new List<ENode> { e });

        var aa = Transmitter.Create(new Vector3(1, 3, 1), Electricity.network, new List<ENode> { });
        var bb = Transmitter.Create(new Vector3(2, 3, 1), Electricity.network, new List<ENode> { aa });
        var cc = Transmitter.Create(new Vector3(2, 4, 1), Electricity.network, new List<ENode> { aa });
        var dd = Transmitter.Create(new Vector3(2, 4, 2), Electricity.network, new List<ENode> { cc });

        a.Generate();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Dictionary<Node, int> nodes = Electricity.network.BFS(Electricity.network.nodes[index]);
            float maxDepth = nodes.Values.Max();
            print(maxDepth);
            foreach ((Node node, int depth) in nodes)
            {
                node.eNode.GetComponent<Renderer>().material.color = node.eNode.Plug ? new Color(depth / maxDepth, depth / maxDepth, depth / maxDepth) : Color.green;
            }
        }
    }*/
}
