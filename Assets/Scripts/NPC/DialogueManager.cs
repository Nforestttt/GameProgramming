using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private string[] lines;
    private int currentLine;

    private bool isTalking = false;

    private AudioClip currentDialogueSound;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!isTalking)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    public void StartDialogue(
    string[] dialogueLines,
    AudioClip dialogueSound = null)
    {
        lines = dialogueLines;

        currentLine = 0;

        currentDialogueSound = dialogueSound;

        isTalking = true;

        dialoguePanel.SetActive(true);

        dialogueText.text = lines[currentLine];

        if (currentDialogueSound != null)
        {
            AudioManager.Instance.PlaySFX(currentDialogueSound);
        }
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= lines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = lines[currentLine];

        if (currentDialogueSound != null)
        {
            AudioManager.Instance.PlaySFX(currentDialogueSound);
        }
    }

    void EndDialogue()
    {
        isTalking = false;

        dialoguePanel.SetActive(false);
    }

    public bool IsTalking()
    {
        return isTalking;
    }
}