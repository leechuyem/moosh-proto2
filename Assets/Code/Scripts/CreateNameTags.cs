using TMPro;
using UnityEngine;

public class CreateNameTags: MonoBehaviour
{
    public GameObject text;
    public GameObject innerTag;
    public GameObject outerTag; 
    public float innerOffset = 0.1f; 
    public float outerHorizontalOffset = 0.2f; 
    public float outerVerticalOffset = 0.1f; 

    public void createTag(string foodName, float x, float y) {
        instantiateText(foodName);
        instantiateInnerTag();
        instantiateOuterTag();
        positionOuterTag(x, y); 
        positionInnerTag(x);
        positionText(x);
    }

    private void instantiateText(string foodName) {
        text = Instantiate(text);

        text.GetComponent<TextMeshPro>().text = foodName; 
    }

    private void instantiateInnerTag() {
        innerTag = Instantiate(innerTag);

        // Get width and height of Text Mesh Pro
        float txtWidth = text.GetComponent<TextMeshPro> ().preferredWidth;
        float txtHeight = text.GetComponent<TextMeshPro> ().preferredHeight;

        // Change the scale of the inner tag sprite to the text's w and h 
        // The sprite is 1px big. 
        innerTag.transform.localScale = new Vector2 (txtWidth + innerOffset, txtHeight);
    }

    private void instantiateOuterTag() {
        outerTag = Instantiate (outerTag);

        // Get width and height of normal sprite
        float innerTagWidth = innerTag.GetComponent<SpriteRenderer> ().bounds.size.x;
        float innerTagHeight = innerTag.GetComponent<SpriteRenderer> ().bounds.size.y;

        // Change the scale of the outer tag sprite to the inner tag's w and h 
        // The sprite is 1px big
        outerTag.transform.localScale = new Vector2 (innerTagWidth + outerHorizontalOffset, innerTagHeight + outerVerticalOffset);
    }

    private void positionOuterTag(float x, float y) {
        // Get the outer tag's height
        float outerHeight = outerTag.GetComponent<SpriteRenderer> ().bounds.size.y;

        // y - height/2
        // because the sprite's pivot point is at the center
        outerTag.transform.localPosition = new Vector3 (x, y - outerHeight / 2, -3); 
    }

    private void positionInnerTag(float x) {
        // Get the outer tag's y cord 
        float outerY = outerTag.transform.localPosition.y;

        // Using the same y cord as the outer tag.
        // So, the inner tag would be positioned a bit lower than the outer tag
        // because the inner tag is smaller than the outer tag
        innerTag.transform.localPosition = new Vector3 (x, outerY, -4);
    }

    private void positionText(float x) {
        float outerY = outerTag.transform.localPosition.y;
        text.transform.localPosition = new Vector3 (x, outerY, -5);
    }
}
