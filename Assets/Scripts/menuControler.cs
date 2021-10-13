using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControler : MonoBehaviour
{
    [SerializeField] private string firstSceneName;
    // Start is called before the first frame update
    public void StartGame(){
        SceneManager.LoadScene(firstSceneName, LoadSceneMode.Single);
    }
}
