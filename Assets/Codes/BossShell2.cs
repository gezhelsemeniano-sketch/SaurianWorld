using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossShell2 : MonoBehaviour
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
    private bool hasBeenUsed = false;

    //health
    public HealthManager bossShell; // reference to your health script

    private void Awake()
    {
    }

    public void OnInteractButtonPressed()
    {
        if (hasBeenUsed) return;

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
        if (hasBeenUsed) return;
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
        //TRUE is incorrect
        bossShell.DamagePlayer(1); // Player loses a heart
        DisableInteraction();
    }

    public void OnFalseButton()
    {
        //FALSE is correct
        bossShell.DamageBoss(1); // Boss loses a brain
        DisableInteraction();
    }
    private void DisableInteraction()
    {
        hasBeenUsed = true;
        trueButton.SetActive(false);
        falseButton.SetActive(false);
        dialoguePanel.SetActive(false);
        Destroy(gameObject);
    }
}
