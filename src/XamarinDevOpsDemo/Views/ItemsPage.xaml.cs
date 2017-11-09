using System;

using XamarinDevOpsDemo.Models;
using XamarinDevOpsDemo.ViewModels;

using Xamarin.Forms;
using Plugin.Fingerprint;

namespace XamarinDevOpsDemo.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            if (await CrossFingerprint.Current.IsAvailableAsync(true))
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
                if (result.Authenticated)
                {
                    await Navigation.PushAsync(new NewItemPage());
                }
                else
                {
                    await DisplayAlert("Error", "not allowed to do secret stuff :(", "OK");
                }
            }
            else
                await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
