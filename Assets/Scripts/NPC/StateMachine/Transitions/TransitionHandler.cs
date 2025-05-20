using System.Collections.Generic;

public class TransitionHandler
{
    public List<Transition> transitions;

    public TransitionHandler(List<Transition> transitions)
    {
        this.transitions = transitions;
    }

    public AbstractState Tick(AbstractState currentState) {
        // Check for valid transitions
        foreach (Transition transition in transitions) {
            if (transition.from == currentState && transition.condition()) {
                return transition.to;
            }
        }

        // If none found, stay in the current one
        return currentState;
    }
}