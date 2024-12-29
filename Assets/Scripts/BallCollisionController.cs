using UnityEngine;
using UnityEngine.Audio;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField] private BallMovementController ballMovement;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private AudioResource racketSound;
    [SerializeField] private AudioResource wallSound;

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
                PlaySound(racketSound);
                ballMovement.Move(GetBounceDirection(collision));
                break;
            case "Point":
                scoreController.GivePoint(GetScoringPlayer());
                StartCoroutine(ballMovement.Setup(GetScoringPlayer()));
                break;
            case "Wall":
                PlaySound(wallSound);
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
        var x = transform.localPosition.x < 0 ? 1 : -1;
        var deltaY = transform.localPosition.y - collision.transform.localPosition.y;
        var y = Mathf.Clamp(deltaY / collision.collider.bounds.extents.y, -1, 1);

        return new Vector2(x, y);
    }

    private int GetScoringPlayer()
    {
        return transform.localPosition.x > 0 ? 1 : 2;
    }
}