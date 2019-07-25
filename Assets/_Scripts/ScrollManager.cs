using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public float speed;
    public int imageCount = 3;
    public float imageHeight = 10f;
    private Vector3 originalPosition;
    void Awake()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -(imageCount - 1) * imageHeight)
        {
            Debug.Log("오리지날포지션");
            transform.position = originalPosition;
        }
           
        transform.Translate(new Vector3(0, speed, 0));
    }
}
