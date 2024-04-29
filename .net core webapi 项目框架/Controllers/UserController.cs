using api.model;
using api.Service;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers; 

[ApiController]
[Route("api/[controller]/")]
public class UserController : ControllerBase {
    private readonly UserService _userService;

    public UserController(UserService userService) {
        _userService = userService;
    }

    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("Login")]
    public ActionResult<User> Login([FromBody] User user) {
        //根据用户名查询用户数据
        var result = _userService.GetUserByUsername(user.Username).Result;
        if (result == null) {
            return NotFound("用户名不存在");
        }
        //密码不能为空
        if (string.IsNullOrEmpty(user.Password)) {
            return BadRequest("密码不能为空");
        }
        
        //密码是否正确
        var loginPassword = CommonUtil.GetMd5Hash(user.Password);
        if (loginPassword != result.Password) {
            return BadRequest("密码输入错误");
        }
        return Ok(result);
    }

    /// <summary>
    /// 用户注册
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    [HttpPost("Register")]
    public ActionResult Register([FromBody] User user) {
        //判断用户名是否已经存在
        var result = _userService.GetUserByUsername(user.Username).Result;
        if (result != null) {
            return BadRequest("用户名已存在");
        }

        //判断邮箱是否已经存在
        result = _userService.GetUserByEmail(user.Email).Result;
        if (result != null) {
            return BadRequest("邮箱已存在");
        }

        var row = _userService.AddUser(user).Result;
        return row > 0 ? Ok("用户注册成功") : BadRequest("用户注册失败");
    }
}