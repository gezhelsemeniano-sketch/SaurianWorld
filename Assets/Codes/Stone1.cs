using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stone1 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    private bool isTalking = false;
    public float wordSpeed;
    public bool playerIsClose;
    // Update is called once per frame

    private void Start()
    {
        OnInteractButtonPressed();
    }
    public void OnInteractButtonPressed()
    {
        Debug.Log("Interact Button was pressed!");
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
                    NextLine();
                }
            }
        }
    }
    public void zeroText()

    {
            dialogueText.text = "";
            index = 0;
            isTalking = false;
            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
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
