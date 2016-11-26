using System.Windows;
using System.Collections.ObjectModel;

namespace BackEndWpf
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ViewModel> AllActivities { get; set; }

        private readonly Service.Service service;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            this.service = new Service.Service();
            this.AllActivities = new ObservableCollection<ViewModel>();
                      
            this.CreateList();
        }

        private void CreateList()
        {
            var point = Sync.SyncPointConnection.First;
            AllActivities.Add(new ViewModel(point));

            //foreach (var activity in this.viewModels)
            //{
            //    AllActivities.Add(activity);
            //}
        }
    }
}
