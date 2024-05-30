using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OyuncuKontrol : MonoBehaviour
{
   public GameObject[] column1Circles; // İlk sütundaki dairelerin GameObject dizisi
    public GameObject[] column2Circles; // İkinci sütundaki dairelerin GameObject dizisi
    public GameObject[] column3Circles; // Üçüncü sütundaki dairelerin GameObject dizisi
    public GameObject[] column4Circles; // Dördüncü sütundaki dairelerin GameObject dizisi
    public GameObject[] column5Circles; // Beşinci sütundaki dairelerin GameObject dizisi
    public GameObject[] column6Circles; // Altıncı sütundaki dairelerin GameObject dizisi
    public Sprite pendingSprite; // Seçili daire sprite'ı (PendingGta)
    public Sprite filledSprite; // Daire sprite'ı (FilledGta)
    public Sprite emptySprite; // Varsayılan sprite (EmptyGta)
    public Sprite falseSprite; // Yanlış seçim sprite'ı (FalseGta)
 public static int gameOverCallCount = 0;
    private GameObject[][] columns; // Sütunların iki boyutlu dizisi
    private int currentSelectedColumn = 0; // Şu an seçili olan sütunun indeksi
    private int currentSelectedIndex = 0; // Şu an seçili olan dairenin indeksi
    public bool canControl = false;
    public bool dogru = false;
    public bool yanlis = false;
    public bool SelectionCorrect { get; private set; }
    public Transform GameOverUI;
     public GameObject winImage;
    public GameObject VideoPlayer2;
     private Matematik matematik;
     

    private List<GameObject> incorrectCircles = new List<GameObject>(); // Yanlış seçilen dairelerin listesi
public Ses ses;
    // RandomlyChoose scriptine erişim için

    void Start()
    {
        // Sütunları iki boyutlu diziye yerleştir
        columns = new GameObject[][] { column1Circles, column2Circles, column3Circles, column4Circles, column5Circles, column6Circles };
       ses = FindObjectOfType<Ses>();

        // ChangeRandomCircleColor scriptinin bitişini beklemek için coroutine başlat
        StartCoroutine(WaitForColorChange());
        matematik = FindObjectOfType<Matematik>();
    }

    IEnumerator WaitForColorChange()
    {
        // ChangeRandomCircleColor scriptinin bitmesini bekle (buradaki süreyi uygun şekilde ayarla)
        yield return new WaitForSeconds(5f); // Bu süre ChangeRandomCircleColor scriptindeki toplam süreyle uyumlu olmalı

        // İlk daireyi seçili olarak ayarla
        SetSelectedCircle(currentSelectedColumn, currentSelectedIndex);

        // Kontrolü oyuncuya ver
        canControl = true;
    }

    void Update()
    {
        if (canControl)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveSelection(-1);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveSelection(1);
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (SelectedCirclesManager.ThirdIterationCircles.Contains(columns[currentSelectedColumn][currentSelectedIndex]))
                {
                    StartCoroutine(AnimateAndMoveToNextColumn(true));
                    
                }
                else
                {
                    StartCoroutine(AnimateAndMoveToNextColumn(false));
                    
                }
            }
        }
    }
     public void CheckAndAnimateSelection()
    {
        bool isCorrect = SelectedCirclesManager.ThirdIterationCircles.Contains(columns[currentSelectedColumn][currentSelectedIndex]);
        SelectionCorrect = isCorrect; // Set the flag before starting the coroutine
        StartCoroutine(AnimateAndMoveToNextColumn(isCorrect));
    }
IEnumerator gameOver()
    {
         if (gameOverCallCount < 5) // Yalnızca sayaç 3'ten küçükse işlemleri gerçekleştir
        {
            gameOverCallCount++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if (gameOverCallCount >= 5) // Eğer sayaç 3'e eşit veya büyükse GameOver sahnesine git
        {
            winImage.gameObject.SetActive(true);
            VideoPlayer2.gameObject.SetActive(true);
             yield return new WaitForSeconds(3f);
            GameOverUI.gameObject.SetActive(true);
        }
    }
    void MoveSelection(int direction)
    {
        // Mevcut daireyi varsayılan sprite'a döndür
        if (!incorrectCircles.Contains(columns[currentSelectedColumn][currentSelectedIndex]))
        {
            columns[currentSelectedColumn][currentSelectedIndex].GetComponent<SpriteRenderer>().sprite = emptySprite;
        }

        // Yeni indeksi hesapla
        do
        {
            currentSelectedIndex += direction;

            // İndeksin sınırlar içinde kalmasını sağla
            if (currentSelectedIndex < 0)
            {
                currentSelectedIndex = columns[currentSelectedColumn].Length - 1;
            }
            else if (currentSelectedIndex >= columns[currentSelectedColumn].Length)
            {
                currentSelectedIndex = 0;
            }
        } while (incorrectCircles.Contains(columns[currentSelectedColumn][currentSelectedIndex]));

        // Yeni daireyi seçili olarak ayarla
        SetSelectedCircle(currentSelectedColumn, currentSelectedIndex);
    }

    public IEnumerator AnimateAndMoveToNextColumn(bool isCorrect)
    {
        // Kontrolü devre dışı bırak
        canControl = false;
        
        GameObject selectedCircle = columns[currentSelectedColumn][currentSelectedIndex];
        SpriteRenderer spriteRenderer = selectedCircle.GetComponent<SpriteRenderer>();

        if (isCorrect)
        {
             if (ses != null)
            {
                ses.PlayCorrectSound();
            }
            dogru = true;
            float elapsedTime = 0f;
            float blinkDuration = 2f;
            bool isFilled = false;

            while (elapsedTime < blinkDuration)
            {
                spriteRenderer.sprite = isFilled ? filledSprite : emptySprite;
                isFilled = !isFilled;

                yield return new WaitForSeconds(0.2f); // Yanıp sönme h
                  elapsedTime += 0.2f;
            }

            // Daireyi FilledGta sprite'ına dönüştür
            spriteRenderer.sprite = filledSprite;
            

            // Sütun değiştirme
            currentSelectedColumn++;
              if (matematik.isCorrect)
        {
            // Doğru cevap olduğunda oyunu bitirme işlemleri
            if (currentSelectedColumn >= columns.Length)
            {
                StartCoroutine(gameOver());
                gameOverCallCount++;
                currentSelectedColumn = 0;
                currentSelectedIndex = 0;
                SetSelectedCircle(currentSelectedColumn, currentSelectedIndex);
                yield break;
            }
        }else ;
        {
             yield return matematik.isCorrect; 
        }

            // Yeni sütundaki ilk daireyi seçili olarak ayarla
            currentSelectedIndex = 0;
            SetSelectedCircle(currentSelectedColumn, currentSelectedIndex);
        }
        else
        {
           
            yanlis = true;
            spriteRenderer.sprite = falseSprite;
              if (ses != null)
            {
                ses.PlayIncorrectSound();
            }
            // Yanlış seçilen daireyi listeye ekle
            incorrectCircles.Add(selectedCircle);
        }

        // Kontrolü tekrar oyuncuya ver
        canControl = true;
        
    }

    void SetSelectedCircle(int columnIndex, int circleIndex)
    {
        // Seçili daireyi pending sprite'a boya
        if (!incorrectCircles.Contains(columns[columnIndex][circleIndex]))
        {
            columns[columnIndex][circleIndex].GetComponent<SpriteRenderer>().sprite = pendingSprite;
        }
    }
  

}
