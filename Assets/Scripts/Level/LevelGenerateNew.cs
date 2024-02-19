using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerateNew : MonoBehaviour
{
    public GameObject[] initialSections; // Karakterin önünde baþlangýçta bulunan sectionlar
    public GameObject[] sectionPrefabs; // Spawnlanacak olan section prefab'larý
    public Transform playerTransform;
    public float sectionLength = 38f;
    public float despawnDistance = 50f;

    private List<GameObject> sections = new List<GameObject>();

    void Start()
    {
        
        foreach (GameObject section in initialSections)
        {
            sections.Add(section);
        }
    }

    void Update()
    {
        // Karakterin ilerlediði yolu kontrol et
        if (playerTransform.position.z > sections[sections.Count - 1].transform.position.z - despawnDistance)
        {
            SpawnSection();
        }

        // Karakterin gerisindeki section'larý devre dýþý býrak
        DespawnSections();
    }

    void SpawnSection()
    {
        //Yeni bir section spawnla
        GameObject sectionPrefab = sectionPrefabs[Random.Range(0, sectionPrefabs.Length)];
        GameObject section = Instantiate(sectionPrefab, new Vector3(-3, 1.5f, sections[sections.Count - 1].transform.position.z + sectionLength), Quaternion.identity);
        sections.Add(section);

        section.SetActive(true);
    }

    void DespawnSections()
    {
        // Karakterin gerisindeki section'larý devre dýþý býrak
        for (int i = 0; i < sections.Count; i++)
        {
            if (sections[i].transform.position.z < playerTransform.position.z - despawnDistance)
            {
                sections[i].SetActive(false);
            }
        }
    }
    
}
