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
    
    public int BallSleepTime => ballSleepTime;
    public int InitialBallSpeed => initialBallSpeed;
    public float BallSpeedBoost => ballSpeedBoost;
    public int MaxBallSpeed => maxBallSpeed;
    public float RacketSpeed => racketSpeed;
    public int WinScore => winScore;
    public float TimeBeforeGameOver => timeBeforeGameOver;
}