using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private Dictionary<string, AIState> states = new Dictionary<string, AIState>();

    public AIState CurrentState { get; private set; }

    public void Update()
    {
        CurrentState?.OnUpdate();
    }

    public void AddState(string name, AIState state)
    {
        Debug.Assert(!states.ContainsKey(name), "State machine already contains state " + name);
        states[name] = state;
    }
    public void SetState(string name)
    {
        Debug.Assert(states.ContainsKey(name), "State machine does not contain state " + name);

        var newState = states[name];
        if (newState == CurrentState) return;

        CurrentState?.OnExit();

        CurrentState = newState;

        CurrentState?.OnEnter();
    }
}
