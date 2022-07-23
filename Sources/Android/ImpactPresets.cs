using System.Collections.Generic;
using Vibration.Common;

namespace Vibration.Android
{
    public static class ImpactPresets
    {
        private const long LightDuration = 20;
        private const long MediumDuration = 40;
        private const long HeavyDuration = 80;
        private const int LightAmplitude = 40;
        private const int MediumAmplitude = 120;
        private const int HeavyAmplitude = 255;
		
        public static readonly Dictionary<Impact, ImpactPreset> Collection = new Dictionary<Impact, ImpactPreset>
        {
            { Impact.Light, new ImpactPreset(new [] { 0, LightDuration }, new [] { 0, LightAmplitude }, -1) },
            { Impact.Medium, new ImpactPreset(new [] { 0, MediumDuration }, new [] { 0, MediumAmplitude }, -1) },
            { Impact.Heavy, new ImpactPreset(new [] { 0, HeavyDuration }, new [] { 0, HeavyAmplitude }, -1) },
            { Impact.Success, new ImpactPreset(new [] { 0, LightDuration, LightDuration, HeavyDuration}, new [] { 0, LightAmplitude, 0, HeavyAmplitude}, -1) },
            { Impact.Warning, new ImpactPreset(new [] { 0, HeavyDuration, LightDuration, MediumDuration}, new [] { 0, HeavyAmplitude, 0, MediumAmplitude}, -1) },
            { Impact.Failure, new ImpactPreset(new [] { 0, MediumDuration, LightDuration, MediumDuration, LightDuration, HeavyDuration, LightDuration, LightDuration}, new [] { 0, MediumAmplitude, 0, MediumAmplitude, 0, HeavyAmplitude, 0, LightAmplitude}, -1) },
        };
    }
}