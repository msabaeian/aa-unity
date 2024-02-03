using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 100f;
    public GameObject noActionPinPrefab;
    private int defaultPins = 5;
    private float radius = 1.8f;
    
    void GeneratePinsAroundCircle()
    {
        for (int i = 0; i < defaultPins; i++)
        {
            // Calculate angle in radians and convert angle to a position
            float angle = i * Mathf.PI * 2 / defaultPins;
            Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            
            GameObject spike = Instantiate(noActionPinPrefab, transform.position + position, Quaternion.identity);
            
            spike.transform.SetParent(transform);
            spike.transform.up = -position.normalized;
        }
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }

    public void SetDefaultPins(int value)
    {
        foreach (var obj in GameObject.FindObjectsOfType<Pin>())
        {
            Destroy(obj.gameObject);
        }
        
        foreach (var obj in GameObject.FindObjectsOfType<NoActionPin>())
        {
            Destroy(obj.gameObject);
        }

        defaultPins = value;
        if (value > 1)
        {
            GeneratePinsAroundCircle();    
        }
    }
}
