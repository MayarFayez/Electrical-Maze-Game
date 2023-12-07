using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
   


    public void backtomenu(){
        SceneManager.LoadScene(0);  // when we click on home button , load menu scene.
        // 0: index of scence in build setting
    }
}