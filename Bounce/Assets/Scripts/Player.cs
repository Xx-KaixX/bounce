using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    [SerializeField] string[] hexCodes;
    [SerializeField] GameObject[] placesForSpawn;
    private void Start()
    {
        GameObject sprite = sprites[Random.Range(0, sprites.Length)];
        Color color;
        //transform.position = placesForSpawn[Random.Range(0, placesForSpawn.Length)].transform.position;
        GameObject player = Instantiate(sprite, sprite.transform.position, Quaternion.identity) as GameObject;
        ColorUtility.TryParseHtmlString(hexCodes[Random.Range(0, hexCodes.Length)],
           out color);
        sprite.GetComponent<SpriteRenderer>().color = color;
        //instantiate the prefab

    }
}