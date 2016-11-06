using UnityEngine;
using System.Collections;

public class StepActionLight : MonoBehaviour
{
    private Light _light;
    private void Awake()
    {
        _light = GetComponentInChildren<Light>();
        if (_light != null)
            TurnLightOnOff(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    public void TurnLightOnOff(bool on)
    {
        _light.enabled = on;
    }
}
