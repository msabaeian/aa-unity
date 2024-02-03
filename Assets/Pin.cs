using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rigid;
    private bool isPinned = false;
    private Spawn spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawn>();
    }

    private void Update()
    {
        if (!isPinned)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spinner")
        {
            isPinned = true;
            transform.SetParent(other.transform);
            
            if (spawner.levelPinsCount == 0)
            {
                GameManager.Instance.Win();
            }
        }else if (other.tag == "Pin")
        {
            GameManager.Instance.GameOver();
        }
    }
}
