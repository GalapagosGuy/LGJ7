﻿using System.Collections;
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

    private void Start()
    {
        SpawnWave();
    }

    public void SpawnWave()
    {
        playerIndex = 0;
        numberOfGoblinsToSpawn = 10;
        StartCoroutine("SpawnWaveOfGoblins", 0);
    }

    public IEnumerator SpawnWaveOfGoblins(int spawnedGoblins)
    {
        GameObject goblin = Instantiate(goblinPrefab, transform.position, transform.rotation);

        goblin.GetComponent<GoblinController>().player = playerReferences[playerIndex];

        spawnedGoblins++;

        playerIndex++;

        if (playerIndex >= playerReferences.Count)
            playerIndex = 0;

        yield return new WaitForSeconds(0.5f);

        if (spawnedGoblins < numberOfGoblinsToSpawn)
            StartCoroutine("SpawnWaveOfGoblins", spawnedGoblins);
    }
}
