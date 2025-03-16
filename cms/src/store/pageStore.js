import { create } from "zustand";
const usePageStore = create((set, get) => ({
    detailData: {},
    formInstance: null,


    // 🔥 Getters (dùng trực tiếp không cần viết)
    getDetailData: () => get().detailData,
    getFormInstance: () => get().formInstance,


    // 🔥 Actions
    setDetailData: (detailData) => {
        set({ detailData });
    },
    setFormInstance: (formInstance) => {
        set({ formInstance });
    },
    resetElementPage: () => {
        set({ detailData: {}, formInstance: null })
    }
}));

export default usePageStore;
