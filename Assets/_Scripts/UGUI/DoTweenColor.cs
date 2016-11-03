using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenColor : MonoBehaviour
{
    public Color colorFrom, colorTo;
    public float durationTime;
    private Image image;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {

        image.DOColor(colorTo, durationTime).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
