using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaWaveFromWind : MonoBehaviour
{
    [SerializeField] Material seaWave;

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = Vector3.Normalize(-transform.forward);

        Debug.Log("Wind " + vector.x+ " " + vector.z);

        seaWave.SetColor("Scroll_Vec2", new Color(vector.x, vector.z, 0, 0));
    }
}
