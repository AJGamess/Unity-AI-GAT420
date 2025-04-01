using UnityEngine;

public class AIPatrolState : AIState
{
    //Vector3 destination = Vector3.zero;
    public AIPatrolState(StateAgent agent) : base(agent)
    {
        CreateTransition(nameof(AIIdleState))
            .AddCondition(agent.destinationDistance, Condition.Predicate.Less, 1.5f)
            .AddCondition(agent.enemySeen, false);

        CreateTransition(nameof(AIChaseState))
            .AddCondition(agent.health, Condition.Predicate.Greater, 20)
            .AddCondition(agent.enemySeen, true);
    }
    public override void OnEnter()
    {
        agent.movement.Destination = NavNode.GetRandomNavNode().transform.position;
        agent.movement.Resume();
    }
    public override void OnUpdate()
    {
        // rotate towards movement direction
        if (agent.movement.Direction != Vector3.zero)
        {
            agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation, Quaternion.LookRotation(agent.movement.Direction, Vector3.up), Time.deltaTime * 5);
        }
    }

    public override void OnExit()
    {

    }

}
