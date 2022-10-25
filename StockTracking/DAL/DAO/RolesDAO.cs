using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking.DAL.DAO
{
    class RolesDAO : StockContext, IDAO<ROL, RolDetailDTO>
    {
        public bool Delete(ROL entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ROL entity)
        {
            throw new NotImplementedException();
        }

        public List<RolDetailDTO> Select()
        {
            
                List<RolDetailDTO> roles = new List<RolDetailDTO>();
                var list = db.ROLs.ToList();
                foreach (var item in list)
                {
                    RolDetailDTO dto = new RolDetailDTO();
                    dto.ID = item.ID;
                    dto.RolName = item.RolName;
                    roles.Add(dto);
                }

                return roles;
        }
            

        public bool Update(ROL entity)
        {
            throw new NotImplementedException();
        }

        internal List<RolDetailDTO> Select(bool isDeleted)
        {
            List<RolDetailDTO> roles = new List<RolDetailDTO>();
            var list = db.ROLs.Where(x => isDeleted == true).ToList();
            foreach (var item in list)
            {
                RolDetailDTO dto = new RolDetailDTO();
                dto.ID = item.ID;
                dto.RolName = item.RolName;
                roles.Add(dto);
            }

            return roles;
        }
    }
}
