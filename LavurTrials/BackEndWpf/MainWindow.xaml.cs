using System;
using System.ComponentModel;
using System.Windows;
using Service;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Sync;

namespace BackEndWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<ViewModel> AllActivities { get; set; }

        private readonly Service.Service service;

        private bool test;
        
        public event PropertyChangedEventHandler PropertyChanged;

        //public bool Test
        //{
        //    get
        //    {
        //        Sync.SyncPointConnection.First.Release();
        //        return this.test;
        //    }
        //    set
        //    {
        //        this.test = value;
        //        RaisePropertyChanged("Test");
        //    }
        //}

        //public List<ViewModel> viewModels { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            this.service = new Service.Service();
            this.AllActivities = new ObservableCollection<ViewModel>();

            //this.BindToSyncPoints();
            //this.viewModels = new List<ViewModel>
            //{
            //    new ViewModel("First", false),
            //    new ViewModel("Second", true),
            //};

            LoadAllActivities();
        }

        private void LoadAllActivities()
        {
            var point = Sync.SyncPointConnection.First;
            AllActivities.Add(new ViewModel(point));

            //foreach (var activity in this.viewModels)
            //{
            //    AllActivities.Add(activity);
            //}
        }

        //private void BindToSyncPoints()
        //{
        //    Sync.SyncPointConnection.First.Blocked += OnFirstSignaled;
        //}

        //private void OnFirstSignaled(object sender, EventArgs e)
        //{
        //    this.Test = true;
        //}

        //private void RaisePropertyChanged(string propertyName)
        //{
        //    var temp = this.PropertyChanged;
        //    if (temp != null)
        //    {
        //        temp(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
