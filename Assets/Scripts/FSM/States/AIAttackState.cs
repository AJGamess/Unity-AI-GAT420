using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class AIAttackState : AIState
{
    float attackTimer;
    bool hasAttacked;

    public AIAttackState(StateAgent agent) : base(agent)
    {
        CreateTransition(nameof(AIIdleState))
            .AddCondition(agent.enemySeen, false);

        CreateTransition(nameof(AIChaseState)).
            AddCondition(agent.timer, Condition.Predicate.LessOrEqual, 0);
    }

    public override void OnEnter()
    {
        attackTimer = 1;
        hasAttacked = false;

        agent.timer.value = 4;
        agent.movement.Stop();
        agent.animator.SetTrigger("Attack");
    }

    public override void OnUpdate()
    {
        // turn towards the enemy
        Vector3 direction = agent.enemy.transform.position - agent.transform.position;
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation, Quaternion.LookRotation(direction, Vector3.up), Time.deltaTime * 5);


        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0 && !hasAttacked)
        {
            hasAttacked = true;
            agent.Attack();
        }
    }

    public override void OnExit()
    {
        //	
    }
}
