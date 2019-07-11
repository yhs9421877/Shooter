using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    private Animator animator;
    public float bulletSpeed;
    public GameObject bullet;
    public Transform[] cannons;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool inputLeft = false;
        bool inputRight = false;
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //spriteRenderer.sprite = leftSprite;
            inputLeft = true;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //spriteRenderer.sprite = rightSprite;
            inputRight = true;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.Space)){
            StartCoroutine("Shooting");
        }

        animator.SetBool("isLeft",inputLeft);
        animator.SetBool("isRight",inputRight); 
    }

    IEnumerator Shooting(){
        foreach(Transform t in cannons){
            GameObject obj = (GameObject)Instantiate(bullet,t.position,Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5) * bulletSpeed);
        }
        yield return new WaitForSeconds(1f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
