using CinemaExampleN.Commands;
using CinemaExampleN.Services;
using CinemaExampleN.Views;
using CinemaExampleN.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaExampleN.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
		private string searchText;

		public string SearchText
		{
			get { return searchText; }
			set { searchText = value; OnPropertyChanged(); }
		}

		private string backImagePath;

		public string BackImagePath
        {
			get { return backImagePath; }
			set { backImagePath = value; OnPropertyChanged(); }
		}


		public RelayCommand SearchCommand { get; set; }
		public MainViewModel()
		{
			BackImagePath = @"\images\cine.jpg";
			SearchCommand = new RelayCommand((p) =>
			{
				var panel = p as WrapPanel;
				panel.Children.Clear();
				var movies = MovieService.GetMovies(SearchText);
				int x = 10;
				int y = 10;

				BackImagePath = movies.First().ImagePath;

				foreach (var m in movies)
				{
					var ucVM = new MovieCellViewModel
					{
						Movie = m
					};

					var d = double.Parse(m.Rating.Replace('.', ',')).ToString();

					double result = (double.Parse(d) + 1) / 2;
					int count = (int)result;
					var uc = new MovieCellUC(ucVM);

					for (int i = 0; i < count; i++)
					{
						ucVM.StarsPanel.Children.Add(new StarUC());
					}

					uc.Margin = new System.Windows.Thickness(x, y, 0, 0);


					panel.Children.Add(uc);
				}
			});
		}
	}
}
