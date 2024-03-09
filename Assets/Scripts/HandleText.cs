using System.IO;
using TMPro;
using UnityEngine;

public class HandleText : MonoBehaviour
{
    [SerializeField] bool inDialogue;
    [SerializeField] TextAsset sourceFile;
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
        if (Input.GetMouseButtonDown(1) && !inDialogue)
        {
            InitializeDialogue();
        }
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
    void InitializeDialogue()
    {
        dialogueLines = sourceFile.text.Split("\n");
        inDialogue = true;
        ShowNextLine();
    }
    void AnimateInOut()
    {
        return;
    }
}

