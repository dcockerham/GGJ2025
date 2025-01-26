using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{

    [SerializeField] private string NextLevel = "";
    [SerializeField] private Transform fadeOutObject;
    private bool touched;
    [SerializeField] private float fadeOutTime = 1.0f;
    private float fadeOutTimer;
    // to destroy music object
	// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	touched = false; 
	fadeOutTimer = fadeOutTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (touched == true)
	{
		fadeOutTimer -= Time.deltaTime;
		float scaleChange = 40f * Time.deltaTime / fadeOutTime;
		fadeOutObject.localScale = new Vector3(fadeOutObject.localScale.x + scaleChange, fadeOutObject.localScale.y + scaleChange, fadeOutObject.localScale.z);
		if (fadeOutTimer <= 0f)
		{
			GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
			foreach (GameObject obj in objs)
			{
				Destroy(obj);
			}
		    SceneManager.LoadScene(NextLevel);
		}
	}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.tag == "Player" && touched == false)
	    {
		    touched = true; 
	    }
    }
}
