using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Error;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Loggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = idsp2025_jared_green.Entities.Image;

namespace idsp2025_jared_green.Services
{
    internal class ItemService : IItems
    {
        // Declare the static logger.
        private static readonly NLog.Logger ItemLogger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly NLog.Logger _itemLogger = NLog.LogManager.GetCurrentClassLogger();
        private readonly BullseyeContext _bullseyeContext;

        public ItemService(BullseyeContext context)
        {
            _bullseyeContext = context;
        }

        public async Task<BindingList<string>> GetImagePaths(int ItemID) 
        {
            try
            {
                var imagePaths = await (from img in _bullseyeContext.Images
                                        join path in _bullseyeContext.ImagePaths on img.ImageID equals path.ImageID
                                        join itm in _bullseyeContext.Items on path.ItemID equals itm.ItemId
                                        where itm.ItemId == ItemID
                                        select img.ImagePath).ToListAsync();

                var bindingList = new BindingList<string>(imagePaths);

                return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(msqlEx, "");
                return new BindingList<string>();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(toEx, "");
                return new BindingList<string>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the image locations", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(ex, "");
                return new BindingList<string>();
            }
        }

        public async Task<Image> AddImage(Image image)
        {
            try
            {
                await _bullseyeContext.Images.AddAsync(image);
                await _bullseyeContext.SaveChangesAsync();
                return image;
            }
            catch (MySqlException msqlEx)
            {
                return new Image();
            }
        }

        public async Task<Image> GetImage(string imagePath)
        {
            try
            {
                var image = await (from img in _bullseyeContext.Images
                                        where img.ImagePath == imagePath
                                        select img).FirstOrDefaultAsync();

                return image;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(msqlEx, "");
                return new Image();
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(toEx, "");
                return new Image();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred fetching the desired image", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(ex, "");
                return new Image();
            }
        }

        public async Task<BindingList<Item>> GetAllItems()
        {
            try
            {
                    var items = await (from itm in _bullseyeContext.Items
                                select itm).Include(i => i.Supplier).ToListAsync();

                    var bindingList = new BindingList<Item>(items);

                    return bindingList;

            }
            catch (MySqlException msqlEx)
            {
                //MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(msqlEx, "");
                return new BindingList<Item>();
            }
            catch (TimeoutException toEx)
            {
                //MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(toEx, "");
                return new BindingList<Item>();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An unexpected error occurred fetching the item data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(ex, "");
                return new BindingList<Item>();
            }
        }

        //public async Task<bool> UpdateItem(Item item)
        //{
        //    try
        //    {
        //        _bullseyeContext.Attach(item);
        //        _bullseyeContext.Entry(item).State = EntityState.Modified;
        //        var result = await _bullseyeContext.SaveChangesAsync();
        //        if (result != null)
        //        {
        //            return true;
        //        } else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (MySqlException msqlEx)
        //    {
        //        MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ItemLogger.Error(msqlEx, "");
        //        return false;
        //    }
        //    catch (TimeoutException toEx)
        //    {
        //        MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ItemLogger.Error(toEx, "");
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("An unexpected error occurred fetching the item data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ItemLogger.Error(ex, "");
        //        return false;
        //    }
        //}

        public async Task<bool> UpdateItem(Item item)
        {
            try
            {
                var trackedEntity = await _bullseyeContext.Items.FindAsync(item.ItemId);
                if (trackedEntity == null)
                {
                    return false; // or throw if appropriate
                }

                _bullseyeContext.Entry(trackedEntity).CurrentValues.SetValues(item);

                var result = await _bullseyeContext.SaveChangesAsync();
                return result > 0;
            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("A database error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(msqlEx, "Database error while updating item.");
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("The operation timed out.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(toEx, "Timeout while updating item.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred while updating the item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(ex, "Unexpected error while updating item.");
                return false;
            }
        }


        //public async Task<Item> GetItem(int itemID)
        //{
        //    try { 
        //        var item = await (from itm in _bullseyeContext.Items
        //                     where itm.ItemId == itemID
        //                     select itm).FirstOrDefaultAsync();

        //        if (item != null)
        //        {
        //            return item;
        //        } else
        //        {
        //            return new Item();
        //        }

        //    }
        //    // Add any other type of exceptions that I explicitly want to catch.
        //    catch (Exception ex)
        //    {
        //        return new Item();
        //    }
        //}

        public async Task<bool> AddImagePath(ImagePath imagePath) 
        {
            try
            {
                var items = await _bullseyeContext.AddAsync(imagePath);
                await _bullseyeContext.SaveChangesAsync();
                if (items != null)
                {
                    return true;
                }

                return false;

            }
            catch (MySqlException msqlEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(msqlEx, "");
                return false;
            }
            catch (TimeoutException toEx)
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(toEx, "");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred adding the image data", "A problem occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ItemLogger.Error(ex, "");
                return false;
            }
        }

        public async Task<object> AddItem(Item item)
        {
            try
            {
                item.Sku = Guid.NewGuid().ToString("N").Substring(0, 19);
                await _bullseyeContext.AddAsync(item);
                int alterations = await _bullseyeContext.SaveChangesAsync();

                if (alterations > 0)
                {
                    return item;
                } else { 
                _itemLogger.Error("Unable to add item",
                        "An unexpected error occurred when attempting to add the item.");
                    return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                }
            }
            catch (ArgumentException argEx)
            {
                _itemLogger.Error(argEx,
                    "Invalid argument provided when attempting to add the item.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _itemLogger.Error(msqlEx,
                    "Database error occurred when attempting to add the item.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _itemLogger.Error(toEx,
                    "Operation timed out when attempting to add the item.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _itemLogger.Error(ex,
                    "An unexpected error occurred when attempting to add the item.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }

        public async Task<object> GetItem(string itemName)
        {
            try
            {
                Item? item = await (from itm in _bullseyeContext.Items where itm.Name == itemName select itm).FirstOrDefaultAsync();

                if (item != null)
                {
                    return item;
                }
                else
                {
                    _itemLogger.Error("Unable to get item",
                        "An unexpected error occurred when attempting to get the item.");
                    return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.");
                }
            }
            catch (ArgumentException argEx)
            {
                _itemLogger.Error(argEx,
                    "Invalid argument provided when attempting to get the item.");
                return new ErrorResult("ARGUMENT_EXCEPTION", "Invalid argument provided.", argEx);
            }
            catch (MySqlException msqlEx)
            {
                _itemLogger.Error(msqlEx,
                    "Database error occurred when attempting to get the item.");
                return new ErrorResult("DB_EXCEPTION", "Database error occurred.", msqlEx);
            }
            catch (TimeoutException toEx)
            {
                _itemLogger.Error(toEx,
                    "Operation timed out when attempting to get the item.");
                return new ErrorResult("TIMEOUT_EXCEPTION", "Operation timed out.", toEx);
            }
            catch (Exception ex)
            {
                _itemLogger.Error(ex,
                    "An unexpected error occurred when attempting to get the item.");
                return new ErrorResult("UNKNOWN_ERROR", "An unexpected error occurred.", ex);
            }
        }
    }
}
