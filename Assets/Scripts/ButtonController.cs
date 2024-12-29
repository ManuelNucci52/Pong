using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private float[] defaultRGB = {255, 255, 255};
    [SerializeField] private float[] hoverRGB = {255, 255, 153};
    
    private Text _buttonText;
    
    private void Awake()
    {
        _buttonText = GetComponentInChildren<Text>();
    }

    private static Color NormalizedRGB(float[] rgb)
    {
        return new Color(rgb[0] / 255, rgb[1] / 255, rgb[2] / 255);
    }
    
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnPointerEnter()
    {
        _buttonText.color = NormalizedRGB(hoverRGB);
    }

    public void OnPointerExit()
    {
        _buttonText.color = NormalizedRGB(defaultRGB);
    }
}