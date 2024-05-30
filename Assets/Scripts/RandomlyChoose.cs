using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomlyChoose : MonoBehaviour
{public GameObject[] columns; // Sütunların GameObject dizisi
    public Sprite filledSprite; // Hedef sprite (FilledGta)
    public Sprite emptySprite; // Varsayılan sprite (EmptyGta)
   
    void Start()
    {
       

        StartCoroutine(ChangeSpritesRepeatedly());
    }
 
    IEnumerator ChangeSpritesRepeatedly()
{
    for (int i = 0; i < 5; i++)
    {
        List<GameObject> selectedCircles = new List<GameObject>();

        if (i < 3)
        {
            foreach (GameObject column in columns)
            {
                int rowCount = column.transform.childCount;
                if (rowCount > 0)
                {
                    int randomRowIndex = Random.Range(0, rowCount);
                    GameObject selectedCircle = column.transform.GetChild(randomRowIndex).gameObject;
                    selectedCircle.GetComponent<SpriteRenderer>().sprite = filledSprite;
                    selectedCircles.Add(selectedCircle);

                    if (i == 2)
                    {
                        SelectedCirclesManager.ThirdIterationCircles.Add(selectedCircle);
                    }
                }
            }
        }
        else
        {
            foreach (GameObject selectedCircle in SelectedCirclesManager.ThirdIterationCircles)
            {
                if (selectedCircle != null) // Nesne hala var mı kontrol et
                {
                    selectedCircle.GetComponent<SpriteRenderer>().sprite = filledSprite;
                    selectedCircles.Add(selectedCircle);
                }
            }
        }

        yield return new WaitForSeconds(0.5f);

        foreach (GameObject circle in selectedCircles)
        {
            if (circle != null) // Nesne hala var mı kontrol et
            {
                circle.GetComponent<SpriteRenderer>().sprite = emptySprite;
            }
        }

        yield return new WaitForSeconds(0.5f);
    }
}
}
// In the snippet above, the RandomlyChoose script selects a random row from each column and changes the color of the selected row to the target color. This script can be used to create visual effects or gameplay mechanics where random elements are highlighted or modified. By using the Random.Range method, the script ensures that a different row is selected each time the game is played, adding variety and unpredictability to the experience. The script demonstrates how to access and modify child objects within a parent object, as well as how to set the color of a material component. Overall, the RandomlyChoose script showcases how to implement random selection and color changes in a Unity project.
