using UnityEngine;
using System.Collections;
using Pan_Tools;
using UnityEngine.UI;

public class UIDownLoadMask : MonoSingleton<UIDownLoadMask>
{
    public Image MaskImg;
    public GameObject Mask;
    public Text TextLoadInfo;

    private void Awake()
    {
        MaskImg = GetComponentInChildren<Image>();
        Mask = MaskImg.gameObject;
        TextLoadInfo = GetComponentInChildren<Text>();
    }
    public void SetMask(bool maskFlag)
    {
        Mask.SetActive(maskFlag);
    }
}
