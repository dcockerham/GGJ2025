using UnityEngine;
using UnityEngine.SceneManagement;

public class ConeObstacle : MonoBehaviour
{
	[SerializeField] private AudioClip deathSound;

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
		GameObject backgroundMusic = GameObject.FindWithTag("Music");
		if (backgroundMusic !=  null && deathSound != null)
		{
    			backgroundMusic.GetComponent<BackgroundMusic>().playSecondarySound(deathSound);
		}
		string scene_name = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(scene_name);
	}
    }
}
