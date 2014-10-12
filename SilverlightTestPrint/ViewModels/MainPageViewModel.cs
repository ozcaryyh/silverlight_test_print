using System.ComponentModel;
using System.Collections.Generic;
using PrinterLib;

namespace SilverlightTestPrint.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private PrinterService _service;

        private string _favoriteConf;
        public string FavoriteConf
        {
            get { return _favoriteConf; }
            set
            {
                _favoriteConf = value;
                NotifyPropertyChanged("FavoriteConf");
            }
        }

        private List<string> _confs;
        public List<string> Confs
        {
            get { return _confs; }
            set
            {
                _confs = value;
                NotifyPropertyChanged("Confs");
            }
        }

        public MainPageViewModel()
        {
            PopulateConfs();
            //FavoriteConf = "MIX";
        }

        private void PopulateConfs()
        {
            _service = new PrinterService();
            _service.LoadPrinters(PrinterEnumFlags.Local);

            Confs = new List<string>();
            foreach(PrinterInformation eachPrinter in _service.Printers)
            {
                Confs.Add(eachPrinter.PrinterName);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
