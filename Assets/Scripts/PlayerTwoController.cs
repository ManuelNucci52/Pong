using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float maxDistanceFromBall = 0.1f;
    [SerializeField] private GameSettings gameController;
    
    private Rigidbody2D _rb;
    private bool _isTouchingWall;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var deltaY = PongUtils.Delta("y", ball, transform).GetValueOrDefault();
        
        if ((Mathf.Abs(deltaY) < maxDistanceFromBall) || (_isTouchingWall && PongUtils.Concordant(deltaY, transform.localPosition.y)))
            _rb.linearVelocityY = 0;
        else
            _rb.linearVelocityY = Mathf.Sign(deltaY) * gameController.RacketSpeed;
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
}