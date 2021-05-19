using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace DeltaSky.Controllers.UI
{
    public class InGameUI : MonoBehaviour
    {
        #region Instance
        public static InGameUI instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
        #endregion
        
        [Header("Game Over")] 
        public GameObject gameOverPanel;
        
        // Start is called before the first frame update
        void Start()
        {
            gameOverPanel.SetActive(false);
        }

        public void GameOver()
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 1;
        }

        public void Retry(int _sceneIndex)
        {
            SceneManager.LoadScene(_sceneIndex);
            gameOverPanel.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
