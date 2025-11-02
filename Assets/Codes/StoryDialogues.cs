using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StoryDialogues : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool isTalking = false;
    public float wordSpeed;
    void Start()
    {
        StoryDialogue();
    }
    
    public void StoryDialogue()
    {
        if(!dialoguePanel.activeInHierarchy && !isTalking)
            {
            isTalking = true;
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }


    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        isTalking = false;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
