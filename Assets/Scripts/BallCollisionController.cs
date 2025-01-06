using UnityEngine;
using UnityEngine.Audio;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField] private BallMovementController ballMovement;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private AudioResource racketHit;
    [SerializeField] private AudioResource wallHit;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Racket":
                PlaySound(racketHit);
                ballMovement.Move(GetBounceDirection(collision));
                break;
            case "Wall":
                PlaySound(wallHit);
                break;
            case "Point":
                var scoringPlayer = PongUtils.ScoringPlayer(transform);
                scoreController.UpdateScore(scoringPlayer);
                StartCoroutine(ballMovement.SetupBall(scoringPlayer));
                
                break;
        }
    }

    private void PlaySound(AudioResource sound)
    {
        _audioSource.resource = sound;
        _audioSource.Play();
    }

    private Vector2 GetBounceDirection(Collision2D collision)
    {
        var x = -Mathf.Sign(transform.localPosition.x);
        
        var deltaY = PongUtils.Delta("y", transform, collision.transform).GetValueOrDefault();
        var rangeY = PongUtils.Extension("y", collision.collider).GetValueOrDefault();
        
        var y = deltaY / rangeY;
        
        return new Vector2(x, y);
    }
}