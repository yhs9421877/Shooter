using System.Collections;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite particle;
    private SpriteRenderer spriteRenderer;

    public string targetTag;

    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(targetTag) || CompareTag("Bullet") && other.gameObject.CompareTag("Boss"))
        {
            
            spriteRenderer.sprite = particle;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.8f);
            Destroy(this.gameObject,0.03f);   
        }
    }

    private void OnDestroy() {
        if(particle!=null){
            spriteRenderer.sprite = particle;   
        }
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
