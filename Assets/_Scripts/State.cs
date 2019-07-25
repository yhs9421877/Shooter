using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public int MaxHp;
    
    [HideInInspector]
    public int hp;
    private Animator anim;
    public string EnemyBulletTag;
    void Start(){
        hp = MaxHp;
        anim = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(EnemyBulletTag)){
            hp -= 1;
        }
        if(hp<=0){
            FindObjectOfType<SceneManager>().addScore(100);
            if(gameObject.CompareTag("Player")){ //플레이어라면 애니메이션 재생
                anim.SetTrigger("die");
                Debug.Log("죽은사람 플레이어");
                FindObjectOfType<SceneManager>().GameEnd();
                Destroy(this.gameObject, 0.4f);
            }
            else{
                Destroy(this.gameObject);
            }
        }
    }
}
// 테스트테스트 깃헙 테스트
