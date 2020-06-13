using System;

using KurirOngkir.Models;

namespace KurirOngkir.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        //public ItemDetailViewModel(Item item = null)
        //{
        //    Title = item?.Text;
        //    Item = item;
        //}
    }
}
