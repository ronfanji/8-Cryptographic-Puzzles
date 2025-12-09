using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;

public class CaesarCipher : MonoBehaviour
{

    public PlayerAnswer player;
    public List<char> playerAnswer;
    public string answerString;
    [SerializeField] private GameObject revealText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerAnswer = player.playerAnswer;
        if (String.Join("", playerAnswer) == answerString)
        {
            revealText.SetActive(true);
        }
    }

}
