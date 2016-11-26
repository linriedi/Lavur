using System.Windows;
using System.Collections.ObjectModel;
using Sync;
using System.Reflection;

namespace BackEndWpf
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ViewModel> SyncPoints { get; set; }

        private readonly Service.Service service;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            this.service = new Service.Service();
            this.SyncPoints = new ObservableCollection<ViewModel>();
                      
            this.CreateList();
        }

        private void CreateList()
        {
            var pointInfos = typeof(SyncPointConnection)
                .GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach(var info in pointInfos)
            {
                var point = (SyncPoint)info.GetValue(null);
                var fieldName = info.Name;
                this.SyncPoints.Add(new ViewModel(fieldName, point));
            }
        }
    }
}
