using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonController : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("GameWorld");
    }
}