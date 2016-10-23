using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
				// the path returned a path which did't work for some reason, so I used buildIndex
				//Debug.Log (SceneManager.GetSceneAt(0).path);
                //SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
				//Debug.Log (SceneManager.GetActiveScene().buildIndex);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
