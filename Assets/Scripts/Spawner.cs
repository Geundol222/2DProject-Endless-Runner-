using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Prefabs;
    private int spawnDelay;
    private int randomIndex;

    private void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnRoutine);
    }

    Coroutine spawnRoutine;

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            spawnDelay = Random.Range(2, 4);
            randomIndex = Random.Range(0, Prefabs.Length);
            Instantiate(Prefabs[randomIndex], transform.position, transform.rotation);
        }
    }
}
