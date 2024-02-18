using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    public GameObject liveCouins;
    public GameObject liveDis;
    public GameObject highScoreText;
    public GameObject endScreen;
    public GameObject fadeOut;
    


    private void Start()
    {
        StartCoroutine(EndSequence());
    }



    IEnumerator EndSequence()
    {
        yield return new WaitForSeconds(5);
        liveCouins.SetActive(false);
        liveDis.SetActive(false);
        endScreen.SetActive(true);
        highScoreText.SetActive(true);
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
