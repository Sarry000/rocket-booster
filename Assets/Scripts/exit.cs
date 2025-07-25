using UnityEngine;
using UnityEngine.InputSystem;

public class exit : MonoBehaviour
{
    void Update()
    {
        if(Keyboard.current.escapeKey.isPressed){
            Debug.Log("exit");
            Application.Quit();

        }
    }
}
