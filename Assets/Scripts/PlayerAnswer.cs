using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System;
using TMPro;

public class PlayerAnswer : MonoBehaviour
{

    public List<char> playerAnswer;
    [SerializeField] private TextMeshProUGUI playerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnswer = new List<char>();   
    }

    // Update is called once per frame
    void Update()
    {
        checkLetter();
        StringBuilder playerString = new StringBuilder();
        foreach (char character in playerAnswer)
        {
            playerString.Append(character);
        }
        playerText.text = playerString.ToString();
    }


    private void checkLetter()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string keyPressed)
    {
        // allow backspaces to decrease playerAnswer size
        if (keyPressed == "\b" && playerAnswer.Count > 0)
        {
            playerAnswer.RemoveAt(playerAnswer.Count - 1);
        }
        else if (keyPressed == " ")
        {
            playerAnswer.Add(' ');
        }
        else
        {
            char convertedChar = Convert.ToChar(keyPressed.ToUpper());
            if (convertedChar < 65 || convertedChar > 90) { return; }
            playerAnswer.Add(convertedChar);

        }
        //Debug.Log(String.Join("", playerAnswer));
    }

    // resets player's current answer
    public void ResetAnswer()
    {
        playerAnswer = new List<char>();
        playerText.text = "";
    }
}
