using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private int[] hoverRGB = {153, 153, 255};

    /// <summary>
    /// Changes text color of the button on hover actions
    /// </summary>
    public void OnPointerEnter()
    {
        text.color = PongUtils.NormalizedRGB(hoverRGB);
    }
    
    /// <summary>
    /// Changes the current scene opened inside the game
    /// </summary>
    /// <param name="sceneName">Name of the new scene to be opened</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Restores text color of the button when user stops hovering on it
    /// </summary>
    public void OnPointerExit()
    {
        text.color = Color.white;
    }
}