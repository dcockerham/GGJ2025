using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	// this class isn't destroyed on load, but if another one is created it will be destroyed
	private static bool exists = false;	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (exists == false)
	{
		DontDestroyOnLoad(this.gameObject);
		exists = true;
	}
	else
	{
		Destroy(this.gameObject);
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
