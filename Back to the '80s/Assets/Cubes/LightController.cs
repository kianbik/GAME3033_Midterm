using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Material[] cubeMaterial = new Material[6];
    public int materialStarter = 0;
    public GameObject Object;

    float timerForColor = 2.0f;


    void Update()
    {
        timerForColor -= Time.deltaTime;
        if (timerForColor < 0)
        {
            ChangeMaterial();

        }
    }

    void ChangeMaterial()
    {
        timerForColor = 2.0f;

        if (materialStarter < cubeMaterial.Length-1)
        {
            materialStarter++;
        }
        else materialStarter = 0;
        Object.GetComponent<MeshRenderer>().material = cubeMaterial[materialStarter];

    }

}
