using UnityEngine;

//[ExecuteInEditMode]
public class PowerEngine : MonoBehaviour
{
    public PowerMechanism[] attachedPowerMechanisms;
    public bool powered { get; protected set; }
    public void TurnOn()
    {
        powered = true;
        foreach (PowerMechanism powerMechanism in attachedPowerMechanisms)
        {
            powerMechanism.TurnOn();
        }
    }
    public void TurnOff()
    {
        powered = false;
        foreach (PowerMechanism powerMechanism in attachedPowerMechanisms)
        {
            powerMechanism.TurnOff();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            TurnOn();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOff();
        }
    }
}
