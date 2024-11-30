using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private int initialSpeed = 5;
    [SerializeField] private float extraSpeedPerHit = 0.5f;
    [SerializeField] private int maxSpeed = 10;

    private Rigidbody2D _rb;
    private float _speed;
    private int _hitCount;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(StartBall());
    }
    
    private void ResetBall(bool turnPlayer1)
    {
        _rb.linearVelocity = Vector2.zero;
        _speed = initialSpeed;
        _hitCount = -1;
        transform.localPosition = turnPlayer1 ? Vector3.left : Vector3.right;
    }

    public IEnumerator StartBall(bool turnPlayer1 = true)
    {
        ResetBall(turnPlayer1);
        
        yield return new WaitForSeconds(2);
        
        MoveBall(turnPlayer1 ? Vector2.left : Vector2.right);
    }

    public void MoveBall(Vector2 direction)
    {
        _speed += extraSpeedPerHit * ++_hitCount;
        
        if (_speed > maxSpeed)
            _speed = maxSpeed;
        
        _rb.linearVelocity = direction.normalized * _speed;
    }
}