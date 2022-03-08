using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State 
{
	public enum STATE
	{
		IDLE, PATROL, PURSUE, ATTACK
	};

	public enum EVENT
	{
		ENTER, UPDATE, EXIT
	};

	public STATE active;
	protected State nextState;

	public EVENT stage;

	protected GameObject npc;
	protected Transform player;
	protected Transform npcTf;
	protected Animator anim;
	protected NavMeshAgent agent;

	protected AIAgent aIAgent;

	float seeDist = 12.0f;
	float seeAngle = 31.0f;
	float shootDist = 6.0f;



	public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, AIAgent _aIAgent)
	{
		npc = _npc;
		agent = _agent;
		anim = _anim;
		player = _player;

		npcTf = npc.transform;
		aIAgent = _aIAgent;

		stage = EVENT.ENTER;
	}

	public virtual void Enter()
	{
		stage = EVENT.UPDATE;
	}

	public virtual void Update()
	{
		stage = EVENT.UPDATE;
	}

	public virtual void Exit()
	{
		stage = EVENT.EXIT;
	}

	public State Process()
	{
		if (stage == EVENT.ENTER)
		{
			Enter();
		}
		if (stage == EVENT.UPDATE)
		{
			Update();
		}
		if (stage == EVENT.EXIT)
		{
			Exit();
			return nextState;
		}

		return this;
	}

	public bool CanSeePlayer()
	{
		Vector3 direction = player.position - npcTf.position;
		float angle = Vector3.Angle(direction, npcTf.forward);

		if (direction.magnitude < seeDist && angle < seeAngle)
		{
			return true;
		}

		return false;
	}

	public bool CanAttackPlayer()
	{
		Vector3 direction = player.position - npc.transform.position;

		if (direction.magnitude < shootDist)
		{
			return true;
		}
		return false;
	}

}
