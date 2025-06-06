import { create } from "zustand";
const usePageStore = create((set, get) => ({
  detailData: {},

  // 🔥 Getters (dùng trực tiếp không cần viết)
  getDetailData: () => get().detailData,

  // 🔥 Actions
  setDetailData: (detailData) => {
    set({ detailData });
  },

  resetElementPage: () => {
    set({ detailData: {} });
  },
}));

export default usePageStore;
