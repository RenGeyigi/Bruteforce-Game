using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Zamanlayıcı : MonoBehaviour
{
 [SerializeField] TextMeshProUGUI zamanText;
    [SerializeField] float remainingTime;
    private bool isTimerRunning = true;
    private OyuncuKontrol oyuncuKontrol;

    void Start()
    {
        oyuncuKontrol = FindObjectOfType<OyuncuKontrol>();
    }

    void Update()
    {
        if (oyuncuKontrol.canControl)
        {
            if (isTimerRunning)
            {
                if (remainingTime > 0)
                {
                    remainingTime -= Time.deltaTime;
                }
                else if (remainingTime <= 0)
                {
                    remainingTime = 0;
                    isTimerRunning = false;
                    LoadGameFailScene();
                }

                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                zamanText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }

    void LoadGameFailScene()
    {
        SceneManager.LoadScene("GameFail");
    }
       
}   


