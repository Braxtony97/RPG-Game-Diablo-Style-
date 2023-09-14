using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapEntryPoint : MonoBehaviour
{
    private string _gamePlayeScene = "GamePlay";
    private float _loadingDuration = 3f;

    private IEnumerator Start()
    {
        while (_loadingDuration > 0f)
        {
            _loadingDuration -= Time.deltaTime;
            Debug.Log("Loading...");
            yield return null;
        }

        SceneManager.LoadScene(_gamePlayeScene);
    }
}
