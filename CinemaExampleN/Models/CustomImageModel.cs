using CinemaExampleN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaExampleN.Models
{
    public class CustomImageModel:BaseViewModel
    {
		private string backImagePath;

		public string BackImagePath
        {
			get { return backImagePath; }
			set { backImagePath = value; OnPropertyChanged(); }
		}

	}
}
