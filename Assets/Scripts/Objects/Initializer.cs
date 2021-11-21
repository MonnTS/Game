using UnityEngine;

namespace Objects
{
    public class Initializer : MonoBehaviour
    {
        private const int TargetFrameRate = 30;
        
        private void Start()
        {
            Time.timeScale = 1;
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = TargetFrameRate;
        }
    }
}