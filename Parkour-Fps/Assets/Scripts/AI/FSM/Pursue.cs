﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pursue : State
{
	public Pursue(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, AIAgent _aIAgent) : base(_npc, _agent, _anim, _player, _aIAgent)
	{
		active = STATE.PURSUE;
		agent.speed = 5;
		agent.isStopped = false;
	}

	public override void Enter()
	{
		anim.SetTrigger("isRunning");
		base.Enter();
	}

	public override void Update()
	{
        
		agent.SetDestination(player.position);

		if (agent.hasPath)
		{
			if (CanAttackPlayer())
			{
				nextState = new Attack(npc, agent, anim, player, aIAgent);
				stage = EVENT.EXIT;
			}

			else if (!CanSeePlayer())
			{
				nextState = new Idle(npc, agent, anim, player, aIAgent);
				stage = EVENT.EXIT;
			}
		}
	}

	public override void Exit()
	{
		anim.ResetTrigger("isRunning");
		base.Exit();
	}
}
