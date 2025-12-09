using UnityEngine;
using System.Collections;

public class HideMap : MonoBehaviour
{

    public MapChecker map;
    public GameObject hider;
    private bool buttonPress = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if player started moving, hide the map
        if (!buttonPress && map.startMoving && !map.stopMoving)
        {
            hider.SetActive(true);
        }
    }

    public void RevealMapButtonPress()
    {
        StartCoroutine(RevealMap());
    }

    public IEnumerator RevealMap()
    {
        hider.SetActive(false);
        buttonPress = true;
        map.stopMoving = true;
        yield return new WaitForSeconds(2f);
        hider.SetActive(true);
        buttonPress = false;
        map.stopMoving = false;
    }

    public void ResetMap()
    {
        hider.SetActive(false);
        map.startMoving = false;
        map.stopMoving = false;
    }
    
}
