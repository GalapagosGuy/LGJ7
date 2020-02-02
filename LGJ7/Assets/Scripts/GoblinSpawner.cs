using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject goblinPrefab;

    [SerializeField]
    private int numberOfGoblinsToSpawn = 0;

    [SerializeField]
    private List<GameObject> playerReferences = new List<GameObject>();

    private int playerIndex = 0;

    private int totalSpawnedGoblins = 0;

    [SerializeField]
    private AudioSource hornSound;

    public void StartTimeToWave()
    {
        InvokeRepeating("SpawnWave", 60, 60);
    }

    public void SpawnWave()
    {
        playerIndex = 0;
        numberOfGoblinsToSpawn = 10;
        StartCoroutine("SpawnWaveOfGoblins", 0);

        hornSound.Play();
    }

    public IEnumerator SpawnWaveOfGoblins(int spawnedGoblins)
    {
        GameObject goblin = Instantiate(goblinPrefab, transform.position, transform.rotation);

        goblin.GetComponent<GoblinAI>().target = playerReferences[playerIndex];

        spawnedGoblins++;
        totalSpawnedGoblins++;

        playerIndex++;

        if (playerIndex >= playerReferences.Count)
            playerIndex = 0;

        yield return new WaitForSeconds(0.5f);

        if (spawnedGoblins < numberOfGoblinsToSpawn)
            StartCoroutine("SpawnWaveOfGoblins", spawnedGoblins);
    }
}
