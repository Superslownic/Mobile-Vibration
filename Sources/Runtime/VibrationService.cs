using UnityEngine;
using Vibration.Common;
using Vibration.Android;
using Vibration.iOS;

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
                    _vibration = new IOSVibration();
                    break;
                
                case RuntimePlatform.Android:
                    _vibration = new AndroidVibration();
                    break;
            }

            _isSupported = _vibration != null;
        }

        public void Vibrate(Impact impact)
        {
            if(!_isSupported)
                return;
            
            _vibration.Vibrate(impact);
        }
    }
}