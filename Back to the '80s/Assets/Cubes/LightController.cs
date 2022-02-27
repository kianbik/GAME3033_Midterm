using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Material[] cubeMaterial = new Material[6];
    public int materialStarter = 0;
    public GameObject Object;
    public bool border = false;
   public float timerForColor = 2.0f;

    float timerRemaining;
    void Update()
    {
        timerRemaining -= Time.deltaTime;
        if (timerRemaining < 0)
        {
            ChangeMaterial();

        }
    }

    void ChangeMaterial()
    {
        timerRemaining = timerForColor;
        if (border)
        {
            if (materialStarter < cubeMaterial.Length - 1)
            {
                materialStarter++;
            }
            else materialStarter = 0;
        }
        else
        materialStarter = Random.Range(0, 5);
        Object.GetComponent<MeshRenderer>().material = cubeMaterial[materialStarter];

    }

}
