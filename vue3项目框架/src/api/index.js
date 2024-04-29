import http from "./server";

const api = {
    login(data) {
        return http.post("/api/User/Login", data);
    },
    register (data) {
        return http.post("/api/User/Register", data);
    }
};

export default api;