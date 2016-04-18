using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Image_BLL
    {
        Image_DAL dal = new Image_DAL();
        public int AddImage(Image img)
        {
            var result = 0;
            try
            {
                result = dal.AddImage(img);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public List<Image> LoadHouseImages(int houseID)
        {
            var images = new List<Image>();
            try
            {
                images = dal.LoadHouseImages(houseID);
            }
            catch (Exception ex)
            {

            }
            return images;
        }

        public bool DeleteHouseImage(int imgID)
        {
            var result = false;
            try
            {
                result = dal.DeleteHouseImage(imgID);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
