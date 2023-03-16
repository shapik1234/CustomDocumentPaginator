using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace CustomDocumentPaginator
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            List<PersonViewModel> people = new List<PersonViewModel>();

            for (int i = 0; i < 10; i++)
            {
                people.Add(new PersonViewModel("Peter Jones", "High Road to Nowhere", true));
                people.Add(new PersonViewModel("Scott James", "Low Road to Everywhere", true));
                people.Add(new PersonViewModel("Michael Marks", "Somewhere in chesterfield", true));
                people.Add(new PersonViewModel("Rich Blair", "Miserville", false));
                people.Add(new PersonViewModel("David Smith", "Happy land", true));
                people.Add(new PersonViewModel("Adam Johnson", "On yer bike", false));
                people.Add(new PersonViewModel("Rob Hood", "The Manor", true));
            }

            this.People = new ObservableCollection<PersonViewModel>(people);

            this.PrintCommand = new DelegateCommand(this.PrintGrid);
        }

        public ObservableCollection<PersonViewModel> People { get; set; }

        public ICommand PrintCommand { get; private set; }

        public void PrintGrid(object param)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == false)
                return;

            string documentTitle = "Test Document";
            Size pageSize = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

            CustomDataGridDocumentPaginator paginator = new CustomDataGridDocumentPaginator(param as DataGrid, documentTitle, pageSize, new Thickness(30, 20, 30, 20));
            printDialog.PrintDocument(paginator, "Grid");
        }

    }
}
