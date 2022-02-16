using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRB;

    public float bounceForce = 6;

    public AudioSource bounceAudio;

    public AudioSource gameOverSound;

    public AudioSource levelCompletedSound;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.Mute)
        {
            bounceAudio.Play();
        }
        
        playerRB.velocity = new Vector3(playerRB.velocity.x, bounceForce, playerRB.velocity.z);
      
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            // the ball hits the safe area

        }
        else if (materialName == "UnSafe (Instance)" && !GameManager.gameOver)
        {
            GameManager.gameOver = true;

            // the ball hits the unsafe area
            if (!GameManager.Mute)
            {
                gameOverSound.Play();
            }
           
        }

        if (materialName == "Last (Instance)" && !GameManager.levelCompleted)
        {
            Debug.Log("Ok");
            // completed level
            GameManager.levelCompleted = true;

            if (!GameManager.Mute)
            {
                levelCompletedSound.Play();
            }
                
            
        }
    }

    

}
