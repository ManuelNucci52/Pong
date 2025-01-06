using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text p1Score;
    [SerializeField] private Text p2Score;
    [SerializeField] private GameSettings gameController;

    private int _p1Score;
    private int _p2Score;
    
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(gameController.TimeBeforeGameOver);
        
        SceneManager.LoadScene("GameOver");
    }

    public void UpdateScore(int scoringPlayer)
    {
        if (scoringPlayer == 1)
            p1Score.text = $"{++_p1Score}";
        else
            p2Score.text = $"{++_p2Score}";

        if ((_p1Score == gameController.WinScore) || (_p2Score == gameController.WinScore))
            StartCoroutine(EndGame());
    }
}