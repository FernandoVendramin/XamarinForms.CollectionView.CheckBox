using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using XLabs.Forms.Behaviors;
using XLabs.Forms.Controls;

namespace CollectionViewExemplo
{
    public partial class MainPage : ContentPage
    {
        //private List<Produto> _selectedItens;
        private List<CheckBox> _checkBoxes;
        private MainViewModel _mainViewModel;

        public MainPage()
        {
            InitializeComponent();

            _mainViewModel = new MainViewModel();
            this.BindingContext = _mainViewModel;

            //_selectedItens = new List<Produto>();
            _checkBoxes = new List<CheckBox>();

            var checkAll = new CheckBox()
            {
                DefaultText = "Selecionar todos",
                Checked = false,
            };
            checkAll.CheckedChanged += (object sender, XLabs.EventArgs<bool> e) =>
            {
                foreach (var item in _checkBoxes)
                {
                    item.Checked = e.Value;
                }
                bool setIsVisible = _checkBoxes.Any(x => x.Checked);
                foreach (var item in _checkBoxes)
                {
                    item.IsVisible = setIsVisible;
                }
            };
            flexLayout.Children.Add(checkAll);

            foreach (var item in _mainViewModel.Produtos)
            {
                AddGridItem(item);
            }
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
        }

        private void AddGridItem(Produto produto)
        {
            try
            {
                StackLayout stackLayout = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    HeightRequest = 50,
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(5),
                    StyleId = $"MyStack_{produto.Nome}"
                };
                Label check = new Label()
                {
                    Text = "\uf058",
                    FontSize = 20,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = new Thickness(5),
                    IsVisible = false
                };
                CheckBox checkBox = new CheckBox()
                {
                    IsVisible = false
                };
                checkBox.CheckedChanged += (object sender, XLabs.EventArgs<bool> e) =>
                {
                    bool setIsVisible = _checkBoxes.Any(x => x.Checked);
                    foreach (var item in _checkBoxes)
                    {
                        item.IsVisible = setIsVisible;
                    }
                };

                Grid grid = new Grid()
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 10
                };
                Label label = new Label()
                {
                    Text = produto.Nome,
                    TextColor = Color.Black,
                    FontSize = 18,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start,
                    Margin = new Thickness(5),
                    IsVisible = true
                };

                GesturesContentView gesturesContentView = new GesturesContentView() {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                StackLayout stackLayout2 = new StackLayout() {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                stackLayout2.SetValue(Gestures.InterestsProperty, new GestureCollection()
                {
                    new GestureInterest()
                    {
                        GestureType = GestureType.LongPress
                    },
                    new GestureInterest()
                    {
                        GestureType = GestureType.SingleTap
                    }
                });

                gesturesContentView.ExcludeChildren = false;
                gesturesContentView.GestureRecognized += (object sender, GestureResult e) =>
                {
                    switch (e.GestureType)
                    {
                        case GestureType.LongPress:
                            if (!check.IsVisible)
                            {
                                //_selectedItens.Add(game);
                                //label.Opacity = 0.5;
                                check.IsVisible = true;
                                checkBox.IsVisible = true;
                                checkBox.Checked = true;
                            }
                            else
                            {
                                //_selectedItens.Remove(game);
                                //label.Opacity = 1;
                                check.IsVisible = false;
                                checkBox.IsVisible = false;
                            }
                            break;
                        case GestureType.SingleTap:
                            if (!_checkBoxes.Any(x => x.Checked))
                            {
                                //var popup = new FilePopup(sampleFile);
                                //PopupNavigation.Instance.PushAsync(popup, true);
                            }
                            else
                            {
                                if (!check.IsVisible)
                                {
                                    //_selectedItens.Add(game);
                                    //label.Opacity = 0.5;
                                    check.IsVisible = true;
                                    checkBox.IsVisible = true;
                                }
                                else
                                {
                                    //_selectedItens.Remove(game);
                                    //label.Opacity = 1;
                                    check.IsVisible = false;
                                    checkBox.IsVisible = false;
                                }
                            }

                            break;
                        //case GestureType.DoubleTap:
                        //    // Add code here
                        //    break;
                        default:
                            break;
                    }

                    bool setIsVisible = _checkBoxes.Any(x => x.Checked);
                    foreach (var item in _checkBoxes)
                    {
                        item.IsVisible = setIsVisible;
                    }

                };
                gesturesContentView.Content = stackLayout2;

                grid.ColumnDefinitions = new ColumnDefinitionCollection();
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.10, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.90, GridUnitType.Star) });

                _checkBoxes.Add(checkBox);
                grid.Children.Add(checkBox, 0, 0);
                grid.Children.Add(label, 1, 0);
                stackLayout2.Children.Add(grid);

                stackLayout.Children.Add(gesturesContentView);
                flexLayout.Children.Add(stackLayout);
            }
            catch (Exception ex)
            {
            }
        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            throw new NotImplementedException();
        }
    }
}
