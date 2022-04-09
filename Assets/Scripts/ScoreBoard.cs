using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    private TMP_Text _scoreText;
    private int _score;


    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = "0";
    }

    public void ScoreIncrease(int scoreCount)
    {
        _score += scoreCount;
        _scoreText.text = _score.ToString();
    }
}
