using CSCore.CoreAudioAPI;
using System;

namespace CrossMixer
{
    public class AudioSession : IDisposable
    {
        public AudioSession(AudioSessionControl2 control, SimpleAudioVolume volume)
        {
            Control = control;
            Volume = volume;
        }

        public AudioSessionControl2 Control { get; }
        public SimpleAudioVolume Volume { get; }

        public void Dispose()
        {
            Control.Dispose();
            Volume.Dispose();
        }
    }
}
