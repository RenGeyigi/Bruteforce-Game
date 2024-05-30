using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sahnedegistir());
    }
IEnumerator sahnedegistir()
    {

    yield return new WaitForSeconds(4f);
    SceneManager.LoadScene("Hafiz");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
