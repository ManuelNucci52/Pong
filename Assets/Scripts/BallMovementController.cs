using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private int timeBeforeMove = 2;
    [SerializeField] private int startSpeed = 5;
    [SerializeField] private float extraSpeedPerHit = 0.5f;
    [SerializeField] private int maxSpeed = 13;

    private Rigidbody2D _rb;
    private float _currentSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Setup(GameController.RaffleReceivingPlayer()));
    }
    
    private void ResetPosition(int receivingPlayer)
    {
        _rb.linearVelocity = Vector2.zero;
        transform.localPosition = receivingPlayer == 2 ? Vector3.left : Vector3.right;
        _currentSpeed = startSpeed;
    }

    public IEnumerator Setup(int receivingPlayer)
    {
        ResetPosition(receivingPlayer);
        
        yield return new WaitForSeconds(timeBeforeMove);
        
        Move(receivingPlayer == 2 ? Vector2.left : Vector2.right);
    }

    public void Move(Vector2 direction)
    {
        _currentSpeed = Mathf.Clamp(_currentSpeed + extraSpeedPerHit, _currentSpeed, maxSpeed);
        _rb.linearVelocity = direction.normalized * _currentSpeed;
    }
}