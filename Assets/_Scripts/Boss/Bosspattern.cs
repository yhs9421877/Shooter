﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosspattern : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] cannons;
    public Transform[] subCannons;
 

    public void Spell_1(Transform[] cannon,int count, float bulletSpeed, float firstDelay, float delay){
        StartCoroutine(_Spell_1(cannon, count,bulletSpeed,firstDelay, delay));
    }

    IEnumerator _Spell_1(Transform[] cannon, int count, float bulletSpeed, float firstDelay, float delay){
        yield return new WaitForSeconds(firstDelay);
        while(count-->0){
            foreach(Transform t in cannon){
                GameObject obj;
                Rigidbody2D temp;
                float digree;

                Vector3 playerPosition;
                try{
                    playerPosition = SceneManager.Instance.player.transform.position;
                }catch(MissingReferenceException e1){ //만약 플레이어를 못 찾는다면
                    Debug.Log("Player is not found");
                    break;
                }

                obj = (GameObject)Instantiate(bullet,t.position,Quaternion.identity);
                temp = obj.GetComponent<Rigidbody2D>();
                #region LookAt2D
                Vector2 ToPlayerDir = playerPosition - obj.transform.position;
                temp.AddForce(ToPlayerDir.normalized*bulletSpeed);
                #endregion


                digree = Mathf.Atan2(obj.transform.position.x - playerPosition.x,
                                    obj.transform.position.y - playerPosition.y)*180f/Mathf.PI;
                obj.transform.Rotate(0,0,-digree);
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public void Spell_2(params Transform[] t){
        StartCoroutine(_Spell_2(t,50));
    }

    IEnumerator _Spell_2(Transform[] t, int count){
        int shoot = 0;
        float angle = 360 / count;
        float speed = 170f;
        do{
            foreach(Transform tr in t){
                for(int i=0; i<count; i++){
                    GameObject obj = (GameObject)Instantiate(bullet,tr.position,Quaternion.identity);
                    Rigidbody2D rb2d = obj.GetComponent<Rigidbody2D>();
                    rb2d.AddForce(
                    new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / count), speed * Mathf.Sin(Mathf.PI * 2 * i / count)));
                    
                    obj.transform.Rotate(new Vector3(0f,0f,360*i/count-90));
                }
            }
            Spell_1(new Transform[1] { transform }, 1, 130f, 0.3f, 0.05f);
            yield return new WaitForSeconds(0.5f);
            shoot++;
        }while(shoot<10);
    }

    public void Phase_2_Spell_1(){
        //StartCoroutine(_Phase_2_Spell_1());
        StartCoroutine(_Spell_1(cannons, 10,130f,0f,0.3f));
        StartCoroutine(_Spell_1(subCannons, 11,130f,0.3f,0.3f));
    }
    

    public void Phase_2_Spell_2(){
        Transform[] t = new Transform[5]{this.transform,subCannons[0],subCannons[1],subCannons[2],subCannons[3]};
        StartCoroutine(_Spell_2(t,30));
    }

}
