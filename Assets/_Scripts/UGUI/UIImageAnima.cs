using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIImageAnima : MonoBehaviour
{
    /// <summary>
    /// 帧率
    /// </summary>
    public int m_fps = 5;
    /// <summary>
    /// 是否自动播放
    /// </summary>
    public bool m_auto = false;
    /// <summary>
    /// 是否循环
    /// </summary>
    public bool m_loop = false;
    /// <summary>
    /// 是否在播放
    /// </summary>
    private bool m_play = false;
    /// <summary>
    /// 表情图Image数组
    /// </summary>
    private List<Sprite> m_spriteList = new List<Sprite>();
    private int spriteListCount = 0; // 表情图数量

    private Image m_image; // 当前播放动画的的Image

    private int m_startIdex = 0;// 起始
    private int m_endIdex = 1;  // 结束
    private int m_curIdex = 0;  // 当前索引 （表情图数组里的索引）

    private float m_delta = 0f;

    void Start()
    {
        if (m_auto)
            Load();
    }
    private void Load()
    {
        // 开始加载表情图
        m_image = this.gameObject.GetComponent<Image>();
        m_endIdex = 10;
        spriteListCount = 10;
        m_play = true;
    }
    /// <summary>
    ///  外部开始播放表情接口
    /// </summary>
    public void Play(int start, int end)
    {
        m_startIdex = start;
        m_endIdex = end;
        Load();
    }

    void Update()
    {
        if (m_play == true && m_fps > 0)
        {
            m_delta += Time.deltaTime;
            float rate = 1f / m_fps;
            if (rate < m_delta)
            {
                if (rate > 0f)
                    m_delta = m_delta - rate;
                else
                    m_delta = 0f;
                m_curIdex++;
                if (m_curIdex >= spriteListCount)
                {
                    m_play = m_loop;
                    if (m_play == false) return;
                    m_curIdex = 1;
                }
                Debug.Log("play Anim is  idex -- > " + m_curIdex);
                //m_image.sprite = m_spriteList[m_curIdex];

            }
        }
    }
}