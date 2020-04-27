﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Models;

namespace WPFUI.ViewModels
{
	public class ShellViewModel : Conductor<object> 
	{
		private string _firstName = "Tim";
		private string _lastName;
		private BindableCollection<PersonModel> _people = new BindableCollection<PersonModel>();
		private PersonModel _selectedPerson;

		public  string FirstName
		{
			get { return _firstName; }
			set 
			{ 
				_firstName = value;
				NotifyOfPropertyChange(() => FirstName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set 
			{ 
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
				NotifyOfPropertyChange(() => FullName);
			}
		}

		public  string FullName
		{
			get 
			{ 
				return $"{FirstName} {LastName}"; 
			}			
		}	

		public BindableCollection<PersonModel> People
		{
			get { return _people; }
			set { _people = value; }
		}		

		public PersonModel SelectedPerson
		{
			get { return _selectedPerson; }
			set 
			{ 
				_selectedPerson = value;
				NotifyOfPropertyChange(() => SelectedPerson);
			}
		}

		public ShellViewModel()
		{
			People.Add(new PersonModel { FirstName = "Rob", LastName = "McGraw" });
			People.Add(new PersonModel { FirstName = "Lefty", LastName = "Legs" });
			People.Add(new PersonModel { FirstName = "Old", LastName = "Paint" });
		}

		public bool CanClearText(string firstName, string lastName)
		{

			return !string.IsNullOrWhiteSpace(firstName) || !string.IsNullOrWhiteSpace(lastName);
		}

		public void ClearText(string firstName, string lastName)
		{
			FirstName = "";
			LastName = "";
		}

		public void LoadPageOne()
		{
			ActivateItem(new FirstChildViewModel());
		}

		public void LoadPageTwo()
		{
			ActivateItem(new SecondChildViewModel());
		}

	}
}
