using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTextChanger : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public string x = "X";
    public string o = "O";
    public Game game;
    public Button button;

    private List<Button> buttons = new List<Button>();

    public void ButtonPressed()
    {
        if (game.gameEnded)
        {
            return;
        }

        if (buttonText.text == "X" || buttonText.text == "O")
        {
            return;
        }

        if (game.WhosTurn == "X")
        {
            buttonText.text = "X";
            game.WhosTurn = "O";
        }
        else
        {
            buttonText.text = "O";
            game.WhosTurn = "X";
        }

        if (game.soundEffect.isPlaying)
        {
            game.soundEffect.Stop();
        }

        game.soundEffect.PlayOneShot(game.soundEffect.clip, 0.5f);

        CheckForWinnerOrTie();
    }

    void Start()
    {
        game = FindObjectOfType<Game>();
        buttons = game.buttons;
    }

    void CheckForWinnerOrTie()
    {
        List<string> buttonTexts = new List<string>();
        foreach (Button btn in buttons)
        {
            buttonTexts.Add(btn.GetComponentInChildren<TextMeshProUGUI>().text);
        }

        if (CheckLine(buttonTexts[0], buttonTexts[1], buttonTexts[2]) ||
            CheckLine(buttonTexts[3], buttonTexts[4], buttonTexts[5]) ||
            CheckLine(buttonTexts[6], buttonTexts[7], buttonTexts[8]) ||
            CheckLine(buttonTexts[0], buttonTexts[3], buttonTexts[6]) ||
            CheckLine(buttonTexts[1], buttonTexts[4], buttonTexts[7]) ||
            CheckLine(buttonTexts[2], buttonTexts[5], buttonTexts[8]) ||
            CheckLine(buttonTexts[0], buttonTexts[4], buttonTexts[8]) ||
            CheckLine(buttonTexts[2], buttonTexts[4], buttonTexts[6]))
        {
            return; 
        }

        if (!buttonTexts.Contains(""))
        {
            game.tieText.text = "It is a Tie!";
            game.tieText.gameObject.SetActive(true);
            game.gameEnded = true;
        }
    }

    bool CheckLine(string button1, string button2, string button3)
    {
        if (button1 == button2 && button2 == button3 && button1 != "")
        {
            game.winnerText.text = $"Player {button1} Won!";
            game.winnerText.gameObject.SetActive(true);
            game.gameEnded = true;
            return true; 
        }
        return false;
    }

    void Update()
    {

    }
}