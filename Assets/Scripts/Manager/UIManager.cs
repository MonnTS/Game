using UnityEngine;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject deathMenu;

        public void ToggleDeathPanel()
        {
            deathMenu.SetActive(!deathMenu.activeSelf);
        }
    }
}