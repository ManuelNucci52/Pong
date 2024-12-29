using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int racketSpeed = 4;
    
    public int RacketSpeed => racketSpeed;
    
    public static bool AreConcordant(float x, float y)
    {
        return (x * y) > 0;
    }
    
    public static int RaffleReceivingPlayer()
    {
        return Random.Range(1, 3);
    }
}