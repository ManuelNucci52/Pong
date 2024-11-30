using UnityEngine;
using UnityEngine.Audio;

public class BallCollisionController : MonoBehaviour
{
    [SerializeField] private BallMovementController bmController;
    [SerializeField] private AudioResource racketSound;
    [SerializeField] private AudioResource wallSound;

    private AudioSource _as;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Racket":
                _as.resource = racketSound;
                _as.Play();
                bmController.MoveBall(GetBounceDirection(collision));
                break;
            case "Point":
                StartCoroutine(bmController.StartBall(transform.localPosition.x < 0));
                break;
            case "Wall":
                _as.resource = wallSound;
                _as.Play();
                break;
        }
    }

    private Vector2 GetBounceDirection(Collision2D collision)
    {
        var x = transform.localPosition.x < 0 ? 1 : -1;
        
        var deltaY = transform.localPosition.y - collision.transform.localPosition.y;

        deltaY = deltaY switch
        {
            > 1 => 1,
            < -1 => -1,
            _ => deltaY
        };

        var y = deltaY / collision.collider.bounds.extents.y;

        return new Vector2(x, y);
    }
}