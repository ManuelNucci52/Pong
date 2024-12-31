using UnityEngine;

public static class PongUtils
{
    public static bool AreConcordant(float x, float y)
    {
        return (x * y) > 0;
    }
    
    public static Color NormalizedRGB(int[] rgb)
    {
        return new Color(rgb[0] / 255f, rgb[1] / 255f, rgb[2] / 255f);
    }
    
    public static int RaffleStartingReceiver()
    {
        return Random.Range(1, 3);
    }
}