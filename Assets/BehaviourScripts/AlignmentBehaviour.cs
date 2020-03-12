using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilterFlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighhbours, maintain current alignment/direction
        if (context.Count == 0)
        { return agent.transform.up; }

        //add all point togheter and average
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filterContext)
        {
            alignmentMove += (Vector2)item.up;
        }
        alignmentMove /= context.Count;

        return alignmentMove;
    }
}
