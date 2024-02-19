using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject countDown1, countDown2, countDown3, countDownGo,fadeIn;
    public AudioSource countDownAS;
    public LevelDistance levelDistance;
    public CollectableControl collectableControl;

    public void Start()
    {
        StartCoroutine(ContSequence());

    }


    public IEnumerator ContSequence()
    {
        collectableControl.ResetCoinCount();
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        countDownAS.Play();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(true);
        PlayerMovement.canMove = true;
       
    }

   
}
