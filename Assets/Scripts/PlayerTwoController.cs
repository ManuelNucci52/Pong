using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Transform ball;
    [SerializeField] private float minDistanceForMove = 0.1f;
    
    private Rigidbody2D _rb;
    private bool _isTouchingWall;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if ((Mathf.Abs(DeltaY()) < minDistanceForMove) || (_isTouchingWall && PongUtils.AreConcordant(DeltaY(), transform.localPosition.y)))
            _rb.linearVelocityY = 0;
        else
            _rb.linearVelocityY = Mathf.Sign(DeltaY()) * gameController.RacketSpeed;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            _isTouchingWall = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            _isTouchingWall = false;
    }

    private float DeltaY()
    {
        return ball.localPosition.y - transform.localPosition.y;
    }
}