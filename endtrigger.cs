using UnityEngine;

public class endtrigger : MonoBehaviour
{
    public gameManager GM;

    void OnTriggerEnter()
    {
        GM.completeLevel();   
    }
}
