using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoToSpecificScene : MonoBehaviour
{
    public string sceneName; 
    private void OnMouseUp() {
        goToScene(); 
    }
    public void goToScene() {
        SceneManager.LoadScene (sceneName);
    }
}
