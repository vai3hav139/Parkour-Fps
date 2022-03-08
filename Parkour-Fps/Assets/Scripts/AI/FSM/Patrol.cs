using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
	List<Transform> wayPoints = new List<Transform>();

	public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, AIAgent _aIAgent) : base(_npc, _agent, _anim, _player, _aIAgent)
	{
		active = STATE.PATROL;
		agent.speed = 2;

		agent.autoBraking = false;
		agent.isStopped = false;
	}

	public override void Enter()
	{
		anim.SetTrigger("isWalking");
		
		Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
		foreach (Transform t in wayPointsObject)
			wayPoints.Add(t);

		agent.SetDestination(wayPoints[0].position);

		base.Enter();
	}

	void GoToNextPoint()
	{
		agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
	}

	public override void Update()
	{
		
		if (agent.remainingDistance < 0.5f && !agent.pathPending)
		{
			GoToNextPoint();
		}

		if (CanSeePlayer())
		{
			nextState = new Pursue(npc, agent, anim, player, aIAgent);
			stage = EVENT.EXIT;
		}

	}

	public override void Exit()
	{
		anim.ResetTrigger("isWalking");
		base.Exit();
	}
}
