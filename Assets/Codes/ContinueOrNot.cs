using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinueOrNot : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject yesButton;
    public GameObject noButton;
    public string nextScene;

    private bool isTalking = false;
    public float wordSpeed;
    public bool playerIsClose;
    // Update is called once per frame

    void Update()
    {
        OnInteractButtonPressed();
    }
    public void OnInteractButtonPressed()
    {
        if (playerIsClose)
        {
            if (!dialoguePanel.activeInHierarchy && !isTalking)
            {
                isTalking = true;
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else
            {
                if (dialogueText.text == dialogue[index])

                {
                    yesButton.SetActive(true);
                    noButton.SetActive(true);
                }
            }
        }
    }
    public void zeroText()

    {
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        index = 0;
        isTalking = false;
        yesButton.SetActive(false);
        noButton.SetActive(false);
    }

    IEnumerator Typing()
    {
        dialogueText.text = "";
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void NextLine()
    {

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
        }
    }
    public void OnYesButton()
    {
        // Load the next scene
        StopAllCoroutines();
        StartCoroutine(LoadNextScene());

    }

    private IEnumerator LoadNextScene() //Because it keeps crashing, this will be the net
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        yield return null; // wait one frame before loading
        SceneManager.LoadScene("floor 1.2");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    public void OnNoButton()
    {
        // Just hide dialogue and buttons
        playerIsClose = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        isTalking = false;
        zeroText();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }


}
