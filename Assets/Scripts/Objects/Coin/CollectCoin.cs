using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinSound.Play();
            CollectableControl.coinCount += 1;
            this.gameObject.SetActive(false);
        }
    }
}
