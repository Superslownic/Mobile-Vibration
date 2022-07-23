namespace Vibration.Android
{
    public class ImpactPreset
    {
        public readonly long[] Pattern;
        public readonly int[] Amplitude;
        public readonly int RepeatTimes;

        public ImpactPreset(long[] pattern, int[] amplitude, int repeatTimes)
        {
            Pattern = pattern;
            Amplitude = amplitude;
            RepeatTimes = repeatTimes;
        }
    }
}