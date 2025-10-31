using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossShell : MonoBehaviour
{
    //dialogues
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public GameObject trueButton;
    public GameObject falseButton;
    private bool isTalking = false;
    public float wordSpeed;
    public bool playerIsClose;

    //health
    public HealthManager bossShell; // reference to your health script

    void Start()
    {
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
                    trueButton.SetActive(true);
                    falseButton.SetActive(true);
                }
            }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

    public void OnTrueButton()
    {
        //TRUE is correct
        bossShell.DamageBoss(1); // Boss loses a heart
        DisableInteraction();

    }

    public void OnFalseButton()
    {
        //FALSE is wrong
        bossShell.DamagePlayer(1); // Player loses a brain
        DisableInteraction();

    }
    private void DisableInteraction()
    {
        trueButton.SetActive(false);
        falseButton.SetActive(false);
        dialoguePanel.SetActive(false);
        StartCoroutine(DestroyAfterDelay());
    }
    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(0.1f); // Let DamageBoss/Player finish first
        Destroy(gameObject);
    }
}
