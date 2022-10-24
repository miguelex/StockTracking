using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    class UserDAO : StockContext, IDAO<USER, UserDetailDTO>
    {
        public bool Delete(USER entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
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
            var list = db.USERs.ToList();
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
            throw new NotImplementedException();
        }
    }

}
