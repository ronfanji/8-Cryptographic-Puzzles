using UnityEngine;

public class ResetText : MonoBehaviour
{
    public PlayerAnswer playerAnswer;
    public void callReset()
    {
        playerAnswer.ResetAnswer();
    }
}
