using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoToSpecificScene : MonoBehaviour
{
    public string sceneName; 
    public void goToScene() {
        SceneManager.LoadScene (sceneName);
    }
}
