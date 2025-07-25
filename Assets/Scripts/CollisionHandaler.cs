using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandaler : MonoBehaviour
{
    [SerializeField] SceneManager Scene;
    [SerializeField] float LevelDelay = 2f;

    [SerializeField] AudioClip Oncollisions;
    [SerializeField] AudioClip Onsuccess;
    [SerializeField] ParticleSystem particlesuccess;
     [SerializeField] ParticleSystem particleoncollision;

    AudioSource audioSource;
    bool iscontrolable = true;
    bool iscollidable = true;
     void Start() {
        audioSource = GetComponent<AudioSource>();
        
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys(){
        if (Keyboard.current.lKey.wasPressedThisFrame){
            LoadNextlevel();
        }
        else if (Keyboard.current.jKey.wasPressedThisFrame){
            iscollidable = !iscollidable ;
            
        }
    }
    private void OnCollisionEnter(Collision other) {

    if(!iscontrolable || !iscollidable){
        return;
    }
    
    switch (other.gameObject.tag){
        case "Fuel":
            Debug.Log("everything is looking good");
            break;

        case "Finish":
            SuccessLevel();
            break;
        default:
            StartCrash();
            break;

    }
   }

     void SuccessLevel()
    {   iscontrolable=false;
        
        audioSource.Stop();
        
        audioSource.PlayOneShot(Onsuccess);
        particlesuccess.Play();
        GetComponent<Movement>().enabled =false;
        Invoke("LoadNextlevel",LevelDelay);
    }

    void StartCrash()
    {
       iscontrolable=false;
       audioSource.Stop();
       audioSource.PlayOneShot(Oncollisions);
       particleoncollision.Play();
       GetComponent<Movement>().enabled =false;
       Invoke("Reloadlevel" , LevelDelay);

    }

    void LoadNextlevel(){
    int currentscene =SceneManager.GetActiveScene().buildIndex;
    int nextscene = currentscene + 1 ;
    if (nextscene ==  SceneManager.sceneCountInBuildSettings){
        nextscene = 0 ;
    }


    SceneManager.LoadScene(nextscene);
}
void Reloadlevel(){

    int currentscene =SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentscene);

}
    
   
}
