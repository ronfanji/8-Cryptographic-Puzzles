using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private CircleCollider2D circleCollider2D;
    public ResetMap reset;
    public HideMap hide;

    public GameObject gate;
    public GameObject key;

    void Start()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Harmful Obstacle"))
        {
            //reset.callReset();
            reset.callReset();

        }
        if (other.collider.CompareTag("Key"))
        {
            key.SetActive(false);
            gate.SetActive(false);
        }
    }

    public void ResetGate()
    {
        key.SetActive(true);
        gate.SetActive(true);
    }
}
