using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject character;
    public GameObject flag;
    public GameObject distance;

    void Start()
    {
        character = GameObject.Find("characterPivot");
        flag = GameObject.Find("flagPivot");
        distance = GameObject.Find("UIDistance");
    }

    void Update()
    {
        //float length = flag.transform.position.z - character.transform.position.z;

        float VecterLength = Vector3.Distance(flag.transform.position, character.transform.position);

        distance.GetComponent<Text>().text = "��ǥ �������� " + VecterLength.ToString("F2") + "m";

    }
}
