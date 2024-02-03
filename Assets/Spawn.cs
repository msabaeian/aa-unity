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

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            this.SpawnPin();
        }
    }

    public void SetLevelPins(int pins)
    {
        levelPinsCount = pins;
        UpdatePinLeftLabel();
    }

    private void SpawnPin()
    {
        if (levelPinsCount > 0)
        {
            levelPinsCount -= 1;
            Instantiate(pinPrefab, transform.position, transform.rotation);
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
