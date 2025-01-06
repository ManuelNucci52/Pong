using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private int[] hoverRGB = {153, 153, 255};

    public void OnPointerEnter()
    {
        text.color = PongUtils.NormalizedRGB(hoverRGB);
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerExit()
    {
        text.color = Color.white;
    }
}