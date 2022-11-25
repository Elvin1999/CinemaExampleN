using CinemaExampleN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaExampleN.ViewModels
{
    public class MovieCellViewModel:BaseViewModel
    {
		private Movie movie;

		public Movie Movie
		{
			get { return movie; }
			set { movie = value;
				movie.Description = movie.Description.Substring(0, 17);
				if (movie.Name.Length >= 18)
				{
					movie.Name = movie.Name.Substring(18);
				}
				
				OnPropertyChanged();			
			}
		}
		public WrapPanel StarsPanel { get; set; }

		public MovieCellViewModel()
		{

		}

	}
}
