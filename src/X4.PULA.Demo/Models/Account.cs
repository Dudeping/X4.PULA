using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace X4.PULA.Demo.Models
{
    /// <summary>
    /// 登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [DisplayName("账号")]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(50, ErrorMessage = "{0}应该在{2}-{1}位之间!", MinimumLength = 2)]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项！")]
        [StringLength(50, ErrorMessage = "{0}应该在{2}-{1}位之间!", MinimumLength = 6)]
        public string Password { get; set; }
    }

    /// <summary>
    /// 重置密码模型
    /// </summary>
    public class ResetPassword
    {
        [DisplayName("旧密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项!")]
        [StringLength(50, ErrorMessage = "{0}应该在{2}-{1}位之间!", MinimumLength = 6)]
        public string OldPassword { get; set; }

        [DisplayName("新密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项!")]
        [StringLength(50, ErrorMessage = "{0}应该在{2}-{1}位之间!", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [DisplayName("重复密码")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0}为必填项!")]
        [StringLength(50, ErrorMessage = "{0}应该在{2}-{1}位之间!", MinimumLength = 6)]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "新密码和重复密码应该相等!")]
        public string RePassword { get; set; }
    }
}