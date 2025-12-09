using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System;
using TMPro;


public class AristocratCipher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string quote;
    public string reveal;
    private string upperCaseQuote;
    public string aristocrat;
    public Dictionary<char, char> encodeLetters = new Dictionary<char, char>();
    private List<int> notEncoded = new List<int>();
    [SerializeField] private TextMeshProUGUI aristocratText;
    [SerializeField] private TextMeshProUGUI revealText;


    public List<char> playerAnswer;
    public PlayerAnswer playerAnswerObject;

    void Start()
    {
        upperCaseQuote = quote.ToUpper();
        playerAnswer = new List<char>(upperCaseQuote.Length);
        //Debug.Log(upperCaseQuote);

        for (int j = 0; j < 26; j++)
        {
            notEncoded.Add(j);
        }

        StringBuilder resultString = new StringBuilder();
        int totalLetters = 26;

        foreach (char encryptLetter in upperCaseQuote)
        {
            // if this letter has already been encoded
            if (encodeLetters.ContainsKey(encryptLetter))
            {
                resultString.Append(encodeLetters[encryptLetter]);
            }
            // if this character is a space
            else if (encryptLetter == ' ')
            {
                resultString.Append(" ");
            }
            // if this is not a letter
            else if (encryptLetter < 65 || encryptLetter > 90)
            {
                resultString.Append(encryptLetter);
            }
            else
            {
                int randomInd = UnityEngine.Random.Range(0, totalLetters);
                char notAdded = (char)((int)'A' + notEncoded[randomInd]);
                encodeLetters[encryptLetter] = notAdded;
                notEncoded.Remove(notEncoded[randomInd]);
                resultString.Append(notAdded);
                totalLetters -= 1;
            }

        }

        aristocrat = resultString.ToString();
        
        aristocratText.text = aristocrat;

    }

    // Update is called once per frame
    // Use to Check current player's input with the actual quote
    void Update()
    {
        playerAnswer = playerAnswerObject.playerAnswer;
        if (checkCipher())
        {
            revealText.text = reveal;
        }

    }

    // check if player's string and correct string match
    private bool checkCipher()
    {
        if (playerAnswer.Count == 0) return false;
        return String.Join("", playerAnswer).Replace(" ", "") == upperCaseQuote.Replace(" ", "");
    }

    
}
