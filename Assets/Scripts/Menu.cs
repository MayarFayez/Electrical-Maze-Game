using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void onplaybutton(){
        Timer.currentTime = 30f;  // return to start timer.
        Accident.health=3;             // return to 3 chances.
        SceneManager.LoadScene(1);  // when we click on go button , load maze scene.
        // 1: index of scence in build setting
        
    }


}

