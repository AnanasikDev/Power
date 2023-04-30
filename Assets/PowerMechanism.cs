using UnityEngine;
using UnityEngine.Events;
[ExecuteInEditMode]
public class PowerMechanism : MonoBehaviour
{
    public UnityEvent turnOnDelegate;
    public UnityEvent turnOffDelegate;
    public void TurnOn()
    {
        Debug.Log("on " + turnOnDelegate);
        if (turnOnDelegate != null) turnOnDelegate.Invoke();
    }
    public void TurnOff()
    {
        turnOffDelegate?.Invoke();
    }

    public void ScaleUp()
    {
        Debug.Log("sc");
        transform.localScale *= 2;
    }
    public void ScaleDown()
    {
        transform.localScale /= 2;
    }
    public void Green()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }
    public void Red()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
