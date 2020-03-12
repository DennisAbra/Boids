using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }
    Collider2D agentCollider;

    public Collider2D AgentCollider { get { return agentCollider; } }
    
    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void  Move(Vector2 direction)
    {
        transform.up = direction;
        transform.position += (Vector3)direction * Time.deltaTime;
    }
}
