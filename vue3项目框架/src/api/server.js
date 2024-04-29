import axios from "axios";
import router from "@/router";


const instance = axios.create({
    timeout: 50000,
    baseURL: 'http://127.0.0.1:5173/',
    headers: {
        'Content-Type': 'application/json;charset=utf-8'
    }
});

//请求拦截器
instance.interceptors.request.use(config => {
    return config;
}, error => {
    return Promise.reject(error);
});

//返回拦截器
instance.interceptors.response.use(res => {
    const data = res.data;
    if (data.code == 20000) {
        router.push('/login');
    }
    return Promise.resolve(res);
}, error => {
    return Promise.reject(error);
});


//封装请求类型
const http = {
    get(url, data) {
        return instance.get(url, { params: data });
    },
    post(url, data) {
        return instance.post(url, data);
    }
}
export default http;