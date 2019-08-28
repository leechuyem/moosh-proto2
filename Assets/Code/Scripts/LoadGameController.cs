using UnityEngine;
using TMPro;

public class LoadGameController : MonoBehaviour
{
    public GameObject loadBtnObj; 
    public GameObject arrowObj; 
    public TextMeshPro mooshTextObj;
    public TextMeshPro btnTxtObj; 
    public Sprite greyArrowSpr; 
    public Color disabledBtnColour; 
    public Color disabledTextColour; 
    public string onlyNewGameTxt; 

    void Start()
    {
        if(Global.sessionId == null) {
            disableLoadButton(); 
        }
    }

    private void disableLoadButton() {
        mooshTextObj.text = onlyNewGameTxt; 
        btnTxtObj.color = disabledTextColour; 
        arrowObj.GetComponent<SpriteRenderer>().sprite = greyArrowSpr;
        Destroy(loadBtnObj.GetComponent<btnOnHoverBehaviour>()); 
        Destroy(loadBtnObj.GetComponent<BoxCollider2D>()); 
        Destroy(loadBtnObj.GetComponent<LoadBtnController>()); 

        for(int i = 0; i < loadBtnObj.transform.childCount; i++) {
            loadBtnObj.transform.GetChild(i).GetComponent<SpriteRenderer>().color = disabledBtnColour; 
        }
    }
}