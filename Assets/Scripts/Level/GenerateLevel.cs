using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sectionPrefabs;
    public int zPos = 121;
    public bool creatingSection = false;
    public int secNum;


    private void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }

       
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 2);
        Instantiate(sectionPrefabs[secNum], new Vector3(-3, 1.5f, zPos), Quaternion.identity);
        zPos += 38;
        yield return new WaitForSeconds(2);
        creatingSection = false;


    }

    
}
