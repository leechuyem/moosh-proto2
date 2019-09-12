using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{
    public TMP_InputField input; 
    public TextMeshPro mooshText; 
    public GameObject textBubble;
    public Color errorBubbleColour;
    public Color errorTextColour; 
    public string errorText; 
    private bool gettingData = false; 
    public async void login() { 
        if(this.input.text != "" && !this.gettingData) {
            this.gettingData = true; 
            string userId = input.text; 

            Response userRes = await HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/users/" + userId); 

            if(userRes.error != null) {
                changeTextDecoration(); 
                this.gettingData = false; 
                return; 
            } else {
                Global.userId = userId; 
            }

            Response sessRes = await HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/sessions/lastopensession/" + userId); 

            if(sessRes.error == null) {
                // HAS an unfinished game                
                Session lastSess = JsonUtility.FromJson<Session>(sessRes.data);
                Global.sessionId = lastSess.id;
            } else {
                print("something went wrong: " + sessRes.error);
            }

            // go to next scene
            GetComponent<GoToNextSceneBehaviour>().goToNextScene(); 
        }
    }

    private void changeTextDecoration() {
        this.input.text = ""; 
        this.mooshText.text = errorText; 
        this.mooshText.color = errorTextColour; 
        this.textBubble.GetComponent<SpriteRenderer>().color = errorBubbleColour;
    }
}
