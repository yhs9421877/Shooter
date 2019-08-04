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
    bool inputLeft;
    bool inputRight;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        inputLeft = false;
        inputRight = false;

        Move();

        animator.SetBool("isLeft",inputLeft);
        animator.SetBool("isRight",inputRight); 
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //spriteRenderer.sprite = leftSprite;
            inputLeft = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //spriteRenderer.sprite = rightSprite;
            inputRight = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("Shooting");
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
    }

    IEnumerator Shooting(){
        foreach(Transform t in cannons){
            GameObject obj = Instantiate(bullet,t.position,Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5) * bulletSpeed);
        }
        yield return new WaitForSeconds(1f);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
