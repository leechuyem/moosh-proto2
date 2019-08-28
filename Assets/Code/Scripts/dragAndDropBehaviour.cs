using UnityEngine;

public class dragAndDropBehaviour : MonoBehaviour
{
    public bool createdFromClick = false; 
    private Vector2 offset = new Vector2(); 

    private void Start() {
        this.gameObject.AddComponent<Rigidbody2D>();
    }
    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            createdFromClick = false; 
        }

        if(createdFromClick) {
            setPositionToMouse(); 
        }
    }

    private void OnMouseDrag() {
        setPositionToMouse(); 
    }

    private void OnMouseDown() {
        setOffset(); 
    }

    private void setOffset() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
        Vector2 currentPosition = new Vector2(transform.localPosition.x, transform.localPosition.y);
        
        offset = currentPosition - mousePosition; 
    }

    private void setPositionToMouse() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);

        transform.position = mousePosition + offset;
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);
    }
}