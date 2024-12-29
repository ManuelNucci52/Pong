using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private Text p1Score;
    [SerializeField] private Text p2Score;
    [SerializeField] private int scoreToWin = 5;
    [SerializeField] private float timeBeforeGameOver = 0.4f;

    private int _p1Score;
    private int _p2Score;
    
    private IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(timeBeforeGameOver);
        
        ButtonController.LoadScene("GameOver");
    }

    public void GivePoint(int scoringPlayer)
    {
        if (scoringPlayer == 1)
        {
            _p1Score++;
            p1Score.text = _p1Score.ToString();
        }
        else
        {
            _p2Score++;
            p2Score.text = _p2Score.ToString();
        }

        if ((_p1Score == scoreToWin) || (_p2Score == scoreToWin))
            StartCoroutine(LoadGameOverScene());
    }
}