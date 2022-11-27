using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winTxt;

    public TextMeshProUGUI player1PointsTxt;
    public TextMeshProUGUI player2PointsTxt;

    private int player1Points;
    private int player2Points;

    public void ScorePlayer1()
    {
        player1Points++;

        player1PointsTxt.text = player1Points.ToString();

        if(player1Points == 10)
        {
            Win("Player 1");
        }
    }

    public void ScorePlayer2()
    {
        player2Points++;

        player2PointsTxt.text = player2Points.ToString();

        if (player2Points == 10)
        {
            Win("Player 2");
        }
    }

    private void Win(string player)
    {
        winTxt.text = player + " won!";
    }

    private IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
