﻿//根据数据库表明生成实体类  ---不通过  存在中间表






using LYZJ.HM3Shop.IDAL;
using LYZJ.HM3Shop.Model;
namespace LYZJ.UserLimitMVC.DAL
{     
      
 
 
    public partial class UserInfoRepository: BaseRepository<UserInfo>,IUserInfoRepository                  
    {                  

 
    }

 
 
    public partial class PropertyRepository: BaseRepository<Property>,IPropertyRepository                  
    {                  

 
    }

 
 
    public partial class ShopRepository: BaseRepository<Shop>,IShopRepository                  
    {                  

 
    }

 
 
    public partial class 实体1集Repository: BaseRepository<实体1集>,I实体1集Repository                  
    {                  

 
    }

 
 
    public partial class RoleRepository: BaseRepository<Role>,IRoleRepository                  
    {                  

 
    }

 
 
    public partial class ActionGroupRepository: BaseRepository<ActionGroup>,IActionGroupRepository                  
    {                  

 
    }

 
 
    public partial class ActionInfoRepository: BaseRepository<ActionInfo>,IActionInfoRepository                  
    {                  

 
    }

 
 
    public partial class GoodInfoRepository: BaseRepository<GoodInfo>,IGoodInfoRepository                  
    {                  

 
    }

 
 
    public partial class CategoryRepository: BaseRepository<Category>,ICategoryRepository                  
    {                  

 
    }

 
 
    public partial class UserInfoActionGroupRepository: BaseRepository<UserInfoActionGroup>,IUserInfoActionGroupRepository                  
    {                  

 
    }

 
 
    public partial class GoodSKURepository: BaseRepository<GoodSKU>,IGoodSKURepository                  
    {                  

 
    }

 
 
    public partial class ActionInfoRoleRepository: BaseRepository<ActionInfoRole>,IActionInfoRoleRepository                  
    {                  

 
    }

 
 
    public partial class ActionInfoActionGroupRepository: BaseRepository<ActionInfoActionGroup>,IActionInfoActionGroupRepository                  
    {                  

 
    }

 
 
    public partial class CategoryPropertyRepository: BaseRepository<CategoryProperty>,ICategoryPropertyRepository                  
    {                  

 
    }

 
 
    public partial class CategoryGoodInfoRepository: BaseRepository<CategoryGoodInfo>,ICategoryGoodInfoRepository                  
    {                  

 
    }

 
 
    public partial class ActionGroupRoleRepository: BaseRepository<ActionGroupRole>,IActionGroupRoleRepository                  
    {                  

 
    }

 
 
    public partial class R_UserInfo_RoleRepository: BaseRepository<R_UserInfo_Role>,IR_UserInfo_RoleRepository                  
    {                  

 
    }

 
 
    public partial class R_UserInfo_ActionInfoRepository: BaseRepository<R_UserInfo_ActionInfo>,IR_UserInfo_ActionInfoRepository                  
    {                  

 
    }

 
 
    public partial class PropOptionRepository: BaseRepository<PropOption>,IPropOptionRepository                  
    {                  

 
    }

 
 
    public partial class PropertyGoodInfoRepository: BaseRepository<PropertyGoodInfo>,IPropertyGoodInfoRepository                  
    {                  

 
    }

 
 
    public partial class ImageInfoRepository: BaseRepository<ImageInfo>,IImageInfoRepository                  
    {                  

 
    }

 
 
    public partial class GoodsPropValueRepository: BaseRepository<GoodsPropValue>,IGoodsPropValueRepository                  
    {                  

 
    }

 
 
    public partial class GoodSKUGoodsPropValueRepository: BaseRepository<GoodSKUGoodsPropValue>,IGoodSKUGoodsPropValueRepository                  
    {                  

 
    }

}
