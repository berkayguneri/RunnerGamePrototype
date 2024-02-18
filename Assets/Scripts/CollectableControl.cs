using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndDisplay;

    private void Update()
    {
        Count();
    }


    public void Count()
    {
        coinCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
        coinEndDisplay.GetComponent<TextMeshProUGUI>().text = "" + coinCount;
    }

    public void ResetCoinCount()
    {
        coinCount = 0;
        Count(); 
    }
}
