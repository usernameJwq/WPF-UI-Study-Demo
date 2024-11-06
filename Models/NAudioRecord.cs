using System;
using System.Threading;
using NAudio.Wave;

namespace WPF.UI.Study.Models
{
    // 录制音频
    public class NAudioRecord
    {
        private WaveInEvent _waveInEvent;
        private WaveFileWriter _waveFileWriter;

        private readonly string _devName = "麦克风 (Realtek(R) Audio)";

        public NAudioRecord()
        {
            NAudioInit();
        }

        private void NAudioInit()
        {
            try
            {
                WaveFormat waveFormat = new WaveFormat();

                _waveInEvent = new WaveInEvent();
                _waveInEvent.WaveFormat = waveFormat;

                _waveFileWriter = new WaveFileWriter($"record_{DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString()}.wav", waveFormat);

                for (int devIndex = 0; devIndex < WaveInEvent.DeviceCount; devIndex++)
                {
                    WaveInCapabilities capabilities = WaveInEvent.GetCapabilities(devIndex);
                    if (_devName == capabilities.ProductName)
                    {
                        _waveInEvent.DeviceNumber = devIndex;
                        break;
                    }
                }

                _waveInEvent.DataAvailable += WriteRecordData;
            }
            catch (Exception ex)
            {
                throw new Exception($"NAudioInit Error {ex.Message}");
            }
        }

        public void StartRecord()
        {
            try
            {
                _waveInEvent.StartRecording();
            }
            catch (Exception ex)
            {
                throw new Exception($"Start Recording Failed, {ex.Message}");
            }
        }

        public void StopRecord()
        {
            try
            {
                _waveInEvent.StopRecording();
                _waveInEvent.DataAvailable -= WriteRecordData;
                _waveInEvent.Dispose();

                Thread.Sleep(500);

                _waveFileWriter.Close();
                _waveFileWriter.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception($"Stop Record Failed, {ex.Message}");
            }
        }

        private void WriteRecordData(object sender, WaveInEventArgs args)
        {
            _waveFileWriter.Write(args.Buffer, 0, args.BytesRecorded);
            _waveFileWriter.Flush();
        }
    }
}
