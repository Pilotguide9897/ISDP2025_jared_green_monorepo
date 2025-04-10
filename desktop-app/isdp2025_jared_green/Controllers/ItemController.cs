using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Controllers
{
    internal class ItemController : IItemController
    {
        // Field to hold the item service class
        private readonly IItems _itemService;

        // Constructor
        public ItemController(IItems itemService)
        {
            _itemService = itemService;
        }

        // Controller Methods
        public async Task<Entities.Image> AddImage(string imagePath)
        {
            Image newImage = new Image();
            newImage.ImagePath = imagePath;
            newImage.ImageName = imagePath;
            return await _itemService.AddImage(newImage);
        }

        public async Task<bool> AddImagePath(int itemID, int imageID)
        {
            ImagePath newImagePath = new ImagePath();
            newImagePath.ItemID = itemID;
            newImagePath.ImageID = imageID;
            return await _itemService.AddImagePath(newImagePath);
        }

        public Task<BindingList<string>> GetImagePaths(int itemID)
        {
            return _itemService.GetImagePaths(itemID);
        }

        public Task<bool> UpdateItem(Item item)
        {
            return _itemService.UpdateItem(item);
        }

        public async Task<BindingList<Item>> GetAllItems()
        {
            return await _itemService.GetAllItems();
        }

        public async Task<Item> AddProduct(Item item)
        {
            var itm = await _itemService.AddItem(item);
            if (itm is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Item();
            }
            else
            {
                Item addedProduct = itm as Item;
                return item;
            }
        }
        

        public async Task<Item> GetItemByName(string itemName)
        {
            var itm = await _itemService.GetItem(itemName);
            if (itm is ErrorResult error)
            {
                MessageBox.Show(error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Item();
            }
            else
            {
                Item item = itm as Item;
                return item;
            }
        }
    } 
}
