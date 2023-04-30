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

        var a = ENode.Create(new Vector3(0, 1), Electricity.network);
        var b = ENode.Create(new Vector3(1, 1), Electricity.network, new List<ENode> { a });
        var c = ENode.Create(new Vector3(1, 3), Electricity.network, new List<ENode> { b });
        var d = ENode.Create(new Vector3(2, 3), Electricity.network, new List<ENode> { b });
        var e = ENode.Create(new Vector3(4, 3), Electricity.network, new List<ENode> { d });
        var f = ENode.Create(new Vector3(5, 4), Electricity.network, new List<ENode> { });
        var g = ENode.Create(new Vector3(6, 4), Electricity.network, new List<ENode> { f });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Node node in Electricity.network.DFS(Electricity.network.nodes[index]))
            {
                node.eNode.Plug = !node.eNode.Plug;
                node.eNode.GetComponent<Renderer>().material.color = node.eNode.Plug ? Color.white : Color.black;
            }
        }
    }
}
