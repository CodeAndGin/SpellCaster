using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public GameObject anyText;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("flashing");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    IEnumerator flashing()
    {
        while (true) {
            anyText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            anyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            
        }
    }
}
