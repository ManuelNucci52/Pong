using System.Collections;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private GameSettings gameController;
    
    private Rigidbody2D _rb;
    private float _currentSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(SetupBall(PongUtils.RaffleStartingReceiver()));
    }
    
    private void ResetBall(int receivingPlayer)
    {
        _rb.linearVelocity = Vector2.zero;
        transform.localPosition = receivingPlayer == 2 ? Vector3.left : Vector3.right;
        _currentSpeed = gameController.InitialBallSpeed;
    }

    public IEnumerator SetupBall(int receivingPlayer)
    {
        ResetBall(receivingPlayer);
        
        yield return new WaitForSeconds(gameController.BallSleepTime);
        
        Move(receivingPlayer == 2 ? Vector2.left : Vector2.right);
    }

    public void Move(Vector2 direction)
    {
        _currentSpeed = PongUtils.Clamp(_currentSpeed + gameController.BallSpeedBoost, gameController.MaxBallSpeed);
        _rb.linearVelocity = direction.normalized * _currentSpeed;
    }
}