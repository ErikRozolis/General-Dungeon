using UnityEngine;

public static class Collision2DExtensions
{
    public static bool FromPlayer(this Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }
}