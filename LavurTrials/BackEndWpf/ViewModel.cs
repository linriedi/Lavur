using Sync;
using System;
using System.ComponentModel;

namespace BackEndWpf
{
    public class ViewModel : INotifyPropertyChanged
    {
        private SyncPoint point;

        private bool isSelected;
        private bool isActivated;
        private int count;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                this.RaisePropertyChanged(nameof(this.IsSelected));
            }
        }

        public bool IsActivated
        {
            get
            {
                return this.isActivated;
            }
            set
            {
                this.isActivated = value;
                if (value)
                {
                    this.point.Block();
                }
                else
                {
                    this.point.Release();
                }
                this.RaisePropertyChanged(nameof(this.IsActivated));
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
                this.RaisePropertyChanged(nameof(this.Count));
            }
        }

        public ViewModel(string name, SyncPoint point)
        {
            this.point = point;
            this.Name = name;

            point.Blocked += OnBlocked;
            point.Released += OnReleased;

            this.IsActivated = point.IsActivated;
        }

        private void OnBlocked(object sender, EventArgs e)
        {
            this.IsSelected = true;
            this.Count = point.Count;
        }

        private void OnReleased(object sender, EventArgs e)
        {
            this.IsSelected = false;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            var temp = this.PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
