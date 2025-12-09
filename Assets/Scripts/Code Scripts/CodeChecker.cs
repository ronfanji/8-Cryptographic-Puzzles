using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System;
using TMPro;
public class CodeChecker : MonoBehaviour
{

    public string codeAnswer;

    [SerializeField] private TextMeshProUGUI numberText1;
    [SerializeField] private TextMeshProUGUI numberText2;
    [SerializeField] private TextMeshProUGUI numberText3;
    [SerializeField] private TextMeshProUGUI numberText4;

    [SerializeField] private GameObject revealImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        revealImage.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        StringBuilder checkString = new StringBuilder();
        checkString.Append(numberText1.text);
        checkString.Append(numberText2.text);
        checkString.Append(numberText3.text);
        checkString.Append(numberText4.text);

        if (checkString.ToString() == codeAnswer)
        {
            revealImage.SetActive(true);
        }
        
    }
}
