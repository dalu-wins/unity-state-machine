using System;

public class Transition {
    public AbstractState from;
    public AbstractState to;
    public Func<bool> condition;

    public Transition(AbstractState from, AbstractState to, Func<bool> condition)
    {
        this.from = from;
        this.to = to;
        this.condition = condition;
    }
}