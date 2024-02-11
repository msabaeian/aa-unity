using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pinPrefab;
    public int levelPinsCount { get; private set; } = 5;
    private TextMeshPro pinLeftCountLabelMesh;
    private void Start()
    {
        pinLeftCountLabelMesh = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        this.UpdatePinLeftLabel();
    }

    public void SetLevelPins(int pins)
    {
        levelPinsCount = pins;
        UpdatePinLeftLabel();
    }

    public void SpawnPin()
    {
        if (levelPinsCount > 0)
        {
            levelPinsCount -= 1;
            Instantiate(pinPrefab, transform.position, transform.rotation);
            gameObject.GetComponent<AudioSource>().Play();
            if (levelPinsCount == 0)
            {
                pinLeftCountLabelMesh.text = "OK!";
            }
            else
            {
                this.UpdatePinLeftLabel();    
            }
            
        }
    }

    private void UpdatePinLeftLabel()
    {
        if (pinLeftCountLabelMesh)
        {
            pinLeftCountLabelMesh.text = levelPinsCount.ToString();
        }
    }
}
