using Vibration.Common;
using UnityEngine;

namespace Vibration.Android
{
	public class AndroidVibration : IVibration
	{
		private readonly AndroidJavaObject _androidVibrator;
		private readonly AndroidJavaClass _vibrationEffectClass;
		private readonly int _sdkVersion;

		public AndroidVibration()
		{
			var unityPlayer = new AndroidJavaClass(Constants.UnityPlayerClass);
			var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>(Constants.CurrentActivityFiledName);
			_androidVibrator = currentActivity.Call<AndroidJavaObject>(Constants.GetSystemServiceMethod, Constants.VibratorSystem);
			_sdkVersion = int.Parse(SystemInfo.operatingSystem.Substring(SystemInfo.operatingSystem.IndexOf("-") + 1, 3));
			_vibrationEffectClass = new AndroidJavaClass(Constants.VibrationEffectClass);
		}

		public void Vibrate(Impact impact)
		{
			var impactPreset = ImpactPresets.Collection[impact];
			CallVibration(impactPreset.Pattern, impactPreset.Amplitude, impactPreset.RepeatTimes);
		}

		public void CancelVibrations() =>
			_androidVibrator.Call(Constants.CancelMethod);

		private void CallVibration(long[] pattern, int[] amplitudes, int repeatTimes)
		{
			if (_sdkVersion < 26)
			{
				_androidVibrator.Call(Constants.VibrateMethod, pattern, repeatTimes);
			}
			else
			{
				var vibrationEffect = _vibrationEffectClass.CallStatic<AndroidJavaObject>(Constants.CreateWaveformMethod, pattern, amplitudes, repeatTimes);
				_androidVibrator.Call(Constants.VibrateMethod, vibrationEffect);
			}
		}
	}
}
