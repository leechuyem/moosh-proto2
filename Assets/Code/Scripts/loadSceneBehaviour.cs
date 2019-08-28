using UnityEngine;
using UnityEngine.SceneManagement;

public class loadSceneBehaviour : MonoBehaviour {
    public string sceneName;
    private void OnMouseUp () {
        SceneManager.LoadScene (sceneName);
    }
}