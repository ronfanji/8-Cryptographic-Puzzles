using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System;
using TMPro;


// holds all letters that were used and also displays them for the user
// prevents using the same letter twice (allow users to type same letter for same encoding)
public class HashTable : MonoBehaviour
{

    public AristocratCipher aristocratCipher;

    private List<char> playerAnswer;
    private string playerString;
    private string aristocrat;
    private Dictionary<char, char> hashTable = new Dictionary<char, char>();
    [SerializeField] private TextMeshProUGUI hashTableText;
    [SerializeField] private TextMeshProUGUI aristocratText;
    public GameObject repeatedText;
    private bool repeated = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // add every letter a-z
        for (int charNum = 65; charNum <= 90; charNum += 1)
        {
            hashTable[(char)charNum] = ' ';
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        repeated = false;
        aristocrat = aristocratText.text.Replace(" ", "");
        playerAnswer = aristocratCipher.playerAnswer;
        playerString = String.Join("", playerAnswer).Replace(" ", "");

        if (playerString.Length > aristocrat.Length) return;

        // add every letter a-z
        for (int charNum = 65; charNum <= 90; charNum += 1)
        {
            hashTable[(char)charNum] = ' ';
        }


        for (int index = 0; index < playerString.Length; index++)
        {
            char playerChar = playerString[index];
            char answerChar = aristocrat[index];

            if (playerChar == ' ' || answerChar == ' ')
            {
                continue;
            }
            else
            {
                if (hashTable[playerChar] == ' ')
                {
                    hashTable[playerChar] = answerChar;
                }
                // if this character was already mapped
                else if(hashTable[playerChar] != answerChar)
                {
                    repeated = true;
                }
            }
        }

        repeatedText.SetActive(repeated);
        

        StringBuilder hashString = new StringBuilder();
        int count = 0;
        foreach (var pair in hashTable)
        {
            if (pair.Value == ' ') continue;
            hashString.Append(pair.Value);
            hashString.Append("->");
            hashString.Append(pair.Key);
            if (count % 3 == 2)
            {
                hashString.Append("\n");
            }
            else
            {
                hashString.Append(", ");
            }
            count += 1;
        }

        hashTableText.text = hashString.ToString();
    }
}
