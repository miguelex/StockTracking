using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    class UserDAO : StockContext, IDAO<USER, UserDetailDTO>
    {
        public bool Delete(USER entity)
        {
            try
            {
                USER user = db.USERs.First(x => x.ID == entity.ID);
                user.isDeleted = true;
                user.DeleteDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public bool GetBack(int ID)
        {
            try
            {
                USER user = db.USERs.First(x => x.ID == ID);
                user.isDeleted = false;
                user.DeleteDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public bool Insert(USER entity)
        {
            try
            {
                db.USERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<UserDetailDTO> Select()
        {
            List<UserDetailDTO> user = new List<UserDetailDTO>();
            var list = db.USERs.Where(x => x.isDeleted == false).ToList();
            foreach (var item in list)
            {
                UserDetailDTO dto = new UserDetailDTO();
                dto.ID = item.ID;
                dto.UserName = item.UserName;
                dto.Password = item.Password;
                dto.Rol_id = item.Rol_id;
                user.Add(dto);
            }
            
            return user;
        }

        public bool Update(USER entity)
        {
            try
            {
                USER user = db.USERs.First(x => x.ID == entity.ID);
                user.UserName = entity.UserName;
                user.Password = entity.Password;
                user.Rol_id = entity.Rol_id;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public UserDetailDTO Select(USER Entity)
        {
            try
            {
                UserDetailDTO userdto = new UserDetailDTO();
                USER user = db.USERs.First(x => x.UserName== Entity.UserName && x.Password == Entity.Password && x.isDeleted == false);
                userdto.ID = user.ID;
                userdto.UserName = user.UserName;
                userdto.Password = user.Password;
                userdto.Rol_id = user.Rol_id;
                return userdto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public List<UserDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<UserDetailDTO> userdto = new List<UserDetailDTO>();
                var user = db.USERs.Where(x => x.isDeleted == isDeleted).ToList();
                
                foreach (var item in user)
                {
                    UserDetailDTO dto = new UserDetailDTO();
                    dto.ID = item.ID;
                    dto.UserName = item.UserName;
                    dto.Password = item.Password;
                    dto.Rol_id = item.Rol_id;
                    userdto.Add(dto);
                }

                
                return userdto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
