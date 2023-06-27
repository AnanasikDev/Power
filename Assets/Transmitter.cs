using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Transmitter : ENode, ITransmitter
{
    public static bool SpreadPower = false;
    public static new Transmitter Create(Vector3 position, Network network, List<ENode> connections = null)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Transmitter enode = obj.AddComponent<Transmitter>();
        enode.node = new Node();
        enode.node.eNode = enode;
        obj.name = $"Transmitter";
        network.AddNode(enode.node);
        enode.node.network = network;

        if (connections != null)
            foreach (ENode _enode in connections)
            {
                enode.node.Connect(_enode.node);
            }

        return enode;
    }

    private void TransmitEqually(int amount)
    {
        List<ENode> enodes = node.neighbours.Select(x => x.eNode).Where(x => !x.visited).ToList();
        List<int> power = Utils.Spread(amount, enodes.Count);

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

    private void TransmitAll(int amount)
    {
        List<ENode> enodes = node.neighbours.Select(x => x.eNode).Where(x => !x.visited).ToList();

        for (int i = 0; i < enodes.Count; i++)
        {
            if (enodes[i] is IConsumer)
            {
                ((IConsumer)enodes[i]).Consume(amount);
            }
            if (enodes[i] is ITransmitter)
            {
                ((ITransmitter)enodes[i]).Transmit(amount);
            }
        }
    }

    void ITransmitter.Transmit(int amount)
    {
        visited = true;
        Power = amount;
        if (SpreadPower)
        {
            TransmitEqually(amount);
        }
        else
        {
            TransmitAll(amount);
        }
    }
}

public interface ITransmitter
{
    void Transmit(int amount);
}
