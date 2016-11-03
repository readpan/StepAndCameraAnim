using UnityEngine;
using System.Collections;

public class StepActionLight : MonoBehaviour
{
    private Light light;
    private void Awake()
    {
        light = GetComponentInChildren<Light>();
        if (light != null)
            TurnLightOnOff(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    public void TurnLightOnOff(bool on)
    {
        light.enabled = on;
    }
}
