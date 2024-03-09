using System.IO;
using TMPro;
using UnityEngine;

public class DialogueManager: MonoBehaviour
{
    [SerializeField] public bool inDialogue;
    [SerializeField] public TextAsset sourceFile;
    string[] dialogueLines;
    int currentLine;
    [SerializeField] GameObject textPrefab;

    TextMeshProUGUI gameTextIn;
    GameObject textObjectIn;

    TextMeshProUGUI gameTextOut;
    GameObject textObjectOut;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            gameTextOut = gameTextIn;
            ShowNextLine();
            AnimateInOut();
            Destroy(gameTextOut.gameObject);
        }
    }
    void ShowNextLine()
    {
        Debug.Log(currentLine);
        textObjectIn = Instantiate(textPrefab);
        textObjectIn.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        gameTextIn = textObjectIn.GetComponent<TextMeshProUGUI>();
        if (currentLine < dialogueLines.Length){
            gameTextIn.text = dialogueLines[currentLine++];
        } else
        {
            inDialogue = false;
            Destroy(gameTextIn.gameObject);
            return;            
        } 
    }
    public void InitializeDialogue()
    {
        dialogueLines = sourceFile.text.Split("\n");
        currentLine = 0;
        ShowNextLine();
    }
    void AnimateInOut()
    {
        return;
    }
}

