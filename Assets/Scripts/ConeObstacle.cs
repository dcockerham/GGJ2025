using UnityEngine;
using UnityEngine.SceneManagement;

public class ConeObstacle : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // trigger
    void OnTriggerEnter2D(Collider2D col)
    {
	if (col.gameObject.tag == "Player")
	{
		string scene_name = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(scene_name);
		Debug.Log("Player In");
	}
    }
}
