using Microsoft.Win32;
using SKW_Video_Player.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKW_Video_Player
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        public bool IsInitialized;

        public event PropertyChangedEventHandler? PropertyChanged;

        public OpenCommand OpenCommand { get; set; }

        public MainWindowViewModel() 
        {
            mediaName = "Open file to load";
            OpenCommand = new OpenCommand(this);
            IsInitialized = true;
        }

        private string mediaName { get; set; }
        public string MediaName
        {
            get => mediaName;
            set
            {
                mediaName = value;
                OnPropertyChanged();
            }
        }

        private Uri? mediaElementSource { get; set; }
        public Uri? MediaElementSource
        {
            get => mediaElementSource;
            set
            {
                mediaElementSource = value;
                OnPropertyChanged();
            }
        }

        public void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "Media files (*.wmv;*.mkv;*.mp4)|*.wmv;*.mkv;*.mp4|All Files (*.*)|*.*";
            dialog.RestoreDirectory = true;
            dialog.ShowDialog();

            MediaName = dialog.FileName;
            MediaElementSource = new Uri(dialog.FileName);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
