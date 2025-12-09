using UnityEngine;

public class RotateObject : MonoBehaviour
{

    private Transform letterTransform;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 downPosition;
    private Vector3 rotation = new Vector3(0, 0, 90);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        letterTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        downPosition = gameObject.transform.position;

    }

    void OnMouseUp()
    {
        Vector3 upPosition = gameObject.transform.position;

        // if position doesn't move or moves very little, rotate
        if ((downPosition - upPosition).magnitude < 0.01f) {
            letterTransform.Rotate(rotation);
        }   
    }

    void OnMouseDrag() {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        // Convert the screen point back to a world point and apply the offset
        Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = cursorWorldPosition;
    }
}
