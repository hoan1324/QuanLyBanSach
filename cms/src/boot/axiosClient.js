import axios from "axios";
import useAuthStore from "../store/authStore";
import authService from "./Service/authService";
import Cookies from "js-cookie";
import constantType from "../CommonHelper/Constant/constantType";

const instance = axios.create({
  baseURL: process.env.REACT_APP_BaseUrlApi,
  timeout: 300000,
  withCredentials: true, // Để gửi cookie trong request
});

instance.interceptors.request.use(
  (config) => {
    const { getAccessToken, setAccessToken } = useAuthStore.getState();
    let token = getAccessToken();

    // Nếu chưa có token trong Zustand nhưng có trong cookies, cập nhật token
    if (!token) {
      token = Cookies.get(constantType.accessToken);
      if (token) {
        setAccessToken(token);
      }
    }

    // Nếu có token, thêm vào header
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
  },
  (error) => Promise.reject(error)
);

instance.interceptors.response.use(
  async (response) => {
    if (response?.status === 200) {
      return response.data;
    }
    return response;
  },
  async (error) => {
    if (error.response?.status === 403) {
      return Promise.reject(error);
    } else {
      // refresh token
      const originalRequest = error.config;
      const wwwAuth = error.response?.headers["www-authenticate"]; // phải viết thường

      if (
        error.response?.status === 401 &&
        !originalRequest._retry &&
        !wwwAuth
      ) {
        originalRequest._retry = true;
        const { getAccessToken, setAccessToken } = useAuthStore.getState();
        if (getAccessToken()) {
          const refreshTokenRes = await authService.refreshToken(
            getAccessToken()
          );
          if (refreshTokenRes.isSuccess) {
            setAccessToken(refreshTokenRes.data.accessToken);
            return instance(originalRequest);
          } else {
            if (Cookies.get(constantType.accessToken)) {
              Cookies.remove(constantType.accessToken);
            }
            window.location.href = "/";
          }
        }
      }
      return Promise.reject(error);
    }
  }
);

export default instance;
