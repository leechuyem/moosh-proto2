using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine; 

public static class HttpHandler {
    public static async Task<Response> getReq(string url) {
        UnityWebRequest request = UnityWebRequest.Get(url);
        Response response = new Response(); 
        
        await request.SendWebRequest(); 
        
        if(request.isNetworkError || request.isHttpError) {
            response.error = request.error; 
        } else {
            response.data = request.downloadHandler.text;  
        }

        return response; 
    }
    
    public static async Task<Response> postReq(string url, string data) {
        UnityWebRequest request = UnityWebRequest.Post(url, data);
        Response response = new Response(); 

        byte[] jsonToSend = new System.Text.UTF8Encoding ().GetBytes (data);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw (jsonToSend);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();
        request.SetRequestHeader ("Content-Type", "application/json");

        await request.SendWebRequest(); 

        if(request.isNetworkError || request.isHttpError) {
            // Debug.Log("ruh oh!" + " - " + request.error + data);
            response.error = request.error;
        } else {
            // Debug.Log("finished: " + request.downloadHandler.text);
            response.data = request.downloadHandler.text;
        }

        return response; 
    }

    public static async Task<Response> updateReq(string url, string data) {
        UnityWebRequest request = UnityWebRequest.Put(url, data); 
        Response response = new Response();

        byte[] jsonToSend = new System.Text.UTF8Encoding ().GetBytes (data);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw (jsonToSend);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer ();
        request.SetRequestHeader ("Content-Type", "application/json");

        await request.SendWebRequest(); 

        if(request.isNetworkError || request.isHttpError) {
            // Debug.Log("ruh oh!" + " - " + request.error + data + url);
            response.error = request.error;
        } else {
            // Debug.Log("finished: " + request.downloadHandler.text);
            response.data = request.downloadHandler.text;
        }

        return response; 
    }

    public static Task<Response>[] postFoodReq(string url, string sessionId, List<InteractiveFood> foodList) {
        Task<Response>[] postFoodTasks = new Task<Response>[foodList.Count]; 

        for(int i = 0; i < foodList.Count; i++) {
            int foodId = foodList[i].foodId; 
            int quantity = foodList[i].quantity; 

            string data = $"{{\"sessionId\": \"{sessionId}\", \"foodId\": \"{foodId}\", \"quantity\": {quantity}}}";

            Task<Response> postTask = postReq(url, data);

            postFoodTasks[i] = postTask; 
        }

        return postFoodTasks; 
    }

    public static Task<Response>[] updateFoodReq(string url, string sessionId, List<InteractiveFood> foodList) {
        Task<Response>[] updateFoodTasks = new Task<Response>[foodList.Count]; 

        for(int i = 0; i < foodList.Count; i++) {
            int foodId = foodList[i].foodId;
            int quantity = foodList[i].quantity; 

            string data = $"{{\"sessionId\": \"{sessionId}\", \"foodId\": \"{foodId}\", \"quantity\": {quantity}}}"; 

            Task<Response> updateTask = updateReq(url, data); 

            updateFoodTasks[i] = updateTask; 
        }
        
        return updateFoodTasks; 
    }

    public static Task<Response>[] updateEndSession(string url, string sessionId, string userId) {
        Task<Response>[] updateSessionEndTask = new Task<Response>[1];         
        string data = $"{{\"userId\": \"{userId}\", \"hasEnded\": true}}";
        url = url + sessionId;         
         
        Task<Response> updateTask = updateReq(url, data); 
        updateSessionEndTask[0] = updateTask; 

        return updateSessionEndTask; 
    }
}