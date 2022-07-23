using System;
using System.Runtime.InteropServices;
using Vibration.Common;
using UnityEngine;
using UnityEngine.iOS;

namespace Vibration.iOS
{
    public class IOSVibration : IVibration, IDisposable
    {
		[DllImport ("__Internal")] private static extern void InstantiateFeedbackGenerators();
		[DllImport ("__Internal")] private static extern void ReleaseFeedbackGenerators();
		[DllImport ("__Internal")] private static extern void SelectionHaptic();
		[DllImport ("__Internal")] private static extern void SuccessHaptic();
		[DllImport ("__Internal")] private static extern void WarningHaptic();
		[DllImport ("__Internal")] private static extern void FailureHaptic();
		[DllImport ("__Internal")] private static extern void LightImpactHaptic();
		[DllImport ("__Internal")] private static extern void MediumImpactHaptic();
		[DllImport ("__Internal")] private static extern void HeavyImpactHaptic();

		public IOSVibration()
		{
			InstantiateFeedbackGenerators();
		}

		public void Dispose()
		{
			ReleaseFeedbackGenerators();
		}

		public void Vibrate(Impact type)
		{
			if (IsSupported())
			{
				switch (type)
				{
					case Impact.Selection: SelectionHaptic(); break;
					case Impact.Success: SuccessHaptic(); break;
					case Impact.Warning: WarningHaptic(); break;
					case Impact.Failure: FailureHaptic(); break;
					case Impact.Light: LightImpactHaptic(); break;
					case Impact.Medium: MediumImpactHaptic(); break;
					case Impact.Heavy: HeavyImpactHaptic(); break;
				}
			}
			else
			{
				Handheld.Vibrate();
			}
		}

		private bool IsSupported()
		{
			switch (Device.generation)
			{
				case DeviceGeneration.iPhone3G:
				case DeviceGeneration.iPhone3GS:
				case DeviceGeneration.iPhone4:
				case DeviceGeneration.iPhone4S:
				case DeviceGeneration.iPhone5:
				case DeviceGeneration.iPhone5C:
				case DeviceGeneration.iPhone5S:
				case DeviceGeneration.iPhone6:
				case DeviceGeneration.iPhone6S:
				case DeviceGeneration.iPhone6Plus:
				case DeviceGeneration.iPhoneSE1Gen:
				case DeviceGeneration.iPad1Gen:
				case DeviceGeneration.iPad2Gen:
				case DeviceGeneration.iPad3Gen:
				case DeviceGeneration.iPad4Gen:
				case DeviceGeneration.iPad5Gen:
				case DeviceGeneration.iPadAir1:
				case DeviceGeneration.iPadAir2:
				case DeviceGeneration.iPadMini1Gen:
				case DeviceGeneration.iPadMini2Gen:
				case DeviceGeneration.iPadMini3Gen:
				case DeviceGeneration.iPadMini4Gen:
				case DeviceGeneration.iPadPro10Inch1Gen:
				case DeviceGeneration.iPadPro10Inch2Gen:
				case DeviceGeneration.iPadPro11Inch:
				case DeviceGeneration.iPadPro1Gen:
				case DeviceGeneration.iPadPro2Gen:
				case DeviceGeneration.iPadPro3Gen:
				case DeviceGeneration.iPadUnknown:
				case DeviceGeneration.iPodTouch1Gen:
				case DeviceGeneration.iPodTouch2Gen:
				case DeviceGeneration.iPodTouch3Gen:
				case DeviceGeneration.iPodTouch4Gen:
				case DeviceGeneration.iPodTouch5Gen:
				case DeviceGeneration.iPodTouch6Gen:
				case DeviceGeneration.iPhone6SPlus:
					return false;
			}
			return true;
		}
    }
}
