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

    public GameObject[] DontDestroyObjects;

    private bool canAddScore = true;

    public float intervalTime = 3f;
    private bool isRaid = false;
    void Awake(){
        if(Instance==null) {Instance=this;}
        else{Destroy(gameObject);}
    }

    void Start(){
        //Invoke("SummonMob_1", 1f);

        //Invoke("SummonMob_2", 4f);
        //Invoke("SummonMob_2", 4.5f);
        //Invoke("SummonMob_2", 5f);

        //Invoke("SummonMob_3", 7f);

        //Invoke("SummonMob_4", 10f);
        //Invoke("SummonMob_4", 10.5f);
        //Invoke("SummonMob_4", 11f);

        //Invoke("SummonBoss", 18.0f);
        foreach(GameObject obj in DontDestroyObjects)
        {
            DontDestroyOnLoad(obj);
        }
        DontDestroyOnLoad(this);
    }

    public void addScore(int score)
    {
        if (canAddScore)
        {
            StartCoroutine(_addScore(score));
        }
        int totalScore = int.Parse(scoreText.text);
        if (totalScore >= 500 && !isRaid)
        {
            isRaid = true;
            //SummonBoss();
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
