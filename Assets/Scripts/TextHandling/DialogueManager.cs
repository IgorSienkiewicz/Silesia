using DG.Tweening;
using System.IO;
using TMPro;
using UnityEngine;

public class DialogueManager: MonoBehaviour
{
    [SerializeField] TextAsset sourceFile;
    string[] dialogueLines;
    int currentLine;
    [SerializeField] TextMeshProUGUI textPrefab;
    [SerializeField] float fadeDuration;
    [SerializeField] float fadeDistance;
    [SerializeField] Transform textSpawnPoint;
    
    [SerializeField] bool inDialogue;
    private bool inAnimation;
    private bool shouldEndDialog;

    TextMeshProUGUI gameText;
    //GameObject textObjectIn;

    //TextMeshProUGUI gameTextOut;
    //GameObject textObjectOut;

    void Start()
    {
        InputManager.Instance.OnInteract += NextLine;
        InitializeDialogue();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown(1) && !inDialogue)
        {
            InitializeDialogue();
        }*/
    }

    private void NextLine()
    {
        if (!inDialogue || inAnimation)
        {
            return;
        }
        
        inAnimation = true;

        Animate(0f, true);

        if (!shouldEndDialog)
        {
            ShowNextLine();
            Animate(1f, false);
        }
    }

    private void Animate(float fadeTarget, bool old)
    {
        if (Equals(gameText, null))
        {
            return;
        }
        var outSeq = DOTween.Sequence();
        outSeq.Insert(0, gameText.DOFade(fadeTarget, fadeDuration));
        var targetY = gameText.transform.position.y;
        outSeq.Insert(0, gameText.transform.DOMoveY(targetY + fadeDistance, fadeDuration));
        if (old)
        {
            //Important line for the lambda
            var go = gameText.gameObject;
            outSeq.AppendCallback(() => Destroy(go));
            if (shouldEndDialog)
            {
                outSeq.AppendCallback(() => 
                {
                    this.inDialogue = false;
                    this.shouldEndDialog = false;
                    this.inAnimation = false;
                });
            }
        } else
        {
            outSeq.AppendCallback(() => this.inAnimation = false);
        }
        outSeq.Play();
    }

    void ShowNextLine()
    {
        gameText = Instantiate(textPrefab, textSpawnPoint);
        gameText.transform.localPosition = new Vector3(0f, -fadeDistance, 0f);

        if (currentLine < dialogueLines.Length) {
            gameText.text = dialogueLines[currentLine++];
        }
        if (currentLine == dialogueLines.Length)
        {
            shouldEndDialog = true;
        }
    }

    void InitializeDialogue()
    {
        dialogueLines = sourceFile.text.Split("\n");
        inDialogue = true;
        currentLine = 0;
        //ShowNextLine();
    }
}

