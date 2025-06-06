import { create } from "zustand";
import Cookies from "js-cookie";
import constantType from "../CommonHelper/Constant/constantType";
import authService from "../boot/Service/authService";
const useAuthStore = create((set, get) => ({
  currentUser: {},
  isLoggedIn: false,
  accessToken: "",
  userStatus: [
    { id: 0, name: "Khóa" },
    { id: 1, name: "Kích hoạt" },
  ],

  // 🔥 Getters (dùng trực tiếp không cần viết)
  getCurrentUser: () => get().currentUser,
  getAccessToken: () => get().accessToken,
  getIsLoggedIn: () => get().isLoggedIn,
  getUserStatus: () => get().userStatus,

  // 🔥 Actions
  setCurrentUser: (userInfo) => {
    set({ currentUser: userInfo, isLoggedIn: true });
  },

  setAccessToken: (accessToken) => {
    if (Cookies.get(constantType.accessToken)) {
      Cookies.remove(constantType.accessToken);
    }
    Cookies.set(constantType.accessToken, accessToken);
    set({ accessToken, isLoggedIn: true });
  },

  refillAccessToken: () => {
    const accessToken = Cookies.get(constantType.accessToken);
    if (accessToken) {
      set({ accessToken, isLoggedIn: true });
    }
  },

  logOut: async () => {
    try {
      const response = await authService.logOut();
      if (response.isSuccess) {
        if (Cookies.get(constantType.accessToken)) {
          Cookies.remove(constantType.accessToken);
        }
        set({ accessToken: "", isLoggedIn: false, currentUser: {} });
      }
      return response;
    } catch (error) {
      return Promise.reject(error);
    }
  },
}));

export default useAuthStore;
