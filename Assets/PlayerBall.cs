using UnityEngine;

public class PlayerBall : Ball
{
    private Camera mainCam;

    protected override void Awake()
    {
        base.Awake(); // keep base initialization
        mainCam = Camera.main;
    }

    protected override void Update()
    {
        base.Update();

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // distance from camera
        transform.position = mainCam.ScreenToWorldPoint(mousePosition);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameController.Instance.GameOver();
        }
    }
}
