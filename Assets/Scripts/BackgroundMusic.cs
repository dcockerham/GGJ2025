using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
	[SerializeField] private AudioSource secondaryAudio;
	[SerializeField] private AudioClip SurfaceTensionTrack;
	[SerializeField] private AudioClip GettingOutTrack;

	// this class isn't destroyed on load, but if another one is created it will be destroyed
	private static bool exists = false;	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (exists == false)
	{
		DontDestroyOnLoad(this.gameObject);
		exists = true;
		SceneManager.activeSceneChanged += ChangedActiveScene;
	}
	else
	{
		Destroy(this.gameObject);
	}
    }

    private void ChangedActiveScene(Scene Original, Scene New)
    {
	if (New.name == "SurfaceTension")
	{
		AudioSource src = GetComponent<AudioSource>();
		src.Stop();
		src.clip = SurfaceTensionTrack;
		src.Play();
	}
	else if (New.name == "GettingOutTheBubble")
	{
		AudioSource src = GetComponent<AudioSource>();
		src.Stop();
		src.clip = GettingOutTrack;
		src.Play();
	}
	else
	{
		AudioSource src = GetComponent<AudioSource>();
		src.Stop();	
	}
    }
	

    // second effect
    public void playSecondarySound(AudioClip newClip)
    {
	secondaryAudio.Stop();
	secondaryAudio.clip = newClip;
	secondaryAudio.Play();
    }
}
