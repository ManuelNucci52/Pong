using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    
    private Rigidbody2D _rb;
    private float _currentSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(Setup(PongUtils.RaffleStartingReceiver()));
    }
    
    private void ResetPosition(int receivingPlayer)
    {
        _rb.linearVelocity = Vector2.zero;
        transform.localPosition = receivingPlayer == 2 ? Vector3.left : Vector3.right;
        _currentSpeed = gameController.InitialBallSpeed;
    }

    public IEnumerator Setup(int receivingPlayer)
    {
        ResetPosition(receivingPlayer);
        
        yield return new WaitForSeconds(gameController.BallSleepTime);
        
        Move(receivingPlayer == 2 ? Vector2.left : Vector2.right);
    }

    public void Move(Vector2 direction)
    {
        _currentSpeed = Mathf.Clamp(_currentSpeed + gameController.BallSpeedBoost, _currentSpeed, gameController.MaxBallSpeed);
        _rb.linearVelocity = direction.normalized * _currentSpeed;
    }
}