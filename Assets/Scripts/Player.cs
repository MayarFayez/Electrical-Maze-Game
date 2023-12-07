using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;  // speed of player.

    // minXPosition and maxXPosition determine width ,where player can move.
    public float minXPosition = 10f;   
    public float maxXPosition = 1000f;
    //minYPosition and maxYPosition determine length ,where player can move.
    public float minYPosition = 10f;
    public float maxYPosition = 400f;

    public static  bool isPicked = false; // states of mouse (hold down or release).
    public Vector3 offset;  // start point of mouse.
     

    // Update is called once per frame
    void Update()
    {
        if (Accident.health > 0) // if player has any chances ,we will do the following.
        {
            if (isPicked)
            {
                if (Input.GetMouseButton(0)) // Check if mouse button is being held down.
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //convert the mouse position from screen space to world space.
                    Vector3 newPosition = mousePosition + offset;  // newposition equal mouseposition in world space + offset.

                    newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);   //limited range of x .
                    newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition);   //limited range of y .
                    transform.position = newPosition; // move to new position.
                }
                else
                {
                    isPicked = false; // Release the picked object if mouse button is released .
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0)) // Check if mouse button is being held down.
                {
                    // Perform object picking .
                    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hit.collider != null && hit.collider.gameObject == gameObject)
                    {
                        isPicked = true;  //the game object has been picked or selected.
                        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }
                }
            }       
        }
        else  // if player loses all chances ,we will do the following.
        {
             
			transform.Translate(-0.5f * Time.deltaTime, 0, 0);  // movement of player after wining.  
        }
    }
}