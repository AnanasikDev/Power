using UnityEngine;

public class PowerEngine : ENode
{
    public bool powered { get; protected set; }
    public void TurnOn()
    {
        Node[] nodes = Electricity.network.DFS(node);

        EasyDebug.LogCollection(nodes);

        foreach (Node _node in nodes)
        {
            _node.eNode.Plug = true;
        }
    }
    public void TurnOff()
    {
        Node[] nodes = Electricity.network.DFS(node);

        foreach (Node _node in nodes)
        {
            _node.eNode.Plug = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TurnOn();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TurnOff();
        }
    }
}
