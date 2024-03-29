﻿using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossMixer
{
    public partial class VolumeMixerCrossFader : Form
    {
        private static readonly string FIRST_CHANNEL_DEFAULT_PROCESS = "chrome";
        private static readonly string SECOND_CHANNEL_DEFAULT_PROCESS = "spotify";
        private static readonly int AUTO_FADE_INTERVAL_MS = 16;
        private static readonly int AUTO_FADE_INCREMENT = 1;

        private string[] _processIgnoreList = { "Idle" };
        private AudioSessionManager2 _audioSessionManager;
        private List<AudioSession> _audioSessions = new List<AudioSession>();
        private AudioSession _firstChannel = null;
        private AudioSession _secondChannel = null;
        private bool _isRemovingChannel = false;
        private bool _isAutoFading = false;
        private int _autoFadeTargetVolume = 0;
        private readonly object _fadeLock = new object();
        

        public VolumeMixerCrossFader()
        {
            InitializeComponent();

            Task.Run(() =>
            {
                _audioSessionManager = GetDefaultAudioSessionManager2(DataFlow.Render);
                GetAudioSessions();

                Invoke(() =>
                {
                    firstChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
                    secondChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
                    firstChannelDropdown.SelectedIndex = _audioSessions.FindIndex(x => x.Control.Process.ProcessName.Equals(FIRST_CHANNEL_DEFAULT_PROCESS, StringComparison.OrdinalIgnoreCase));
                    secondChannelDropdown.SelectedIndex = _audioSessions.FindIndex(x => x.Control.Process.ProcessName.Equals(SECOND_CHANNEL_DEFAULT_PROCESS, StringComparison.OrdinalIgnoreCase));
                });
            });
        }

        private void GetAudioSessions()
        {
            using (var sessionEnumerator = _audioSessionManager.GetSessionEnumerator())
            {
                foreach (var session in sessionEnumerator)
                {
                    var volume = session.QueryInterface<SimpleAudioVolume>();
                    var control = session.QueryInterface<AudioSessionControl2>();


                    if (!_audioSessions.Any(x => x.Control.BasePtr == control.BasePtr) && !_processIgnoreList.Contains(control.Process.ProcessName))
                    {
                        control.StateChanged += Control_StateChanged;
                        control.SessionDisconnected += Control_SessionDisconnected;
                        control.SimpleVolumeChanged += Control_SimpleVolumeChanged;
                        _audioSessions.Add(new AudioSession(control, volume));
                    }
                    else
                    {
                        volume.Dispose();
                        control.Dispose();
                    }
                }
            }
        }

        private void HandleDisconnectedSessions()
        {
            using (var sessionEnumerator = _audioSessionManager.GetSessionEnumerator())
            {
                var currentSessions = sessionEnumerator.Select(x => x.QueryInterface<AudioSessionControl2>());
                foreach (var disconnectedSession in _audioSessions.Where(x => !currentSessions.Any(y => y.BasePtr == x.Control.BasePtr)).ToArray())
                {
                    _audioSessions.Remove(disconnectedSession);

                    if (_firstChannel == disconnectedSession) _firstChannel = null;
                    if (_secondChannel == disconnectedSession) _secondChannel = null;

                    disconnectedSession.Control.Dispose();
                    disconnectedSession.Volume.Dispose();
                }
            }

            Invoke(() => RefreshUI());
        }

        private void Control_SessionDisconnected(object sender, AudioSessionDisconnectedEventArgs e)
        {
            HandleDisconnectedSessions();
        }

        private void Control_StateChanged(object sender, AudioSessionStateChangedEventArgs e)
        {
            HandleDisconnectedSessions();
        }

        private void RefreshUI()
        {
            if (_firstChannel == null)
            {
                _isRemovingChannel = true;
                firstChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
                firstChannelDropdown.SelectedIndex = -1;
                firstChannelDisplayNameLabel.Text = "<First channel unselected>";
                firstChannelVolumeBar.Value = 50;
                _isRemovingChannel = false;
            }
            else
            {
                firstChannelVolumeBar.Value = (int)Math.Ceiling(_firstChannel.Volume.MasterVolume * 100);
            }

            if (_secondChannel == null)
            {
                _isRemovingChannel = true;
                secondChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
                secondChannelDropdown.SelectedIndex = -1;
                secondChannelDisplayNameLabel.Text = "<Second channel unselected>";
                secondChannelVolumeBar.Value = 50;
                _isRemovingChannel = false;
            }
            else
            {
                secondChannelVolumeBar.Value = (int)Math.Ceiling(_secondChannel.Volume.MasterVolume * 100);
            }

            if (_firstChannel == null || _secondChannel == null) 
                crossFaderBar.Value = 50;

        }

        private void Control_SimpleVolumeChanged(object sender, AudioSessionSimpleVolumeChangedEventArgs e)
        {
            Invoke(() => RefreshUI());
        }

        private void channelDropdown_KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void firstChannelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (firstChannelDropdown.SelectedIndex == -1 || _isRemovingChannel) return;
            _firstChannel = _audioSessions[firstChannelDropdown.SelectedIndex];
            firstChannelDisplayNameLabel.Text = _audioSessions[firstChannelDropdown.SelectedIndex].Control.Process.ProcessName;
            firstChannelVolumeBar.Value = (int)Math.Ceiling(_audioSessions[firstChannelDropdown.SelectedIndex].Volume.MasterVolume * 100);

            if (_firstChannel != null && _secondChannel != null)
            {
                crossFaderBar.Value = (int)Math.Ceiling(100 - 100 * _firstChannel.Volume.MasterVolume);
            }
        }

        private void secondChannelDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (secondChannelDropdown.SelectedIndex == -1 || _isRemovingChannel) return;
            _secondChannel = _audioSessions[secondChannelDropdown.SelectedIndex];
            secondChannelDisplayNameLabel.Text = _audioSessions[secondChannelDropdown.SelectedIndex].Control.Process.ProcessName;
            secondChannelVolumeBar.Value = (int)Math.Ceiling(_audioSessions[secondChannelDropdown.SelectedIndex].Volume.MasterVolume * 100);

            if (_firstChannel != null && _secondChannel != null)
            {
                crossFaderBar.Value = (int)Math.Ceiling(100 * _secondChannel.Volume.MasterVolume);
            }
        }

        private void alwaysOnTopCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = alwaysOnTopCheckbox.Checked;
        }

        private async void firstChannelDropdown_MouseClick(object sender, MouseEventArgs e)
        {
            await Task.Run(() => GetAudioSessions());
            int oldIndex = firstChannelDropdown.SelectedIndex;
            firstChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
            firstChannelDropdown.SelectedIndex = oldIndex;
        }

        private async void secondChannelDropdown_MouseClick(object sender, MouseEventArgs e)
        {
            await Task.Run(() => GetAudioSessions());
            int oldIndex = secondChannelDropdown.SelectedIndex;
            secondChannelDropdown.DataSource = _audioSessions.Select((x, idx) => new ListElement(x.Control.Process.ProcessName, idx)).ToArray();
            secondChannelDropdown.SelectedIndex = oldIndex;
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(DataFlow dataFlow)
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                using (var device = enumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    Debug.WriteLine("DefaultDevice: " + device.FriendlyName);
                    var sessionManager = AudioSessionManager2.FromMMDevice(device);
                    return sessionManager;
                }
            }
        }

        private void crossFaderBar_ValueChanged(object sender, EventArgs e)
        {
            if (_firstChannel == null || _secondChannel == null) 
                crossFaderBar.Value = 50;
        }

        private void firstChannelVolumeBar_Scroll(object sender, EventArgs e)
        {
            if (_firstChannel != null) 
                _firstChannel.Volume.MasterVolume = firstChannelVolumeBar.Value / 100f;
            else 
                firstChannelVolumeBar.Value = 50;
        }

        private void secondChannelVolumeBar_Scroll(object sender, EventArgs e)
        {
            if (_secondChannel != null) 
                _secondChannel.Volume.MasterVolume = secondChannelVolumeBar.Value / 100f;
            else 
                secondChannelVolumeBar.Value = 50;
        }

        private void crossFaderBar_Scroll(object sender, EventArgs e)
        {
            if (_firstChannel == null || _secondChannel == null)
            {
                crossFaderBar.Value = 50;
                return;
            }

            _firstChannel.Volume.MasterVolume = 1f - crossFaderBar.Value / 100f;
            _secondChannel.Volume.MasterVolume = crossFaderBar.Value / 100f;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                _audioSessionManager.Dispose();
                foreach (var session in _audioSessions)
                {
                    session.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void autoFadeButton_MouseClick(object sender, EventArgs e)
        {
            if (_firstChannel == null || _secondChannel == null)
                return;

            lock (_fadeLock)
            {
                if (_isAutoFading)
                    StopAutoFade();
                else
                    StartAutoFade();
            }
        }

        private void StopAutoFade()
        {
            autoFadeButton.Text = "Auto Fade";
            _isAutoFading = false;
        }

        private void StartAutoFade()
        {
            if (crossFaderBar.Value == 50)
                return;

            _autoFadeTargetVolume = crossFaderBar.Value < 50 ? 100 : 0 ;

            autoFadeButton.Text = "Stop Fade";
            _isAutoFading = true;
            Task.Run(() => PerformAutoFade());
        }

        private async Task PerformAutoFade()
        {
            while (true)
            {
                lock (_fadeLock)
                {
                    if (!_isAutoFading)
                        return;
                }

                Invoke(() => {
                    lock (_fadeLock)
                    {
                        if ((_firstChannel == null || _secondChannel == null) || crossFaderBar.Value == _autoFadeTargetVolume)
                        {
                            StopAutoFade();
                            return;
                        }

                        var targetValue = _autoFadeTargetVolume > crossFaderBar.Value ? crossFaderBar.Value + AUTO_FADE_INCREMENT : crossFaderBar.Value - AUTO_FADE_INCREMENT;
                        crossFaderBar.Value = Clamp(targetValue, 0, 100);
                        crossFaderBar_Scroll(null, null);
                    }
                });

                await Task.Delay(AUTO_FADE_INTERVAL_MS);
            }
        }

        private int Clamp(int value, int minValue, int maxValue)
        {
            if (value < minValue) return minValue;
            if (value > maxValue) return maxValue;
            return value;
        }

        private void Invoke(Action action)
        {
            BeginInvoke(new MethodInvoker(() => action()));
        }
    }
}
