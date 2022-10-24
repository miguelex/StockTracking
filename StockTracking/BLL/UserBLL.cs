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
        public bool Delete(UserDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(UserDetailDTO entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
