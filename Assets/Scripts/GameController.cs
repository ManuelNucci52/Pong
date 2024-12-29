using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float racketSpeed = 4.5f;
    
    public float RacketSpeed => racketSpeed;
    
    public static bool AreConcordant(float x, float y)
    {
        return (x * y) > 0;
    }
    
    public static int RaffleReceivingPlayer()
    {
        return Random.Range(1, 3);
    }
}