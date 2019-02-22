using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace X4.PULA.Common
{
    /// <summary>
    /// X4 一些共用数据
    /// </summary>
    public struct X4Env
    {
        /// <summary>
        /// 登录的 CookieName
        /// </summary>
        public static string LoginCookieName => "X4LoginId";
        /// <summary>
        /// 获取在模块之间传递的登录信息的 Key
        /// </summary>
        public static string LoginInfoKey => "LoginInfo";
        /// <summary>
        /// 获取登录信息
        /// </summary>
        public static LoginInfo LoginInfo => (HttpContext.Current.Items[LoginInfoKey] as LoginInfo) ?? new LoginInfo();
        /// <summary>
        /// X4 角色
        /// </summary>
        public static X4Role X4Roles { get; set; } = new X4Role();
    }

    /// <summary>
    /// X4 角色
    /// </summary>
    public class X4Role
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        public string SuperAdmin => X4RoleType.SuperAdmin.ToString();
        /// <summary>
        /// 系统管理员
        /// </summary>
        public string SysAdmin => X4RoleType.SysAdmin.ToString();
        /// <summary>
        /// 校园大使
        /// </summary>
        public string CampusAdmin => X4RoleType.CampusAdmin.ToString();
        /// <summary>
        /// 企业
        /// </summary>
        public string Company => X4RoleType.Company.ToString();
        /// <summary>
        /// 学校
        /// </summary>
        public string School => X4RoleType.School.ToString();
        /// <summary>
        /// 学校组织
        /// </summary>
        public string Organize => X4RoleType.Organize.ToString();

        /// <summary>
        /// 角色
        /// </summary>
        public string[] Roles = { X4RoleType.SuperAdmin.ToString(), X4RoleType.SysAdmin.ToString(), X4RoleType.CampusAdmin.ToString(), X4RoleType.Company.ToString(), X4RoleType.School.ToString(), X4RoleType.Organize.ToString() };
    }

    /// <summary>
    /// 已登录用户信息
    /// </summary>
    public class LoginInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; } = -1;

        /// <summary>
        /// 用户角色Id
        /// </summary>
        public int RoleId { get; set; } = -1;

        /// <summary>
        /// 登录名
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string UserName { get; set; } = null;

        /// <summary>
        /// 用户角色名
        /// </summary>
        public string RoleName { get; set; } = null;

        /// <summary>
        /// 用户角色描述
        /// </summary>
        public string RoleDescript { get; set; } = null;

        /// <summary>
        /// 用户数据
        /// </summary>
        public string UserData { get; set; } = null;

        /// <summary>
        /// 是否已登录
        /// </summary>
        public bool IsLogin { get; set; } = false;

        /// <summary>
        /// 校验角色
        /// </summary>
        /// <param name="role">要校验的角色名</param>
        /// <returns></returns>
        public bool IsInRole(string role) => role == RoleName;
    }

    /// <summary>
    /// X4 角色类型
    /// </summary>
    public enum X4RoleType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdmin,
        /// <summary>
        /// 系统管理员
        /// </summary>
        SysAdmin,
        /// <summary>
        /// 校园大使
        /// </summary>
        CampusAdmin,
        /// <summary>
        /// 企业
        /// </summary>
        Company,
        /// <summary>
        /// 学校
        /// </summary>
        School,
        /// <summary>
        /// 学校组织
        /// </summary>
        Organize
    }
}
