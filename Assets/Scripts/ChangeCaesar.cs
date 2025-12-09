using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;

public class ChangeCaesar : MonoBehaviour
{

    public CaesarCipher player;
    private List<char> playerAnswer;
    [SerializeField] private TextMeshProUGUI playerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerAnswer = player.playerAnswer;
    }
    
    public void IncreaseCipher()
    {

        for (int j = 0; j < playerAnswer.Count; j++)
        {
            int character = (int) playerAnswer[j];
            character += 1;
            if (character > 90)
            {
                character = 65;
            }
            playerAnswer[j] = (char) character;
        }
        playerText.text = String.Join("", playerAnswer);
    }

    public void DecreaseCipher()
    {
        for (int j = 0; j < playerAnswer.Count; j++)
        {
            int character = (int) playerAnswer[j];
            character -= 1;
            if (character < 65)
            {
                character = 90;
            }
            playerAnswer[j] = (char) character;
        }
        playerText.text = String.Join("", playerAnswer);
    }
}
