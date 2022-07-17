using TMPro;
using UnityEngine;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI message;

        public void SetMessage(string text)
        {
            message.text = text;
        }
    }
}