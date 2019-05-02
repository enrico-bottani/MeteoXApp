﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MeteoApp.ViewModels;
using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoListPage : ContentPage
    {
        MeteoListViewModel ViewModel= new MeteoListViewModel();

        public MeteoListPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            _ = ShowPrompt(this);
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage()
                {
                    BindingContext = new MeteoItemViewModel(e.SelectedItem as Entry)
                });
            }
        }
        private async Task ShowPrompt(MeteoListPage instance)
        {
            var pResult = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Name,
                OkText = "Create",
                Title = "New Entry",
            });
            // esempio: creo una nuova Entry partendo dal testo e la aggiungo al ViewModel
            if (pResult.Ok && !string.IsNullOrWhiteSpace(pResult.Text))
            {
                var newEntry = new Entry
                {
                    ID = 99,

                    Name = pResult.Text
                };

                ViewModel.Entries.Add(newEntry);
            }
        }
    }
}