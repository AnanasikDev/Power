using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENode : MonoBehaviour
{
    private static int id = 0;

    public Node node;
    public int Power = 0;

    public Producer producer = null;
    public Consumer consumer = null;

    public bool visited = false;

    private void Start() => Init();

    public virtual void Init()
    {
        node.eNode = this;
    }

    public static ENode Create(Vector3 position, Network network, List<ENode> connections = null)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        ENode enode = obj.AddComponent<ENode>();
        enode.node = new Node();
        enode.node.eNode = enode;
        obj.name = $"Node {id++}";
        network.AddNode(enode.node);
        enode.node.network= network;
        
        if (connections != null)
            foreach (ENode _enode in connections)
            {
                enode.node.Connect(_enode.node);
            }   

        return enode;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        foreach (Node _node in node.neighbours)
        {
            Gizmos.DrawLine(transform.position, _node.eNode.transform.position);
        }
    }
}
