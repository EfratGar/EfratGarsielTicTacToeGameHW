using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Game game;
    public Button restart;

    public void RestartButtonPressed()
    {
        game.winnerText.gameObject.SetActive(false);
        game.tieText.gameObject.SetActive(false);

        game.WhosTurn = "X";
        game.gameEnded = false;

        foreach (Button btn in game.buttons)
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = ""; 
        }
    }

    void Start()
    {
        if (game == null)
        {
            game = FindObjectOfType<Game>();
        }
    }

    void Update()
    {

    }
}
