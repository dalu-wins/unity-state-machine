using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    protected StateMachine stateMachine;
    public Vision vision;
    private NavMeshAgent agent;
    public Transform target;
    public float sightRange = 10f;

    // States of a guard agent
    private PatrolState patrolState;
    private HuntState huntState;

    // State dependent variables
    public Transform[] patrolPoints;

    void Awake()
    {
        
    }

    void Start()
    {
        // Setup vision
        vision = new Vision(transform, sightRange, target);
        
        agent = GetComponentInChildren<NavMeshAgent>();
        patrolState = new PatrolState(agent, patrolPoints);
        huntState = new HuntState(agent, target);

        // Setup state-machine
        AbstractState initialState = patrolState;
        List<Transition> transitions = new()
        {

            // Patrol -> Hunt when target visible
            new (
                patrolState,
                huntState,
                () => vision.CanSeeTarget
            ),

            // Hunt -> Patrol when target lost
            new (
                huntState,
                patrolState,
                () => !vision.CanSeeTarget
            ),

        };
        stateMachine = new StateMachine(initialState, transitions);
    }

    void Update()
    {
        vision.Tick();
        stateMachine.Tick();
    }

    public AbstractState GetCurrentState()
    {
        return stateMachine.GetCurrentState();
    }
}