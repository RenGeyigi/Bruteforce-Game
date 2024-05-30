using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ses : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public AudioSource correctSoundSource;
    public AudioSource incorrectSoundSource;
    public int playCount;// Sesi kaç kez çalmak istediğinizi belirleyin

    void Awake()
    {
        // AudioSource bileşenini al
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource2 == null)
        {
            // Eğer ikinci AudioSource bileşeni atanmadıysa, hata mesajı göster
            Debug.LogError("Second AudioSource is not assigned.");
        }
    }

    void Start()
    {
        // İlk ses dosyasının doğru şekilde ayarlanmış olduğundan emin olun
        if (audioSource != null)
        {
            StartCoroutine(PlayAudioMultipleTimes(playCount));
        }
    }
 public void PlayCorrectSound()
    {
        if (correctSoundSource != null)
        {
            correctSoundSource.Play();
        }
    }

    public void PlayIncorrectSound()
    {
        if (incorrectSoundSource != null)
        {
            incorrectSoundSource.Play();
        }
    }
    private IEnumerator PlayAudioMultipleTimes(int times)
    {
        // İlk ses dosyasını belirtilen sayıda çal
        for (int i = 0; i < 2; i++)
        {
        
            audioSource.Play();
            // Ses dosyasının çalma süresi kadar bekle
            yield return new WaitForSeconds(1f);
        }

        // İkinci ses dosyasını belirtilen sayıda çal
        for (int i = 0; i < 3; i++)
        {
          
            audioSource2.Play();
            // Ses dosyasının çalma süresi kadar bekle
            yield return new WaitForSeconds(1f);
        }
    }
}

    
