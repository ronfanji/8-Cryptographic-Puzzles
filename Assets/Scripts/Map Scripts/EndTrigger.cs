using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTrigger : MonoBehaviour
{

    public HideMap hide;
    public MapChecker map;
    [SerializeField] private GameObject revealText;

    BoxCollider2D gateCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gateCollider = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            revealText.SetActive(true);
            hide.ResetMap();
            map.StopPlayer();   
        }
    }
    


}
