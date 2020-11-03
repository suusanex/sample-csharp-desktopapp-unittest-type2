using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ut_winapp_sample1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public class BindingSource : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged実装 
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName = null));
            }
            #endregion

            public BindingSource()
            {
            }

            string _SrcFilePath;
            public string SrcFilePath
            {
                get => _SrcFilePath;
                set { _SrcFilePath = value; OnPropertyChanged(); }
            }

            string _DestFilePath;
            public string DestFilePath
            {
                get => _DestFilePath;
                set { _DestFilePath = value; OnPropertyChanged(); }
            }

        }

        public BindingSource m_Bind;
        public MainWindow()
        {
            InitializeComponent();

            m_Bind = new BindingSource();

            DataContext = m_Bind;

        }

        private MessageOut m_MessageOut = new MessageOut();

        private void OnRun(object sender, RoutedEventArgs e)
        {
            var zip = new ZipArchive(m_MessageOut);
            zip.CreateZip(m_Bind.SrcFilePath, m_Bind.DestFilePath);
        }
    }
}
