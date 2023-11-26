using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SKW_Video_Player.Commands
{
    public class OpenCommand : ICommand
    {
        public MainWindowViewModel ViewModel { get; set; }
        public OpenCommand(MainWindowViewModel mainWindowViewModel)
        {
            ViewModel = mainWindowViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                ViewModel.Open();
            }
            catch(Exception ex) 
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
