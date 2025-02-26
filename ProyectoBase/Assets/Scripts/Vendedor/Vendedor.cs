using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class Vendedor : MonoBehaviour
{
    private bool isPlayerInArea = false;
    private bool dialogueStart = false;

    private int lineIndex = 0;
    private float typeSpeed = 0.05f;

    [SerializeField] private GameObject sellerMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines; // TextArea para que se vea mejor en el inspector
    public void Update()
    {
        //si el jugador esta cerca y presion E inicia el dialogo
        if(isPlayerInArea && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueStart)
            {
                //empieza a typear el dialogo
                StartDialogue();
            }
            // al terminar el dialogo y presionar E se pasa al siguiente dialogo
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            //si se presiona E y no se ha terminado de typear se muestra completo el dialogo
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        sellerMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            sellerMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typeSpeed);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            isPlayerInArea = true;
            sellerMark.SetActive(true);
            Debug.Log("Sos la verga"); 
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInArea = false;
            sellerMark.SetActive(false);
            Debug.Log("si ja la verga");
        }
    }
}
