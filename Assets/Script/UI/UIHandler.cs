using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject winImage;
        [SerializeField] private GameObject loseImage;
        [SerializeField] private TextMeshProUGUI timeTMP;
        private void Start()
        {
            winImage.SetActive(false);
            loseImage.SetActive(false);
        }

        public void ShowWinImage() => winImage.SetActive(true);

        public void ShowLoseImage() => loseImage.SetActive(true);

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }
}
