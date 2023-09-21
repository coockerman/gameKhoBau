using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookKhobau : MonoBehaviour
{
    [SerializeField] GameObject wingame;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        wingame.SetActive(true);
    }
}
