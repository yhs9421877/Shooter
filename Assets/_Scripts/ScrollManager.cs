using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public float speed;
    public int imageCount = 3;
    public float imageHeight = 900f;

    // Update is called once per frame
    void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        Debug.Log(rt.anchoredPosition.y < -(imageCount - 1) * imageHeight);
        if (rt.anchoredPosition.y < -(imageCount - 1) * imageHeight)
        {
            Debug.Log("오리지날포지션");
            rt.anchoredPosition = new Vector2(0f, 0f);
        }

        rt.anchoredPosition += Vector2.down * speed;
    }
}
