using UnityEngine;

public class PlayerCollision : MonoBehaviour { 

    public movement move;
    public Transform player;
    public Vector3 power;
    public Rigidbody playerRB;
    public Rigidbody obsticleRB;
    public bool poweredUP = false;

    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obsticle")
        {
            Debug.Log(obsticleRB.mass + "" + playerRB.mass);
            Debug.Log(obsticleRB.mass >= playerRB.mass);
            Debug.Log(poweredUP == true);
            if (obsticleRB.mass >= playerRB.mass )
            {
                if (poweredUP == true)
                {
                    transform.localScale = player.localScale - power;
                    playerRB.mass = playerRB.mass - 2;
                    move.positiveForce = move.positiveForce - 2;
                    poweredUP = false;

                } else {
                    Debug.Log("I died");
                    move.enabled = false;
                    FindObjectOfType<gameManager>().endgame();
                }
                
            } else
            {
                Debug.Log("I killed an obsticle");
                Destroy(collisionInfo.gameObject);
            }
            
        }
        if (collisionInfo.collider.tag == "PowerUP" && poweredUP == false)
        {
            Destroy(collisionInfo.gameObject);
            poweredUP = true;
            Debug.Log("woohoo a powerup");
            transform.localScale = player.localScale + power;
            playerRB.mass = playerRB.mass * 2;
            move.positiveForce = move.positiveForce * 2;
        }
    }

}
