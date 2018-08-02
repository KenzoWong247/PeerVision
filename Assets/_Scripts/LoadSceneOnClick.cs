using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void UnloadScene(int scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}
