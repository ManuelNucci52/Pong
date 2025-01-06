using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    [SerializeField] private GameSettings gameController;

    private Rigidbody2D _rb;
    private bool _isTouchingWall;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_isTouchingWall && PongUtils.Concordant(Input.GetAxisRaw("Vertical"), transform.localPosition.y))
            _rb.linearVelocityY = 0;
        else
            _rb.linearVelocityY = Input.GetAxisRaw("Vertical") * gameController.RacketSpeed;
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