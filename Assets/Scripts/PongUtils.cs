using UnityEngine;

public static class PongUtils
{
    public static float Clamp(float value, int max)
    {
        return Mathf.Clamp(value, float.MinValue, max);
    }
    
    public static bool Concordant(float x, float y)
    {
        return (x * y) > 0;
    }

    public static float? Delta(string axis, Transform first, Transform second)
    {
        return axis.ToLowerInvariant() switch
        {
            "x" => first.localPosition.x - second.localPosition.x,
            "y" => first.localPosition.y - second.localPosition.y,
            "z" => first.localPosition.z - second.localPosition.z,
            _ => null
        };
    }

    public static float? Extension(string axis, Collider2D collider)
    {
        return axis.ToLowerInvariant() switch
        {
            "x" => collider.bounds.extents.x,
            "y" => collider.bounds.extents.y,
            _ => null
        };
    }
    
    public static Color NormalizedRGB(int[] rgb)
    {
        return new Color(rgb[0] / 255f, rgb[1] / 255f, rgb[2] / 255f);
    }
    
    public static int RaffleStartingReceiver()
    {
        return Random.Range(1, 3);
    }
    
    public static int ScoringPlayer(Transform ball)
    {
        return ball.localPosition.x > 0 ? 1 : 2;
    }
}