using idsp2025_jared_green.Entities;
using System.ComponentModel;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Interfaces.Controllers
{
    public interface IItemController
    {
        public Task<BindingList<string>> GetImagePaths(int itemID);

        public Task<Image> AddImage(string imagePath);

        public Task<bool> AddImagePath(int itemID, int imageID);

        public Task<bool> UpdateItem(Item item);

        public Task<BindingList<Item>> GetAllItems();

        public Task<object> AddProduct(Item item);

        public Task<object> GetItemByName(string itemName);
    }
}