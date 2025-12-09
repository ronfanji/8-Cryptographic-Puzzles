using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;
using System;
using TMPro;
public class ButtonBehavior : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI numberText;
    private int currInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currInt = int.Parse(numberText.text);
        Debug.Log(currInt);
    }

    public void IncreaseNumber()
    {
        currInt += 1;
        currInt %= 10;
        numberText.text = currInt.ToString();
    }

    public void DecreaseNumber()
    {
        currInt -= 1;
        if (currInt < 0)
        {
            currInt = 9;
        }
        numberText.text = currInt.ToString();
    }

}
