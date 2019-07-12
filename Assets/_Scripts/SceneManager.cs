using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject player;
    public static SceneManager Instance {get; private set;}
    public Text scoreText;
    private int score = 0;
    public GameObject mob_1;
    public GameObject mob_2;
    public GameObject boss;
    void Awake(){
        if(Instance==null) {Instance=this;}
        else{Destroy(gameObject);}
    }

    void Start(){
        Invoke("SummonMob_1",1f);
        Invoke("SummonMob_2",4f);
        Invoke("SummonMob_2",4.5f);
        Invoke("SummonMob_2",5f);
        Invoke("SummonMob_3",7f);
        Invoke("SummonBoss",15.0f);
    }

    public void addScore(int score)
    {
        StartCoroutine(_addScore(score));
    }

    IEnumerator _addScore(int score){
        while(score-->0)
        {
            this.score += 1;
            scoreText.text = this.score.ToString();
            yield return null;
        }
    }

    void SummonMob_1(){ Instantiate(mob_1,mob_1.transform.position,Quaternion.identity);  }

    void SummonMob_2(){ Instantiate(mob_2,mob_2.transform.position,Quaternion.identity); }

    void SummonMob_3(){
        Vector2[] pos = new Vector2[3]{new Vector2(-2,5.5f), new Vector2(0,5.5f), new Vector2(2,5.5f)};
        foreach(Vector2 p in pos){
            Instantiate(mob_1,p,Quaternion.identity);
        }
    }

    void SummonBoss(){ Instantiate(boss,boss.transform.position,Quaternion.identity); }

    //테스트 주석
}
