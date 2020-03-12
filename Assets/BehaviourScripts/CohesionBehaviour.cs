using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilterFlockBehaviour
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
       // if no neighhbours, return no adjustment
       if(context.Count == 0)
        { return Vector2.zero; }

       //add all point togheter and average
       Vector2 cohesionMove = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filterContext)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        //Create offset from agent position
        cohesionMove -= (Vector2)agent.transform.position;
        return cohesionMove;
    }

}
