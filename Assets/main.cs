using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class main : MonoBehaviour
{
    public int index = 0;
    void Start()
    {
        ENode[] enodes = (ENode[])FindObjectsOfType(typeof(ENode));

        Electricity.network.AddNodes(enodes.Select(x => x.node).ToArray());

        var a = ENode.Create(new Vector3(0, 0, 0), Electricity.network);
        var b = ENode.Create(new Vector3(0, 0, 1), Electricity.network, new List<ENode> { a });
        var c = ENode.Create(new Vector3(0, 0, 2), Electricity.network, new List<ENode> { b });
        var d = ENode.Create(new Vector3(1, 0, 1), Electricity.network, new List<ENode> { b });
        var e = ENode.Create(new Vector3(2, 0, 1), Electricity.network, new List<ENode> { d });
        var f = ENode.Create(new Vector3(2, 1, 1), Electricity.network, new List<ENode> { d });
        var g = ENode.Create(new Vector3(2, 1, 2), Electricity.network, new List<ENode> { d });
        var h = ENode.Create(new Vector3(3, 0, 0.5f), Electricity.network, new List<ENode> { e });
        var i = ENode.Create(new Vector3(3, 0, 1.5f), Electricity.network, new List<ENode> { e });

        var aa = ENode.Create(new Vector3(1, 3, 1), Electricity.network, new List<ENode> { });
        var bb = ENode.Create(new Vector3(2, 3, 1), Electricity.network, new List<ENode> { aa });
        var cc = ENode.Create(new Vector3(2, 4, 1), Electricity.network, new List<ENode> { aa });
        var dd = ENode.Create(new Vector3(2, 4, 2), Electricity.network, new List<ENode> { cc });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Dictionary<Node, int> nodes = Electricity.network.BFS(Electricity.network.nodes[index]);
            float maxDepth = nodes.Values.Max();
            print(maxDepth);
            foreach ((Node node, int depth) in nodes)
            {
                node.eNode.Plug = !node.eNode.Plug;
                node.eNode.GetComponent<Renderer>().material.color = node.eNode.Plug ? new Color(depth / maxDepth, depth / maxDepth, depth / maxDepth) : Color.green;
            }
        }
    }
}
