<script setup>
import { getCurrentInstance, reactive, ref, toRaw } from 'vue';

const globalProperties = getCurrentInstance().appContext.config.globalProperties;
const api = globalProperties.$api;

let userInfo = reactive({
  value: {
    Username:'',Email:'',Password:'',VerifyPassword:''
  }
});
//登录点击事件
const loginClick = async () => {
  let user = toRaw(userInfo.value);
  if (!user.Username) {
    alert("用户名不能为空");
    return;
  }
  if (!user.Password) {
    alert("密码不能为空");
    return;
  }

  let result = await api.login(user);
  if (result && result.status == 200) {
    alert("你好" + result.data.username + "，恭喜你登录成功!");
  } else {
    alert(result.data);
  }
}
//注册点击事件
const registerClick = async () => {
  let user = toRaw(userInfo.value);
  if (!user.Username) {
    alert("用户名不能为空");
    return;
  }
    if (!user.Email) {
    alert("邮箱不能为空");
    return;
  }
  if (!user.Password) {
    alert("密码不能为空");
    return;
  }
  if (user.Password != user.VerifyPassword) {
    alert("确认密码和原密码不同");
    return;
  }

  let result = await api.register(user);
  if (result && result.status == 200) {
    alert("注册成功，请登录！");
    switchShowLogin();
  } else {
    alert(result.data)
  }
}


let showLogin = ref(true);
//控制登录框和注册框的显示与隐藏
const switchShowLogin = () => {
  showLogin.value = !showLogin.value;
  userInfo.value = {};
}
</script>

<template>
  <div class="login">
    <div class="container">
      <div class="login-form" v-if="showLogin">
        <div class="header">
          <span>登录</span>
          <button @click="switchShowLogin">没有用户，去注册？</button>
        </div>
        <input type="text" placeholder="请输入用户名" class="username" v-model="userInfo.value.Username">
        <input type="password" placeholder="请输入密码" class="password" v-model="userInfo.value.Password">
        <button class="login-btn" @click="loginClick">点击登录</button>
      </div>
      <div class="register-form" v-else>
        <div class="header">
          <span>注册</span>
          <button @click="switchShowLogin">已有用户，去注册？</button>
        </div>
        <input type="text" placeholder="请输入用户名" class="username" v-model="userInfo.value.Username">
        <input type="text" placeholder="请输入邮箱" class="email" v-model="userInfo.value.Email">
        <input type="password" placeholder="请输入密码" class="password" v-model="userInfo.value.Password">
        <input type="password" placeholder="请确认密码" class="verify-password" v-model="userInfo.value.VerifyPassword">
        <button class="register-btn" @click="registerClick">点击注册</button>
      </div>
    </div>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .login {
    min-height: 100vh;
    min-width: 100vw;
    display: flex;
    align-items: center;
  }
}
.container {
  margin: auto;
  width: 500px;
  height: 400px;
  background-color: #2C3030;
  border-radius: 10px;
}
.login-form,
.register-form {
  display: flex;
  flex-direction: column;
  margin: 25px 80px;
}
.header {
  margin-bottom: 25px;
  display: flex;
  justify-content: space-between;
  color: #FFFFFF;
}
.header span {
  font-size: 18px;
}
.header button {
  border: none;
  background-color: transparent;
}
.login-form input,
.register-form input {
  margin-bottom: 25px;
  height: 40px;
}
.login-btn,
.register-btn {
  height: 40px;
  width: 120px;
  margin: auto;
}
</style>
