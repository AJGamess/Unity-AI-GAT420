using System.Collections;
using UnityEngine;

public class AIHitState : AIState
{

    public AIHitState(StateAgent agent) : base(agent)
    {
        //CreateTransition(nameof(AIDeathState))
        //    .AddCondition(agent.health, Condition.Predicate.LessOrEqual, 0);

        //CreateTransition(nameof(AIPatrolState))
        //    .AddCondition(agent.enemySeen, false);
        CreateTransition(nameof(AIIdleState))
            .AddCondition(agent.timer, Condition.Predicate.LessOrEqual, 0);

        //CreateTransition(nameof(AIChaseState))
        //    .AddCondition(agent.health, Condition.Predicate.Greater, 20)
        //    .AddCondition(agent.enemySeen, true);
    }
    public override void OnEnter()
    {
        //agent.health.value -= 5;

        agent.timer.value = 2;
        agent.movement.Stop();
        agent.animator.SetTrigger("Hit");
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
