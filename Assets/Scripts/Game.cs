using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public string WhosTurn = "X";
    public AudioSource soundEffect;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI tieText;

    public List<Button> buttons = new List<Button>();

    public bool gameEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        WhosTurn = "X";
        gameEnded = false;
        winnerText.gameObject.SetActive(false);
        tieText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
