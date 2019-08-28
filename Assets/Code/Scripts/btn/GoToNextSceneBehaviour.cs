using UnityEngine;
using UnityEngine.SceneManagement; 

public class GoToNextSceneBehaviour : MonoBehaviour
{
    public void goToNextScene() {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
