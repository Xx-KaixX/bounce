using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField] string[] hexCodes;
    // Start is called before the first frame update
    void Start()
    {
        Color c = GetComponent<SpriteRenderer>().color;
        string a = hexCodes[Random.Range(0, hexCodes.Length)];
        if (ColorUtility.TryParseHtmlString(a, out c))
        {
            GetComponent<SpriteRenderer>().color = c;

        }

    }
}
