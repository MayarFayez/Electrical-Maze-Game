using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public Button button1; // define button. 

    void Start()
    {
        button1.onClick.AddListener(Reload); // when we click on button ,execute 'Reload function'.
    }

    void Reload()
    {
        Timer timer = FindObjectOfType<Timer>();   //searches for an instance of the Timer component in the current scene.
        Health  health = FindObjectOfType<Health>(); //is used to find and assign a reference to a component of the type Health in the current scene.
        End end = FindObjectOfType<End>(); //is used to find and assign a reference to a component of the type End in the current scene.
        

        if (timer != null)
        {
            timer.RestartTimer();  // return to value of game Time and deactivate gameover panel.
            health.RestartHealth(); // return 3 chances and activate all squares.
            end.Restart();   // assign winner = false (player can movement).
            SceneManager.LoadScene("Maze");  // return to defualt scene.
        }
    }
}