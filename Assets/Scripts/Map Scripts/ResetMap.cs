using UnityEngine;

public class ResetMap : MonoBehaviour
{
    public PlayerAnswer playerAnswer;
    public MapChecker map;
    public HideMap hide;
    public PlayerBehavior playerBehavior;

    public void callReset()
    {
        hide.ResetMap();
        playerAnswer.ResetAnswer();
        map.ResetPlayer();
        playerBehavior.ResetGate();
    }   

    
}
