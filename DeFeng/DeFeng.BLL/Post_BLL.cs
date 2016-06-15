using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeFeng.Model;
using DeFeng.DAL;

namespace DeFeng.BLL
{
    public class Post_BLL
    {
        public List<Post> GetPostByDepartment(int departmentID,int pageIndex=1)
        {
            var list = new List<Post>();
            Post_DAL dal = new Post_DAL();
            try
            {           
                list = dal.GetPostByDepartment(departmentID, pageIndex);
                list[0].TotalCount = list[0].TotalCount + ((pageIndex - 1) * 10);
                list[0].PageIndex = pageIndex;
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return list;
        }

        public List<Post> GetPost(int pageIndex=1)
        {
            var list = new List<Post>();
            Post_DAL dal = new Post_DAL();
            try
            {
                list = dal.GetPost(pageIndex);
                list[0].TotalCount = list[0].TotalCount + ((pageIndex - 1) * 10);
                list[0].PageIndex = pageIndex;
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return list;
        }

        public bool AddPost(Post post)
        {
            Post_DAL dal = new Post_DAL();
            var result = false;
            try
            {
                result = dal.AddPost(post);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }

        public bool UpdatePost(Post post)
        {
            var result = false;
            Post_DAL dal = new Post_DAL();
            try
            {
                result = dal.UpdatePost(post);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }

        public bool DeletePost(List<int> idArr)
        {
            var result = false;
            Post_DAL dal = new Post_DAL();
            try
            {
                result = dal.DeletePost(idArr);
                dal = null;
            }
            catch (Exception ex)
            {
                dal = null;
            }
            return result;
        }
    }
}
