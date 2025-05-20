using System;
using System.Runtime.InteropServices;
using UnityEngine;

[Serializable]
public class Vision
{
    public Transform agent;
    public float sightRange = 10f;
    public Transform target;

    public bool CanSeeTarget;

    public Vision(Transform agent, float sightRange, Transform target)
    {
        this.agent = agent;
        this.sightRange = sightRange;
        this.target = target;
    }

    public void Tick()
    {
        // Check if traget is set
        if (target == null)
        {
            CanSeeTarget = false;
            return;
        }

        // Check if target is out of range
        Vector3 dir = target.position - agent.position;
        if (dir.sqrMagnitude > sightRange * sightRange)
        {
            CanSeeTarget = false;
            return;
        }

        CanSeeTarget = true;
    }
}
