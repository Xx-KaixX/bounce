using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    [SerializeField] GameObject[] placesForSpawn;
    private void Start()
    {
        GameObject sprite = sprites[Random.Range(0, sprites.Length)];
        //transform.position = placesForSpawn[Random.Range(0, placesForSpawn.Length)].transform.position;
        GameObject player = Instantiate(sprite, sprite.transform.position, Quaternion.identity) as GameObject;
        //instantiate the prefab

    }
}