using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private int[] hoverRGB = {153, 153, 255};
    
    private Text _buttonText;
    
    private void Awake()
    {
        _buttonText = GetComponentInChildren<Text>();
    }

    private static Color NormalizedRGB(int[] rgb)
    {
        return new Color(rgb[0] / 255f, rgb[1] / 255f, rgb[2] / 255f);
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
        _buttonText.color = Color.white;
    }
}