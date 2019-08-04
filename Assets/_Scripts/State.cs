using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public int MaxHp;
    
    [HideInInspector]
    public int hp;
    public string TargetBulletTag;
    private Animator anim;
    private SceneManager sceneManager;

    void Awake(){
        Screen.SetResolution(600, 800, false);

        hp = MaxHp;
        anim = GetComponent<Animator>();
        sceneManager = FindObjectOfType<SceneManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(TargetBulletTag)){
            hp -= 1;
        }
        if(hp<=0){
            if(gameObject.CompareTag("Player")){ //플레이어라면 애니메이션 재생
                sceneManager.GameEnd();
            }
            else{
                sceneManager.addScore(100);
                if (gameObject.CompareTag("Boss"))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }
            }

            anim.SetTrigger("die");
            Destroy(this.gameObject, 0.4f);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
