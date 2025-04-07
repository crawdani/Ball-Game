using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public static PhysicsController Instance;

    private void Awake()
    {
        Instance = this;
    }

public void ResolveCollision(EnemyBall ballA, EnemyBall ballB)
{
    if (ballA == null || ballB == null) return;

    Vector2 normal = (ballB.transform.position - ballA.transform.position).normalized;
    Vector2 relativeVelocity = ballA.velocity - ballB.velocity;

    float velocityAlongNormal = Vector2.Dot(relativeVelocity, normal);

    // Skip if balls are moving apart
    if (velocityAlongNormal > 0) return;

    // Basic equal-mass collision response (swaps velocity along the normal)
    Vector2 impulse = normal * velocityAlongNormal;

    ballA.velocity -= impulse;
    ballB.velocity += impulse;
}

}
