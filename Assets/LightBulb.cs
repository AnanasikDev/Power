using System.Collections.Generic;
using UnityEngine;


public class LightBulb : ENode, IConsumer
{
    public override void Init()
    {
        base.Init();
        consumer = new Consumer();
    }

    public static LightBulb Create(Vector3 position, Network network, int consumption, List<ENode> connections = null)
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.transform.position = position;
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        LightBulb enode = obj.AddComponent<LightBulb>();
        enode.node = new Node();
        enode.Init();
        enode.consumer.Consumption = consumption;
        obj.name = $"Light bulb";
        network.AddNode(enode.node);
        enode.node.network = network;

        if (connections != null)
            foreach (ENode _enode in connections)
            {
                enode.node.Connect(_enode.node);
            }

        return enode;
    }


   public override int Consume(int inPower)
   {


        if (inPower >= consumer.Consumption)
        {
            GetComponent<Renderer>().material.color = Color.yellow;

            return inPower - consumer.Consumption;
        }

        GetComponent<Renderer>().material.color = Color.black;

        return 0;
   }
}

public interface IConsumer
{
    public int Consume(int inPower);
}