using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.DAL;
using LYZJ.HM3Shop.Model;
using LYZJ.HM3Shop.IBLL;


namespace LYZJ.HM3Shop.BLL
{
    public class RoleService:BaseService<Role>,IRoleService
    {   //面向接口编程
        private IRoleRepository _roleRepository = RepositoryFactory.RoleRepository;
        //重写抽象方法，设置当前仓储为Role仓储
        public override void SetCurrentReposity()
        {
            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
        //private Role AddEntity(Role role)
        //{
        //    return _roleRepository.AddEntity(role);
        //}
        //private bool UpdateEntity(Role role)
        //{
        //    return _roleRepository.UpdateEntity(role);
        //}
        //private bool DeleteEntity(Role role)
        //{
        //    return _roleRepository.UpdateEntity(role);
        //}
    }
}
