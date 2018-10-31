using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LYZJ.HM3Shop.Model
{
    public class UserInfo
    {
        public UserInfo()
        {
            this.DelFlag = 0;
            this.R_UserInfo_Role = new HashSet<R_UserInfo_Role>();
            this.R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
            this.ActionGroup = new HashSet<ActionGroup>();
            this.实体1 = new HashSet<实体1>();
        }
        public int UserInfoID { get; set; }
        public string UName { get; set; }
        public string Pwd { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public System.DateTime SubTime { get; set; }
        public System.DateTime LastModifiedOn { get; set; }
        public short DelFlag { get; set; }

        public virtual ICollection<R_UserInfo_Role> R_UserInfo_Role { get; set; }
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
        public virtual ICollection<实体1> 实体1 { get; set; }
    }
    public class ActionGroup
    {
        public ActionGroup()
        {
            this.ActionInfo = new HashSet<ActionInfo>();
            this.UserInfo = new HashSet<UserInfo>();
            this.Role = new HashSet<Role>();
        }
        public int ActionGroupID { get; set; }
        public string GroupName { get; set; }
        public short DelFlag { get; set; }
        public short GroupType { get; set; }

        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<UserInfo> UserInfo { get; set; }
        public virtual ICollection<Role> Role { get; set; }
    }

    public class ActionInfo
    {
        public ActionInfo()
        {
            this.RequestHttpType = "\"Get\"";
            this.ActionType = 0;
            this.Role = new HashSet<Role>();
            this.R_UserInfo_ActionInfo = new HashSet<R_UserInfo_ActionInfo>();
            this.ActionGroup = new HashSet<ActionGroup>();
        }
        public int ActionInfoID { get; set; }
        public string RequestUrl { get; set; }
        public string RequestHttpType { get; set; }
        public string ActionName { get; set; }
        public System.DateTime SubTime { get; set; }
        public short ActionType { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<R_UserInfo_ActionInfo> R_UserInfo_ActionInfo { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
    }

    public class Category
    {
        public Category()
        {
            this.Property = new HashSet<Property>();
            this.GoodInfo = new HashSet<GoodInfo>();
        }
        public int CategoryID { get; set; }
        public string CatName { get; set; }
        public short DelFlag { get; set; }
        public int ParentID { get; set; }
        public string TreePath { get; set; }
        public int Level { get; set; }
        public short IsLeaf { get; set; }
        public virtual ICollection<Property> Property { get; set; }
        public virtual ICollection<GoodInfo> GoodInfo { get; set; }
    }
    public class GoodInfo
    {
        public GoodInfo()
        {
            this.Property = new HashSet<Property>();
            this.GoodSKU = new HashSet<GoodSKU>();
            this.GoodsPropValue = new HashSet<GoodsPropValue>();
            this.Category = new HashSet<Category>();
            this.ImageInfo = new HashSet<ImageInfo>();
        }
        public int GoodInfoID { get; set; }
        public string GoodName { get; set; }
        public string GoodNo { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string GoodStatus { get; set; }
        public System.DateTime Subtime { get; set; }
        public System.DateTime OnShelfTime { get; set; }
        public System.DateTime OffLineTime { get; set; }
        public short GoodMark { get; set; }
        public int MainInageId { get; set; }

        public virtual ICollection<Property> Property { get; set; }
        public virtual ICollection<GoodSKU> GoodSKU { get; set; }
        public virtual ICollection<GoodsPropValue> GoodsPropValue { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<ImageInfo> ImageInfo { get; set; }
    }
    public class GoodSKU
    {
        public GoodSKU()
        {
            this.GoodsPropValue = new HashSet<GoodsPropValue>();
        }
        public int GoodSKUID { get; set; }
        public string SkuCode { get; set; }
        public string Remark { get; set; }
        public string SKUOptions { get; set; }
        public int GoodInfoID { get; set; }
        public decimal StoreCount { get; set; }
        public virtual GoodInfo GoodInfo { get; set; }
        public virtual ICollection<GoodsPropValue> GoodsPropValue { get; set; }
    }


    public class GoodsPropValue
    {
        public GoodsPropValue()
        {
            this.GoodSKU = new HashSet<GoodSKU>();
        }
        public int GoodsPropValueID { get; set; }
        public int PropID { get; set; }
        public int OptionID { get; set; }
        public int GoodInfoID { get; set; }
        public GoodInfo GoodInfo { get; set; }
        public virtual ICollection<GoodSKU> GoodSKU { get; set; }
    }
    public class ImageInfo
    {
        public int ImageInfoID { get; set; }
        public string URL { get; set; }
        public string Alt { get; set; }
        public string ImageSize { get; set; }
        public short DelFlag { get; set; }
        public int GoodInfoID { get; set; }

        public virtual GoodInfo GoodInfo { get; set; }
    }
    public class Property
    {
        public Property()
        {
            this.PropOption = new HashSet<PropOption>();
            this.Category = new HashSet<Category>();
            this.GoodInfo = new HashSet<GoodInfo>();
        }
        public int PropertyID { get; set; }
        public string PropName { get; set; }
        public short ShowType { get; set; }
        public string PropOptions { get; set; }
        public virtual ICollection<PropOption> PropOption { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<GoodInfo> GoodInfo { get; set; }
    }
    public class PropOption
    {
        public int PropOptionID { get; set; }
        public string OptionName { get; set; }
        public string ShowName { get; set; }
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }
    }

    public class R_UserInfo_ActionInfo
    {
        public int R_UserInfo_ActionInfoID { get; set; }
        public int UserInfoID { get; set; }
        public int ActionInfoID { get; set; }
        public bool HasPermation { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual ActionInfo ActionInfo { get; set; }
    }
    public class R_UserInfo_Role
    {
        public int R_UserInfo_RoleID { get; set; }
        public int UserInfoID { get; set; }
        public int RoleID { get; set; }
        public System.DateTime SubTime { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual Role Role { get; set; }
    }
    public class Role
    {
        public Role()
        {
            this.RoleType = 0;
            this.DelFlag = 0;
            this.R_UserInfo_Role = new HashSet<R_UserInfo_Role>();
            this.ActionInfo = new HashSet<ActionInfo>();
            this.ActionGroup = new HashSet<ActionGroup>();
        }

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public short RoleType { get; set; }
        public short DelFlag { get; set; }
        public System.DateTime SubTime { get; set; }

        public virtual ICollection<R_UserInfo_Role> R_UserInfo_Role { get; set; }
        public virtual ICollection<ActionInfo> ActionInfo { get; set; }
        public virtual ICollection<ActionGroup> ActionGroup { get; set; }
    }
    public class Shop
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string Property1 { get; set; }

    }
    public class 实体1
    {
        public int 实体1ID { get; set; }
        public int UserInfoID { get; set; }
        public virtual UserInfo UserInfo { get; set; }

    }
}
