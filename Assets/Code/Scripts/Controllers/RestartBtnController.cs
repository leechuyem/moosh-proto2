using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtnController : MonoBehaviour
{
    private void Start() {
        
    }
    private async void OnMouseUp() {
        Global.sessionId = null; 
        string userId = Global.userId; 

        Response sessRes = await HttpHandler.getReq("https://monstermoosh.azurewebsites.net/api/sessions/lastopensession/" + userId); 

        if(sessRes.error == null) {
            // HAS an unfinished game                
            Session lastSess = JsonUtility.FromJson<Session>(sessRes.data);
            Global.sessionId = lastSess.id;
        } else {
            print("something went wrong: " + sessRes.error);
        }

        GetComponent<GoToSpecificScene>().goToScene(); 
    }
}
