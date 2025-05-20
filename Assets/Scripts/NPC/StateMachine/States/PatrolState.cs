using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AbstractState
{
    private readonly NavMeshAgent agent;
    private readonly Transform[] patrolPoints;
    private readonly float tolerance = 3;
    private int currentPointIndex;

    public PatrolState(NavMeshAgent agent, Transform[] patrolPoints)
    {
        this.agent = agent;
        this.patrolPoints = patrolPoints;
        this.currentPointIndex = 0;
    }

    public override void Tick()
    {
        if (patrolPoints.Length == 0) return;

        // Head for next patrol point
        if (HasReachedDestination())
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }

        // Set destination after (re-)joining patroling state 
        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
}


    private bool HasReachedDestination()
    {
        var distanceToPatrolPoint = Vector3.Distance(agent.transform.position, patrolPoints[currentPointIndex].position);
        return !agent.pathPending &&
                distanceToPatrolPoint <= agent.stoppingDistance + tolerance &&
                (!agent.hasPath || agent.velocity.sqrMagnitude == 0f);
    }
}