using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ButtonGroup : MonoBehaviour
{
    public CanvasGroup CanvasGroup { get; set; }
    public Button Button { get; set; }

    public Text Text;

    public void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
        Button = GetComponent<Button>();
        Text = GetComponentInChildren<Text>();
    }
}
