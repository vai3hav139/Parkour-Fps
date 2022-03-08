using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : State
{
	float rotationSpeed = 3.0f;

	public Attack(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, AIAgent _aIAgent) : base(_npc, _agent, _anim, _player, _aIAgent)
	{
		active = STATE.ATTACK;
	}



	public override void Enter()
	{
		anim.SetTrigger("isShooting");
		agent.isStopped = false;
		agent.speed = 0;
		base.Enter();
	}

	public override void Update()
	{
		Vector3 direction = player.position - npcTf.position;
		direction.y = 0;
		npcTf.rotation = Quaternion.Slerp(npcTf.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

		if (!CanAttackPlayer())
		{
			nextState = new Idle(npc, agent, anim, player, aIAgent);
			stage = EVENT.EXIT;
		}
	}

	public override void Exit()
	{
		anim.ResetTrigger("isShooting");
		base.Exit();
	}
}
