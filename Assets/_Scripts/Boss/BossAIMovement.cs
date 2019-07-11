using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAIMovement : MonoBehaviour
{
    private Transform[] points;
    private bool isMoving;
    private Transform target;
    private float speed;
    void Start()
    {
        points = new Transform[5];
        points[0] = GameObject.Find("Point (1)").transform;
        points[1] = GameObject.Find("Point (2)").transform;
        points[2] = GameObject.Find("Point (3)").transform;
        points[3] = GameObject.Find("Point (4)").transform;
        points[4] = GameObject.Find("Point (5)").transform;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            Moving(target);
        }else{
            int length = points.Length;
            int index = UnityEngine.Random.Range(0, length);
            target = points[index]; //points중 랜덤 좌표 저장
            speed = UnityEngine.Random.Range(0.5f,3f);
            isMoving = true;
        }
    }

    private void Moving(Transform target){
        if(Vector2.Distance(transform.position,target.position)>0){
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed*Time.deltaTime);
        }else{
            isMoving = false;
        }
    }
}
