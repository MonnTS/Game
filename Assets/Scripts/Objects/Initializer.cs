using UnityEngine;

namespace Objects
{
    public class Initializer : MonoBehaviour
    {
        #region FIELDS

        private const int TargetFrameRate = 30;
        
        #endregion

        #region UNITYMETHODS

        private void Start()
        {
            Time.timeScale = 1;
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = TargetFrameRate;
        }

        #endregion
    }
}