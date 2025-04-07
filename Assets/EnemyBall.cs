using UnityEngine;

public class EnemyBall : Ball
{
    public Vector2 velocity;

    protected override void Start()
    {
        base.Start();
        velocity = Random.insideUnitCircle.normalized * 10f;

    }

    protected override void Update()
    {
        base.Update();
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            EnemyBall other = collision.collider.GetComponent<EnemyBall>();
            if (other != null && other != this && PhysicsController.Instance != null)
            {
Debug.Log($"{name} collided with {other.name}");
                PhysicsController.Instance.ResolveCollision(this, other);
            }
        }

        if (collision.collider.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            velocity = Vector2.Reflect(velocity, normal);
        }
    }
}
