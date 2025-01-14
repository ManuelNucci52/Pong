using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [Header("Ball")]
    [SerializeField] private int ballSleepTime = 2;
    [SerializeField] private int initialBallSpeed = 5;
    [SerializeField] private float ballSpeedBoost = 0.5f;
    [SerializeField] private int maxBallSpeed = 13;
    
    [Header("Racket")]
    [SerializeField] private float racketSpeed = 4.5f;
    
    [Header("Score")]
    [SerializeField] private int winScore = 5;
    
    [Header("Scene")]
    [SerializeField] private float timeBeforeGameOver = 0.9f;
    
    /// <summary>
    /// Time before the start of a new game round
    /// </summary>
    public int BallSleepTime => ballSleepTime;
    
    /// <summary>
    /// Ball speed at the start of a new game round
    /// </summary>
    public int InitialBallSpeed => initialBallSpeed;
    
    /// <summary>
    /// Speed boost gained by ball for each racket hit
    /// </summary>
    public float BallSpeedBoost => ballSpeedBoost;
    
    /// <summary>
    /// Maximum possible speed of the ball
    /// </summary>
    public int MaxBallSpeed => maxBallSpeed;
    
    /// <summary>
    /// Speed at which players can move their racket
    /// </summary>
    public float RacketSpeed => racketSpeed;
    
    /// <summary>
    /// Score to be reached to win the game
    /// </summary>
    public int WinScore => winScore;
    
    /// <summary>
    /// Time before switching to game over scene
    /// </summary>
    public float TimeBeforeGameOver => timeBeforeGameOver;
}