using System.Collections.Generic;

public class StateMachine
{
    private readonly TransitionHandler transitionHandler;
    private AbstractState currentState;

    public StateMachine(AbstractState currentState, List<Transition> transitions)
    {
        this.currentState = currentState;
        transitionHandler = new TransitionHandler(transitions);
    }

    public void Tick()
    {
        currentState.Tick();
        currentState = transitionHandler.Tick(currentState);
    }

    public AbstractState GetCurrentState()
    {
        return currentState;
    }
}
