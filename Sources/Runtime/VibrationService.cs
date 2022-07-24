using UnityEngine;
using Vibration.Common;

#if UNITY_ANDROID
using Vibration.Android;
#elif UNITY_IOS
using Vibration.iOS;
#endif

namespace Vibration
{
    public sealed class VibrationService : IVibration
    {
        private readonly IVibration _vibration;
        private readonly bool _isSupported;
        
        public VibrationService()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                case RuntimePlatform.Android:
                    _isSupported = true;
                    break;
            }

#if!UNITY_EDITOR

#if UNITY_ANDROID
            _vibration = new AndroidVibration();
#elif UNITY_IOS
            _vibration = new IOSVibration();
#endif
            
#endif
        }

        public void Vibrate(Impact impact)
        {
            if(!_isSupported)
                return;
            
            _vibration.Vibrate(impact);
        }
    }
}