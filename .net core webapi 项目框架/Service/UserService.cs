using api.model;
using api.Utils;
using Microsoft.EntityFrameworkCore;

namespace api.Service; 

public class UserService: IBaseService {
    private readonly MySqlContext _mySqlContext;

    public UserService(MySqlContext mySqlContext) {
        _mySqlContext = mySqlContext;
    }

    /// <summary>
    /// 添加一个用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<int> AddUser(User user) {
        //邮箱、用户名或者密码为空
        if (string.IsNullOrEmpty(user.Username) ||
            string.IsNullOrEmpty(user.Email) ||
            string.IsNullOrEmpty(user.Password)) {
            return 0;
        }
        
        //对密码二次加密
        user.Password = CommonUtil.GetMd5Hash(user.Password);
        
        //补全
        user.CreateTime = DateTime.Now;
        user.CreateUser = user.Username;
        user.UpdateTime = DateTime.Now;
        user.UpdateUser = user.Username;
        
        //存入数据库
        _mySqlContext.User.Add(user);
        var result = await _mySqlContext.SaveChangesAsync();
        return result;
    }

    /// <summary>
    /// 根据用户名获取用户
    /// </summary>
    /// <returns></returns>
    public async Task<User?> GetUserByUsername(string? username) {
        if (string.IsNullOrEmpty(username)) {
            return null;
        }

        return await _mySqlContext.User.FirstOrDefaultAsync(u => u.Username == username);
    }
    /// <summary>
    /// 根据邮箱获取用户
    /// </summary>
    /// <returns></returns>
    public async Task<User?> GetUserByEmail(string? email) {
        if (string.IsNullOrEmpty(email)) {
            return null;
        }

        return await _mySqlContext.User.FirstOrDefaultAsync(u => u.Email == email);
    }
}