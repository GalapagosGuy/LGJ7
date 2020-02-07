using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinSpawner : MonoBehaviour
{
    public static GoblinSpawner instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        StartTimeToWave();
    }
    [SerializeField]
    private Image fillImage;

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

    private int defeatedGoblins = 0;

    public void StartTimeToWave()
    {
        InvokeRepeating("SpawnWave", 60, 60);
    }

    public void SpawnWave()
    {
        fillImage.color = new Color(154.0f / 255.0f, 17 / 255.0f, 0, 255.0f);
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

    public bool AreAllGoblinsDefeated()
    {
        if (defeatedGoblins == totalSpawnedGoblins && totalSpawnedGoblins != 0)
            return true;
        else
            return false;
    }

    [SerializeField]
    private DoorsScript doors;

    public void GoblinDefeated()
    {
        defeatedGoblins++;

        if (AreAllGoblinsDefeated())
            doors.CloseTheDoor();
        fillImage.color = new Color(58.0f / 255.0f, 125.0f / 255.0f, 51.0f / 255.0f, 255.0f);

    }
}
