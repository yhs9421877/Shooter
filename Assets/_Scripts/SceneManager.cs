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
    public GameObject mob_3;
    public GameObject boss;

    public Button restartButton;
    public Button exitButton;

    private bool canAddScore = true;

    void Awake(){
        if(Instance==null) {Instance=this;}
        else{Destroy(gameObject);}
    }

    void Start(){
        //Invoke("SummonMob_1",1f);
        //Invoke("SummonMob_2",4f);
        //Invoke("SummonMob_2",4.5f);
        //Invoke("SummonMob_2",5f);
        //Invoke("SummonMob_3",7f);
        //Invoke("SummonMob_4",10f);
        //Invoke("SummonMob_4",10.5f);
        //Invoke("SummonMob_4",11f);
        //Invoke("SummonBoss",18.0f);
        SummonBoss();
    }

    public void addScore(int score)
    {
        if (canAddScore)
        {
            StartCoroutine(_addScore(score));
        }
    }

    IEnumerator _addScore(int score){
        while(score-->0)
        {
            canAddScore = false;
            this.score += 1;
            scoreText.text = this.score.ToString();
            yield return null;
        }
        canAddScore = true;
    }

    void SummonMob_1(){ Instantiate(mob_1,mob_1.transform.position,Quaternion.identity);  }

    void SummonMob_2(){ Instantiate(mob_2,mob_2.transform.position,Quaternion.identity); }

    void SummonMob_3(){
        Vector2[] pos = new Vector2[3]{new Vector2(-2,5.5f), new Vector2(0,5.5f), new Vector2(2,5.5f)};
        foreach(Vector2 p in pos){
            Instantiate(mob_1,p,Quaternion.identity);
        }
    }

    void SummonMob_4(){
        Vector2[] pos = new Vector2[2]{new Vector2(-4,5.5f), new Vector2(4,5.5f)};
        for(int i=0; i<2; i++){
            GameObject obj = (GameObject)Instantiate(mob_3,pos[i],Quaternion.identity);
            if(i==1){
                obj.transform.localScale = new Vector3(-1,1,1);
            }
        }
    }

    void SummonBoss(){ Instantiate(boss,boss.transform.position,Quaternion.identity); }

    public void GameEnd()
    {
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);

    }

    public void RestartButtonOnClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    //테스트 주석
}
