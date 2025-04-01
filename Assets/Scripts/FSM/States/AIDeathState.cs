using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class AIDeathState : AIState
{
	public AIDeathState(StateAgent agent) : base(agent)
	{
		//
	}

	public override void OnEnter()
	{
		GameObject.Destroy(agent.gameObject, 5);

		agent.movement.Stop();
		agent.animator.SetTrigger("Death");
	}

	public override void OnUpdate()
	{
		//
	}

	public override void OnExit()
	{
		//	
	}
}
