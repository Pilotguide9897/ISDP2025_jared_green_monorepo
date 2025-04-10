using idsp2025_jared_green.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Interfaces.Services
{
    internal interface IItems
    {
        public Task<BindingList<Item>> GetAllItems();

        public Task<bool> UpdateItem(Item item);

        public Task<BindingList<string>> GetImagePaths(int itemID);

        Task<Image> AddImage(Image image);

        Task<bool> AddImagePath(ImagePath image);

        Task<object> AddItem(Item item);

        public Task<object> GetItem(string itemName);
    }
}
