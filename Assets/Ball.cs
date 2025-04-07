using UnityEngine;

public class Ball : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start() { }
    protected virtual void Update() { }
}
