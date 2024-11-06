using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF.UI.Study.Models;

namespace WPF.UI.Study.ViewMode
{
    public partial class NAudioRecordViewModel : ObservableObject
    {
        private NAudioRecord _audioRecord = null;

        private bool _recording = false;

        [RelayCommand]
        public void StartRecord()
        {
            if (_recording)
            {
                return;
            }

            _audioRecord = new NAudioRecord();
            _audioRecord.StartRecord();
            _recording = true;
        }

        [RelayCommand]
        public void StopRecord()
        {
            _audioRecord.StopRecord();
            _recording = false;
        }
    }
}
