using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerEngine : ENode, IGenerator
{
    public bool powered { get; protected set; }
    
    public int Production = 1200;

    public static PowerEngine Create(Vector3 position, Network network, List<ENode> connections = null)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        PowerEngine enode = obj.AddComponent<PowerEngine>();
        enode.node = new Node();
        enode.node.eNode = enode;
        obj.name = $"Power Engine";
        network.AddNode(enode.node);
        enode.node.network = network;

        if (connections != null)
            foreach (ENode _enode in connections)
            {
                enode.node.Connect(_enode.node);
            }

        return enode;
    }

    public void Generate()
    {
        visited = true;
        Power = Production;
        List<ENode> enodes = node.neighbours.Select(x => x.eNode).ToList();
        List<int> power = Utils.Spread(Production, enodes.Count);

        EasyDebug.LogCollection(power);

        for (int i = 0; i < enodes.Count; i++)
        {
            if (enodes[i] is IConsumer)
            {
                ((IConsumer)enodes[i]).Consume(power[i]);
            }
            if (enodes[i] is ITransmitter)
            {
                ((ITransmitter)enodes[i]).Transmit(power[i]);
            }
        }
    }
}

public interface IGenerator
{
    public void Generate();
}