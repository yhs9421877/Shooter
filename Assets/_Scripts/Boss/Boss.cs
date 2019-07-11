using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator anim;
    private State state;
    void Start()
    {
        anim = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.hp < state.MaxHp/2){
            anim.SetTrigger("Phase2");
        }
    }
}
