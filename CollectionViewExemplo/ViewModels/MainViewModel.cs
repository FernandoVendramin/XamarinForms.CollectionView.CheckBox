using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectionViewExemplo
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public ObservableCollection<Produto> Produtos { get; }
        public MainViewModel()
        {
            Produtos = new ObservableCollection<Produto>();

            Produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Trigo"
            });
            Produtos.Add(new Produto
            {
                Id = 2,
                Nome = "Pão de Forma"
            });
            Produtos.Add(new Produto
            {
                Id = 3,
                Nome = "Ovos"
            });
            Produtos.Add(new Produto
            {
                Id = 4,
                Nome = "Arroz"
            });
            Produtos.Add(new Produto
            {
                Id = 5,
                Nome = "Feijão"
            });
            Produtos.Add(new Produto
            {
                Id = 6,
                Nome = "Frango"
            });
            Produtos.Add(new Produto
            {
                Id = 7,
                Nome = "Carne"
            });
            Produtos.Add(new Produto
            {
                Id = 8,
                Nome = "Detergente"
            });
            Produtos.Add(new Produto
            {
                Id = 9,
                Nome = "Sabão em pó"
            });
            Produtos.Add(new Produto
            {
                Id = 10,
                Nome = "Refrigerante"
            });
            Produtos.Add(new Produto
            {
                Id = 11,
                Nome = "Suco de Laranja"
            });
            Produtos.Add(new Produto
            {
                Id = 12,
                Nome = "Suco de Limão"
            });
            Produtos.Add(new Produto
            {
                Id = 13,
                Nome = "Suco de Uva"
            });
            Produtos.Add(new Produto
            {
                Id = 14,
                Nome = "Suco de Pêra"
            });
            Produtos.Add(new Produto
            {
                Id = 15,
                Nome = "Suco de Maça"
            });
            Produtos.Add(new Produto
            {
                Id = 16,
                Nome = "Suco de Goiaba"
            });
            Produtos.Add(new Produto
            {
                Id = 17,
                Nome = "Pasta de Dente"
            });
            Produtos.Add(new Produto
            {
                Id = 18,
                Nome = "Escova de Dente"
            });
        }

    }
}
