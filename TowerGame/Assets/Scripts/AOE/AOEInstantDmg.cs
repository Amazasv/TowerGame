using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void CollisionEvent(Collider2D collision);
public class AOEInstantDmg : AOEBase
{
    public string targetTag = "Enemy";
    public CollisionEvent collisionEvent = null;
    public override bool CheckTarget(Collider2D collision)
    {
        return collision.CompareTag(targetTag);
    }

    public override void InstantEffect(Collider2D collision)
    {
        base.InstantEffect(collision);
        collisionEvent?.Invoke(collision);
    }
}
