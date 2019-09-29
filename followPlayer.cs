using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public PlayerCollision col;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        
        if (col.poweredUP == true)
        {
            transform.position = player.position + (offset *2);
        } else
        {
            transform.position = player.position + offset;
        }
    }  
}
