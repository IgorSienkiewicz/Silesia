using System.IO;
using TMPro;
using UnityEngine;

public class HandleText : MonoBehaviour
{
    public int dialogueNumber;
    public TextMeshProUGUI gameText;
    public StreamReader reader;
    public bool inDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            InitializeDialogue();
        }
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            ReadNextLine();
        }
    }
    void ReadNextLine()
    {
        string line = reader.ReadLine();
        if (line != null)
        {
            gameText.SetText(line);
        }
        else
        {
            inDialogue = false;
            
            return;
        }
    }
    void InitializeDialogue()
    {
        string path = "Assets/Resources/Scenario" + dialogueNumber + ".txt";
        reader = new StreamReader(path);
        string line = reader.ReadLine();
        gameText.SetText(line);
        inDialogue = true;
    }

    static void ReadString()
    {
        string path = "Assets/Resources/Scenario1.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine())!= null)
        {
            Debug.Log(line);
        }
        reader.Close();
    }

}
