using UnityEngine;

public static class PongUtils
{
    /// <summary>
    /// Forces a decimal number to not exceed a specific amount
    /// </summary>
    /// <param name="value">Decimal number to be checked</param>
    /// <param name="max">Maximum value that can be possible</param>
    /// <returns>Original number if in the range, maximum value otherwise</returns>
    public static float Clamp(float value, int max)
    {
        return Mathf.Clamp(value, float.MinValue, max);
    }
    
    /// <summary>
    /// Checks if two decimal numbers have the same sign
    /// </summary>
    /// <param name="x">First number to be checked</param>
    /// <param name="y">Second number to be checked</param>
    /// <returns>true if numbers have the same sign, false otherwise</returns>
    public static bool Concordant(float x, float y)
    {
        return (x * y) > 0;
    }

    /// <summary>
    /// Calculates the distance (with sign) between two objects on a specific axis
    /// </summary>
    /// <param name="axis">Axis to be considered for calculations</param>
    /// <param name="first">First object to be checked</param>
    /// <param name="second">Second object to be checked</param>
    /// <returns>Signed distance amount if the specified axis is valid, null otherwise</returns>
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

    
    /// <summary>
    /// Calculates the extension of an object on a specific axis
    /// </summary>
    /// <param name="axis">Axis to be considered for calculations</param>
    /// <param name="collider">Total colliding area of an object</param>
    /// <returns>Decimal extension amount if the specified axis is valid, null otherwise</returns>
    public static float? Extension(string axis, Collider2D collider)
    {
        return axis.ToLowerInvariant() switch
        {
            "x" => collider.bounds.extents.x,
            "y" => collider.bounds.extents.y,
            _ => null
        };
    }
    
    /// <summary>
    /// Normalizes a specific RGB color to be represented in Unit form
    /// </summary>
    /// <param name="rgb">Integer array representing the desired RGB color</param>
    /// <returns>Unit RGB representation of the desired color</returns>
    public static Color NormalizedRGB(int[] rgb)
    {
        return new Color(rgb[0] / 255f, rgb[1] / 255f, rgb[2] / 255f);
    }
    
    
    /// <summary>
    /// Randomly chooses the player which will receive ball at game start
    /// </summary>
    /// <returns>Number of player that will receive the ball at game start</returns>
    public static int RaffleStartingReceiver()
    {
        return Random.Range(1, 3);
    }
    
    /// <summary>
    /// Checks which player scored in the last game round
    /// </summary>
    /// <param name="ball">Object representing the ball</param>
    /// <returns>Number of player that scored in the last game round</returns>
    public static int ScoringPlayer(Transform ball)
    {
        return ball.localPosition.x > 0 ? 1 : 2;
    }

    /// <summary>
    /// Checks if collision between ball and racket should be ignored in order to avoid weird behaviours
    /// </summary>
    /// <param name="ball">Object representing the ball</param>
    /// <param name="racket">Object representing colliding area of the racket</param>
    /// <returns>true if the ball may be squeezed by the racket, false otherwise</returns>
    {
        return racket.transform.localPosition.x < 0 ?
            (ball.transform.localPosition.x < (racket.transform.localPosition.x + racket.bounds.extents.x)) :
            (ball.transform.localPosition.x > (racket.transform.localPosition.x - racket.bounds.extents.x));
    }
}