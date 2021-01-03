using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] sprites;
    [SerializeField] string[] hexCodes;
    [SerializeField] GameObject[] placesForSpawn;
    [SerializeField] Color color;
    private void Start()
    {
        GameObject sprite = sprites[Random.Range(0, sprites.Length)];
        color = sprite.GetComponent<SpriteRenderer>().color;
        transform.position = placesForSpawn[Random.Range(0, placesForSpawn.Length)].transform.position;
        GameObject player = Instantiate(sprite, transform.position, Quaternion.identity) as GameObject;
        ColorUtility.TryParseHtmlString(hexCodes[Random.Range(0, hexCodes.Length)],
           out color);
        //instantiate the prefab

    }
}