using System;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : AbstractState
{
    
    private readonly NavMeshAgent agent;
    private Transform target;

    public HuntState(NavMeshAgent agent, Transform target)
    {
        this.agent = agent;
        this.target = target;
    }

    public override void Tick()
    {
        agent.SetDestination(target.position);
    }
}