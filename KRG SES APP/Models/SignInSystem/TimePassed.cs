using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace KRG_SES_APP.Models.SignInSystem
{
    public class TimePassed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string formattedString;
        public string FormattedString
        {
            get => formattedString;
            set
            {
                if (formattedString == value)
                    return;

                formattedString = value;
                OnPropertyChanged();
            }
        }

        public void Update(CurrentAttendance attendance)
        {
            FormattedString = DateTime.UtcNow.Subtract(attendance.StartTime).ToString(@"hh\:mm\:ss");
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
