import { create } from "zustand";
const useResponseStore = create((set, get) => ({
    convertRequest: null,
    convertResponse: null,

    // 🔥 Getters (dùng trực tiếp không cần viết)
    getConvertRequest: () => get().convertRequest,
    getConvertResponse: () => get().convertResponse,
    getResponse: (response) => {
        if (get().convertResponse && typeof get().convertResponse === "function") {
            return get().convertResponse(response);
        }
        return response
    },
    getRequest: (request) => {
        if (get().convertRequest && typeof get().convertRequest === "function") {
            return get().convertRequest(request);
        }
        return request
    },

    // 🔥 Actions
    setConvertRequest: (convertRequest) => {
        set({ convertRequest });
    },
    setConvertResponse: (convertResponse) => {
        set({ convertResponse });
    },
    resetElementConvert: () => {
        set({ convertRequest: null, convertResponse: null })
    }
}));

export default useResponseStore;
