using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickableTransition : MonoBehaviour
{
    [SerializeField] private string scenename;

    void OnMouseDown()
    {
        // this object was clicked - do something
        SceneManager.LoadScene(scenename);
    }
}
