using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	[SerializeField] private SetOfDialogue dialoguetext;
	[SerializeField] private TextMeshProUGUI uiText;
	private int indexDialogue;
	[SerializeField] private string nextScene = "";
	[SerializeField] private GameObject showObject;
    [SerializeField] private GameObject hideObject;
    [SerializeField] private int showOnLine = -1;
    [SerializeField] private int hideOnLine = -1;

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
			if (showOnLine == indexDialogue) showObject.SetActive(true);
            if (hideOnLine == indexDialogue) hideObject.SetActive(true);
            if (indexDialogue >= dialoguetext.text.Length)
			{
				if(nextScene != "") SceneManager.LoadScene(nextScene);
				if(hideOnLine == -1 && hideObject != null) hideObject.SetActive(false);
				if(showOnLine == -1 && showObject != null) showObject.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}
}
