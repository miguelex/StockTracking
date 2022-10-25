using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using StockTracking.DAL;
using System.Windows.Forms;

namespace StockTracking.BLL
{
    class UserBLL : IBLL<UserDetailDTO, UserDTO>
    {
        UserDAO usersdao = new UserDAO();
        RolesDAO rolesdao = new RolesDAO();

        public UserDetailDTO Select(UserDetailDTO detail)
        {
            USER user = new USER();
            UserDetailDTO userdto = new UserDetailDTO();
            user.UserName = detail.UserName;
            user.Password = detail.Password;
            userdto = usersdao.Select(user);
            return userdto;
        }
        
        public bool Delete(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            usersdao.Delete(user);
            return true;
        }

        public bool GetBack(UserDetailDTO entity)
        {
            return usersdao.GetBack(entity.ID);
        }
        
        public bool Insert(UserDetailDTO entity)
        {
            USER user = new USER();
            user.UserName = entity.UserName;
            user.Rol_id = entity.Rol_id;
            user.Password = entity.Password;
            return usersdao.Insert(user);
        }

        public UserDTO Select()
        {
            UserDTO dto = new UserDTO();
            dto.Roles = rolesdao.Select();
            dto.Users = usersdao.Select();
            return dto;
        }

        public bool Update(UserDetailDTO entity)
        {
            USER user = new USER();
            user.ID = entity.ID;
            user.UserName = entity.UserName;
            user.Rol_id = entity.Rol_id;
            user.Password = entity.Password;
            
            return usersdao.Update(user);
        }

        internal UserDTO Select(bool isDeleted)
        {
            UserDTO dto = new UserDTO();
            //dto.Roles = rolesdao.Select(isDeleted);
            dto.Users = usersdao.Select(isDeleted);
            return dto;
        }
    }
}
