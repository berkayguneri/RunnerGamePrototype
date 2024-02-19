using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject charModel;
    public AudioSource crahsAS;
    public GameObject levelControl;
    //public AudioSource backgroundMusic;
    //public Animator playerAnim;

    private void OnTriggerEnter(Collider other)
    {
        
        player.GetComponent<PlayerMovement>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        //charModel.GetComponent<Animator>().Play("Standard Run", -1, 0f);
        //playerAnim.SetTrigger("die");
        levelControl.GetComponent<LevelDistance>().enabled = false;
        crahsAS.Play();
        levelControl.GetComponent<EndRunSequence>().enabled = true;
        //backgroundMusic.Stop();
        player.GetComponent<PlayerMovement>().Die();
    }


}
