using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(PowerEngine))]
//[CanEditMultipleObjects]
public class PowerEngineEditor : Editor
{
    PowerEngine powerEngine;
    private void OnValidate()
    {
        powerEngine = (PowerEngine)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Turn on"))
        {
            powerEngine.TurnOn();
        }
        if (GUILayout.Button("Turn off"))
        {
            powerEngine.TurnOff(); 
        }
    }
}
