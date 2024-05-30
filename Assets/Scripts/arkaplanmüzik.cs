using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arkaplanmüzik : MonoBehaviour
{
    private static arkaplanmüzik instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // GameObject'in sahne değişimlerinde yok olmamasını sağlar
            audioSource = GetComponent<AudioSource>();
            audioSource.loop = true; // Müzik sürekli tekrar etsin
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject); // Eğer başka bir instance varsa, bu instance'ı yok et
        }
    }
}
