using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{

    public GameObject bullet;
    public float firstdelay;
    public float delay;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BasicAttack",firstdelay);
    }

    public void BasicAttack(){
        StartCoroutine(_BasicAttack(9,200f,delay));
    }

    IEnumerator _BasicAttack(int count, float bulletSpeed, float delay){
        while(count-->0){
                GameObject obj;
                Rigidbody2D temp;
                float digree;

                obj = (GameObject)Instantiate(bullet,transform.position,Quaternion.identity);
                obj.SetActive(true);
                temp = obj.GetComponent<Rigidbody2D>();
                #region LookAt2D
                Vector2 ToPlayerDir;
                try{
                    ToPlayerDir = SceneManager.Instance.player.transform.position - obj.transform.position;
                }catch(MissingReferenceException e1){ //만약 플레이어를 못 찾는다면
                    Debug.Log("Player is not found");
                    break;
                }
                temp.AddForce(ToPlayerDir.normalized*bulletSpeed);
                #endregion


                digree = Mathf.Atan2(obj.transform.position.x - SceneManager.Instance.player.transform.position.x,
                                    obj.transform.position.y - SceneManager.Instance.player.transform.position.y)*180f/Mathf.PI;
                obj.transform.Rotate(0,0,-digree);
                yield return new WaitForSeconds(delay);
        }
    }
}
