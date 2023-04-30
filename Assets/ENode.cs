using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENode : MonoBehaviour
{
    private static int id = 0;

    public Node node;

    public bool Plug = false;

    private void Start()
    {
        node.eNode = this;
    }

    public static ENode Create(Vector3 position, List<ENode> connections = null)
    {
        var obj = new GameObject();
        obj.transform.position = position;
        ENode enode = obj.AddComponent<ENode>();
        enode.node = new Node();
        obj.name = $"Node {id++}";
        
        if (connections != null)
            foreach (ENode _enode in connections)
            {
                enode.node.Connect(_enode.node);
            }   

        return enode;
    }
}
