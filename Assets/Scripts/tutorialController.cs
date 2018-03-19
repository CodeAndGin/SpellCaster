using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialController : MonoBehaviour
{
    private GameObject GameState;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    // Use this for initialization
    void Start()
    {
        GameState = GameObject.Find("GameStateController");
        StartCoroutine("TutorialText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TutorialText()
    {
        GameState.SendMessage("Pause");
        text1.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        text1.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        text2.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        text2.SetActive(false);
        yield return new WaitForSecondsRealtime(0f);
        GameState.SendMessage("Unpause");
        yield return new WaitForSecondsRealtime(6f);
        GameState.SendMessage("Pause");
        yield return new WaitForSecondsRealtime(0f);
        text3.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        text3.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        text4.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        text4.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        text5.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        text5.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        text6.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        text6.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        text7.SetActive(true);
        yield return new WaitForSecondsRealtime(8f);
        text7.SetActive(false);
        yield return new WaitForSecondsRealtime(0f);
        GameState.SendMessage("Unpause");
    }
}
