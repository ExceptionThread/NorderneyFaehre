using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Windows.Input;
using Wpf_NorderneyFaehre.Model;
using Wpf_NorderneyFaehre.ViewModel;

namespace Wpf_NorderneyFaehre
{
    internal class FaehreSuchenViewModel : ViewModelBase
    {
        private Verbindung _selectedVerbindung;
        private Faehrfahrt _selectedFaehrnfahrt;
        private DateTime _selectedDateTime;

        private FaehrfahrtenManager? _faehrfahrtenManager;

        public List<Verbindung> Verbindungen { get; set; }
        public ObservableCollection<Faehrfahrt> Faehrfahrten { get; set; }

 
        public Verbindung SelectedVerbindung
        {
            get => _selectedVerbindung;
            set
            {
                if (_selectedVerbindung != value)
                {
                    _selectedVerbindung = value;
                    OnPropertyChanged(nameof(SelectedVerbindung));
                }
            }
        }

        public Faehrfahrt SelectedFaehrnfahrt
        {
            get => _selectedFaehrnfahrt;
            set
            {
                if (_selectedFaehrnfahrt != value)
                {
                    _selectedFaehrnfahrt = value;
                    OnPropertyChanged(nameof(SelectedFaehrnfahrt));
                }
            }
        }

        public DateTime SelectedDatum
        {
            get => _selectedDateTime;
            set
            {
                if (_selectedDateTime != value)
                {
                    _selectedDateTime = value;
                    OnPropertyChanged(nameof(SelectedDatum));
                }
            }
        }

        public ICommand VerbindungSuchen { get; }

        private bool CanExecute(object? param)
        {
            return true;
        }

        private void Execute(object? param)
        {
            var result = _faehrfahrtenManager.Faehrfahrten(SelectedVerbindung, SelectedDatum);
            Faehrfahrten.Clear();
            result.ForEach(item => Faehrfahrten.Add(item));
           
        }

        public FaehreSuchenViewModel()
        {
            _faehrfahrtenManager = new FaehrfahrtenManager();
            Verbindungen = _faehrfahrtenManager.NorderneyFaehren;
            SelectedDatum = DateTime.Today;
            Faehrfahrten = new ObservableCollection<Faehrfahrt>();
            VerbindungSuchen = new RelayCommand(Execute, CanExecute);

            
        }
    }
}
