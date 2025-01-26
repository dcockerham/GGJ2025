using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] private SetOfDialogue dialoguetext;
	[SerializeField] private TextMeshProUGUI uiText;
	private int indexDialogue;
	[SerializeField] private string nextScene = "";
		
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	indexDialogue = 0; 
    }

    // Update is called once per frame
    void Update()
    {	
	uiText.text = (dialoguetext.text)[indexDialogue];
	if (Input.GetButtonDown("Jump"))
	{
		indexDialogue += 1;
		if (indexDialogue >= dialoguetext.text.Length)
		{
			SceneManager.LoadScene(nextScene);
		}
	}
    }
}
