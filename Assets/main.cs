using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class main : MonoBehaviour
{
    void Start()
    {
        ENode[] enodes = (ENode[])FindObjectsOfType(typeof(ENode));

        Electricity.network.AddNodes(enodes.Select(x => x.node).ToArray());

        var a = ENode.Create(new Vector3(0, 1));
        var b = ENode.Create(new Vector3(1, 1), new List<ENode> { a });
        var c = ENode.Create(new Vector3(1, 3), new List<ENode> { a, b });
        var d = ENode.Create(new Vector3(2, 3), new List<ENode> { b });
        var e = ENode.Create(new Vector3(4, 3), new List<ENode> { b });
    }
}
