using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public State myState;

    public Transform player;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        myState = new Idle(this.gameObject, agent, anim, player, this);
    }

    void Update()
    {
        myState = myState.Process();
    }


}
