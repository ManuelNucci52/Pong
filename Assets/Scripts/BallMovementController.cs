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
    
    /// <summary>
    /// Resets ball position and speed in order to start a new game round
    /// </summary>
    /// <param name="receivingPlayer">Number of player that will receive the ball in next round</param>
    private void ResetBall(int receivingPlayer)
    {
        _rb.linearVelocity = Vector2.zero;
        transform.localPosition = receivingPlayer == 2 ? Vector3.left : Vector3.right;
        _currentSpeed = gameController.InitialBallSpeed;
    }

    /// <summary>
    /// Handles the start of a new round
    /// </summary>
    /// <param name="receivingPlayer">Number of player that will receive ball in next round</param>
    /// <returns>Routine to be managed by the desired Coroutine</returns>
    public IEnumerator SetupBall(int receivingPlayer)
    {
        ResetBall(receivingPlayer);
        
        yield return new WaitForSeconds(gameController.BallSleepTime);
        
        Move(receivingPlayer == 2 ? Vector2.left : Vector2.right);
    }

    /// <summary>
    /// Moves ball to a certain direction with the correct speed
    /// </summary>
    /// <param name="direction">2D vector representing the direction to be followed by ball</param>
    public void Move(Vector2 direction)
    {
        _currentSpeed = PongUtils.Clamp(_currentSpeed + gameController.BallSpeedBoost, gameController.MaxBallSpeed);
        _rb.linearVelocity = direction.normalized * _currentSpeed;
    }
}