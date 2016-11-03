using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanelBase : MonoBehaviour,IReset
{
    public CanvasGroup TheCanvasGroup;

    protected virtual void Awake()
    {
        TheCanvasGroup = GetComponent<CanvasGroup>();
    }

    // Use this for initialization
    protected virtual void Start()
    {

    }

    public virtual void Reset()
    {
        
    }
}
