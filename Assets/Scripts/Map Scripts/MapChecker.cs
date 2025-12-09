using UnityEngine;
using System.Collections.Generic;

public class MapChecker : MonoBehaviour
{

    public PlayerAnswer playerAnswerObject;
    public List<char> playerAnswer;
    public int moveVelocity;

    public Transform playerTransform;
    private Vector3 startPos;
    [SerializeField] private Rigidbody2D rb;

    public bool startMoving = false;
    public bool stopMoving = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnswer = new List<char>();
        startPos = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerAnswer = playerAnswerObject.playerAnswer;

        // if size of the list is 0 (not yet changed), skip
        if (playerAnswer.Count == 0 || stopMoving)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        char lastChar = playerAnswer[playerAnswer.Count - 1];
        string fish = "FISH";
        if (!fish.Contains(lastChar))
        {
            return;
        }
        startMoving = true;
        // up
        if (lastChar == 'I')
        {
            rb.linearVelocity = new Vector3(0, moveVelocity, 0);
        }
        // left
        else if (lastChar == 'S')
        {
            rb.linearVelocity = new Vector3(-moveVelocity, 0, 0);
        }
        // down
        else if (lastChar == 'H')
        {
            rb.linearVelocity = new Vector3(0, -moveVelocity, 0);
        }
        // right
        else if (lastChar == 'F')
        {
            rb.linearVelocity = new Vector3(moveVelocity, 0, 0);
        }
    }

    public void StopPlayer()
    {
        rb.linearVelocity = Vector3.zero;
        stopMoving = true;
    }

    public void ResetPlayer()
    {
        playerTransform.position = startPos;
        startMoving = false;
        stopMoving = false;
    }

}
