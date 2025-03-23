using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using System.ComponentModel;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Controllers
{
    internal class ItemImageController : IItemController
    {
        private readonly IItems _items;
        public ItemImageController(IItems items)
        {
            _items = items;
        }

        public Task<BindingList<string>> GetImagePaths(int itemID)
        {
            return _items.GetImagePaths(itemID);
        }

        public async Task<Image> AddImage(string imagePath)
        {
            try
            {
                Image image = new Image();
                image.ImagePath = imagePath;
                return await _items.AddImage(image);
            }
            catch (Exception ex)
            {
                return new Image();
            }
        }

        public Task<bool> AddImagePath(int itemID, int imageID)
        {
            ImagePath imagePath = new ImagePath();
            imagePath.ItemID = itemID;
            imagePath.ImageID = imageID;
            return _items.AddImagePath(imagePath);
        }

        public Task<bool> UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<BindingList<Item>> GetAllItems()
        {
            throw new NotImplementedException();
        }
    }
}