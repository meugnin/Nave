using UnityEngine;
using UnityEngine.SceneManagement;

public class Colisao : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Largada");
                break;
            case "Combustivel":
                Debug.Log("Fuel");
                break;
            case "Fim":
                Debug.Log("Fim");
                break;
            default:
                ReloadScene();
                Debug.Log("Colisao");
                break;
        }

    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex );
    }
}
