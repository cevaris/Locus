using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Locus.Views.Models;

namespace Locus.Pages
{
    public partial class ListPage : ContentPage
    {
        private readonly static ILogger logger = new ConsoleLogger(nameof(ListPage));

        public ListPage()
        {
            InitializeComponent();
        }

        void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            LocationListRecordViewModel selectedPokemon = (LocationListRecordViewModel)e.SelectedItem;
            if (selectedPokemon != null)
            {
                logger.Info(selectedPokemon);
                //PokemonDetailPage page = new PokemonDetailPage();
                //PokemonModel pokemon = await PokemonMapper.GetById(selectedPokemon.Id);
                //page.BindingContext = new PokemonDetailViewModel()
                //{
                //    Pokemon = pokemon
                //};
                //await Navigation.PushAsync(page);
                //// deselect item
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
