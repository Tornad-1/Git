using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace LYZJ.HM3Shop.Model
{
    public class UserInfoConfig : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfig()
        {
            this.ToTable("UserInfo");
            this.HasKey(x => x.UserInfoID);
        }
    }
    public class ActionGroupConfig : EntityTypeConfiguration<ActionGroup>
    {
        public ActionGroupConfig()
        {
            this.ToTable("ActionGroup");
            this.HasKey(x => x.ActionGroupID);
            this.HasMany(r => r.Role).WithMany(r => r.ActionGroup).Map(r => r.ToTable("ActionGroupRole").MapLeftKey("ActionGroupID").MapRightKey("RoleID"));
        }
    }
    public class ActionInfoConfig : EntityTypeConfiguration<ActionInfo>
    {
        public ActionInfoConfig()
        {
            this.ToTable("ActionInfo");
            this.HasKey(x => x.ActionInfoID);
            this.HasMany(r => r.ActionGroup).WithMany(r => r.ActionInfo).Map(r => r.ToTable("ActionInfoActionGroup").MapLeftKey("ActionInfoID").MapRightKey("ActionGroupID"));
        }
    }
    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            this.ToTable("Category");
            this.HasKey(x => x.CategoryID);
            this.HasMany(r => r.Property).WithMany(r => r.Category).Map(r => r.ToTable("CategoryProperty").MapLeftKey("CategoryID").MapRightKey("PropertyID"));
            this.HasMany(r => r.GoodInfo).WithMany(r => r.Category).Map(r => r.ToTable("CategoryGoodInfo").MapLeftKey("CategoryID").MapRightKey("GoodInfoID"));
        }
    }
    public class GoodInfoConfig : EntityTypeConfiguration<GoodInfo>
    {
        public GoodInfoConfig()
        {
            this.ToTable("GoodInfo");
            this.HasKey(x => x.GoodInfoID);
            this.HasMany(r => r.Property).WithMany(r => r.GoodInfo).Map(r => r.ToTable("GoodInfoProperty").MapLeftKey("GoodInfoID").MapRightKey("PropertyID"));
        }
    }
    public class GoodSKUConfig : EntityTypeConfiguration<GoodSKU>
    {
        public GoodSKUConfig()
        {
            this.ToTable("GoodSKU");
            this.HasKey(x => x.GoodSKUID);
            this.HasRequired(r => r.GoodInfo).WithMany(r => r.GoodSKU).HasForeignKey(x => x.GoodInfoID);
            this.HasMany(r => r.GoodsPropValue).WithMany(r => r.GoodSKU).Map(r => r.ToTable("GoodSKUGoodsPropValue").MapLeftKey("GoodSKUID").MapRightKey("GoodsPropValueID"));
        }
    }
    public class GoodsPropValueConfig : EntityTypeConfiguration<GoodsPropValue>
    {
        public GoodsPropValueConfig()
        {
            this.ToTable("GoodsPropValue");
            this.HasKey(x => x.GoodsPropValueID);
            this.HasRequired(r => r.GoodInfo).WithMany(r => r.GoodsPropValue).HasForeignKey(x => x.GoodInfoID).WillCascadeOnDelete(false);
        }
    }
    public class ImageInfoConfig : EntityTypeConfiguration<ImageInfo>
    {
        public ImageInfoConfig()
        {
            this.ToTable("ImageInfo");
            this.HasKey(x => x.ImageInfoID);
            this.HasRequired(r => r.GoodInfo).WithMany(r => r.ImageInfo).HasForeignKey(x => x.GoodInfoID);
        }
    }
    public class PropertyConfig : EntityTypeConfiguration<Property>
    {
        public PropertyConfig()
        {
            this.ToTable("Property");
            this.HasKey(x => x.PropertyID);
        }
    }
    public class PropOptionConfig : EntityTypeConfiguration<PropOption>
    {
        public PropOptionConfig()
        {
            this.ToTable("PropOption");
            this.HasKey(x => x.PropOptionID);
            this.HasRequired(r => r.Property).WithMany(r => r.PropOption).HasForeignKey(x => x.PropertyID);
        }
    }
    public class R_UserInfo_ActionInfoConfig : EntityTypeConfiguration<R_UserInfo_ActionInfo>
    {
        public R_UserInfo_ActionInfoConfig()
        {
            this.ToTable("R_UserInfo_ActionInfo");
            this.HasKey(x => x.R_UserInfo_ActionInfoID);
            HasRequired(x => x.UserInfo).WithMany(x => x.R_UserInfo_ActionInfo).HasForeignKey(x => x.UserInfoID);
            HasRequired(x => x.ActionInfo).WithMany(x => x.R_UserInfo_ActionInfo).HasForeignKey(x => x.ActionInfoID);
        }
    }
    public class R_UserInfo_RoleConfig : EntityTypeConfiguration<R_UserInfo_Role>
    {
        public R_UserInfo_RoleConfig()
        {
            this.ToTable("R_UserInfo_Role");
            this.HasKey(x => x.R_UserInfo_RoleID);
            HasRequired(x => x.UserInfo).WithMany(x => x.R_UserInfo_Role).HasForeignKey(x => x.UserInfoID);
            HasRequired(x => x.Role).WithMany(x => x.R_UserInfo_Role).HasForeignKey(x => x.RoleID);
        }
    }
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            this.ToTable("Role");
            this.HasKey(x => x.RoleID);
        }
    }
    public class ShopConfig : EntityTypeConfiguration<Shop>
    {
        public ShopConfig()
        {
            this.ToTable("Shop");
            this.HasKey(x => x.ShopID);
        }
    }
    public class 实体1Config : EntityTypeConfiguration<实体1>
    {
        public 实体1Config()
        {
            this.ToTable("实体1集");
            this.HasKey(x => x.实体1ID);
            this.HasRequired(x => x.UserInfo).WithMany(x => x.实体1).HasForeignKey(x => x.UserInfoID);
        }
    }
}
