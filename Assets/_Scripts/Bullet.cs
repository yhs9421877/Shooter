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
        if(other.gameObject.CompareTag(targetTag)){
            spriteRenderer.sprite = particle;
            Destroy(this.gameObject);   
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
