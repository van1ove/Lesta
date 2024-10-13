using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject winImage;
        [SerializeField] private GameObject loseImage;
        [SerializeField] private GameObject pauseImage;

        private void Start()
        {
            winImage.SetActive(false);
            loseImage.SetActive(false);
            pauseImage.SetActive(false);
        }

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
